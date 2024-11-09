function formSubmit() {
    let login = document.getElementById("login").value;
    if (login.length <= 8) {
        alert("En az 8 simvol olmalidir!");
        return false;
    }
    if (/\d/.test(login)) {
        alert("Reqem olamamlidir!");
        return false;
    }
    if (!login.includes(".")) {
        alert("Noqte olmalidir!");
        return false;
    }

    let password = document.getElementById("password").value;
    if (password.length <= 8) {
        alert("En az 8 simvol olmalidir!");
        return false;
    }
    if (password[0] !== password[0].toUpperCase()) {
        alert("Sifrenin ilk herfi boyuk olmalidir!");
        return false;
    }
    if (!password.includes(".")) {
        alert("Sifrede noqte olmalidir!");
        return false;
    }

    let email = document.getElementById("email").value;
    if (!email.includes("@")) {
        alert("Emaildə '@' işarəsi olmalidir!");
        return false;
    }

    alert("Form ugurla gonderildi!");
    return true;
}