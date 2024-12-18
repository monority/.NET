// Calculer le prix total en fonction du nombre de photocopies

let photocopiesNumber = Number(prompt("How many photocopies you want ?"));
let price = 0.3;

if (photocopiesNumber < 10) {
	price = 0.5;
}
else if (photocopiesNumber >= 20) {
	price = 0.4;
}
alert(`PAY : ${(photocopiesNumber * price)}`);


switch (photocopiesNumber) {
	case photocopiesNumber < 10:
		price = 0.5;
		break;
	case photocopiesNumber >= 10 && photocopiesNumber <= 20:
		price = 0.4;
		break;
	default:
		price = 0.3;
}

