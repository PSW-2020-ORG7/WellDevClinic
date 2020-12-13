$(document).ready(function () {
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

