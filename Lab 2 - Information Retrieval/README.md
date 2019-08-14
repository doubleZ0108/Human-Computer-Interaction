# Lab 2: Image similarity search using deep learning

Make use of deep learning to do state-of-the-art image similarity search.


Table of Contents
=================

   * [Lab 2: Image similarity search using deep learning](#lab-2-image-similarity-search-using-deep-learning)
      * [Background](#background)
      * [Function](#function)
      * [Development Environment](#development-environment)
      * [Project Structure](#project-structure)
      * [How to Run](#how-to-run)
      * [ScreenShot](#screenshot)
         * [Homepage](#homepage)
         * [Before search](#before-search)
         * [Show the source file](#show-the-source-file)
         * [Display the 8 similar image](#display-the-8-similar-image)
         * [Drag the image to the favorites](#drag-the-image-to-the-favorites)
         * [Display the favorite images only](#display-the-favorite-images-only)
         * [See images hold the selected tag only](#see-images-hold-the-selected-tag-only)
         * [Enlarge &amp; Shrink](#enlarge--shrink)
      * [Function Realization](#function-realization)
         * [The slide of the homepage](#the-slide-of-the-homepage)
         * [Show the source file](#show-the-source-file-1)
         * [Overview of the results](#overview-of-the-results)
         * [Tags &amp; Classify](#tags--classify)
            * [Obtain tags](#obtain-tags)
            * [Transfer](#transfer)
            * [Usage of tags](#usage-of-tags)
         * [Favorites](#favorites)
            * [Found favorites](#found-favorites)
            * [Drag the images to the favorites](#drag-the-images-to-the-favorites)
         * [Enlarge &amp; shrink of the images](#enlarge--shrink-of-the-images)
      * [About the author](#about-the-author) 

## Background

Currently, there are many picture-to-picture search engine around the word. (e.g. Baidu Image Search Engine, Google Image Search Engine, etc.)

It mainly includes three aspects: 

- on the one hand, the analysis and transformation of user needs, forming a question that can retrieve the index database; 
- on the other hand, collecting and processing image resources, extracting features, analyzing and indexing, and establishing an index database of images; 
- The aspect is that according to the similarity algorithm, the similarity degree of the user question and the record in the index database is calculated, and the record satisfying the threshold is extracted as a result, and output is performed in the descending order of similarity.

<a name="Function"></a>  

## Function

1. Upload a image.
2. Overview the total number of the similar images.
3. Overview the tags of all results (each tag will be decorated with a random color).
4. Enlarge or shrink the images.
5. Drag the images to the favorite.
6. Click the favorite to see the favorite images only.
7. Click on tag button to see the images which hold this tag only.
8. Clear the image and choose another one.

<a name="Development Environment"></a>  

## Development Environment

- **Development Environment:** Win 10

- **Development Software:**

  1. **PyCharm** *2019.1.1.PC-191.6605.12*
  2. **Visual Studio Code** 1.33.1.0

- **Development Language:**

  1. python3
  2. HTML
  3. JavaScript
  4. CSS
  5. jQuery

- **Mainly Reference Count:**

  1. flask (Flask, jsonify)
  2. flask_httpauth (HTTPBasicAuth)
  3. tensorflow
  4.  numpy

- **Others:**

  Use some **third-party library  - Baidu** to enhance the interface

<a name="Project Structure"></a>  

## Project Structure

│  README.md   
│  report.md   
│  report.pdf   
│  
└─server   
    │  rest-server.py   
    │  
    ├─database   
    │  ├─dataset   
    │  └─tag   
    ├─static   
    │  ├─css   
    │  │      imgtable.css   
    │  │      imgtag.css   
    │  │      
    │  ├─images   
    │  │      ajax-loader.gif   
    │  │      
    │  ├─js   
    │  │      favorites.js   
    │  │      imgSearch.js   
    │  │      randColor.js   
    │  │      showSource.js   
    │  │      slide.js   
    │  │      tag.js   
    │  │      toggleImgSize.js   
    │  │      
    │  └─result   
    └─templates   
            mymain.html    

<a name="How to Run"></a>  

## How to Run

1. **File configuration:**
   - Please change the **HTML file** in *templates folder.*
   - Please change the **rest-server.py** file in *server folder*.
   - Create two folders under *static folder*:
     - *js folder* which contain the **js file** I wrote to support the search system
     - *css folder* which contain the **css file** I wrote to present the interface
   - Final the folder structure will be as above.
2. Start the server by **running rest-server.py**. This project uses flask based REST implementation for UI.

```
  python server/rest-server.py 
```

3. Once the server starts up, access <http://localhost:5000/> to get the UI. 
4. Click "**识图一下**" to start image search.
5. **Upload** any image and click "**Search!**", then you can see 8 similar images.
6. You can **click any image** to enlarge it and another click you can shrink it into the normal size.
7. You can **drag any image to the favorites**, it means you want to hold it in the favorites.
8. **Click the favorites**, then you will see the images which you collect only, another click will show all the images.
9. You can **click the tag button** on the right side of the interface, and then you will see the images which belong to this tag only.
10. Click "**Clear**" to get back to the homepage, and you can upload another image again.



<a name="ScreenShot"></a>  

## ScreenShot

<a name="Homepage"></a>  

### Homepage

A slide is showed in the homepage (powered by **third-party library  - Baidu**)

![image.png](https://upload-images.jianshu.io/upload_images/12014150-a338187d2de67d49.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

![image.png](https://upload-images.jianshu.io/upload_images/12014150-d34d92895ae8e32f.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

<a name="Before search"></a>  

### Before search

![image.png](https://upload-images.jianshu.io/upload_images/12014150-dcd9962384e58e1f.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

<a name="Show the source file"></a>  

### Show the source file

![image.png](https://upload-images.jianshu.io/upload_images/12014150-f1d81518c41a7082.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

<a name="Display the 8 similar image"></a>  

### Display the 8 similar image

![image.png](https://upload-images.jianshu.io/upload_images/12014150-f041124c134a67d6.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

<a name="Drag the image to the favorites"></a>  

### Drag the image to the favorites

![image.png](https://upload-images.jianshu.io/upload_images/12014150-c197e12a80bb5c08.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

<a name="Display the favorite images only"></a>  

### Display the favorite images only

![image.png](https://upload-images.jianshu.io/upload_images/12014150-4031b3d49893515b.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

<a name="See images hold the selected tag only"></a>  

### See images hold the selected tag only

![1558008366210](C:\Users\28718\AppData\Roaming\Typora\typora-user-images\1558008366210.png)

<a name="Enlarge & Shrink"></a>  

### Enlarge & Shrink

![image.png](https://upload-images.jianshu.io/upload_images/12014150-e5948acf35c141d7.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

<a name="Function Realization"></a>  

## Function Realization

<a name="The slide of the homepage"></a>  

1. ### The slide of the homepage

   Use some **third-party library  - Baidu** to realize the silde, the mainly use library are as fellow:

   To see the detailed code, please find them in `mymain.html`

   ```html
   <!--百度第三方css及js文件-->
   <script type="text/javascript" src="//img0.bdstatic.com/static/home/shitu/mod_6f6741d.js"></script>
       <link rel="stylesheet" type="text/css" href="//img0.bdstatic.com/static/home/shitu/reset_3f5059c.css" />
       <link rel="stylesheet" type="text/css" href="//img1.bdstatic.com/static/home/pkg/stu_3c9d544.css" />
       <link rel="stylesheet" type="text/css"
           href="//img1.bdstatic.com/static/common/widget/ui/slider/slider_ecce195.css" />
       <link rel="stylesheet" type="text/css" href="//img1.bdstatic.com/static/common/pkg/co_2e2be3c.css" />
       <link rel="stylesheet" type="text/css"
           href="//img0.bdstatic.com/static/common/widget/ui/userInfo/userInfo_5bd6198.css" />
   
   <!--幻灯片的轮播 & 识图一下点击事件js-->
       <!--百度第三方库-->
       <script type="text/javascript" src="js/slide.js"> </script>
   ```

   <a name="Show the source file"></a>  

2. ### Show the source file

   Add a function `show()` to make the file which user chose to show in the left side of the interface

   1. Instantiate an `FileReader` object, which is used to read file.
   2. Get the label of the image to display
   3. Read the data of the File object and display it in the homologous position of the interface.

   ```html
   <form method=post enctype=multipart/form-data"> <input type="file" name="file" required onchange="show(this)" />
   ```

   ```javascript
   function show(file) {
       var reader = new FileReader(); // 实例化一个FileReader对象，用于读取文件
       var source_img = document.getElementById('source_img'); // 获取要显示图片的标签
   
       //读取File对象的数据
       reader.onload = function (evt) {
           source_img.width = "180";
           source_img.height = "180";
           source_img.src = evt.target.result;
       }
       reader.readAsDataURL(file.files[0]);
   }
   ```

   <a name="Overview of the results "></a>  

3. ### Overview of the results 

   Add 3 labels to complete the task, and the initialization value is `display: none;`, only if the user choose a image and click Search!, then the 3 labels will show to the user.

    The codes are as fellows:

   ```html
   <!--搜索结果 => 本次共检索到8张图片-->
   <center>
       <td>
          <b id="retrieval-result1" style="color: rgb(103, 32, 218);font-size: 15px;display: none;">
            本次共检索到 
          </b>
          <b id="retrieval-result2" style="color: rgb(255, 0, 0); font-size: 15px;display: none;">
           &nbsp;8&nbsp; </b>
          <b id="retrieval-result3" style="color: rgb(103, 32, 218);font-size: 15px;display: none;">
           张相似图片 </b>
        </td>
   </center>
   ```

   <a name="Tags & Classify"></a>  

4. ### Tags & Classify

   #### Obtain tags

   - All the result of the similar images will be stored in the `server\static\result` folder

   - All the tags information are stored in the `server\database\tags` folder. Each `.txt` file contains the index of the image which hold this tag.

   - Traverse all the file in tags folder and check if it contain the index of  the images in result folder, store the information in a dictionary, which the storage structure is like "Key - Value" <=> "index - tag"

     ```python
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
     ```

   #### Transfer

   - Then, change the `dictioinary` to a `list`, which can be sent to HTML by `jsonify`

     ```python
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
     }
     return jsonify(images)    
     ```

   #### Usage of tags

   - Build some label to show the tags

     ```html
     <div class="imgtag" id="imgtag0"></div>
     ...
     <div class="imgtag" id="imgtag7"></div>
     
     
     <!--标签按钮-->
     <div class="tagbtn" style="margin-left: 10%;z-index: 9999;position: fixed !important;right: 12%;top: 40%;">
           <table id="tagtable" class="table" style="display:none;bottom: 30%;">
                  <tbody>
                  </tbody>
           </table>
     </div>
     ```

   - The style of the imgtag & tagbtn

     ```css
     .imgtag {
         background-color: rgba(7, 214, 221, 0.7);
         position: absolute;
         top: 75%;
         left: 59%;
         width: 34px;
         height: 15px;
         text-align: center;
         line-height: 15px;
         font-size: 5px;
     }
     
     .tagbtn {
         margin-left: 10%;
         z-index: 9999;
         position: fixed !important;
         right: 12%;
         top: 40%;
     }
     ```

   - Create function `addrow()` to dynamic enhancement the total number of the tags

     ```javascript
     function addrow(name, color) {
         console.log("name is " + name)
         var c = document.getElementById('tagtable'); //获得表格的信息
         if (c.rows.length == 0) { //如果是向一个空表增加一行
             var x = c.insertRow(0); //向空表插入一行
             var y = x.insertCell(0); //向新行插入一列
             y.innerHTML += "<button id=\"" + name +
                 "\" style=\"background-color:" + color + ";\" onclick=\"tagClick(this)\">" + name + "</button>"
         } else {
             var z = c.rows[0].cells; //如果不是空表，首先获得表格有多少列，先获取再插入新行
             var x = c.insertRow(0);
             for (var i = 0; i < z.length; i++) { //依次向新行插入表格列数的单元格
                 var y = x.insertCell(i);
                 y.innerHTML += "<button id=\"" + name +
                     "\" style=\"background-color:" + color + ";\" onclick=\"tagClick(this)\">" + name + "</button>"
             }
         }
     }
     ```

   - Bind a click event for tagbtn which allow the user to see the images which hold the tag only

     ```javascript
     function tagClick(e) {
         //隐藏对应的图片
         //隐藏对应的图片标签
         for (var i = 0; i < 8; ++i) {
             if (document.getElementById("img" + String(i)).name != e.id) {
                 document.getElementById("img" + String(i)).style.visibility = "hidden";
                 document.getElementById("imgtag" + String(i)).style.visibility = "hidden";
             }
         }
     
         //显示对应的图片
         //显示对应的图片标签
         for (var i = 0; i < 8; ++i) {
             if (document.getElementById("img" + String(i)).name == e.id) {
                 document.getElementById("img" + String(i)).style.visibility = "visible"
                 document.getElementById("imgtag" + String(i)).style.visibility = "visible";
             }
         }
     }
     ```

     

   - Generate random color for different imgtag & tagbtn which can classify the result clearly and easily

     ```javascript
     function randomHexColor() { //随机生成十六进制颜色
         var hex = Math.floor(Math.random() * 16777216).toString(16); //生成ffffff以内16进制数
         while (hex.length < 6) { //while循环判断hex位数，少于6位前面加0凑够6位
             hex = '0' + hex;
         }
         return '#' + hex; //返回‘#'开头16进制颜色
     }
     
     for (var i = 0; i < tags.length; ++i) {
          var color = randomHexColor()
          color_list.push(color)
          addrow(tags[i], color)
     }
     
     document.getElementById("imgtag0").style.backgroundColor = String(
                         color_list[tags.indexOf(response.image0[1])])
     ...
     document.getElementById("imgtag7").style.backgroundColor = String(
                         color_list[tags.indexOf(response.image7[1])])
     ```

   <a name="Favorites"></a>  

5. ### Favorites

   #### Found favorites

   - Place the favorites in the top level, which the favorites can roll with the screen

     ```html
     <!--收藏夹-->
     <div style="margin-left: 70%;z-index: 9999; position: fixed ! important;right: 12%;top: 67%;">
          <img class="favorites" 
               src="https://upload-images.jianshu.io/upload_images/12014150-dd7e1b70111fdaa9.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240"
               id="favorites" 
               style="position: absolute;right: 0px;top: 0px;width: 120px;height: 95px;" draggable="false" onclick="favoritesClick()" />
     </div>
     ```

   #### Drag the images to the favorites

   - The user can drag the images to the favorites which mean you want to save it specially.

   - If you click the favorites, you can see the favorite images which you save only.

     ```javascript
     const OPEN = 1;
     const CLOSED = 2;
     const STAR_OPEN = 3;
     const STAR_CLOSED = 4;
     
     var favorites_img = [];
     var favorites_flag = CLOSED;
     
     document.addEventListener("dragstart", function (event) {
         console.log("start...")
         //dataTransfer.setData()方法设置数据类型和拖动的数据 
         console.log(event.target.id)
         event.dataTransfer.setData("Text", event.target.id);
         //修改拖动元素的透明度 
         event.target.style.opacity = "0.4";
     });
     // 当拖完p元素输出一些文本元素和重置透明度 
     document.addEventListener("dragend", function (event) {
         event.target.style.opacity = "1";
     });
     // 当p元素完成拖动进入droptarget,改变div的边框样式 
     document.addEventListener("dragenter", function (event) {
         if (event.target.className == "favorites") {
             console.log("ok...")
         }
     });
     
     /*对于drop,防止浏览器的默认处理数据(在drop中链接是默认打开) 
     复位输出文本的颜色和DIV的边框颜色 
     利用dataTransfer.getData()方法获得拖放数据 
     拖拖的数据元素id("drag1") 
     拖拽元素附加到drop元素*/
     document.addEventListener("drop", function (event) {
         event.preventDefault();
         if (event.target.className == "favorites") {
             if (favorites_flag == OPEN) {
                 favorites_flag = STAR_OPEN;
             } else if (favorites_flag == CLOSED) {
                 favorites_flag = STAR_CLOSED;
             }
             //更换收藏夹图标
             event.target.src =
                 "https://upload-images.jianshu.io/upload_images/12014150-383ad52c8d75dfbb.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240"
     
             var data = event.dataTransfer.getData("Text");
             favorites_img.push(data)
         }
     });
     
     // 默认情况下,数据/元素不能在其他元素中被拖放。对于drop我们必须防止元素的默认处理 
     document.addEventListener("dragover", function (event) {
         event.preventDefault();
     });
     
     function favoritesClick() {
         favoriateData = document.getElementById("favorites");
         if (favorites_flag == OPEN) {
             favorites_flag = CLOSED;
             favoriateData.src =
                 "https://upload-images.jianshu.io/upload_images/12014150-dd7e1b70111fdaa9.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240";
         } else if (favorites_flag == CLOSED) {
             favorites_flag = OPEN;
             favoriateData.src =
                 "https://upload-images.jianshu.io/upload_images/12014150-1b0432d7f3f099a8.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240";
         } else if (favorites_flag == STAR_CLOSED) {
             favorites_flag = STAR_OPEN;
             favoriateData.src =
                 "https://upload-images.jianshu.io/upload_images/12014150-1b0432d7f3f099a8.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240"
             for (var i = 0; i < 8; ++i) {
                 if (favorites_img.indexOf("img" + String(i)) == -1) {
                     document.getElementById("img" + String(i)).style.visibility = "hidden";
                     document.getElementById("imgtag" + String(i)).style.visibility = "hidden";
                 } else {
                     document.getElementById("img" + String(i)).style.visibility = "visible";
                 }
             }
         } else if (favorites_flag == STAR_OPEN) {
             favorites_flag = STAR_CLOSED;
             favoriateData.src =
                 "https://upload-images.jianshu.io/upload_images/12014150-383ad52c8d75dfbb.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240";
             for (var i = 0; i < 8; ++i) {
                 document.getElementById("img" + String(i)).style.visibility = "visible";
                 document.getElementById("imgtag" + String(i)).style.visibility = "visible";
             }
         }
     }
     ```

   <a name="Enlarge & shrink of the images"></a>  

6. ### Enlarge & shrink of the images

   - Click the image of the result, then the image while enlarge.

   - Another click will shrink the image

   - First, I define two style of the images

     ```css
     .max {
         transition: 0.3s;
         width: 180px;
         height: 180px;
     }
     
     .min {
         transition: 0.3s;
         width: 80px;
         height: 80px;
     }
     ```

   - Then, bind a event for all the images which toggle the image to change from two style

     ```javascript
     $(function () {
         for (var i = 0; i <= 8; i++) {
             $('#img' + String(i)).click(function () {
                 $(this).toggleClass('min');
                 $(this).toggleClass('max');
             });
         }
     });
     ```

     

<a name="About the author"></a>  

## About the author

​	**ID**			1754060

​	**name**	  Zhe Zhang

​	**adviser**	Ying Shen

​	**contact**	email: doubleZ0108@gmail.com
