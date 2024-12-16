var refreshBtn = document.querySelector(".btn-refresh")

refreshBtn.addEventListener("click", (e)=>{
    e.preventDefault();
    location.reload();
})

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
