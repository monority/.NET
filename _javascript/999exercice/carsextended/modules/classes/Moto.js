import { Vehicule } from './Vehicule.js';
export class Moto extends Vehicule {
	constructor(brand, model, km, year) {
		super(brand, model, km, year);
	}

	toString() {
		return `Moto : ${super.display()}`;
	}
}