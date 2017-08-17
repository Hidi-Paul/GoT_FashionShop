var button = document.getElementById("ASD")
button.addEventListener("click", myFunc);

function myFunc() {

    var xhr = new XMLHttpRequest();
    xhr.open('GET', 'https://localhost:44300/GetAllProducts');
    xhr.setRequestHeader('Access-Control-Allow-Headers', '*');
    xhr.setRequestHeader('Access-Control-Allow-Origin', '*');
    xhr.onload = function () {
        if (xhr.status === 200) {
            alert("DONE");
        }
        else {
            alert('Request failed.  Returned status of ' + xhr.status);
        }
    };
    alert("HEY")
    xhr.send();
}

window.onload = function () {
    loadCategories();
};

function loadCategories() {
    var colBrand = document.getElementById("collapsibleBrands");
    var colCateg = document.getElementById("collapsibleCategs");

    var Brandies = colBrand.getElementsByClassName("smallThingies");
    var Categies = colCateg.getElementsByClassName("smallThingies");

    console.log("Brandies", Brandies)
    console.log("Categies", Categies)



    console.log("Left Bar initialized");
};