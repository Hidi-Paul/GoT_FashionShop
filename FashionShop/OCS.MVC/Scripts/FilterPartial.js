var searchBar = document.getElementById("searchBar");
var brandCollapseBtn = document.getElementById("collapsibleBrands");
var categCollapseBtn = document.getElementById("collapsibleCategs");



//Make Brands button collapse options
function initBrandFilterBtn() {
    var trigger = brandCollapseBtn.querySelectorAll(".bigThingie")[0];
    var brandCollapsibles = brandCollapseBtn.querySelectorAll(".collapse")[0];

    trigger.addEventListener("click", function () {
        $(brandCollapsibles).collapse("toggle"); /*imi recunosc pacatele*/
    });
    //console.log("BrandFilterBtn initialized");
};
//Make Categories button collapse options
function initCategFilterBtn() {
    var trigger = categCollapseBtn.querySelectorAll(".bigThingie")[0];
    var categCollapsibles = categCollapseBtn.querySelectorAll(".collapse")[0];

    trigger.addEventListener("click", function () {
        $(categCollapsibles).collapse("toggle"); /*imi recunosc pacatele*/
    });
    //console.log("CategFilterBtn initialized");
};
//Search Bar keyup triggers search
function initSearchBar() {
    searchBar.addEventListener("keyup", function () {
        RefreshProducts();
    })
    //console.log("SearchBar initialized");
};

//Makes Brands and Categories selectable and activates filtering mechanix
function initFilters() {
    //Brands
    var options = brandCollapseBtn.getElementsByClassName("smallThingies")[0].children;
    for (var i = 0; i < options.length; i++) {
        options[i].isTriggered = false;
        options[i].addEventListener("click", FilterToggle);
    }
    //Categories
    options = categCollapseBtn.getElementsByClassName("smallThingies")[0].children;
    for (i = 0; i < options.length; i++) {
        options[i].isTriggered = false;
        options[i].addEventListener("click", FilterToggle);
    }
    //console.log("Filters initialized");
};
function FilterToggle(evt) {
    var filterObj = evt.target;
    if (filterObj.isTriggered) {
        filterObj.isTriggered = false;
        filterObj.style.backgroundColor = "white";
    } else {
        filterObj.isTriggered = true;
        filterObj.style.backgroundColor = "#b3daff";
    }
    //console.log("FilterToggle Event Procced");
    RefreshProducts();
};
function RefreshProducts() {
    console.log("Refresh called");
    var BrandFilters = [];
    var CategoryFilters = [];

    var options = categCollapseBtn.getElementsByClassName("smallThingies")[0].children;
    for (var i = 0; i < options.length; i++) {
        if (options[i].isTriggered) {
            BrandFilters.push(options[i].innerHTML);
            //console.log(options[i].innerHTML);
        }
    }
    options = brandCollapseBtn.getElementsByClassName("smallThingies")[0].children;
    for (i = 0; i < options.length; i++) {
        if (options[i].isTriggered) {
            CategoryFilters.push(options[i].innerHTML);
            //console.log(options[i].innerHTML);
        }
    }
    console.log("Searching \"" + searchBar.textContent + "\"");
    console.log("Brands: ", BrandFilters);
    console.log("Categories: ", CategoryFilters);
};

//This one initializes everything related to the filters
function initFilterBar() {
    initSearchBar();
    initCategFilterBtn();
    initBrandFilterBtn();

    initFilters();
};
initFilterBar();