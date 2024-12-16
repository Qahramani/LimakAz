var emailInput = document.querySelector(".recovery-email-input")
var recoveryBtn = document.querySelector(".recoveryBtn");

recoveryBtn.disabled = true;


emailInput.addEventListener("input", function() {
    var inpValue = emailInput.value.trim(); 

    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!inpValue || !emailRegex.test(inpValue)) {
        recoveryBtn.disabled = true; 
    } else {
        recoveryBtn.disabled = false; 
        
    }
});

recoveryBtn.addEventListener("click", function(e) {
    e.preventDefault();

    var inpValue = emailInput.value.trim(); 
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    if (!inpValue || !emailRegex.test(inpValue)) {
        console.log("uygun deyil");
        return; // Formu gönderme
    }

});


