function calculateDate() {
    var x = new Date(document.getElementById("startTime").value);
    var y = new Date(document.getElementById("endTime").value);
    var price = document.getElementById("pricePerDay").innerText;
    var Difference_In_Time = y.getTime() - x.getTime();
    var Difference_In_Days = Math.trunc(Difference_In_Time / (1000 * 3600 * 24));
    var actualPrice = price * Difference_In_Days;
    if (!Number.isNaN(actualPrice)) {
        if (actualPrice <= 0) {
            var ele = document.getElementsByClassName("stripe-button-el")[0];
            ele.style.display = "none";
            alert('Ending date can not be less or eqauls to starting date');

        } else {
            var ele = document.getElementsByClassName("stripe-button-el")[0];
            ele.style.display = "block";
            document.getElementById("actualAmount").innerHTML = actualPrice + " for " + Difference_In_Days + " Days";
        }
    }
}