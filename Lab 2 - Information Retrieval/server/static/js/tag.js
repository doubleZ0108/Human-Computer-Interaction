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

function tagClick(e) {
    console.log("点击的是" + e.id)

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