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