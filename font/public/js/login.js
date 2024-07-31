var app = angular.module('AppBanHang', []);
app.controller('LoginCtrl', function ($scope, $http) {
    $scope.login = function () {
      if (!$scope.tTaiKhoan || !$scope.tMatKhau) {
        alert('Vui lòng nhập đủ thông tin tài khoản!');
        return;
      }
      var data = {
        "username": $scope.tTaiKhoan,
        "password": $scope.tMatKhau
      };
      $http({
          method: 'POST',
          url: 'https://localhost:44378/api/Account/login',
          data: data,
          dataType: 'json',
          headers: { "Content-Type": "application/json" }
      }).then(function (response) {
          $scope.dataId = response.data;
          var storedIdInfo = localStorage.getItem('id_' + $scope.taikhoan);
          if (!storedIdInfo) {
            var localStorageIdKey = 'id_' + $scope.dataId.taikhoan;
            localStorage.setItem(localStorageIdKey, JSON.stringify($scope.dataId));
          }
          alert('Đăng nhập thành công!')
          window.location.href = './main.html'
      }).catch(function () {
          alert('Thông tin tài khoản hoặc mật khẩu không chính xác'); 
      });


      $http({
        method: 'GET',
        url: 'https://localhost:44378/api/User/get-id-khach?username=' + $scope.tTaiKhoan + '&password=' + $scope.tMatKhau,
        data: data,
        dataType: 'json',
        headers: { "Content-Type": "application/json" }
      }).then(function (response) {
        $scope.dataUser = response.data;
        var storedUserInfo = localStorage.getItem('user_' + $scope.taikhoan);
        if (!storedUserInfo) {
          var localStorageUserKey = 'user_' + $scope.dataUser.taikhoan;
          localStorage.setItem(localStorageUserKey, JSON.stringify($scope.dataUser));
        }
      }).catch(function () {
        alert('Thông tin tài khoản hoặc mật khẩu không chính xác'); 
      });
    };
});