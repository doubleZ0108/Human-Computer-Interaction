var tags = new Array();
var color_list = new Array();

function myFunction() {
    document.getElementById("predictedResult").innerHTML = "";
    $('#clear').hide();
}

function fun() {
    $('#load').show();
    $("form").submit(function (evt) {
        //$('#loader-icon').show();
        evt.preventDefault();
        //$('#loader-icon').show();
        var formData = new FormData($(this)[0]);
        $.ajax({
            url: 'imgUpload',
            type: 'POST',
            data: formData,
            //async: false,
            cache: false,
            contentType: false,
            enctype: 'multipart/form-data',
            processData: false,
            success: function (response) {
                $('#load').hide();
                $('#row1').show();
                //$('#clear').show();
                //console.log(response[1]);
                //document.getElementById("predictedResult").innerHTML= response;

                //先要设置tag => 动态添加button
                tags = response.tags
                console.log(tags)
                for (var i = 0; i < tags.length; ++i) {
                    var color = randomHexColor()
                    color_list.push(color)
                    addrow(tags[i], color)
                }

                document.getElementById("img0").src = response.image0[0];
                document.getElementById("img1").src = response.image1[0];
                document.getElementById("img2").src = response.image2[0];
                document.getElementById("img3").src = response.image3[0];
                document.getElementById("img4").src = response.image4[0];
                document.getElementById("img5").src = response.image5[0];
                document.getElementById("img6").src = response.image6[0];
                document.getElementById("img7").src = response.image7[0];

                document.getElementById("imgtag0").append(response.image0[1])
                document.getElementById("imgtag0").style.backgroundColor = String(
                    color_list[tags.indexOf(response.image0[1])])
                document.getElementById("img0").name = response.image0[1]

                document.getElementById("imgtag1").append(response.image1[1])
                document.getElementById("imgtag1").style.backgroundColor = String(
                    color_list[tags.indexOf(response.image1[1])])
                document.getElementById("img1").name = response.image1[1]

                document.getElementById("imgtag2").append(response.image2[1])
                document.getElementById("imgtag2").style.backgroundColor = String(
                    color_list[tags.indexOf(response.image2[1])])
                document.getElementById("img2").name = response.image2[1]

                document.getElementById("imgtag3").append(response.image3[1])
                document.getElementById("imgtag3").style.backgroundColor = String(
                    color_list[tags.indexOf(response.image3[1])])
                document.getElementById("img3").name = response.image3[1]

                document.getElementById("imgtag4").append(response.image4[1])
                document.getElementById("imgtag4").style.backgroundColor = String(
                    color_list[tags.indexOf(response.image4[1])])
                document.getElementById("img4").name = response.image4[1]

                document.getElementById("imgtag5").append(response.image5[1])
                document.getElementById("imgtag5").style.backgroundColor = String(
                    color_list[tags.indexOf(response.image5[1])])
                document.getElementById("img5").name = response.image5[1]

                document.getElementById("imgtag6").append(response.image6[1])
                document.getElementById("imgtag6").style.backgroundColor = String(
                    color_list[tags.indexOf(response.image6[1])])
                document.getElementById("img6").name = response.image6[1]

                document.getElementById("imgtag7").append(response.image7[1])
                document.getElementById("imgtag7").style.backgroundColor = String(
                    color_list[tags.indexOf(response.image7[1])])
                document.getElementById("img7").name = response.image7[1]



                //document.getElementById("img8").src = response.image8;
                $('#table').show();
                $('#tagtable').show();
                $('#clear').show();

                //显示检索结果
                $('#retrieval-result1').show();
                $('#retrieval-result2').show();
                $('#retrieval-result3').show();
            }
        });
        return false;
    })
};

