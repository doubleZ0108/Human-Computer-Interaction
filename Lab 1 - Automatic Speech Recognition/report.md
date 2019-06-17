## Lab1: Automatic Speech Recognition

###### 简易版语音助手 ---- myKerr

### 目录

- [modifications](#modifications)  
  - [GUI](#GUI)
    - [窗口图标和名称](#窗口图标和名称)
    - [主界面(启动界面)](#主界面(启动界面))
    - [帮助界面](#帮助界面)
    - [唤醒界面(指令识别界面)](#唤醒界面(指令识别界面))
    - [无法读取麦克风声音](#无法读取麦克风声音)
    - [无匹配指令](#无匹配指令)
  - [code](#code)
    - [界面代码](#界面代码)
    - [语音识别](#语音识别)
    - [指令相似度匹配](#指令相似度匹配)
    - [定时器](#定时器)
    - [监听鼠标双击事件](#监听鼠标双击事件)
    - [调用系统接口,执行用户指令](#调用系统接口,执行用户指令)
- [accuracy_of_speech_recognition](accuracy_of_speech_recognition)
  - [环境噪声的影响](#环境噪声的影响)
  - [英语发音不准的影响](#英语发音不准的影响)
- [improve](#improve)
  - [改善录音文件](#改善录音文件)
  - [调用其他语音识别接口](#调用其他语音识别接口)



<a name="modifications"></a>  

### modifications

经过一周时间对asr.py/asrInterface.py的结构分析, 此次项目更改了全部的用户界面

并使用Qt Designer对界面进行布局   

~~(删完.ui文件之后才看到report中要写这个内容)~~     

~~(Qt Designer感觉是真的不好用)~~   

<a name="GUI"></a>  

### GUI

<a name="modifications"></a>  

#### 0. 窗口图标和名称

- **更改窗口名称:** myKerr
- **更改窗口图标**

![window.png](https://upload-images.jianshu.io/upload_images/12014150-cc9dff9d96b49be9.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

<a name="主界面(启动界面)"></a>  

#### 1. 主界面(启动界面)

- **"Hey Kerr" to wake me!:** 提示用户唤醒语音助手的方式
- **Double Click to know more!:** 提示用户如何查看帮助信息  *(没有明确说明是双击底部的gif是为了整体界面的简洁和大气)*

![start.png](https://upload-images.jianshu.io/upload_images/12014150-f0fb1d2d0b43800b.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

<a name="帮助界面"></a>  

#### 2. 帮助界面

显示四条帮助信息:

- **Enjoy music by saying:** Play music
- **Take some notes by saying:** Open Notepad
- **Do math work by saying:** Open the calculator
- **Chat with me by saying:** Talk to double Z

![help.png](https://upload-images.jianshu.io/upload_images/12014150-0f37a605e347fc13.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

<a name="唤醒界面(指令识别界面)"></a>  

#### 3. 唤醒界面(指令识别界面)

- **Kerr is here!:** 提醒用户语音助手已经唤醒
- **What can I do for you?:** 提示用户可以输入语音指令

![wake.png](https://upload-images.jianshu.io/upload_images/12014150-e0239f609c83c357.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

<a name="无法读取麦克风声音"></a>  

#### 4. 无法读取麦克风声音

无法无法读取麦克风声音时, 在gif上端放置提示信息 **Sorry, I can't hear you clearly!**

![can't-hear-clearly1.png](https://upload-images.jianshu.io/upload_images/12014150-2ae193d77906c694.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

![can't-hear-clearly2.png](https://upload-images.jianshu.io/upload_images/12014150-fde08c540e39b79e.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

<a name="无匹配指令"></a>  

#### 5. 无匹配指令

唤醒之后用户的动作指令无法和4条内设指令匹配, 在gif上端放置提示信息 **I guess you want to...** 并随机执行一条指令

![I-guess-you-want-to.png](https://upload-images.jianshu.io/upload_images/12014150-e180ff907ba9ee86.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

<a name="code"></a>  

### code

<a name="界面代码"></a>  

#### 0. 界面代码

- 文字QLabel

  ```python
  self.label.setText(_translate("MainWindow", "1. Enjoy music by saying"))
  self.label_2.setText(_translate("MainWindow", "2. Take some notes by saying"))
  self.label_3.setText(_translate("MainWindow", "3. Do math work by saying"))
  self.label_3_1.setText(_translate("MainWindow", "4. Chat with me by saying"))
  self.label_4.setText(_translate("MainWindow", "Play music"))
  self.label_5.setText(_translate("MainWindow", "Open Notepad"))
  self.label_6.setText(_translate("MainWindow", "Open the calculator"))
  self.label_6_1.setText(_translate("MainWindow", "Talk to double Z"))
  self.label_7.setText(_translate("MainWindow", "\"Hey Kerr\" to wake me!"))
  self.label_8.setText(_translate("MainWindow", "Double Click me to know more!"))
  self.label_9.setText(_translate("MainWindow", "Sorry, I can\'t hear your clearly!"))
  self.label_10.setText(_translate("MainWindow", "Kerr is here!"))
  self.label_11.setText(_translate("MainWindow", "What can I do for you?"))
  self.label_12.setText(_translate("MainWindow", "I guess you want to..."))
  ```

  

- 动图QMovie

  ```python
  self.siriGif = QtWidgets.QLabel(self.centralwidget)
  self.siriGif.setGeometry(QtCore.QRect(70, 450, 271, 131))
  self.siriGif.setText("")
  self.gif = QMovie("Resources/icon/siri.gif")
  self.siriGif.setMovie(self.gif)
  self.gif.start()
  self.siriGif.setScaledContents(True)
  self.siriGif.setObjectName("voiceFig")
  ```

  

- 图标QIcon

  ```python
  self.setWindowIcon(QIcon('Resources/icon/siri.png'))
  ```

  <a name="语音识别"></a>  

#### 1. 语音识别

通过麦克风检测用户的语音指令, 当无法检测到声音时自动停止, 并通过recognize_sphinx进行语音识别

```python
import speech_recognition as sr
r = sr.Recognizer()

mic = sr.Microphone()
with mic as source:
    r.adjust_for_ambient_noise(source)
    audio = r.listen(source)
    
command = r.recognize_sphinx(audio)
```

<a name="指令相似度匹配"></a>  

#### 2. 指令相似度匹配

通过string_similar进行指令相似度的匹配

- 唤醒过程: 用户command与"Hey Kerr"的相似度大于0.1认为唤醒成功
  - 唤醒成功: 调用self.WakeSuccess(), 让用户输入希望执行的语音指令
  - 唤醒失败: 调用self.WakeFailed(), 定时器重新进行唤醒识别
- 指令识别过程: 将用户指令与四个预设指令分别进行字符换相似度匹配
  - 最大的匹配度小于0.2: 在屏幕上显示I guess you want to..., 并随机执行一个指令
  - 最大的匹配度大于0.2: 执行匹配度最高的指令

```python
import difflib

def string_similar(s1, s2):
    return difflib.SequenceMatcher(None, s1, s2).quick_ratio()

similar = string_similar(command, "Hey Kerr")
print("The similar is ", similar)

if similar > 0.1:
    if self.flag == False:    # 如果此时正在看帮助信息则识别不成功
         self.WakeSuccess()
    else:
         self.WakeFailed()
    else:
         self.WakeFailed()
```

```python
list = [string_similar(command, "play music"),
        string_similar(command, "open notepad"),
        string_similar(command, "open the calculator"),
        string_similar(command, "talk to double z")]

max_value = max(list)           	  # 最大值
max_index = list.index(max_value)     # 最大值的索引

if max_value < 0.2:
    print("I guess you want to...")
    max_index = random.randint(0, 2)
    self.label_12.setVisible(True)
    time.sleep(3)
    self.label_12.setVisible(False)
```

<a name="定时器"></a>  

#### 3. 定时器

- 通过threading.Timer(), start(), cancel(), 使用定时器
- 每5.1s进行一次唤醒识别
- 在用户查看帮助信息的时候停止定时器, 返回主页后重新打开定时器

```python
import threading, time

global timer
timer = threading.Timer(5.1, self.siri_recognition)
timer.start()
print("Time clock...")

# 关闭定时器
timer.cancel()
```

<a name="监听鼠标双击事件"></a>  

#### 4. 监听鼠标双击事件

- 在主页的时候, 用户可以双击底部的gif查看帮助信息
- 在进入帮助信息页面后, 可以双击同样的位置返回主页
- 当唤醒Kerr后, 双击不会进入帮助页面

```python
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
```

<a name="调用系统接口,执行用户指令"></a>  

#### 5. 调用系统接口, 执行用户指令

- os.startfile()播放音乐
- os.system()打开记事本
- os.system()打开计算器
- os.startfile()打开特定网址

```python
if max_index == 0:
   os.startfile(r"Resources\music\CHINA-2.mp3")
elif max_index == 1:
   os.system("C:\\Windows\\System32\\notepad.exe")
elif max_index == 2:
   os.system("C:\\Windows\\System32\\calc.exe")
else:
   os.startfile("https://github.com/doubleZ0108/")
```

<a name="accuracy_of_speech_recognition"></a>  

### accuracy of speech recognition

recognize_sphinx()接口的语音识别效果~~非常好~~无法形容

​		<a name="modifications"></a>  

- **环境噪声的影响:** 最开始认为是环境噪声太大   

  `r.adjust_for_ambient_noise(source)`

  通过代码减小噪声对识别结果的影响仍然效果不大   

  <a name="英语发音不准的影响"></a>  

- **英语发音不准的影响:** 噪音的影响减小后仍不见效果, 以为应该是英语发音的问题   

  之后找到了[百度AI开放平台](http://ai.baidu.com/tech/speech/tts?track=cp:ainsem|pf:pc|pp:chanpin-yuyin|pu:yuyin-yuyinhecheng|ci:|kw:10003520), 通过在线文本转语音, 并使用`sr.AudioFile()`进行读取, 仍然识别的很不理想  *(甚至连词的个数都识别不对)*  

<a name="improve"></a>  

### improve

​		<a name="改善录音文件"></a>  

- **改善录音文件:**

  `r.adjust_for_ambient_noise(source)`函数默认的duration=1.0, 即开始的1s音频会被当做噪声进行处理, 因此在录音文件开头添加大约1s的空白区段       

  效果一般但是有小幅度提高

  <a name="调用其他语音识别接口"></a>  

- **调用其他语音识别接口:**

  `r.recognize_google(audio)`改用google的语音识别接口进行语音识别

  处理效果较好, 但是处理时间较长且要保持联网

  其他接口如`r.recognize_bing()` `r.recognize_ibm()`等不仅需要联网而且还需要key才能使用, 故未做测试

  