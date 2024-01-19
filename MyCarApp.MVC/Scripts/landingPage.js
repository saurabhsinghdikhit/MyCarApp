$(document).ready(function () {
    $('#container1').hide();
    $('#Renting').hide();
    $('#RentingSubscribe').hide();
    $('#RentingRent').hide();
    $('#containerNewCar').hide();
    $('#containerNewCarByBudget').hide();
    $('#containerNewCarByModel').hide();
    $('#containerOldCar').hide();
    $('#containerOldCarLocation').hide();
    $('#containerOldCarByBudget').hide();
    $('#containerOldCarByModel').hide();
    $('#containerOldCarSearch').hide();
    $('#buyCar').click(function () {
        $('#containerBuyOrRent').hide("slide", {
            direction: "left"
        }, 200);
        $('#container1').show("slide", {
            direction: "right"
        }, 200);
    });
    $('#buyNewCar').click(function () {
        $('#container1').hide("slide", {
            direction: "left"
        }, 200);
        $('#containerNewCar').show("slide", {
            direction: "right"
        }, 200);
    });
    $('#buyNewCarByBudget').click(function () {
        $('#containerNewCar').hide("slide", {
            direction: "left"
        }, 200);
        $('#containerNewCarByBudget').show("slide", {
            direction: "right"
        }, 200);
    });
    $('#buyNewCarByModel').click(function () {
        $('#containerNewCar').hide("slide", {
            direction: "left"
        }, 200);
        $('#containerNewCarByModel').show("slide", {
            direction: "right"
        }, 200);
    });
    $('#buyOldCar').click(function () {
        $('#container1').hide("slide", {
            direction: "left"
        }, 200);
        $('#containerOldCar').show("slide", {
            direction: "right"
        }, 200);
    });
    $('#buyOldCarByLocation').click(function () {
        $('#containerOldCar').hide("slide", {
            direction: "left"
        }, 200);
        $('#containerOldCarLocation').show("slide", {
            direction: "right"
        }, 200);
    });
    $('#buyOldCarBySearch').click(function () {
        $('#containerOldCar').hide("slide", {
            direction: "left"
        }, 200);
        $('#containerOldCarSearch').show("slide", {
            direction: "right"
        }, 200);
    });
    $('#buyOldCarByBudget').click(function () {
        $('#containerOldCarSearch').hide("slide", {
            direction: "left"
        }, 200);
        $('#containerOldCarByBudget').show("slide", {
            direction: "right"
        }, 200);
    });
    $('#buyOldCarByModel').click(function () {
        $('#containerOldCarSearch').hide("slide", {
            direction: "left"
        }, 200);
        $('#containerOldCarByModel').show("slide", {
            direction: "right"
        }, 200);
    });
    $('#rentCar').click(function () {
        $('#containerBuyOrRent').hide("slide", {
            direction: "left"
        }, 200);
        $('#Renting').show("slide", {
            direction: "right"
        }, 200);
    });
    $('#RentingrentCar').click(function () {
        $('#Renting').hide("slide", {
            direction: "left"
        }, 200);
        $('#RentingRent').show("slide", {
            direction: "right"
        }, 200);
    });
    $('#subscribeCar').click(function () {
        $('#Renting').hide("slide", {
            direction: "left"
        }, 200);
        $('#RentingSubscribe').show("slide", {
            direction: "right"
        }, 200);
    });

});