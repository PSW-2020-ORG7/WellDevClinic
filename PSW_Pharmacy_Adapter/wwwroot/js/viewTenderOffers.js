var currTender;
var winner;
$(document).ready(function () {
    $.ajax({
        method: "GET",
        url: "../api/tender/" + window.location.search.slice(1),
        contentType: "application/json",
        success: function (data) {
            currTender = data;
            console.log(data);
            viewTender(data)
            $.ajax({
                method: "GET",
                url: "../api/tenderoffer/" + window.location.search.slice(1),
                contentType: "application/json",
                success: function (data) {
                    console.log(data);
                    if (data != null) {
                        viewAllOffers(data)
                    }
                },
            });
        },
    });
})

function viewTender(tender) {
    $("#viewTender").empty();
    var now = new Date().getTime()
    var endDate = new Date(currTender.period.endDate).getTime();

    var content = '<div class="card border-info mb-3" style="width:350px; position:relative; left:40%">';
    content += '<div class="card-body">';
    content += '<div class="data"> <h4 class="card-subtitle mb-2 text-muted">ID: '
    content += tender.id;
    content += '</h4>';
    content += '<h5><table style="margin:10px">';
    if (tender.medications != null) {
        content += '<h4>Hospital need:<h4>';

        for (let med of tender.medications) {
            content += '<tr><td float="right">';
            content += med.name + '</td><td>  x' + med.amount + '</td></tr>';
        }
    }
    content += '</table></h5>'
    var countDownDate = new Date(tender.period.endDate).getTime();
    content += '<p style="background-color:red;font-size:40px" id="timerTender"></p>';

    if (tender.offerWinner != null && endDate < now) {
        content += '<button id="btnDeal" class="btn btn-primary btn-lg expand" data-target="#expiredActionModal"';
        content += 'data-toggle="modal" onclick="sendEmail()"> Accept selected offer </button > ';
    } else if (endDate < now) {
        content += '<p style="font-size:20px">Choose tender winner!</p>';
    } 
    content += '</div></div></div>';
    $("#viewTender").append(content);


    var countdownfunction = setInterval(function () {
        var now = new Date().getTime();

        var distance = countDownDate - now;

        var days = Math.floor(distance / (1000 * 60 * 60 * 24));
        var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
        var seconds = Math.floor((distance % (1000 * 60)) / 1000);

        document.getElementById("timerTender").innerHTML = days + "d " + hours + "h "
            + minutes + "m " + seconds + "s ";

        if (distance < 0) {
            clearInterval(countdownfunction);
            document.getElementById("timerTender").innerHTML = "EXPIRED";
        }
    }, 1000);

}

function ISOtoShort(date) {
    let day = date.getDate();
    let month = (date.getMonth() + 1);
    let year = date.getFullYear();

    if (day < 10)
        day = '0' + day;
    if (month < 10)
        month = '0' + month;

    return String(day + '-' + month + '-' + year);
}


function viewAllOffers(offers) {
    $("#viewTenderOffers").empty();

    for (let offer of offers) {
        var content = '<div class="card" style="width:350px; display:inline-block ';

        if (currTender.offerWinner != null &&  offer.id == currTender.offerWinner)
        {
            winner = offer;
            content += '; border: 10px solid red';
        }
        content += '"><div class="card-body">';
        content += '<div class="data"> <h5 class="card-subtitle mb-2 text-muted">ID: '
        content += offer.id;
        content += '<br>' + offer.pharmacyName;
        content += '</h5>';
        content += '<h6><table style="margin:10px">';
        if (offer.medications != null) {
            content += '<h4>Offer:<h4>';

            for (let med of offer.medications) {
                content += '<tr><td float="right">';
                content += med.name + '</td><td>  x' + med.amount + '</td></tr>';
            }
            content += '<tr><td></td><td float="left">  = ' + offer.price +  ' €';
            content += '</td></tr>';
        }
        content += '</table></h6><hr color="#FFFF33"> <table>';
        content += '<tr style="color: gray"><td float="left">Message:</td><td float="left">';
        content += offer.message;
        content += '</td></tr>';
        content += '</table><br>';
        if (currTender.offerWinner != null && offer.id == currTender.offerWinner) {
            content += '<button class="btn btn-danger" data-toggle="modal" data-target="#deleteActionModal" ';
            content += ' onclick="deleteAction(' + offer.id + ')" disabled> Decline </button > ';
            content += '<button class="btn btn-success" ';
            content += ' onclick="useAction(' + offer.id + ')" disabled> Select </button > ';
        } else {
            content += '<button class="btn btn-danger" data-toggle="modal" data-target="#deleteActionModal" ';
            content += ' onclick="deleteAction(' + offer.id + ')"> Decline </button > ';
            content += '<button class="btn btn-success" ';
            content += ' onclick="useAction(' + offer.id + ')"> Select </button > ';
        }
        content += '</div></div></div>';
        $("#viewTenderOffers").append(content);
    }

    if (!winner)
        $("#btnDeal").prop("disabled", true);

}


function deleteAction(id) {
	$("#deleteAction").show();
	$("button#btnYes1").click(function () {
        $.ajax({
            method: "DELETE",
            url: "../api/tenderoffer/delete/" + id,
            contentType: "application/json",
            success: function (data) {
                if (data) {
                    window.location.reload();
                }
            },
        });

	});
}

function useAction(id) {
    $.ajax({
        method: "PUT",
        url: "../api/tender/winner/" + id,
        contentType: "application/json",
        success: function (data) {
            if (data) {
                $("#setWinnerActionModal").modal('toggle');
                $("#setWinnerAction").show();
                $("#btnOkOk").click(function () {
                    window.location.reload();
                });
            }
        },
    });
} 

function sendEmail() {
    var now = new Date().getTime()
    var endDate = new Date(currTender.endDate).getTime();
    if (endDate < now) {
        console.log("curr:" + endDate + "; " + now);
        if (currTender.offerWinner != null) {
            $("#expiredAction").show();
            $("#btnYesTender").click(function () {
                $.ajax({
                    method: "GET",
                    url: "../api/tender/email/" + currTender.offerWinner,
                    contentType: "application/json",
                    success: function (data) {
                        alert("Mail sent");
                        window.location.reload();
                    },
                });
                let order = [];

                for (let med of winner.medications) {
                    let item = {
                        "medicineName": med.name,
                        "amount": med.amount
                    }
                    order.push(item);
                }

                $.ajax({
                    method: "POST",
                    url: "../api/medication/orderMedicines?phName=" + winner.pharmacyName,
                    contentType: "application/json",
                    data: JSON.stringify(order),
                    success: function (data) {
                        if (data != null) {
                            let message = 'Order: ';
                            for (let d of data) {
                                message += d.amount + 'x' + d.name + ', ';
                            }

                            message += '. Expect your package soon!';
                            $("#message").text(message);
                            $("#pageInfoModal").modal('toggle');
                            $("#pageInfo").show();
                        }
                    },
                    error: function (e) {
                        alert("ERROR: " + e.status);
                    }
                });
            })
        }
    }
}

function myTimer() {
    alert("Lekovi su stigli");
}
