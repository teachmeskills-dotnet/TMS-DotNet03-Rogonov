function addTheme() {
    document.getElementById("add-theme-modal").classList.toggle("show");
}

function closeForm() {
    document.getElementById("add-theme-modal").classList.toggle("show");
}
//window.onclick = function (event) {
//    if (!event.target.matches('.add-new-theme-btn')) {
//        var dropdowns = document.getElementsByClassName("add-theme-modal");
//        var i;
//        for (i = 0; i < dropdowns.length; i++) {
//            var openDropdown = dropdowns[i];
//            if (openDropdown.classList.contains('show')) {
//                openDropdown.classList.remove('show');
//            }
//        }
//    }
//}