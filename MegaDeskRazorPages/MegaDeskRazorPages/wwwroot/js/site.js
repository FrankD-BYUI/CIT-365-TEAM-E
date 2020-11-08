// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

function setMaterialImage() {
    var img = document.getElementById("materialImage");
    img.src = "../images/" + this.value +".jpg";
    return false;
}
document.getElementById("desktopMaterial").onchange = setMaterialImage;
