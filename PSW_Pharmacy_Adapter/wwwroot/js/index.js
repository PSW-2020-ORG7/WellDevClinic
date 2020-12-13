$(document).ready(function () {
    $("#testDugme").click(function () {
        $.ajax({
            method: "GET",
            url: "../api/medication",
            contentType: "application/json",
            //datatype: "application/json",
            success: function (data) {          
                alert(data[0].id);
            },
        });
    })

    $("#testDugmeRecepti").click(function () {
        $.ajax({
            method: "GET",
            url: "../api/prescription",
            contentType: "application/json",
            //dataType: "application/json",
            success: function (data) {
                alert(data[0].id);
            },
        });
    })

    $("#testDugmeSlanje").click(function () {
        $.post({
            url: "../api/sftp/sendReport",
            contentType: "aplication/json",
            data: JSON.stringify({ path : "..\\..\\..\\..\\PSW_Pharmacy_Adapter\\wwwroot\\index.html"}),

            success: function (data) {
               alert("usao");
               location.href = "../index.html";
            },
            error: function (message) {
                alert("Nije usao")
            }
        });
    })

    
    
});

