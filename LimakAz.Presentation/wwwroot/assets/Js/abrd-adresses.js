var tabList = document.querySelectorAll(".nav-tabs-head-list");

tabList.forEach(function(tab) {
    tab.addEventListener("click", (e) => {
        e.preventDefault();
        var clickedTab = e.target.parentElement;

        if (clickedTab.tagName === "UL") {
            return;
        }

        tabList.forEach(function(tab) {
            if (tab !== clickedTab && tab.classList.contains("nav-tabs-active")) {
                tab.classList.remove("nav-tabs-active");
            }
        });

        clickedTab.classList.add("nav-tabs-active");
        console.log(clickedTab);
    });
});


// Button'u seç
var button = document.querySelectorAll(".copy-btn");

button.forEach((btn)=>{
    btn.addEventListener("click", function() {
        // Butonun ID'sini al
        var buttonId = this.id;
    
        // ID'yi kopyala
        var textarea = document.createElement("textarea");
        textarea.value = buttonId;
        document.body.appendChild(textarea);
        console.log(buttonId)
        textarea.select();
        document.execCommand("copy");
        document.body.removeChild(textarea);
    
        // Kopyalandı mesajı göster
        console.log(buttonId)
    });
})

var button = document.querySelectorAll(".copy-btn-amrk");

button.forEach((btn)=>{
    btn.addEventListener("click", function() {
        // Butonun ID'sini al
        var buttonId = this.id;
    
        // ID'yi kopyala
        var textarea = document.createElement("textarea");
        textarea.value = buttonId;
        document.body.appendChild(textarea);
        console.log(buttonId)
        textarea.select();
        document.execCommand("copy");
        document.body.removeChild(textarea);
    
        // Kopyalandı mesajı göster
        console.log(buttonId)
    });
})
