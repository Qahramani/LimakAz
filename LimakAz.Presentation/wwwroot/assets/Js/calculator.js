var region = document.querySelector(".select-region");
var weight = document.querySelector(".weight");
var count = document.querySelector(".input-count");
var total = document.querySelector(".all-count");
var calcBtn = document.querySelector(".form-calc-btn");
var tariffData = document.getElementById("tariff-data-turkey");
var aznPrice = parseFloat(tariffData.getAttribute("data-azn-price"));
var usdPrice = parseFloat(tariffData.getAttribute("data-usd-price"));
var onekgAznPrice = parseFloat(tariffData.getAttribute("data-onekg-azn-price"));
var onekgUsdPrice = parseFloat(tariffData.getAttribute("data-onekg-usd-price"));

// Amerika Tarif
var tarifbirAzn = 4.17;
var tarifbirUsd = 2.45;
var tarifikiAzn  = 6.71;
var tarifikiUsd = 3.95;
var tarifucAzn = 10.12;
var tarifucUsd = 5.95;
var tarifdordAzn = 11.81
var tarifdordUsd = 6.95;
var tarifbesAzn = 13.52;
var tarifbesUsd = 7.95;
var bironkgAzn = 13.52;
var bironkgUsd = 7.95;
var onkgyuxAzn = 12.24;
var onkgyuxUsd = 7.20;
 




calcBtn.addEventListener("click", (e)=> {
    e.preventDefault();
    let kg  = parseFloat(weight.value)
    let totalCount = count.value || 1
    let selectedRegion = region.value;
      
    //Turkey Custom Cost(Weight)
    if(kg >= 0 && kg <= 0.100 && selectedRegion == 1){
        let totalAzn = (aznPrice*totalCount);
        let totalUsd = (usdPrice*totalCount).toFixed(2)
        total.innerHTML = `AZN ${totalAzn}0 | $ ${totalUsd}`
    }
    if(kg >= 0.101 && kg <= 0.250 && selectedRegion == 1){
        let totalAzn = (2*(aznPrice*totalCount));
        let totalUsd = (2*(usdPrice*totalCount)).toFixed(2)
        total.innerHTML = `AZN ${totalAzn}0 | $ ${totalUsd}`
    }
    if(kg >= 0.251 && kg <= 0.500 && selectedRegion == 1){
        let totalAzn = (3*(aznPrice*totalCount));
        let totalUsd = (3*(usdPrice*totalCount)).toFixed(2)
        total.innerHTML = `AZN ${totalAzn}0 | $ ${totalUsd}`
    }
    if(kg >= 0.501 && kg <= 0.700 && selectedRegion == 1){
        let totalAzn = (4*(aznPrice*totalCount));
        let totalUsd = (4*(usdPrice*totalCount)).toFixed(2)
        total.innerHTML = `AZN ${totalAzn}0 | $ ${totalUsd}`
    }
    if(kg >= 0.701 && kg >= 1 && selectedRegion == 1){
        if(kg == 1){
            let totalAzn = (onekgAznPrice*totalCount);
            let totalUsd = (onekgUsdPrice*totalCount).toFixed(2)
            total.innerHTML = `AZN ${totalAzn} | $ ${totalUsd}`
        }
        if(kg > 1 && totalCount === 1 ){
            let aznhesab = hesapla(kg,onekgAznPrice)
            let usdhesab = hesapla(kg,onekgUsdPrice)
            console.log(aznhesab)
            total.innerHTML = `AZN ${aznhesab} | $ ${usdhesab}`

        }
        if(kg > 1  ){
            let aznhesab = totalCount*(hesapla(kg,onekgAznPrice))
            let usdhesab = totalCount*(hesaplaUsd(kg,onekgUsdPrice))
            console.log(aznhesab)
            total.innerHTML = `AZN ${aznhesab} | $ ${usdhesab}`

        }
    }

    // America Custom Cost(Weight)

    if(kg >= 0 && kg <= 0.100 && selectedRegion == 2){
        let totalAzn = (tarifbirAzn*totalCount).toFixed(2);
        let totalUsd = (tarifbirUsd*totalCount).toFixed(2)
        total.innerHTML = `AZN ${totalAzn} | $ ${totalUsd}`
    }
    if(kg >= 0.101 && kg <= 0.250 && selectedRegion == 2){
        let totalAzn = (tarifikiAzn*totalCount).toFixed(2);
        let totalUsd = (tarifikiUsd*totalCount).toFixed(2)
        total.innerHTML = `AZN ${totalAzn} | $ ${totalUsd}`
    }
    if(kg >= 0.251 && kg <= 0.500 && selectedRegion == 2){
        let totalAzn = (tarifucAzn*totalCount).toFixed(2);
        let totalUsd = (tarifucUsd*totalCount).toFixed(2)
        total.innerHTML = `AZN ${totalAzn} | $ ${totalUsd}`
    }
    if(kg >= 0.501 && kg <= 0.700 && selectedRegion == 2){
        let totalAzn = (tarifdordAzn*totalCount).toFixed(2);
        let totalUsd = (tarifdordUsd*totalCount).toFixed(2)
        total.innerHTML = `AZN ${totalAzn} | $ ${totalUsd}`
    }
    if(kg >= 0.701 && kg >= 1 && kg <=10 && selectedRegion == 2){
        if(kg == 1){
            let totalAzn = (tarifbesAzn*totalCount).toFixed(2);
            let totalUsd = (tarifbesUsd*totalCount).toFixed(2)
            total.innerHTML = `AZN ${totalAzn} | $ ${totalUsd}`
        }
        if(kg > 1 && kg <= 10){
            let aznamericahesab = hesaplabirkgAmerica(kg,tarifbesAzn)
            let usdhesab = hesaplabirkgAmercUsd(kg,tarifbesUsd);
            console.log(aznamericahesab)
            total.innerHTML = `AZN ${aznamericahesab} | $ ${usdhesab}`

        }
        if(kg > 1 && kg <= 10 && totalCount > 1){
            let aznhesab = totalCount*(hesaplabirkgAmerica(kg,bironkgAzn))
            let usdhesab = totalCount*(hesaplabirkgAmercUsd(kg,bironkgAzn))
            console.log(aznhesab)
            total.innerHTML = `AZN ${aznhesab} | $ ${usdhesab}`
        }
        if(kg >= 10){
            let aznhesab = hesablaAmercAzn(kg,onekgAznPrice)
            let usdhesab = hesablaAmercUsd(kg,onekgUsdPrice)
            total.innerHTML = `AZN ${aznhesab} | $ ${usdhesab}`
        }

        
    }


})

function hesapla(kg, kgAznPrice) {
    for (let i = 1; i <= kg; i++) {
        if (i !== 1) {
            kgAznPrice += onekgAznPrice; // Her kilo için fiyatı önceki fiyatın iki katı yap
        }
    }
    return kgAznPrice.toFixed(2);
}

function hesaplaUsd(kg, kgUsdPrice) {
    for (let i = 1; i <= kg; i++) {
        if (i !== 1) {
            kgUsdPrice += onekgUsdPrice; // Her kilo için fiyatı önceki fiyatın iki katı yap
        }
    }
    return kgUsdPrice.toFixed(2);
}
function hesaplabirkgAmerica(kg, kgAznPrice) {
    for (let i = 1; i <= kg; i++) {
        if (i !== 1) {
            kgAznPrice += bironkgAzn; // Her kilo için fiyatı önceki fiyatın iki katı yap
        }
    }
    return kgAznPrice.toFixed(2);
}

function hesaplabirkgAmercUsd(kg, kgUsdPrice) {
    for (let i = 1; i <= kg; i++) {
        if (i !== 1) {
            kgUsdPrice += bironkgUsd; // Her kilo için fiyatı önceki fiyatın iki katı yap
        }
    }
    return kgUsdPrice.toFixed(2);
}

function hesablaAmercAzn(kg, kgAznPriceAmerc){
    for (let i = 10; i <= kg; i++) {
        if (i !== 10) {
            kgAznPriceAmerc += onkgyuxAzn; // Her kilo için fiyatı önceki fiyatın iki katı yap
        }
    }
    return kgAznPriceAmerc.toFixed(2);
}
function hesablaAmercUsd(kg, kgUsdPriceAmerc){
    for (let i = 10; i <= kg; i++) {
        if (i !== 10) {
            kgUsdPriceAmerc += onkgyuxUsd; // Her kilo için fiyatı önceki fiyatın iki katı yap
        }
    }
    return kgUsdPriceAmerc.toFixed(2);
}



// fetch('https://api.currencyapi.com/v3/latest?apikey=cur_live_ZKCy2YaxiNRZ2barsizYajkUr9n4enQC5Cn6Fc3M')
//   .then(response => {
//     if (!response.ok) {
//       throw new Error('Network response was not ok');
//     }
//     return response.json(); // JSON verisini JavaScript nesnesine dönüştür
//   })
//   .then(data => {
//     // Alınan JSON verisinden "rates" alanındaki "EUR" değerini al
//     const usdRateCode = data.data.USD.code;
//     const usdRateValue = data.data.USD.value;

//     const aznRateCode = data.data.AZN.code;
//     const aznRateValue = data.data.AZN.value;
//     const tryRateCode = data.data.TRY.code;
//     const tryRateValue = data.data.TRY.value;


//     var inp = document.querySelector(".currency-input1")
//     var inp2 = document.querySelector(".currency-input2")
//     var currencyType = document.querySelector(".currency-type");
//     console.log(currencyType)
    
    
//     inp.addEventListener("input", (e)=>{
//         e.preventDefault();
//         var inpvalue = inp.value
//         var converterPrice = inpvalue*aznRateValue
//         inp2.value=converterPrice.toFixed(2)
//         console.log(converterPrice)
//     })


//   })
//   .catch(error => {
//     console.error('There was a problem with the fetch operation:', error);
//   });

// var XMLRequest = new XMLHttpRequest();

// XMLRequest.open('GET','https://www.cbar.az/currencies/08.02.2024.xml')

// XMLRequest.send()

// XMLRequest.onload = () =>{
//     if(XMLRequest.status === 200){
//         console.log("request succesfully")
//     }
//     else{
//         console.log("Dont work")
//     }

//     console.log(JSON.parse(XMLRequest.response))
// }


  var inp = document.querySelector(".currency-input1")
  var inp2 = document.querySelector(".currency-input2")
  var currencyType = document.querySelector(".currency-type");
//   console.log(currencyType.children[1].value)

 var resetBtn = document.querySelector(".calc-resetBtn");
 var calcForm = document.querySelector(".form-calc");
 

 resetBtn.addEventListener("click", (e)=>{
    e.preventDefault();
    calcForm.reset();
    total.innerHTML = "AZN 0.00 | $0.00"
     })

