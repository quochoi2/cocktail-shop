let index = 1;
let indexNext1 = 0;
let indexNext2 = 1;
let indexNext3 = 3;
showSlide(index);

// Next/previous controls
function slide(n) {
  showSlide(index += n);
}

// Thumbnail image controls
function dot(n) {
  showSlide(index = n);
}

function showSlide(n = null) {
  let i;
  let slides = document.getElementsByClassName("first__child");
  let dots = document.getElementsByClassName("dot__child");
  if (n > slides.length) { index = 1 }
  if (n < 1) { index = slides.length }
  for (i = 0; i < slides.length; i++) {
    slides[i].style.display = "none";
  }
  indexNext1++;
  for (i = 0; i < dots.length; i++) {
    dots[i].className = dots[i].className.replace(" active", " dot__child");
  }
  slides[index - 1].style.display = "block";
  dots[slideIndex - 1].className += " active";
}