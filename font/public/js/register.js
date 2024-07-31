var app = angular.module('AppBanHang', [])
app.controller('MainCtrl', function ($scope, $http, $window) {
  $scope.register = function () {
    console.log('a');
    if (!$scope.kTen || !$scope.tTaiKhoan || !$scope.tMatKhau || !$scope.tMatKhauLai) {
      alert('Vui lòng nhập đủ thông tin tài khoản!');
      return;
    }
    if ($scope.tMatKhauLai == $scope.tMatKhau) {
        var obj = {
            "tTaiKhoan": $scope.tTaiKhoan,
            "tMatKhau": $scope.tMatKhau,
            "kTen": $scope.kTen,
            "tLoai": "Khách hàng",
            "token": "khoa bi mat"
        };
        $http({
            method: 'POST',
            url: 'https://localhost:44378/api/Account/create-account',
            data: obj,
            dataType: 'json',
            headers: { "Content-Type": "application/json" }
        }).then(function (response) {
            alert('Đăng ký thành công!')
            location.href = './login.html';
        });
    }
  };
}); 