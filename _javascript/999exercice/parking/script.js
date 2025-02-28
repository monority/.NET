import { Vehicule } from "./classes/Vehicule.js";
let car01 = new Vehicule("123", "2018-09-22T15:00:00", new Date());
let car02 = new Vehicule("456", "2025-02-28T15:00:00", new Date());
let car03 = new Vehicule("789", "2025-02-28T15:00:00", new Date());
let car04 = new Vehicule("012", "2025-02-28T15:00:00", new Date());
let display = document.querySelector(".display");
let input = document.querySelector("#imm");
let cars = [car01, car02, car03, car04];
const calculPrice = (outDate, enterDate) => {
	let differenceInMilliseconds = outDate - enterDate;
	let differenceDate = differenceInMilliseconds / (1000 * 60);

	let price;
	if (differenceDate <= 15) {
		price = 0.8;
	} else if (differenceDate > 15 && differenceDate <= 30) {
		price = 1.30;
	} else if (differenceDate > 30 && differenceDate <= 45) {
		price = 1.70;
	} else {
		price = 6.00;
	}
	return price;
}

document.querySelector(".btn_pay").addEventListener("click", () => {

	let findCar = cars.find(car => car.imm === input.value);
	if (!findCar) {
		display.innerHTML = `<p class="error">Car doesn't exist</p>`;
		setTimeout(() => {
			display.innerHTML = "";
		}, 5000);
		return;
	}
	display.innerHTML = `<p class="green">Take your ticket for ${input.value}</p>`;
	setTimeout(() => {
		display.innerHTML = "";
	}, 5000);

	let totalPrice = calculPrice(findCar.outDate, findCar.enterDate);
	display.innerHTML = `<p class="pay"> You paid for ${findCar.imm} : ${totalPrice}</p>`;
	setTimeout(() => {
		display.innerHTML = "";
	}, 5000);

});

document.querySelector(".btn_ticket").addEventListener("click", () => {
	let findCar = cars.find(car => car.imm === input.value);
	
	if (findCar) {
		let totalPrice = calculPrice(findCar.outDate, findCar.enterDate);
		display.innerHTML = `<p class="pay">Price you have to pay for ${findCar.imm} is ${totalPrice}</p>`;
		setTimeout(() => {
			display.innerHTML = "";
		}, 5000);
	}
	else {
		
		cars.push(new Vehicule(input.value, new Date(), new Date()));
		display.innerHTML = `<p class="green">You have a ticket for ${input.value}</p>`;
		setTimeout(() => {
			display.innerHTML = "";
		}, 5000);
	}

});