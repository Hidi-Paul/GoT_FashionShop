var serverAddr = "https://localhost:44300/"

var brands;
var categs;
var products

var brandCollapseBtn = document.getElementById("collapsibleBrands");
var categCollapseBtn = document.getElementById("collapsibleCategs");
var searchBar = document.getElementById("searchBar");

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
if (searchBar != null) {
    searchBar.addEventListener("keyup", function () {
        UpdateProducts();
    })
}
window.onload = function () {
    getBrands();
    getCategs();
    getProducts();
};

function readCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function getBrands() {
    var xhr = new XMLHttpRequest();
    xhr.open('GET', serverAddr + 'GetAllBrands');
    xhr.setRequestHeader('Access-Control-Allow-Headers', '*');
    xhr.setRequestHeader('Access-Control-Allow-Origin', '*');
    xhr.setRequestHeader("Authorization", 'Bearer ' + 'mOQMWWvVsC7LmXSsGIu3GcIcFOmqJxmG0m7YHqLAbOI88qBcarISEOWm_hMs37DytOcmo17spMedmQUswOwi_PnsJoct2lXXOud2f0bjPvS3iY3r4QoJ2oMIwyjci8WKyB2UPWP4a9jU3PcQp0XsD4GeQbqA6HPOL9oRDibc87fEuPGtg8qm7569z2AO_dgTFbQIloe4IP2EErYxha-mbPjdGVYULF-3YnwITiFMQeR7fwNW6J-Cdax7r0QgJdSKd66bCBRuT4uuLGHUPxC6tBzi8lMn6Z0Jlk0OE9X24T5sKvASIjOIAkU5nMa5BPnZr38RzTabTTp6sgi2i_UxzpfiwNiINMpluHZO6P2t339VDKtByDmCqCdnhHpJa7-RDOzGWDXe5s16T-wZ3EFueKNiPqcbCQUZQG5qhOVPMV2foP-dErcsI91z7RHfT9YfOtRtfPHRNDxyOgFXAMeu5lHKbMhNPIrIOxLDKpnIPD9vnDv0gNC3VpA1bmzU6bMExwlez3r_tL6RDSqaftyXXw' ); 
    
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
function getProducts() {
    var xhr = new XMLHttpRequest();
    xhr.open('GET', serverAddr + 'GetAllProducts');
    xhr.setRequestHeader('Access-Control-Allow-Headers', '*');
    xhr.setRequestHeader('Access-Control-Allow-Origin', '*');
    xhr.onload = function () {
        if (xhr.status === 200) {
            //console.log("prods:", xhr.response);
            products = JSON.parse(xhr.response);

            initProducts();
        }
        else {
            alert('Products Request failed.  Returned status of ' + xhr.status);
        }
    };
    xhr.send();
}
function getProductsFiltered(categoryFilters, brandFilters) {
    var xhr = new XMLHttpRequest();
    
    if (searchBar.textContent.length > 0) {
        var searchText = searchBar.textContent;
        xhr.open('GET', serverAddr + 'FilteredSearch'
            + "?" + searchText
            + "?" + JSON.stringify(categoryFilters)
            + "?" + JSON.stringify(brandFilters)
            + "?format=json");
    } else {
        xhr.open('GET', serverAddr + 'Filter'
            + "?" + JSON.stringify(categoryFilters)
            + "?" + JSON.stringify(brandFilters)
            + "?format=json");
    }
    
    xhr.setRequestHeader('Access-Control-Allow-Headers', '*');
    xhr.setRequestHeader('Access-Control-Allow-Origin', '*');
    xhr.onload = function () {
        if (xhr.status === 200) {
            //console.log("prods:", xhr.response);
            products = JSON.parse(xhr.response);

            initProducts();
        }
        else {
            alert('Filter Products Request failed.  Returned status of ' + xhr.status);
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
function initProducts() {
    var storeContent = document.getElementsByClassName("storeContent")[0];
    storeContent.innerText = "";

    for (var i = 0; i < products.length; i++) {

        var newCard = document.createElement("div");
        newCard.classList = "col-md-3 prodCard";
        var newCardContainer = document.createElement("div");
        newCardContainer.classList = "prodContainer";
        var newCardImage = document.createElement("img");
        var newCardContainerBody = document.createElement("div");
        newCardContainerBody.classList = "prodContainer-body";

        var newCardTitle = document.createElement("h4");
        var newCardBrand = document.createElement("p");
        newCardBrand.classList = "prodBrand";
        var newCardPrice = document.createElement("p");
        newCardPrice.classList = "prodPrice";

        var arr = ""+products[i].Image+"";
        var arr = decode_utf8(arr);
        console.log(arr.substring(0,40));

        newCardImage.src = "data:image/jpg;base64,"+arr;
        newCardTitle.innerText = products[i].ProductName;
        newCardBrand.innerText = products[i].Brand;
        newCardPrice.innerText = products[i].ProductPrice;


        newCard.appendChild(newCardContainer);
        newCardContainer.appendChild(newCardImage);


        newCardContainer.appendChild(newCardContainerBody);
        newCardContainerBody.appendChild(newCardTitle);
        newCardContainerBody.appendChild(newCardBrand);
        newCardContainerBody.appendChild(newCardPrice);

        storeContent.appendChild(newCard);
    }
};
function encode_utf8(s) {
    return unescape(encodeURIComponent(s));
}

function decode_utf8(s) {
    return decodeURIComponent(escape(s));
}

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
    getProductsFiltered(activeCategoryFilters, activeBrandFilters);
}
