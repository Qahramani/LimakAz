var checkKargoTrue = document.querySelectorAll(".custom-control-input")
var priceInput = document.querySelector(".price-input")
var kargoPrice = document.getElementById("olke-daxili-kargo")


checkKargoTrue.forEach((radio)=>{
    radio.addEventListener("click", (e)=>{
        var targetValue = e.target.value
        if(targetValue == "true"){
            console.log("salam")
            kargoPrice.disabled = false
            console.log(priceInput)
        }
        else{
            kargoPrice.disabled = true
            console.log("sagol")
        }
    })
})


var newLinkBtn = document.querySelectorAll(".link-button")
var cardBody = document.querySelector(".tab-content")
var fullCardBody = document.querySelector(".order-card-body");
var cardContaner = document.querySelector(".extraTabContent");
var trtapPane = document.querySelector(".tukish")
console.log(trtapPane)
var tabpane = document.querySelectorAll(".order-turkish")


var orderFormHtml = `
<div class="tab-pane active" id="1">
    <div class="ordercard-list">
        <div class="order-card-body">
            <form class="form-ordercard">
                <div class="row">
                    <div class="col-sm-9 col-12">
                        <div>
                            <label class="form-control-label" for="product-link">Məhsulun linki *</label>
                            <div class="url-input-block">
                                <input type="url" placeholder="Məhsulun linki" required="required" class="form-control-url">
                            </div>
                        </div>
                    </div>
                    <!-- Diğer HTML içeriği buraya ekleyin -->
                </div>
                <div class="order-card-actions">
                    <div></div>
                    <div>
                        <button type="button" class="link-button">
                            <img src="https://limak.az/new_front/assets/img/icons/plus-circle.svg" alt="">
                            <span>Yeni link</span>
                        </button>
                    </div>
                </div>
            </form>
        </div>
    </div>
</div>
`;


newLinkBtn.forEach(btnLink =>{
    btnLink.addEventListener("click", (e) => {
        e.preventDefault();
        
        tabpane.forEach((element) => {
            if (element.classList.contains("active")) {
                // Yeni form elementi oluştur
                // var newForm = document.createElement('div');
                // console.log(trtapPane.innerHTML);
                // newForm.innerHTML = trtapPane.innerHTML;
                let newForm = trtapPane.innerHTML
                element.innerHTML(newForm);
                console.log(newForm)
            }
        });
    });
});

// newLinkBtn.addEventListener("click", (e) => {
//     e.preventDefault();
    
//     tabpane.forEach((element) => {
//         if (element.classList.contains("active")) {
//             cardContaner.innerHTML = orderFormHtml;
//         }
//     });
// });


var paymentInputSidebar = document.querySelectorAll(".custom-payment-input")
var paymentBtn = document.querySelector(".payment-btn")

paymentInputSidebar.forEach((inputs) =>{
    inputs.addEventListener("click", (e)=>{
        var selectedValue = e.target.value
        if(selectedValue == 1 || selectedValue == 2 || selectedValue == 3){
            paymentBtn.disabled = false
            paymentBtn.classList.add('btnPointer')
        }
        else{
            paymentBtn.disabled = true
        }
    })
})


    // TURKEY PRICE PERCENT CALCULATION
    var productPriceTr = document.querySelector(".product-priceTr");
    var pricePercentTr = document.querySelector(".product-price-percentTr")
    var sideBarTotalPrice = document.querySelector(".payment-total-price");
    
    
    
    productPriceTr.addEventListener("input", (e) => {
        e.preventDefault();
    
        // Input deyeri
        var inputValue = parseFloat(e.target.value);
        console.log(inputValue)
    
        if (isNaN(inputValue)) {
            inputValue = 0;
        }
    
        var values = inputValue;
        var percentPrice = (values * 5) / 100;
        var lastTotalTryPrice = values + percentPrice;
        console.log(lastTotalTryPrice)
    
        
        pricePercentTr.value = lastTotalTryPrice
        sideBarTotalPrice.innerHTML = lastTotalTryPrice + " TRY";
    });
    
    // AMERIKA PRICE PERCENT CALCULATION
    var productPriceUsd = document.querySelector(".product-price-usd");
    var pricePercentUsd = document.querySelector(".price-percent-usd")
    var sideBarTotalPrice = document.querySelector(".payment-total-price");
    
    productPriceUsd.addEventListener("input", (e) => {
        e.preventDefault();
    
        // Input deyeri
        var inputValue = parseFloat(e.target.value);
        console.log(inputValue)
    
        if (isNaN(inputValue)) {
            inputValue = 0;
        }
    
        var values = inputValue;
        var percentPrice = (values * 7) / 100;
        var lastTotalTryPrice = values + percentPrice;
        console.log(lastTotalTryPrice)
    
        
        pricePercentUsd.value = lastTotalTryPrice
        sideBarTotalPrice.innerHTML = lastTotalTryPrice + " USD";
    });



var tabs= document.querySelector(".nav-tabs")
var liElements = tabs.querySelectorAll("li");
var sideBarpayment = document.querySelector(".payment-group")
var payments = sideBarpayment.querySelectorAll(".check-custom-payment")
var sidebarUsd = document.querySelectorAll(".check-payment-usd");


var tabLink = document.querySelectorAll(".tabs-head")

tabLink.forEach((tag)=>{
    tag.addEventListener("click", (e)=>{
        e.preventDefault();
        var selectedTag = e.target.text
        if(selectedTag === "Amerika"){
            sidebarUsd.forEach((element) =>{
                element.classList.add('sideBarUsd')
            })
        }
        if(selectedTag === "Türkiyə"){
            sidebarUsd.forEach((element) =>{
                element.classList.remove('sideBarUsd')
            })

        }
        

    })
})


// console.log(birinciLi)
// console.log(ikincili)
// if(birinciLi.classList.contains("active")){
//     console.log("dogru")
// }
// if(ikincili.classList.contains("active")){
//     console.log("heszad ")

// }

// liElements.forEach(function(li){
//     if(li.classList.contains("active")){
//         console.log("dogru")
//     }
//     else{
//         console.log("Bi siqeet")
//     }
// })

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

// Tab-pane'ın içindeki formu submit etmek için 
document.addEventListener("DOMContentLoaded", function() {
    var tabPane = document.querySelector(".tab-pane.active form.form-ordercard");
    var submitButton = document.querySelector(".tab-pane.active .link-button");

    if (tabPane && submitButton) {
        submitButton.addEventListener("click", function() {
            tabPane.submit();
        });
    }
});
