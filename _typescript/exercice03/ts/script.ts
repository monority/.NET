import { CreateUser } from "./fonctions.js";
import { User } from "./User.js";

const clientFirstname  = (<HTMLInputElement>document.querySelector("#firstName")).value;
const clientLastname = (<HTMLInputElement>document.querySelector("#lastName")).value;
const clientEmail = (<HTMLInputElement>document.getElementById("email")).value;
const clientPhone =(<HTMLInputElement>document.getElementById("phone")).value;
const clientBirthdate = (<HTMLInputElement>document.getElementById("birthDate")).value;
let arrayUsers = JSON.parse(localStorage.getItem('users')) || [];


const form = document.querySelector("#form_submit");

	form.addEventListener("submit", function (event) {
	event.preventDefault();
		const user = CreateUser(
			crypto.randomUUID(),
			clientFirstname,
			clientLastname,
			clientBirthdate,
			clientEmail,
			clientPhone,
		)
		arrayUsers.push(User);
		localStorage.setItem('users', JSON.stringify(arrayUsers));

		return user;
	});
