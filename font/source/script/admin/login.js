const form = document.forms["form__login"];
const btnLg = document.querySelector(".sign-in");

var app = angular.module("AppBanHang", []);
app.controller("HomeLogin", function ($scope, $http) {
  $scope.listAccount = [];

  $scope.Account = function (data) {
    $http({
      method: "POST",
      data,
      url: "https://localhost:44390/api/Account/login",
    }).then(function (response) {
      // localStorage.setItem("account", JSON.stringify(response.data));
      location.assign("./admin.html");
    });
  };

  function handleForm() {
    btnLg.onclick = function () {
      var username = form.elements.username.value;
      var password = form.elements.password.value;
      if (username === "" || password === "") {
        alert("Bạn chưa nhập đủ thông tin tài khoản!");
        return;
      }
      var formData = {
        username,
        password,
      };
      $scope.Account(formData);
    };

    // Ngăn chặn sự kiện mặc định của form
    form.onsubmit = (e) => {
      e.preventDefault();
    };
  }
  handleForm();
});
