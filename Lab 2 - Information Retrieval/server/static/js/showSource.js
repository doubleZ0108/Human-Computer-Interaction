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