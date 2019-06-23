$(function () {
    for (var i = 0; i <= 8; i++) {
        $('#img' + String(i)).click(function () {
            $(this).toggleClass('min');
            $(this).toggleClass('max');
        });
    }
});