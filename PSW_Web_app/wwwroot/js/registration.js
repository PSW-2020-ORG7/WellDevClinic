
$(document).ready(function () {

    let form = $("#registrationForm");
    form.submit(function (event) {

        event.preventDefault();

        $(".warning").remove();
        var divs = document.getElementsByClassName("form-group");
        console.log(divs);


        let name = $("#nameInput"); //document.getElementById('nameInput'); 
        let middleName = $("#middleNameInput"); //document.getElementById('middleNameInput');
        let surname = $("#surnameInput"); //document.getElementById('surnameInput');
        let country = $("#patientCountry"); //document.getElementById('patientCountry');
        let city = $("#patientCity"); //document.getElementById('patientCity');
        let address = $("#patientAddress"); //document.getElementById('patientAddress');
        let jmbg = $("#patientID"); //document.getElementById('patientID');
        let dateOfBirth = $("#patientDateOfBirth"); //document.getElementById('patientDateOfBirth');
        let email = $("#patientEmail"); //document.getElementById('patientEmail');
        let emailConfirm = $("#patientEmailConfirm"); //document.getElementById('patientEmailConfirm');
        let phone = $("#patientPhone"); //document.getElementById('patientPhone');
        let username = $("#patientUsername"); //document.getElementById('patientUsername');
        let password = $("#patientPassword"); //document.getElementById('patientPassword');
        let passwordConfirm = $("#patientPasswordConfirm"); //document.getElementById('patientPasswordConfirm')
        let img = $("#patientImg"); //document.getElementById('patientImg');


        var genderVal;
        var gender = document.getElementsByName("rdbPatientGender");
        for(i = 0; i < gender.length; i++) { 
            if(gender[i].checked) 
             genderVal = gender[i].value;
        } 

        var raceVal;
        var race = document.getElementsByName("rdbPatientRace");
        for( i = 0; i < race.length; i++){
            if(race[i].checked){
                raceVal = race[i].value;
            }
        }

        var bloodVal;
        var bloodType = document.getElementsByName("rdbPatientBType");
        for (i=0; i<bloodType.length; i++){
            if(bloodType[i].checked){
                bloodVal = bloodType[i].value;
            }
        }


        document.getElementById("nameInput").style.borderColor = "black";          // ako neko polje nije popunjeno pa se kasnije popuni da ne ostane oznaceno
        document.getElementById("middleNameInput").style.borderColor = "black";
        document.getElementById("surnameInput").style.borderColor = "black";
        document.getElementById("patientCity").style.borderColor = "black";
        document.getElementById("patientAddress").style.borderColor = "black";
        document.getElementById("patientEmail").style.borderColor = "black";
        document.getElementById("patientEmailConfirm").style.borderColor = "black";
        document.getElementById("patientPhone").style.borderColor = "black";
        document.getElementById("patientUsername").style.borderColor = "black";
        document.getElementById("patientPassword").style.borderColor = "black";
        document.getElementById("patientPasswordConfirm").style.borderColor = "black";
        document.getElementById("patientDateOfBirth").style.borderColor = "black";
        document.getElementById("patientImg").style.borderColor = "black";

        var nameBool = true;
        var middleBool = true;
        var surnameBool = true;
        var countryBool = true;
        var cityBool = true;
        var addressBool = true;
        var jmbgBool = true;
        var dateOfBirthBool = true;
        var emailBool = true;
        var email2Bool = true;
        var emailConfBool = true;
        var phoneBool = true;
        var usernameBool = true;
        var passwordBool = true;
        var password2Bool = true;
        var passwordConfBool = true;
        var imageBool = true;
        var DateBool = true;

        var date = new Date($('#patientDateOfBirth').val());

        console.log(document.getElementById('patientImg').files[0])
        var imageToLoad = document.getElementById('patientImg')
        console.log(imageToLoad);

        var nameREGEX = /^$|[A-Z]{1}[a-z]+$/;
        var middleNameREGEX = /^$|[A-Z]{1}[a-z]+$/;
        var surnameREGEX = /^$|[A-Z]{1}[a-z]+$/;
        var cityREGEX = /^$|[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$/
        var addressREGEX = /^$|[a-zA-Z0-9\s,'-.]*$/
        var jmbgREGEX = /^$|[0-9]{13}$/
        var emailREGEX = /^$|[a-z0-9]+@[a-z]+.com$/
        var phoneREGEX = /^$|[0-9]+$/

        if (!name.val() || 0 === name.val().length) {
            document.getElementById("nameInput").style.borderColor = "red";
            var divName = divs[0];
            var divNameWarning = document.createElement("div");
            divNameWarning.setAttribute("class", "warning");
            divNameWarning.appendChild(document.createTextNode("Enter patient name"));
            divName.appendChild(divNameWarning);
            nameBool = false;
        }

        if (!nameREGEX.test(name.val())) {
            document.getElementById("nameInput").style.borderColor = "red";
            var divName = divs[0];
            var divNameWarning = document.createElement("div");
            divNameWarning.setAttribute("class", "warning");
            divNameWarning.appendChild(document.createTextNode("Enter correct characters"));
            divName.appendChild(divNameWarning);
            nameBool = false;
        }

        if (!middleName.val() || 0 === middleName.val().length) {
            document.getElementById("middleNameInput").style.borderColor = "red";
            var divMiddle = divs[1];
            var divMiddleWarning = document.createElement("div");
            divMiddleWarning.setAttribute("class", "warning");
            divMiddleWarning.appendChild(document.createTextNode("Enter patient middle name"));
            divMiddle.appendChild(divMiddleWarning);
            middleBool = false;
        }
        if (!middleNameREGEX.test(middleName.val())) {
            document.getElementById("middleNameInput").style.borderColor = "red";
            var divMiddle = divs[1];
            var divMiddleWarning = document.createElement("div");
            divMiddleWarning.setAttribute("class", "warning");
            divMiddleWarning.appendChild(document.createTextNode("Enter correct characters"));
            divMiddle.appendChild(divMiddleWarning);
            middleBool = false;
        }

        if (!surname.val() || 0 === surname.val().length) {
            document.getElementById("surnameInput").style.borderColor = "red";
            var divSurname = divs[2];
            var divSurnameWarning = document.createElement("div");
            divSurnameWarning.setAttribute("class", "warning");
            divSurnameWarning.appendChild(document.createTextNode("Enter patient surname"));
            divSurname.appendChild(divSurnameWarning);
            surnameBool = false;
        }
        if (!surnameREGEX.test(surname.val())) {
            console.log("USAO");
            document.getElementById("surnameInput").style.borderColor = "red";
            var divSurname = divs[2];
            var divSurnameWarning = document.createElement("div");
            divSurnameWarning.setAttribute("class", "warning");
            divSurnameWarning.appendChild(document.createTextNode("Enter correct characters"));
            divSurname.appendChild(divSurnameWarning);
            surnameBool = false;
        }

        if (!city.val() || 0 === city.val().length) {
            document.getElementById("patientCity").style.borderColor = "red";
            var divCity = divs[4];
            var divCityWarning = document.createElement("div");
            divCityWarning.setAttribute("class", "warning");
            divCityWarning.appendChild(document.createTextNode("Enter patient city"));
            divCity.appendChild(divCityWarning);
            cityBool = false;
        }
        if (!cityREGEX.test(city.val())) {
            document.getElementById("patientCity").style.borderColor = "red";
            var divCity = divs[4];
            var divCityWarning = document.createElement("div");
            divCityWarning.setAttribute("class", "warning");
            divCityWarning.appendChild(document.createTextNode("Enter correct characters"));
            divCity.appendChild(divCityWarning);
            cityBool = false;
        }

        if (!address.val() || 0 === address.val().length) {
            document.getElementById("patientAddress").style.borderColor = "red";
            var divAddress = divs[5];
            var divAddressWarning = document.createElement("div");
            divAddressWarning.setAttribute("class", "warning");
            divAddressWarning.appendChild(document.createTextNode("Enter patient address"));
            divAddress.appendChild(divAddressWarning);
            addressBool = false;
        }
        if (!addressREGEX.test(address.val())) {
            document.getElementById("patientAddress").style.borderColor = "red";
            var divAddress = divs[5];
            var divAddressWarning = document.createElement("div");
            divAddressWarning.setAttribute("class", "warning");
            divAddressWarning.appendChild(document.createTextNode("Enter correct characters"));
            divAddress.appendChild(divAddressWarning);
            addressBool = false;
        }

        if (!jmbg.val() || 0 === jmbg.val().length) {
            document.getElementById("patientID").style.borderColor = "red";
            var divJmbg = divs[6];
            var divJmbgWarning = document.createElement("div");
            divJmbgWarning.setAttribute("class", "warning");
            divJmbgWarning.appendChild(document.createTextNode("Enter patient ID"));
            divJmbg.appendChild(divJmbgWarning);
            jmbgBool = false;
        }

        if (!jmbgREGEX.test(jmbg.val())) {
            document.getElementById("patientID").style.borderColor = "red";
            var divJmbg = divs[6];
            var divJmbgWarning = document.createElement("div");
            divJmbgWarning.setAttribute("class", "warning");
            divJmbgWarning.appendChild(document.createTextNode("Enter 13 digits"));
            divJmbg.appendChild(divJmbgWarning);
            jmbgBool = false;
        }

        if (!email.val() || 0 === email.val().length) {
            document.getElementById("patientEmail").style.borderColor = "red";
            var divEmail = divs[10];
            var divEmailWarning = document.createElement("div");
            divEmailWarning.setAttribute("class", "warning");
            divEmailWarning.appendChild(document.createTextNode("Enter patient email"));
            divEmail.appendChild(divEmailWarning);
            emailBool = false;
        }
        if (!emailREGEX.test(email.val())) {
            document.getElementById("patientEmail").style.borderColor = "red";
            var divEmail = divs[10];
            var divEmailWarning = document.createElement("div");
            divEmailWarning.setAttribute("class", "warning");
            divEmailWarning.appendChild(document.createTextNode("Enter correct characters"));
            divEmail.appendChild(divEmailWarning);
            emailBool = false;
        }

        if (!emailConfirm.val() || 0 === emailConfirm.val().length) {
            document.getElementById("patientEmailConfirm").style.borderColor = "red";
            var divEmailConf = divs[11];
            var divEmailConfWarning = document.createElement("div");
            divEmailConfWarning.setAttribute("class", "warning");
            divEmailConfWarning.appendChild(document.createTextNode("Confirm email"));
            divEmailConf.appendChild(divEmailConfWarning);
            email2Bool = false;
        }
        if (!emailREGEX.test(emailConfirm.val())) {
            document.getElementById("patientEmailConfirm").style.borderColor = "red";
            var divEmailConf = divs[11];
            var divEmailConfWarning = document.createElement("div");
            divEmailConfWarning.setAttribute("class", "warning");
            divEmailConfWarning.appendChild(document.createTextNode("Enter correct characters"));
            divEmailConf.appendChild(divEmailConfWarning);
            email2Bool = false;
        }

        if (email.val() !== emailConfirm.val() && emailREGEX.test(emailConfirm.val()) && emailConfirm.val().length > 0) {
            document.getElementById("patientEmailConfirm").style.borderColor = "red";
            var divEmailConf = divs[11];
            var divEmailConfWarning = document.createElement("div");
            divEmailConfWarning.setAttribute("class", "warning");
            divEmailConfWarning.appendChild(document.createTextNode("Emails do not match"));
            divEmailConf.appendChild(divEmailConfWarning);
            emailConfBool = false;
        }

        if (!phone.val() || 0 === phone.val().length) {
            document.getElementById("patientPhone").style.borderColor = "red";
            var divPhone = divs[12];
            var divPhoneWarning = document.createElement("div");
            divPhoneWarning.setAttribute("class", "warning");
            divPhoneWarning.appendChild(document.createTextNode("Enter patient primary number"));
            divPhone.appendChild(divPhoneWarning);
            phoneBool = false;
        }
        if (!phoneREGEX.test(phone.val())) {
            document.getElementById("patientPhone").style.borderColor = "red";
            var divPhone = divs[12];
            var divPhoneWarning = document.createElement("div");
            divPhoneWarning.setAttribute("class", "warning");
            divPhoneWarning.appendChild(document.createTextNode("Invalid input"));
            divPhone.appendChild(divPhoneWarning);
            phoneBool = false;
        }

        if (!username.val() || 0 === username.val().length) {
            document.getElementById("patientUsername").style.borderColor = "red";
            var divUsername = divs[13];
            var divUsernameWarning = document.createElement("div");
            divUsernameWarning.setAttribute("class", "warning");
            divUsernameWarning.appendChild(document.createTextNode("Enter username"));
            divUsername.appendChild(divUsernameWarning);
            usernameBool = false;
        }

        if (!password.val() || 0 === password.val().length) {
            document.getElementById("patientPassword").style.borderColor = "red";
            var divPassword = divs[14];
            var divPasswordWarning = document.createElement("div");
            divPasswordWarning.setAttribute("class", "warning");
            divPasswordWarning.appendChild(document.createTextNode("Enter password"));
            divPassword.appendChild(divPasswordWarning);
            passwordBool = false;
        }

        if (!passwordConfirm.val() || 0 === passwordConfirm.val().length) {
            document.getElementById("patientPasswordConfirm").style.borderColor = "red";
            var divPasswordConf = divs[15];
            var divPasswordConfWarning = document.createElement("div");
            divPasswordConfWarning.setAttribute("class", "warning");
            divPasswordConfWarning.appendChild(document.createTextNode("Enter password validation"));
            divPasswordConf.appendChild(divPasswordConfWarning);
            password2Bool = false;
        }

        if (password.val() !== passwordConfirm.val() && passwordConfirm.val().length > 0) {
            document.getElementById("patientPasswordConfirm").style.borderColor = "red";
            var divPasswordConf = divs[15];
            var divPasswordConfWarning = document.createElement("div");
            divPasswordConfWarning.setAttribute("class", "warning");
            divPasswordConfWarning.appendChild(document.createTextNode("Passwords do not match"));
            divPasswordConf.appendChild(divPasswordConfWarning);
            passwordConfBool = false;
        }

        if (!dateOfBirth.val() || 0 === dateOfBirth.val().length) {
            document.getElementById("patientDateOfBirth").style.borderColor = "red";
            var divDate = divs[8];
            var divDateWarning = document.createElement("div");
            divDateWarning.setAttribute("class", "warning");
            divDateWarning.appendChild(document.createTextNode("Enter birthday"));
            divDate.appendChild(divDateWarning);
            DateBool = false;
        }

        var base64;
        if (imageToLoad.files.length > 0) {
            var file = imageToLoad.files[0];
            var reader = new FileReader();
            reader.readAsDataURL(file);
            reader.onloadend = function () {            // ne ide dalje dok ne ucita sliku, mora slika!!
                base64 = reader.result;
                console.log('RESULT', base64)

                console.log(base64)

                if (nameBool && middleBool && surnameBool && countryBool && cityBool && addressBool && jmbgBool && DateBool && emailBool && email2Bool && emailConfBool && phoneBool && usernameBool && passwordBool && password2Bool && passwordConfBool && imageBool) {

                    let state = new Object();
                    state.Id = 0; state.Name = country.val();
                    let town = new Object();
                    town.Id = 0; town.Name = city.val(); town.State = state;
                    let address1 = new Object();
                    address1.Id = 0; address1.Street = address.val(); address1.Town = town;

                    //let address1 = new Object({ Id: 0, Street: address.val(), Number: null, FullAddress: null, Town: town })
                    var start = new Date();
                    var person = { FirstName: name.val(), LastName: surname.val(), Jmbg: jmbg.val()}
                    var userDetails = { MiddleName: middleName.val(), Phone: phone.val(), Race: raceVal, BloodType: bloodVal, Image: base64, Email: email.val(), Gender: genderVal, DateOfBirth: date, Address: address1 }
                    var userLogin = { Username: username.val(), Password: password.val() }
                    var data2 = {  Person : person, UserDetails : userDetails, UserLogin : userLogin }
                    $.ajax({
                        url: window.location.protocol + "//" + window.location.host + "/api/registration",
                        type: 'POST',
                        data: JSON.stringify(data2),
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {

                            if ( data.username === username.val() && data.jmbg === jmbg.val() && data.email === email.val()){
                                Swal.fire({
                                    position: 'top-end',
                                    icon: 'success',
                                    title: 'You have successfully registered!',
                                    showConfirmButton: false,
                                    timer: 1500
                                })
                            }
                            else if (data.username === username.val()) {
                                Swal.fire({
                                    position: 'top-end',
                                    icon: 'error',
                                    title: 'Patient with same username already exists!',
                                    showConfirmButton: false,
                                    timer: 1500
                                })
                            }

                            else if (data.jmbg === jmbg.val()) {
                                Swal.fire({
                                    position: 'top-end',
                                    icon: 'error',
                                    title: 'Patient with same id already exists!',
                                    showConfirmButton: false,
                                    timer: 1500
                                })
                            }
                            else if (data.email === email.val()) {
                                Swal.fire({
                                    position: 'top-end',
                                    icon: 'error',
                                    title: 'Patient with same email already exists!',
                                    showConfirmButton: false,
                                    timer: 1500
                                })
                            }
                        }
                    })
                }
                else {
                    console.log("Nisu popunjena sva polja");
                }
            }
        }
        else {
            document.getElementById("patientImg").style.borderColor = "red";
            var divImage = divs[16];
            var divImageWarning = document.createElement("div");
            divImageWarning.setAttribute("class", "warning");
            divImageWarning.appendChild(document.createTextNode("Choose profile picture"));
            divImage.appendChild(divImageWarning);

            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Fill the required fields',
            })
        }
    })
})