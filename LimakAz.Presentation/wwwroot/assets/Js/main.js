$('.imgCarousel').slick({
    slidesToShow: 1,
    slidesToScroll: 1,
    autoplay: true,
    arrows: true,
    dots: true,
    autoplaySpeed: 2000,
    responsive: [
        {
          breakpoint: 1024,
          settings: {
            slidesToShow: 3,
            slidesToScroll: 3,
            infinite: true,
            dots: true
          }
        },
        {
          breakpoint: 600,
          settings: {
            slidesToShow: 2,
            slidesToScroll: 2
          }
        },
        {
          breakpoint: 480,
          settings: {
            slidesToShow: 1,
            slidesToScroll: 1
          }
        }
        // You can unslick at a given breakpoint now by adding:
        // settings: "unslick"
        // instead of a settings object
      ]
  });
  
  //Sertification section slider
$('.sertf-body').slick({
  slidesToShow: 4,
  slidesToScroll: 1,
  arrows:false,
  autoplay: true,
  autoplaySpeed: 4000,
  responsive:[
    {
      breakpoint: 480,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1
      }
    }
  ]
});
			

  var tarifcards = document.querySelector(".tarif-card");

  var tarifItem = document.querySelectorAll(".tarif-item");
  var tarifItemZabrat = document.querySelector(".tarif-item-zabrat");

  tarifItem.forEach(aTag=>{
    aTag.addEventListener("click", (e)=>{
      e.preventDefault();
      aTag.classList.add("clicked");
      console.log("salam")
        
        // Diğer öğelerden "clicked" sınıfını kaldırın
        tarifItem.forEach(otherTag => {
            if (otherTag !== aTag) {
                otherTag.classList.remove("clicked");
            }
        });
    })
  })