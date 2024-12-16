// Example starter JavaScript for disabling form submissions if there are invalid fields
(function () {
  'use strict'

  // Fetch all the forms we want to apply custom Bootstrap validation styles to
  var forms = document.querySelectorAll('.needs-validation')

  // Loop over them and prevent submission
  Array.prototype.slice.call(forms).forEach(function (form) {
      form.addEventListener("blur", function (event) {
        if (!form.checkValidity()) {
          event.preventDefault()
          event.stopPropagation()
        }

        form.classList.add('was-validated')
      }, true)
    })
})()


var prefix = document.querySelector(".dropdown-select-prefix");

prefix.addEventListener("change",(e)=>{
  e.preventDefault();
  var optionValue = e.target.value
  console.log(optionValue)
})


// onkeydown="if(this.value.length == 7 && event.keyCode!=8) return false

var termAgreBtn = document.querySelector(".btn-terms-agree");
var termAgrement = document.querySelector(".form-check-input");
var modalTerms = document.getElementById("exampleTermandCondi");
var modalBackShadow = document.querySelector(".modal-backdrop");
var termModalClose = document.querySelector(".btn-close");

termAgreBtn.addEventListener("click", (e) => {
e.preventDefault();
termAgrement.checked = true;
modalTerms.style.display = "none"

});


var headFirstLetter = document.querySelector(".register-card-head-first")
var firstLetter = headFirstLetter.innerHTML.charAt(0)
var restOftext = headFirstLetter.innerHTML.slice(1);
headFirstLetter.innerHTML = "<span id='firstLetter'>" + firstLetter + "</span>" + restOftext;

var firstLetterSpan = document.getElementById("firstLetter");
firstLetterSpan.style.color = "#F05835";
firstLetterSpan.style.fontWeight = "bold";



// FORMDA PASSWORD SHOW FUNKSIYASI -----START-----

var newPassword = document.getElementById("password-regr")
var confirmPassword = document.getElementById("password-confirmation-regr")
var visibilityBtnPassword = document.querySelector(".visibility-btn-new-password")
var visibilityBtnPassConfirm = document.querySelector(".visibility-btn-password-confirm");


visibilityBtnPassword.addEventListener("click", (e)=>{
e.preventDefault();
var  newPasswordValue = newPassword.value.trim();
if(newPasswordValue !== ""){
  if(newPassword.type == "text"){
    newPassword.type = "password"
  }
  else{
    newPassword.type = "text"
  }
}

})

visibilityBtnPassConfirm.addEventListener("click", (e)=>{
e.preventDefault();
console.log("ishledi")

var currentPasValue = confirmPassword.value.trim();

if(currentPasValue !== ""){
  if(confirmPassword.type == "text"){
    confirmPassword.type = "password"
  }
  else{
    confirmPassword.type = "text"

  }
}

})

// FORMDA PASSWORD SHOW FUNKSIYASI -----END-----

var checkBox = document.querySelector(".form-check-input");

checkBox.addEventListener("click", (e) => {
  e.preventDefault();
  if (e.checked) {
      console.log("true oldu")
      return true
  }
  else {
      console.log("false")
      return false

  }
})

