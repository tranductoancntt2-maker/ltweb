// AssetHub - hiệu ứng giao diện cơ bản (nút "lên đầu trang")
$(function () {
    $(window).on('scroll', function () {
        $('.to-top').toggle($(this).scrollTop() > 200);
    });
    $('.to-top').on('click', function () {
        $('html, body').animate({ scrollTop: 0 }, 400);
    });
    $('.search-box input').on('focus', function () { $(this).select(); });
});
$(document).ready(function () {
    $(".loc-tai-san").click(function (e) {
        e.preventDefault();
        var maLoai = $(this).data("maloai");
        $.ajax({
            url: "/Home/LocTaiSan", type: "GET", data: { maLoai: maLoai }, success: function (data) { $("#ketQua").html(data); }
        });
    });
});
