var app = angular.module('AppBanHang', []);
app.controller("sanpham", function ($scope, $http) {
    $scope.listItem = [];

    $scope.LoadMenu = function () {
        $http({
            method: 'GET',
            url: 'https://localhost:44378/api/Product/get-all',
        }).then(function (response) {
            $scope.listItem = response.data;
        });
    };

    $scope.LoadMenu();
});






// let productsData = [
//   {
//     id: 1,
//     name: "ESSENTIAL COCKTAIL SET",
//     color: "STAINLESS STEEL",
//     price: "700.000 VND",
//     img: "./images/tool and kits/c1.PNG",
//     imgInto: "./images/tool and kits/c1-into.PNG"
//   },
//   {
//     id: 2,
//     name: "ESSENTIAL COCKTAIL SET",
//     color: "COPPER-PLATED",
//     price: "750.000 VND",
//     img: "./images/tool and kits/c2.PNG",
//     imgInto: "./images/tool and kits/c2-into.PNG"
//   },
//   {
//     id: 3,
//     name: "ESSENTIAL COCKTAIL SET",
//     color: "GOLD-PLATED",
//     price: "800.000 VND",
//     img: "./images/tool and kits/c3.PNG",
//     imgInto: "./images/tool and kits/c3-into.PNG"
//   },
//   {
//     id: 4,
//     name: "ESSENTIAL COCKTAIL SET",
//     color: "MATE BLACK",
//     price: "500.000 VND",
//     img: "./images/tool and kits/c4.PNG",
//     imgInto: "./images/tool and kits/c4-into.PNG"
//   },
//   {
//     id: 5,
//     name: "DAVID WONDRICH STIRRED",
//     color: "SILVER-PLATED EPNS",
//     price: "350.000 VND",
//     img: "./images/tool and kits/c5.PNG",
//     imgInto: "./images/tool and kits/c5-into.PNG"
//   },
//   {
//     id: 6,
//     name: "DAVID WONDRICH GALLON PUNCH",
//     color: "SILVER-PLATED EPNS",
//     price: "400.000 VND",
//     img: "./images/tool and kits/c6.PNG",
//     imgInto: "./images/tool and kits/c6-into.PNG"
//   },
//   {
//     id: 7,
//     name: "CAFE BRULOT BOWL AND FORK SET",
//     color: "CLASSIC EDITION",
//     price: "1.200.000 VND",
//     img: "./images/tool and kits/c7.PNG",
//     imgInto: "./images/tool and kits/c7-into.PNG"
//   },
//   {
//     id: 8,
//     name: "CAFE BRULOT BOWL AND FORK SET",
//     color: "SPECIAL EDITION WITH DALE STATUETTES",
//     price: "1.400.000 VND",
//     img: "./images/tool and kits/c7.PNG",
//     imgInto: "./images/tool and kits/c8-into.PNG"
//   },
//   {
//     id: 9,
//     name: "BARWARE ROLL-UP KIT",
//     color: "BLACK CANVAS",
//     price: "600.000 VND",
//     img: "./images/tool and kits/c9.PNG",
//     imgInto: "./images/tool and kits/c9-into.PNG"
//   },
//   {
//     id: 10,
//     name: "BARWARE ROLL-UP KIT",
//     color: "ARMY GREEN CANVAS",
//     price: "600.000 VND",
//     img: "./images/tool and kits/c10.PNG",
//     imgInto: "./images/tool and kits/c9-into.PNG"
//   },
//   {
//     id: 11,
//     name: "SAZERAC KIT",
//     color: "SILVER-PLATED EPNS",
//     price: "150.000 VND",
//     img: "./images/tool and kits/c11.PNG",
//     imgInto: "./images/tool and kits/c11-into.PNG"
//   },
//   {
//     id: 12,
//     name: "PROHIBITION BOOK BUNDLE",
//     color: "SET OF 3 BOOK",
//     price: "250.000 VND",
//     img: "./images/tool and kits/c12.PNG",
//     imgInto: "./images/tool and kits/c12-into.PNG"
//   },
// ]
// let kits = document.getElementById('kit-box');

// let renderKit = () => {
//   return (kits.innerHTML = productsData.map((x) => {
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

// renderKit();

