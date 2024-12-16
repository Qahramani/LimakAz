    var showPaswordBtn = document.querySelector(".visibility-btn-password");
    var passwordInput = document.getElementById("login-password");

     showPaswordBtn.addEventListener("click", (e)=>{
    e.preventDefault();
    var newPassValue = passwordInput.value.trim();
    if(newPassValue !== ""){
        if(passwordInput.type == "text"){
            passwordInput.type = "password"
        }
        else{
            passwordInput.type = "text"
        
        }
    }
    })



    var rememberMe = document.getElementById("__Rem-Me");
    
    rememberMe.addEventListener("click", (e)=>{
        if (rememberMe.checked) {
            console.log("truee")
            return rememberMe.value = true;
        }
        else {
            console.log("Falseee")
            return rememberMe.value = false;
    
        }
    })


