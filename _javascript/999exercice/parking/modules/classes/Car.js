import { Vehicule } from './Vehicule.js';

export class Car extends Vehicule {
	constructor(brand, model, km, year, clim) {
		super(brand, model, km, year);
		this.clim = clim;

	}

	toString() {
		return `Car : ${super.display()} ${this.clim ? "Climatisée" : "Non Climatisée"}`;
	}

}