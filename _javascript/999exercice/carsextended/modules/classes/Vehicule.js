export class Vehicule {
	constructor(brand, model, km, year) {
		this.brand = brand;
		this.model = model;
		this.km = km;
		this.year = year;
	}

	display(){
		return `Brand : ${this.brand} Model : ${this.model} KM : ${this.km} Year : ${this.year}`;
	}
}
