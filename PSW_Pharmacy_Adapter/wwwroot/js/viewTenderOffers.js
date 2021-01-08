$(document).ready(function () {
    $.ajax({
        method: "GET",
        url: "../api/tenderoffer/" + window.location.search.slice(1),
        contentType: "application/json",
        success: function (data) {
            console.log(data);
            viewAllOffers(data)
        },
    });

})

function viewTender() {
    // preko id dobiti tender
}


function viewAllOffers(offers) {
    $("#viewTenderOffers").empty();

    for (let offer of offers) {
        var content = '<div class="card" style="width:350px; display:inline-block">';
        content += '<div class="card-body">';
        content += '<div class="data"> <h4 class="card-subtitle mb-2 text-muted">ID: '
        content += offer.id;
        content += '<br>' + offer.pharmacyName;
        content += '</h4>';
        content += '<h5><table style="margin:10px">';
        if (offer.medications != null) {
            content += '<h4>Offer:<h4>';

            for (let med of offer.medications) {
                content += '<tr><td float="right">';
                content += med.name + '</td><td>, &nbsp; amount: ' + med.amount + ';</td></tr>';
            }
            content += '<tr><td></td><td float="left">  = ' + offer.price +  ' €';
            content += '</td></tr>';
        }
        content += '</table></h5><hr color="#FFFF33"> <table>';
        content += '<tr style="color: gray"><td float="right" >Message:</td><td>';
        content += offer.message;
        content += '</td></tr>';
        content += '</table><br>';
        content += '<button class="btn btn-danger" data-toggle="modal" data-target="#deleteActionModal" ';
        content += ' onclick="deleteAction(' + offer.id + ')"> Decline </button > ';
        content += '<button class="btn btn-success" data-toggle="modal" data-target="#exampleModalCenter"';
        content += ' onclick="useAction(' + offer.id + ')"> Accept </button > ';
        content += '</div></div></div>';
        $("#viewTenderOffers").append(content);
    }
    
}

function deleteAction(id) {
	$("#deleteAction").show();
	$("button#btnYes1").click(function () {
		//ajax poziv za brisanje
	});
	
	
}
