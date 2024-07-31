var app = angular.module("AppBanHang", []);
app.controller("ProductDetail", function ($scope, $http, $window) {
  $scope.sp;

  $scope.handleAddToCartClick = function () {
    $scope.addToCart($scope.sp);
  };

  
  $scope.load = function () {
    var urlObject = new URL(window.location.href); // tao doi tuong url
    var id = urlObject.searchParams.get("id");
    $http({
      method: "GET",
      url:'https://localhost:44378/api/Product/get-by-id?id='+id,
    }).then(function (response) {
      $scope.sp = response.data;
    });
  };
  $scope.load();


  // Hàm chung để thêm sản phẩm vào giỏ hàng
  $scope.addToCart = function (item) {
    var i = JSON.parse(localStorage.getItem('cart')) || []
    console.log(i);
    i.push(item)
    localStorage.setItem("cart", JSON.stringify(i));
    
    alert("Đã thêm vào giỏ hàng thành công!");
    var confirmAddToCart = confirm("Bạn có muốn đến giỏ hàng không?");

    if (confirmAddToCart) {
      $window.location.replace("/public/cart.html");
    } else {

    }
  };
});