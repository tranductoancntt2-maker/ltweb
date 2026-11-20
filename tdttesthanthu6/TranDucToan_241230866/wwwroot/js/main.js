// BookHub - hiệu ứng giao diện cơ bản (nút "lên đầu trang")
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
    $(".loc-the-loai").click(function (e) {
        e.preventDefault();
        var maTl = $(this).data("maTl");
        $.ajax({
            url: "/Home/LocSach",
            type: "GET",
            data: { maTL: maTl },
            success: function (data) {
                $("#ketQuaSach").html(data);
            }
        });
    });
});
