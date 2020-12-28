$(document).ready(function () {
    $("#btnAddOffer").click(function () {
        let name = $("#txtPharmacy").val();
        let price = $("#txtPrice").val();
        let id = $("#txtId").val();
        let message = $("#txtMessage").val();

        let valid = true;

        if (!name) {
            valid = false;
            $("#txtPharmacy").css("border-width", "1");
            $("#invalidName").css("display", "block");
        } else {
            $("#txtPharmacy").css("border-width", "0");
            $("#invalidName").css("display", "none");
        }
        if (!price) {
            valid = false;
            $("#txtPrice").css("border-width", "1");
            $("#invalidPrice").css("display", "block");
        } else {
            $("#txtPrice").css("border-width", "0");
            $("#invalidPrice").css("display", "none");
        }

        if (valid) {
            var jsonApi = JSON.stringify({
                PharmacyName : name,
                Price : Number(price),
                Id : Number(id),
                Medications: [],
                Message: message
            });
        }


        $.ajax({
            method: "POST",
            url: "../api/tenderoffer/add",
            contentType: "application/json",
            data: jsonApi,
            success: function (data) {
                if (data) {
                    $('#message').html('Succesfully added to database.');
                    $("#regAction").show();
                }
                //alert("Uspeo sam");
                //console.log(data);
            },
            error: function (e) {
                $("#message").empty();
                $('#message').html('Already exists.');
                $("#regAction").show();
            }
        })
    })
})