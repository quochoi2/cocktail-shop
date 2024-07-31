var app = angular.module("AppBanHang", []);
app.controller("CartController", function ($scope, $http, $window) {
    $scope.cartItems = JSON.parse(localStorage.getItem('cart')) || [];

    $scope.removeItem = function (index) {
      var confirmRemove = confirm("Bạn có chắc chắn muốn xóa sản phẩm này khỏi giỏ hàng không?");
      if (confirmRemove) {
        $scope.cartItems.splice(index, 1);
        localStorage.setItem("cart", JSON.stringify($scope.cartItems));
      }
    };

    $scope.decreaseQuantity = function (index) {
      console.log('aa');
      if ($scope.cartItems[index].sSoLuong > 1) {
        $scope.cartItems[index].sSoLuong--;
        localStorage.setItem("cart", JSON.stringify($scope.cartItems));
      }
    };

    $scope.increaseQuantity = function (index) {
      $scope.cartItems[index].sSoLuong++;
      localStorage.setItem("cart", JSON.stringify($scope.cartItems));
    };

    $scope.updateQuantity = function (index) {
      if ($scope.cartItems[index].sSoLuong < 1) {
        $scope.cartItems[index].sSoLuong = 1;
      }
      localStorage.setItem("cart", JSON.stringify($scope.cartItems));
    };

    $scope.goToPaymentPage = function () {
      $window.location.href = "./pay.html";
    };

    $scope.getTotalPrice = function () {
      let totalPrice = 0;
      for (let x of $scope.cartItems) {
        totalPrice += x.sSoLuong * x.sGia;
      }
      return totalPrice.toLocaleString('vi-VN');
    };
});