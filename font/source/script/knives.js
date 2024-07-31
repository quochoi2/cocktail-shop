var app = angular.module('AppBanHang', []);
app.controller("sanpham", function ($scope, $http) {
    $scope.handleAddToCartClick = function (item) {
        $scope.addToCart(item);
    };

    $scope.LoadMenu = function () {
        $http({
            method: 'GET',
            url: 'https://localhost:44378/api/Product/get-all',
        }).then(function (response) {
            $scope.listItem = response.data;
        });
    };
    $scope.LoadMenu();


    $scope.addToCart = function (item) {
        var cartItems = JSON.parse(localStorage.getItem('cart')) || [];
        console.log(cartItems);
        cartItems.push(item);
        localStorage.setItem('cart', JSON.stringify(cartItems));
        alert('Đã thêm vào giỏ hàng thành công!');
    };

    $scope.arrangeIncrease = function () {
        $http({
            method: 'GET',
            url: 'https://localhost:44378/api/Product/get-all-filter-increase',
        }).then(function (response) {
            $scope.listItem = response.data;
        });
    }
    $scope.arrangeDecrease = function () {
        $http({
            method: 'GET',
            url: 'https://localhost:44378/api/Product/get-all-filter-decrease',
        }).then(function (response) {
            $scope.listItem = response.data;
        });
    }
    $scope.arrangeLow = function () {
        $http({
            method: 'GET',
            url: 'https://localhost:44378/api/Product/get-all-filter-low',
        }).then(function (response) {
            $scope.listItem = response.data;
        });
    }
    $scope.arrangeMedium = function () {
        $http({
            method: 'GET',
            url: 'https://localhost:44378/api/Product/get-all-filter-medium',
        }).then(function (response) {
            $scope.listItem = response.data;
        });
    }
    $scope.arrangeHigh = function () {
        $http({
            method: 'GET',
            url: 'https://localhost:44378/api/Product/get-all-filter-high',
        }).then(function (response) {
            $scope.listItem = response.data;
        });
    }
});






// let productKnive = [
//   {
//     id: 1,
//     name: "OVERLORD™ 3.5” PARING KNIFE",
//     color: "DAMASCUS STEEL / PAKKAWOOD HANDLE",
//     price: "600.000",
//     img: "./images/knives/c1.PNG",
//     imgInto: "./images/knives/c1-into.PNG"
//   },
//   {
//     id: 2,
//     name: "OVERLORD™ 3.5” PARING KNIFE",
//     color: "COMPOSITE HANDLE",
//     price: "650.000",
//     img: "./images/knives/c2.PNG",
//     imgInto: "./images/knives/c2-into.PNG"
//   },
//   {
//     id: 3,
//     name: "OVERLORD™ 5” UTILITY KNIFE",
//     color: "COMPOSITE HANDLE",
//     price: "750.000",
//     img: "./images/knives/c3.PNG",
//     imgInto: "./images/knives/c3-into.PNG"
//   },
//   {
//     id: 4,
//     name: "OVERLORD™ 5” UTILITY KNIFE",
//     color: "PAKKAWOOD HANDLE",
//     price: "850.000",
//     img: "./images/knives/c4.PNG",
//     imgInto: "./images/knives/c4-into.PNG"
//   },
//   {
//     id: 5,
//     name: "OVERLORD™ 8” CHEF'S KNIFE",
//     color: "PAKKAWOOD / DAMASCUS STEEL",
//     price: "1.100.000",
//     img: "./images/knives/c5.PNG",
//     imgInto: "./images/knives/c5-into.PNG"
//   },
//   {
//     id: 6,
//     name: "OVERLORD™ 8” SERRATED KNIFE",
//     color: "COMPOSITE HANDLE",
//     price: "1.000.000",
//     img: "./images/knives/c6.PNG",
//     imgInto: "./images/knives/c6-into.PNG"
//   },
//   {
//     id: 7,
//     name: "OVERLORD™ 6.8” NAKIRI KNIFE",
//     color: "PAKKAWOOD HANDLE",
//     price: "1.200.000",
//     img: "./images/knives/c7.PNG",
//     imgInto: "./images/knives/c7-into.PNG"
//   },
//   {
//     id: 8,
//     name: "OVERLORD™ 8” CHEF'S KNIFE",
//     color: "COMPOSITE HANDLE",
//     price: "950.000",
//     img: "./images/knives/c8.PNG",
//     imgInto: "./images/knives/c8-into.PNG"
//   },
//   {
//     id: 9,
//     name: "OVERLORD™ 8” SERRATED KNIFE",
//     color: "PAKKAWOOD HANDLE",
//     price: "1.600.000",
//     img: "./images/knives/c9.PNG",
//     imgInto: "./images/knives/c9-into.PNG"
//   },
//   {
//     id: 10,
//     name: "OVERLORD™ 6.8” NAKIRI KNIFE",
//     color: "COMPOSITE HANDLE",
//     price: "1.300.000",
//     img: "./images/knives/c10.PNG",
//     imgInto: "./images/knives/c10-into.PNG"
//   }
// ]

// let knives = document.getElementById('kit-box');

// let renderKnive = () => {
//   return (knives.innerHTML = productKnive.map((x) => {
//     return `
//       <div class="product-box">
//         <div class="product-img">
//           <img src="${x.img}" alt="" class="product-img__img">
//           <img src="${x.imgInto}" alt="" class="product-img__img">
//         </div>
//         <div class="product-form">
//           <h1>${x.name}</h1>
//           <p>${x.color}</p>
//           <span>${x.price}</span>
//           <div class="shop-cart">
//             <a href="">Add to cart</a>
//           </div>
//         </div>
//       </div>
//     `;
//   }).join(''));
// };

// renderKnive();