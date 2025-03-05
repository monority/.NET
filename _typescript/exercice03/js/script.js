import { CreateUser } from "./fonctions.js";
import { User } from "./User.js";
const clientFirstname = document.querySelector("#firstName").value;
const clientLastname = document.querySelector("#lastName").value;
const clientEmail = document.getElementById("email").value;
const clientPhone = document.getElementById("phone").value;
const clientBirthdate = document.getElementById("birthDate").value;
let arrayUsers = JSON.parse(localStorage.getItem('users')) || [];
const form = document.querySelector("#form_submit");
form.addEventListener("submit", function (event) {
    event.preventDefault();
    const user = CreateUser(crypto.randomUUID(), clientFirstname, clientLastname, clientBirthdate, clientEmail, clientPhone);
    arrayUsers.push(User);
    localStorage.setItem('users', JSON.stringify(arrayUsers));
    return user;
});
