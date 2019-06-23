# Lab 2: Image similarity search using deep learning

Make use of deep learning to do state-of-the-art image similarity search.



❗ PLEASE READ [README.md](README.md) FOR DETAILED INTRODUCTION

## Catalogue

- [Describe the requirements of an image search task](#Describe the requirements of an image search task)
- [Five-stage search framework](#Five-stage search framework)
  - [Formulation](#Formulation)
  - [Initiation of action](#Initiation of action)
  - [Review of results](#Review of results)
  - [Refinement](#Refinement)
  - [Use](#Use)

- [About the author](#About the author)

<a name="Describe the requirements of an image search task"></a>  

## Describe the requirements of an image search task

- A homepage which hold a brief introduction to let the user know what can this image search engine do.

- The way that this engine provide to upload your image.

  *The following picture show that the Baidu-Shitu hold 3 ways for user to upload his or her images.*

  ![image.png](https://upload-images.jianshu.io/upload_images/12014150-84c547c3a1b32983.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

- Show a waiting logo, which can relax the user when the engine is searching

  *Take Baidu-Shitu for instance:*

  ![image.png](https://upload-images.jianshu.io/upload_images/12014150-d71a0fc7b8859cd0.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

- Show the source file to let the user know which image I upload to search just now.

- Show the total number of the result which can let the user know how many images are similar to my picture in your engine.

- Classify the images of the result, which can let the user browse the result  distinctly and the tags should be different(colorful).

- User can click one tag, and the system should show the images which hold this tag only.

- There should present a favorites and the user can drag the images of the result to the favorites. And if he or she click the favorites, the image search engine are supposed to show the favorite images only.

- Provide a **Clear button** to search image again



<a name="Five-stage search framework"></a>  

## Five-stage search framework

<a name="Formulation"></a>  

### Formulation

- Homepage (powered by **third-party library  - Baidu**)

  ![image.png](https://upload-images.jianshu.io/upload_images/12014150-a338187d2de67d49.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

  ![image.png](https://upload-images.jianshu.io/upload_images/12014150-d34d92895ae8e32f.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

- The user can only upload his or her picture fromlocal

  ![image.png](https://upload-images.jianshu.io/upload_images/12014150-0d5f8ad4d8d6a059.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

- Permit variants to allow relaxation of search constraints 

- Show the source file

  ![1558010973716](C:\Users\28718\AppData\Roaming\Typora\typora-user-images\1558010973716.png)

<a name="Initiation of action"></a>  

### Initiation of action

- A  `Search!` button

  ![image.png](https://upload-images.jianshu.io/upload_images/12014150-ac59186cb69ff1c7.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

- Drag the image to the favorites

  ![image.png](https://upload-images.jianshu.io/upload_images/12014150-c197e12a80bb5c08.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

<a name="Review of results"></a>  

### Review of results

-  Keep search terms and constrains visible

-  Overview of results

  ![image.png](https://upload-images.jianshu.io/upload_images/12014150-1a1f3da9e54ba374.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

- Enlarge & Shrink

  ![image.png](https://upload-images.jianshu.io/upload_images/12014150-e5948acf35c141d7.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

- Display the favorite images only

  ![image.png](https://upload-images.jianshu.io/upload_images/12014150-4031b3d49893515b.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

<a name="Refinement"></a>  

### Refinement

-  Make changing of search parameters convenient, click `Clear` button and will back to the homepage which allow the user to choose another image.

  ![image.png](https://upload-images.jianshu.io/upload_images/12014150-63357547271e0dca.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

<a name="Use"></a>  

#### Use

- Save the result in the favorites and can see the favorite images only.

  ![1558008366210](C:\Users\28718\AppData\Roaming\Typora\typora-user-images\1558008366210.png)

<a name="About the author"></a>  

## About the author

​	**ID**			1754060

​	**name**	  Zhe Zhang

​	**adviser**	Ying Shen

​	**contact**	email: doubleZ0108@gmail.com