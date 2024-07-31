var app = angular.module('AppBanHang', []);
app.controller("MainCtrl", function ($scope, $http) {
    $scope.listCustomer = [];
    $scope.listProduct = [];
    $scope.listManafacture = [];
    $scope.listBill = [];
    $scope.listReceipt = [];

    // Khach hang
    $scope.LoadCustomer = function () {
        $http({
            method: 'GET',
            url: 'https://localhost:44390/api/User/get-all',
        }).then(function (response) {  
            $scope.listCustomer = response.data;  
        });
    };
    $scope.LoadCustomer();


    // San pham
    $scope.LoadProduct = function () {
        $http({
            method: 'GET',
            url: 'https://localhost:44390/api/Product/get-all',
        }).then(function (response) {  
            $scope.listProduct = response.data;  
        });
    };
    $scope.LoadProduct();


    // Nha san xuat
    $scope.LoadManafacture = function () {
        $http({
            method: 'GET',
            url: 'https://localhost:44390/api/Manafacture/get-all',
        }).then(function (response) {  
            $scope.listManafacture = response.data;  
        });
    };
    $scope.LoadManafacture();

    
    // Hoa don ban
    $scope.LoadBill = function () {
        $http({
            method: 'GET',
            url: 'https://localhost:44390/get-all',
        }).then(function (response) {  
            $scope.listBill = response.data;  
        });
    };
    $scope.LoadBill();


    // Hoa don nhap
    // $scope.LoadReceipt = function () {
    //     $http({
    //         method: 'POST',
    //         url: 'https://localhost:44390/create-receipt',
    //     }).then(function (response) {  
    //         $scope.listReceipt = response.data;  
    //     });
    // };
    // $scope.LoadReceipt();
});