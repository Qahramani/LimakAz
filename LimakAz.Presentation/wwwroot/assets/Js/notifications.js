var refreshBtn = document.querySelector(".btn-refresh")

refreshBtn.addEventListener("click", (e)=>{
    e.preventDefault();
    location.reload();
})