$(document).ready(function () {
    $(".add-to-cart").click(function () {
        var productId = $(this).data("productid");
        var quantity = $(this).data("quantity");

        $.ajax({
            url: "/ShoppingCart/AddToCart",
            type: "POST",
            data: { productId: productId, quantity: quantity },
            success: function (response) {
                if (response.success) {
                    // Cập nhật số lượng sản phẩm trong giỏ hàng ngay lập tức
                    $("#cart-count").text(response.cartItemCount).removeClass("d-none");

                    // Hiển thị thông báo thêm thành công
                    var alertBox = $("#cart-alert");
                    alertBox.text("🛒 Đã thêm vào giỏ hàng!").removeClass("d-none").fadeIn();

                    // Ẩn thông báo sau 3 giây
                    setTimeout(function () {
                        alertBox.fadeOut(function () {
                            $(this).addClass("d-none");
                        });
                    }, 3000);
                } else {
                    alert("Lỗi: " + response.message);
                }
            },
            error: function () {
                alert("Có lỗi xảy ra khi thêm vào giỏ hàng!");
            }
        });
    });
});
