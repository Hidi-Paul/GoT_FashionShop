var serverAddr = "https://localhost:44300/"

var brands;
var categs;

var brandCollapseBtn = document.getElementById("collapsibleBrands");
var categCollapseBtn = document.getElementById("collapsibleCategs");

if (brandCollapseBtn != null) {
    var trigger = brandCollapseBtn.querySelectorAll(".bigThingie")[0];
    var brandCollapsibles = brandCollapseBtn.querySelectorAll(".collapse")[0];

    trigger.addEventListener("click", function () {
        $(brandCollapsibles).collapse("toggle"); /*imi recunosc pacatele*/
    });
}
if (categCollapseBtn != null) {
    var trigger = categCollapseBtn.querySelectorAll(".bigThingie")[0];
    var categCollapsibles = categCollapseBtn.querySelectorAll(".collapse")[0];

    trigger.addEventListener("click", function () {
        $(categCollapsibles).collapse("toggle"); /*imi recunosc pacatele*/
    });
}

window.onload = function () {
    getBrands();
    getCategs();
};

function getBrands() {
    var xhr = new XMLHttpRequest();
    xhr.open('GET', serverAddr + 'GetAllBrands');
    xhr.setRequestHeader('Access-Control-Allow-Headers', '*');
    xhr.setRequestHeader('Access-Control-Allow-Origin', '*');
    xhr.onload = function () {
        if (xhr.status === 200) {
            //console.log("brands:", xhr.response);
            brands = JSON.parse(xhr.response);


            initBrands();
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
            //console.log("categs:", xhr.response);
            categs = JSON.parse(xhr.response);

            initCategs();
        }
        else {
            alert('Categories Request failed.  Returned status of ' + xhr.status);
        }
    };
    xhr.send();
}
function initBrands() {
    var colBrand = document.getElementById("collapsibleBrands");
    var Brandies = colBrand.getElementsByClassName("smallThingies");
    var listToBePopulated = Brandies[0];

    for (var i = 0; i < brands.length; i++) {
        var newNode = document.createElement("li")
        newNode.classList = "list-group-item";
        newNode.textContent = brands[i].Name;
        newNode.id = "BrandFilterNo" + i;
        newNode.objId = newNode.id;
        newNode.isTriggered = false;

        newNode.addEventListener("click", FilterToggle);

        listToBePopulated.appendChild(newNode);
    }
};

function initCategs() {
    var colCateg = document.getElementById("collapsibleCategs");
    var Categies = colCateg.getElementsByClassName("smallThingies");
    var listToBePopulated = Categies[0];

    for (var i = 0; i < categs.length; i++) {
        var newNode = document.createElement("li")
        newNode.classList = "list-group-item";
        newNode.textContent = categs[i].Name;
        newNode.id = "CategFilterNo" + i;
        newNode.objId = newNode.id;
        newNode.isTriggered = false;

        newNode.addEventListener("click", FilterToggle);

        listToBePopulated.appendChild(newNode);
    }
};

function FilterToggle(evt) {
    var filterObj = document.getElementById(evt.target.objId)

    if (filterObj.isTriggered) {
        filterObj.isTriggered = false;
        filterObj.style.backgroundColor = "white";
    } else {
        filterObj.isTriggered = true;
        filterObj.style.backgroundColor = "#b3daff";
    }

    UpdateProducts();
}
function UpdateProducts() {
    var activeBrandFilters = [];
    var activeCategoryFilters = [];

    var colBrand = document.getElementById("collapsibleBrands");
    var Brandies = colBrand.getElementsByClassName("smallThingies");
    var possibleFilters = Brandies[0].children;
    
    for (var i = 0; i < possibleFilters.length; i++) {
        if (possibleFilters[i].isTriggered) {
            activeBrandFilters.push(possibleFilters[i].innerText);
        }
    }

    var colCateg = document.getElementById("collapsibleCategs");
    var Categies = colCateg.getElementsByClassName("smallThingies");
    possibleFilters = Categies[0].children;

    for (var i = 0; i < possibleFilters.length; i++) {
        if (possibleFilters[i].isTriggered) {
            activeCategoryFilters.push(possibleFilters[i].innerText);
        }
    }


    console.log(activeBrandFilters);
    console.log(activeCategoryFilters);
}