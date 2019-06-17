import sys, threading, time, difflib, os, random
from PyQt5.QtWidgets import *
from PyQt5.QtGui import QIcon
import speech_recognition as sr

from mySiriInterface import *

r = sr.Recognizer()


def string_similar(s1, s2):
    return difflib.SequenceMatcher(None, s1, s2).quick_ratio()

class mywindow(QtWidgets.QMainWindow,Ui_MainWindow):
    def __init__(self):
        super(mywindow,self).__init__()
        self.setupUi(self)
        self.setWindowIcon(QIcon('Resources/icon/siri.png'))

    # 语音识别函数
    def siri_recognition(self):

        # 在定时器执行函数内部重复构造定时器
        global timer
        timer = threading.Timer(5.1, self.siri_recognition)  # 之后是5.1s执行一次
        timer.start()
        print("Time clock...")

        # Working with Microphones
        mic = sr.Microphone()

        with mic as source:
            r.adjust_for_ambient_noise(source)
            audio = r.listen(source)  # 直到检测到静音时自动停止

        try:
            command = r.recognize_sphinx(audio)
        except:
            print("无法读取内容")
            self.RecognitionFailed()
        else:
            print('The statement you said is {' + command + '}')
            global similar
            similar = string_similar(command, "Hey Kerr")
            print("The similar is ", similar)

            if similar > 0.1 or string_similar(command, "what") > 0.5:    # 第二个条件是为了提高唤醒概率(测试用)
                if self.flag == False:        # 如果此时正在看帮助信息则识别不成功
                    self.WakeSuccess()
                else:
                    self.WakeFailed()
            else:
                 self.WakeFailed()


    def mouseDoubleClickEvent(self, event):
        if self.label_10.isVisible()==True:     # 当Kerr已经被唤醒时, 取消双击事件 => 直接返回
            return

        self.label_7.setVisible(self.flag)
        self.label_8.setVisible(self.flag)

        global timer
        # 交替显示
        if self.flag == True:
            self.flag = False
            # 打开定时器
            timer = threading.Timer(0.1, self.siri_recognition)
            timer.start()
            print("==============Timer is start==============")
        else:
            self.flag = True
            # 关闭定时器
            timer.cancel()

            print("==============Timer is cancel==============")

        # 操作指南 开/关
        self.label.setVisible(self.flag)
        self.label_2.setVisible(self.flag)
        self.label_3.setVisible(self.flag)
        self.label_4.setVisible(self.flag)
        self.label_5.setVisible(self.flag)
        self.label_6.setVisible(self.flag)
        self.label_3_1.setVisible(self.flag)
        self.label_6_1.setVisible(self.flag)


    def RecognitionFailed(self):
        self.label_9.setVisible(True)
        time.sleep(2)
        self.label_9.setVisible(False)

    def WakeSuccess(self):
        print("wake success!")

        global timer
        timer.cancel()
        self.label_7.setVisible(False)
        self.label_8.setVisible(False)
        self.label_10.setVisible(True)
        self.label_11.setVisible(True)

        mic = sr.Microphone()
        with mic as source:
            r.adjust_for_ambient_noise(source)
            audio = r.listen(source)

        try:
            command = r.recognize_sphinx(audio)
        except:
            print("无法读取内容")
            self.RecognitionFailed()
        else:
            print('The statement you said is {' + command + '}')
            list = [string_similar(command, "play music"),
                   string_similar(command, "open notepad"),
                   string_similar(command, "open the calculator"),
                   string_similar(command, "talk to double z")]

            max_value = max(list)           # 最大值
            max_index = list.index(max_value)     # 最大值的索引

            if max_value < 0.2:
                print("I guess you want to...")
                max_index = random.randint(0, 2)
                self.label_12.setVisible(True)
                time.sleep(3)
                self.label_12.setVisible(False)

            if max_index == 0:
                os.startfile(r"Resources\music\CHINA-2.mp3")
            elif max_index == 1:
                os.system("C:\\Windows\\System32\\notepad.exe")
            elif max_index == 2:
                os.system("C:\\Windows\\System32\\calc.exe")
            else:
                os.startfile("https://github.com/doubleZ0108/")

        time.sleep(2.1)

        self.label_7.setVisible(True)
        self.label_8.setVisible(True)
        self.label_10.setVisible(False)
        self.label_11.setVisible(False)
        timer = threading.Timer(0.1, self.siri_recognition)
        timer.start()

    def WakeFailed(self):
        print("wake failed!")


if __name__ == '__main__':

    app = QApplication(sys.argv)

    window = mywindow()
    window.show()

    timer = threading.Timer(0.1, window.siri_recognition)  # 第一次执行0.1s后开始
    timer.start()

    sys.exit(app.exec())
