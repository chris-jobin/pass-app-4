function SetResize(dotnethelper) {
    window.addEventListener("resize", () => {
        UpdateItemsPerPage(dotnethelper);
    })
}

function UpdateItemsPerPage(dotnethelper) {
    var viewHeight = window.innerHeight;
    if (viewHeight >= 360) {
        var table = document.querySelector("table");
        var rows = table.querySelectorAll("tr");
        var rowHeight = rows[0].offsetHeight;
        var itemsPerPage = Math.floor(viewHeight / rowHeight) - 6;
        dotnethelper.invokeMethodAsync("UpdateItemsPerPage", itemsPerPage);
    }
}