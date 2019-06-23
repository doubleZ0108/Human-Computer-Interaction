#!flask/bin/python
################################################################################################################################
# ------------------------------------------------------------------------------------------------------------------------------
# This file implements the REST layer. It uses flask micro framework for server implementation. Calls from front end reaches
# here as json and being branched out to each projects. Basic level of validation is also being done in this file. #
# -------------------------------------------------------------------------------------------------------------------------------
################################################################################################################################
from flask import Flask, jsonify, abort, request, make_response, url_for, redirect, render_template
from flask_httpauth import HTTPBasicAuth
from werkzeug.utils import secure_filename
import os
import shutil
import numpy as np
from search import recommend
import tarfile
from datetime import datetime
from scipy import ndimage
from scipy.misc import imsave

UPLOAD_FOLDER = 'uploads'
ALLOWED_EXTENSIONS = set(['png', 'jpg', 'jpeg'])
from tensorflow.python.platform import gfile

app = Flask(__name__, static_url_path="")
app.config['UPLOAD_FOLDER'] = UPLOAD_FOLDER
auth = HTTPBasicAuth()

# ==============================================================================================================================
#
#    Loading the extracted feature vectors for image retrieval
#
#
# ==============================================================================================================================
extracted_features = np.zeros((10000, 2048), dtype=np.float32)
with open('saved_features_recom.txt') as f:
    for i, line in enumerate(f):
        extracted_features[i, :] = line.split()
print("loaded extracted_features")


# ==============================================================================================================================
#
#  This function is used to do the image search/image retrieval
#
# ==============================================================================================================================
@app.route('/imgUpload', methods=['GET', 'POST'])
# def allowed_file(filename):
#    return '.' in filename and \
#           filename.rsplit('.', 1)[1].lower() in ALLOWED_EXTENSIONS


def upload_img():
    print("image upload")
    result = 'static/result'
    if not gfile.Exists(result):
        os.mkdir(result)
    shutil.rmtree(result)

    if request.method == 'POST' or request.method == 'GET':
        print(request.method)
        # check if the post request has the file part
        if 'file' not in request.files:
            print('No file part')
            return redirect(request.url)

        file = request.files['file']
        print(file.filename)
        # if user does not select file, browser also
        # submit a empty part without filename
        if file.filename == '':
            print('No selected file')
            return redirect(request.url)
        if file:  # and allowed_file(file.filename):
            filename = secure_filename(file.filename)
            file.save(os.path.join(app.config['UPLOAD_FOLDER'], filename))
            inputloc = os.path.join(app.config['UPLOAD_FOLDER'], filename)
            recommend(inputloc, extracted_features)
            os.remove(inputloc)
            image_path = "/result"
            image_list = [os.path.join(image_path, file) for file in os.listdir(result)
                          if not file.startswith('.')]

            # region tagfinder
            dict = {}

            dict.clear()
            # region 将result文件夹中的图片名字保存到result_list中
            resultPath = 'static/result'
            result_list = os.listdir(resultPath)
            for i in range(0, len(result_list)):
                result_list[i] = result_list[i][2:]  # 去除搜索结果图片名中的im

                (filename, extension) = os.path.splitext(result_list[i])  # 划分文件名和后缀名
                result_list[i] = filename
            print(result_list)
            # endregion

            tagPath = 'database/tags'
            tag_list = os.listdir(tagPath)

            for tagnow in tag_list:
                if result_list.__len__() == 0:  # 8张图片都已找到tag
                    break
                # print(tagnow)
                with open("database/tags/" + tagnow, "r") as fp:
                    str_list = fp.readlines()  # 读取文件的全部信息存储到str_list中

                    for i in range(0, len(str_list)):
                        str_list[i] = str_list[i].rstrip()  # 去除行尾的\n

                    for result in result_list[::-1]:  # 倒序遍历避免删除错误
                        if str_list.count(result):  # 如果打开的此文件中有此图片标号
                            dict.setdefault(result, tagnow)  # 将图片[名-tag]加入字典中
                            result_list.remove(result)

            # region 去除字典中的后缀
            for key in dict.keys():
                (filename, extension) = os.path.splitext(dict[key])
                dict[key] = filename
            # endregion

            print(dict)
            # endregion

            copy_list = image_list.copy()
            for i in range(0, len(copy_list)):
                copy_list[i] = copy_list[i][10:]
                (filename, extension) = os.path.splitext(copy_list[i])
                copy_list[i]=filename
            print(copy_list)

            tagset = set()
            for key in dict.keys():
                tagset.add(dict[key])

            taglist = []
            for tag in tagset:
                taglist.append(tag)

            images = {
                'image0': [image_list[0],dict[copy_list[0]]],
                'image1': [image_list[1],dict[copy_list[1]]],
                'image2': [image_list[2],dict[copy_list[2]]],
                'image3': [image_list[3],dict[copy_list[3]]],
                'image4': [image_list[4],dict[copy_list[4]]],
                'image5': [image_list[5],dict[copy_list[5]]],
                'image6': [image_list[6],dict[copy_list[6]]],
                'image7': [image_list[7],dict[copy_list[7]]],
                'tags': taglist,
                # 'image8': image_list[8],
            }
            return jsonify(images)


# ==============================================================================================================================
#
#                                           Main function                                                        	            #
#
# ==============================================================================================================================
@app.route("/")
def main():
    return render_template("mymain.html")


if __name__ == '__main__':
    app.run(debug=True, host='localhost')
