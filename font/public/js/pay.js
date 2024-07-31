var app = angular.module('AppBanHang', []);
app.controller('CtrlPay', function ($scope, $http, $window) {
    $scope.hoaDon = {
        "kId": 0,
        "hdbNgayLap": "string",
        "hdbMoTa": "Đang duyệt",
        "list_json_chitiethoadon": []
    };

    var kIdFromLocalStorage = JSON.parse(localStorage.getItem('user_' + $scope.tTaiKhoan));
    if (kIdFromLocalStorage) {
        $scope.hoaDon.kId = kIdFromLocalStorage.kId;
    }

    var currentDay = new Date();
    $scope.hoaDon.hdbNgayLap = currentDay.toISOString();

    var CartListFromLocalStorage = JSON.parse(localStorage.getItem('cart'));
    if (CartListFromLocalStorage) {
        for (var i = 0; i < CartListFromLocalStorage.length; i++) {
            var item = CartListFromLocalStorage[i];
            var obj = {
                "spId": item.spId,
                "ctbSoLuong": item.sSoLuong,
                "ctbTongTien": item.sGia
            };
            $scope.hoaDon.list_json_chitiethoadon.push(obj);
        }
    }

    $scope.Create = function () {
        $http({
            method: 'POST',
            url: 'https://localhost:44378/create-bill',
            data: $scope.hoaDon,
            headers: { 'Content-Type': 'application/json' }
        }).then(function (response) {
            alert('Đặt hàng thành công!');
            localStorage.removeItem("cart");
            window.location.href = './main.html';
        }, function (error) {
            console.error('Lỗi khi gửi dữ liệu:', error);
        });
    };
});
