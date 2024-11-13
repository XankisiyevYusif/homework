const loginInput = document.getElementById('login');
const passwordInput = document.getElementById('password');
const emailInput = document.getElementById('email');
const checkboxInput = document.getElementById('checkboxInput');
const submitButton = document.getElementById('submit');

const loginError = document.getElementById('loginError');
const passwordError = document.getElementById('passwordError');
const emailError = document.getElementById('emailError');

submitButton.disabled = true;

let isLoginTrue = false;
let isPasswordTrue = false;
let isEmailTrue = false;

loginInput.addEventListener('input', (e) => {
    const value = e.target.value;
    if (value.length < 8) {
        loginError.textContent = "8 herfden daha cox olmalidir";
        isLoginTrue = false;
    } else if (value[0] !== value[0].toLowerCase()) {
        loginError.textContent = "Kicik herfle baslamalidir";
        isLoginTrue = false;
    } else if (/\d/.test(value)) {
        loginError.textContent = "Reqemlerden istifade olunmamalidir";
        isLoginTrue = false;
    } else {
        loginError.textContent = "";
        isLoginTrue = true;
    }
    toggleSubmitButton();
});

passwordInput.addEventListener('input', (e) => {
    const value = e.target.value;
    if (value.length <= 8) {
        passwordError.textContent = "8 herfden daha cox olmalidir";
        isPasswordTrue = false;
    } else if (value[0] !== value[0].toUpperCase()) {
        passwordError.textContent = "Boyuk herfle baslamalidir";
        isPasswordTrue = false;
    } else if (!/[._]/.test(value)) {
        passwordError.textContent = ". ve ya _ istifade olunmalidir";
        isPasswordTrue = false;
    } else if (!/\d/.test(value)) {
        passwordError.textContent = "Reqemlerden istifade olunmalidir";
        isPasswordTrue = false;
    } else {
        passwordError.textContent = "";
        isPasswordTrue = true;
    }
    toggleSubmitButton();
});

emailInput.addEventListener('input', (e) => {
    const value = e.target.value;
    if (!value.includes("@")) {
        emailError.textContent = "@ simvolundan istifade olunmalidir";
        isEmailTrue = false;
    } else if (!/\.(ru|com|az)$/.test(value)) {
        emailError.textContent = ".com, .az ve ya .ru istifade olunmalidir";
        isEmailTrue = false;
    } else {
        emailError.textContent = "";
        isEmailTrue = true;
    }
    toggleSubmitButton();
});

checkboxInput.addEventListener('change', toggleSubmitButton);

function toggleSubmitButton() {
    submitButton.disabled = !(isLoginTrue && isPasswordTrue && isEmailTrue && checkboxInput.checked);
}
