$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/AdminScreen/Cars/GetCountries",
        data: "{}",
        success: function (data) {
            var s = '';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].CountryId + '">' + data[i].CountryName + '</option>';
            }
            $("#countryDropdown").html(s);
        }
    });
    $.ajax({
        type: "GET",
        url: "/AdminScreen/Cars/GetStates?CountryId=bb300cee-8c5f-4a52-b5ba-304f094f9e15",
        data: "{}",
        success: function (data) {
            var s = '';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].StateId + '">' + data[i].StateName + '</option>';
            }
            $("#stateDropdown").html(s);
        }
    });
    $.ajax({
        type: "GET",
        url: "/AdminScreen/Cars/GetCities?StateId=35b70a61-714a-449d-a520-2678b88296db",
        data: "{}",
        success: function (data) {
            var s = '';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].CityId + '">' + data[i].CityName + '</option>';
            }
            $("#CityDropdown").html(s);
        }
    });
    $.ajax({
        type: "GET",
        url: "/AdminScreen/Cars/GetPincodes?CityId=02a68be8-fb5b-4dc7-8fa2-9ae9b9c92560",
        data: "{}",
        success: function (data) {
            var s = '';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].PincodeId + '">' + data[i].Pincode1 + '</option>';
            }
            $("#PincodeDropdown").html(s);
        }
    });
});
$('#countryDropdown').on('change', function () {
    var countryId = $(this).val();

    $.ajax({
        type: "GET",
        url: "/AdminScreen/Cars/GetStates?CountryId=" + countryId,
        data: "{}",
        success: function (data) {
            var s = '';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].StateId + '">' + data[i].StateName + '</option>';
            }
            $("#stateDropdown").html(s);
        }
    });
});
$('#stateDropdown').on('change', function () {
    var stateId = $(this).val();

    $.ajax({
        type: "GET",
        url: "/AdminScreen/Cars/GetCities?StateId=" + stateId,
        data: "{}",
        success: function (data) {
            var s = '';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].CityId + '">' + data[i].CityName + '</option>';
            }
            $("#cityDropdown").html(s);
        }
    });
});
$('#cityDropdown').on('change', function () {
    var cityId = $(this).val();

    $.ajax({
        type: "GET",
        url: "/AdminScreen/Cars/GetPincodes?CityId=" + cityId,
        data: "{}",
        success: function (data) {
            var s = '';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].PincodeId + '">' + data[i].Pincode1 + '</option>';
            }
            $("#PincodeDropdown").html(s);
        }
    });
});