var button = document.getElementById("ASD")
button.addEventListener("click", myFunc);

var serverAddr ="https://localhost:44300/"

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
    getBrands();
    getCategs();
};

function getBrands() {
    var xhr = new XMLHttpRequest();
    xhr.open('GET', serverAddr+'GetAllBrands');
    xhr.setRequestHeader('Access-Control-Allow-Headers', '*');
    xhr.setRequestHeader('Access-Control-Allow-Origin', '*');
    xhr.onload = function () {
        if (xhr.status === 200) {
            console.log("brands:", xhr.response);
            initBrands(xhr.response);
        }
        else {
            alert('Brand Request failed.  Returned status of ' + xhr.status);
        }
    };
    xhr.send();
}
function getCategs() {
    var xhr = new XMLHttpRequest();
    xhr.open('GET', serverAddr + 'GetAllCategories');
    xhr.setRequestHeader('Access-Control-Allow-Headers', '*');
    xhr.setRequestHeader('Access-Control-Allow-Origin', '*');
    xhr.onload = function () {
        if (xhr.status === 200) {
            console.log("categs:", xhr.response);
            initCategs(xhr.response);
        }
        else {
            alert('Categories Request failed.  Returned status of ' + xhr.status);
        }
    };
    xhr.send();
}
function initBrands(brands) {
    var colBrand = document.getElementById("collapsibleBrands");
    var Brandies = colBrand.getElementsByClassName("smallThingies");

    console.log("Brandies", Brandies);
}
function initCategs(categs) {
    var colCateg = document.getElementById("collapsibleCategs");
    var Categies = colCateg.getElementsByClassName("smallThingies");

    console.log("Categies", Categies);
}