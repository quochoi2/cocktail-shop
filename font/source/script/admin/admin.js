var user = JSON.parse(localStorage.getItem("account"));
if (!user) {
  window.location.href = "./login.html";
}

const logOut = () => {
  if(confirm("Bạn có muốn thoát không?")) {
    localStorage.clear();
    window.location.href = 'login.html';
  }
}

// window.onload = function() {
//   if (window.jQuery) {  
//       // jQuery is loaded  
//       alert("Yeah!");
//   } else {
//       // jQuery is not loaded
//       alert("Doesn't Work");
//   }
// }


// function getPageList(totalPages, page, maxLength) {
//   function range(start, end) {
//     return Array.from(Array(end - start + 1), (_, i) => i + start );
//   }

//   var sideWidth = maxLength < 9 ? 1 : 2;
//   var leftWidth = (maxLength - sideWidth * 2 - 3) >> 1;
//   var rightWidth = (maxLength - sideWidth * 2 - 3) >> 1;

//   if(totalPages <= maxLength) {
//     return range(1, totalPages)
//   }
//   if(page <= maxLength - sideWidth - 1 - rightWidth) {
//     return range(1, maxLength - sideWidth - 1).concat(0, range(totalPages - sideWidth + 1, totalPages));
//   }
//   if(page >= totalPages -sideWidth - 1 - rightWidth) {
//     return range(1, sideWidth).concat(0, range(totalPages - sideWidth - 1 - rightWidth - leftWidth, totalPages));
//   }
//   return range(1, sideWidth).concat(0, range(page - leftWidth, page + rightWidth), 0, range(totalPages - sideWidth + 1, totalPages));
// }

// $(function() {
//   var numberOfItem = $(".table-content-box .colum-content-box").length;
//   var limitPerPage = 5;
//   var totalPages = Math.ceil(numberOfItem / limitPerPage);
//   var paginationSize = 7;
//   var currentPage;

//   function showPage(whichPage) {
//     if(whichPage < 1 || whichPage > totalPages) return false;

//     currentPage = whichPage;

//     $(".table-content-box .colum-content-box").hide().slice((currentPage - 1) * limitPerPage, currentPage * limitPerPage).show();
//     $(".pagination li").slice(1, -1).remove();

//     getPageList(totalPages, currentPage, paginationSize).forEach(item => {
//       $("<li>").addClass("page-item").addClass(item ? "current-page":"dot").toggleClass("active-page", item === currentPage).append($("<a>").addClass("page-link").attr({href: "javascript:void(0)"}).text(item || "...")).insertBefore(".next-page");
//     });
//     $(".previous-page").toggleClass("disable", currentPage === 1)
//     $(".next-page").toggleClass("disable", currentPage === 1)
//     return true;
//   }

//   $(".pagination").append(
//       $("<li>").addClass("page-item").addClass("previous-page").append($("<a>").addClass("page-link").attr({href: "javascript:void(0)"}).text("Prev")),
//       $("<li>").addClass("page-item").addClass("next-page").append($("<a>").addClass("page-link").attr({href: "javascript:void(0)"}).text("Next"))
//     );

//     $(".table-content-box").show();

//     showPage(1);

//     $(document).on("click", ".pagination li.current-page:not(.active-page)", function() {
//       return showPage(+$(this).text());
//     });

//     $(".next-page").on("click", function() {
//       return showPage(currentPage + 1);
//     });
//     $(".previous-page").on("click", function() {
//       return showPage(currentPage - 1);
//     });
// }); 






// const allSideMenu = document.querySelectorAll('#sidebar .side-menu.top li a');

// allSideMenu.forEach(item => {
//   const li = item.parentElement;

//   item.addEventListener('click', function () {
//     allSideMenu.forEach(i => {
//       i.parentElement.classList.remove('active');
//     })
//     li.classList.add('active');
//   })
// });

// TOGGLE SIDEBAR
// const menuBar = document.querySelector('#content nav .bx.bx-menu');
// const sidebar = document.getElementById('sidebar');

// menuBar.addEventListener('click', function () {
//   sidebar.classList.toggle('hide');
// })


// const searchButton = document.querySelector('#content nav form .form-input button');
// const searchButtonIcon = document.querySelector('#content nav form .form-input button .bx');
// const searchForm = document.querySelector('#content nav form');

// searchButton.addEventListener('click', function (e) {
//   if (window.innerWidth < 576) {
//     e.preventDefault();
//     searchForm.classList.toggle('show');
//     if (searchForm.classList.contains('show')) {
//       searchButtonIcon.classList.replace('bx-search', 'bx-x');
//     } else {
//       searchButtonIcon.classList.replace('bx-x', 'bx-search');
//     }
//   }
// })

// if (window.innerWidth < 768) {
//   sidebar.classList.add('hide');
// } else if (window.innerWidth > 576) {
//   searchButtonIcon.classList.replace('bx-x', 'bx-search');
//   searchForm.classList.remove('show');
// }


// window.addEventListener('resize', function () {
//   if (this.innerWidth > 576) {
//     searchButtonIcon.classList.replace('bx-x', 'bx-search');
//     searchForm.classList.remove('show');
//   }
// })

// const switchMode = document.getElementById('switch-mode');

// switchMode.addEventListener('change', function () {
//   if (this.checked) {
//     document.body.classList.add('dark');
//   } else {
//     document.body.classList.remove('dark');
//   }
// })




// điều hướng trang
// document.addEventListener("DOMContentLoaded", function() {
//   const navLinks = document.querySelectorAll("nav a");
  
//   navLinks.forEach(function(link) {
//       link.addEventListener("click", function(e) {
//           e.preventDefault(); // Ngăn chuyển hướng mặc định
          
//           const pageToLoad = this.getAttribute("href");
          
//           // Sử dụng AJAX để tải nội dung của trang
//           fetch(pageToLoad)
//               .then(response => response.text())
//               .then(data => {
//                   // Thay thế nội dung của trang hiện tại
//                   document.documentElement.innerHTML = data;
//               })
//               .catch(error => console.log(error));
//       });
//   });
// });