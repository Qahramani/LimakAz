var tabList = document.querySelectorAll(".nav-tabs-head-list");
var tabPaneList = document.querySelectorAll(".tab-pane");

tabList.forEach(function (tab) {
    tab.addEventListener("click", (e) => {
        e.preventDefault();
        var clickedTab = e.target.parentElement;

        if (clickedTab.tagName === "UL") {
            return;
        }

        tabList.forEach(function (tab) {
            if (tab !== clickedTab && tab.classList.contains("nav-tabs-active")) {
                tab.classList.remove("nav-tabs-active");
            }
        });
        clickedTab.classList.add("nav-tabs-active");

        var tabPaneId = clickedTab.children[0].getAttribute("href").substr(1);
        console.log(tabPaneId)
        tabPaneList.forEach(function (pane) {
            if (pane.id === tabPaneId) {
                pane.classList.add("active");
            } else {
                pane.classList.remove("active");
            }
        });
    });
});
