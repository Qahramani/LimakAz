var tarifItem = document.querySelectorAll(".tarif-item");

  tarifItem.forEach(aTag=>{
    aTag.addEventListener("click", (e)=>{
      e.preventDefault();
      aTag.classList.add("clicked");
        
        // Diğer öğelerden "clicked" sınıfını kaldırın
        tarifItem.forEach(otherTag => {
            if (otherTag !== aTag) {
                otherTag.classList.remove("clicked");
            }
        });
    })
  })