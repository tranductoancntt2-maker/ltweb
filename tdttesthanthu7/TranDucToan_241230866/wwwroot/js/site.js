$(document).ready(function () {
    $(".loc-loai-hang").click(function (e) {
        var maLoai = $(this).data("malh");
        $.ajax({
            url: "/Home/LocHang",
            type: "GET",
            data: { maLoai: maLoai },
            success: function (data) {
                $("#ketQua").html(data);
            }
        });
    });
});
