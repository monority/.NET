export class Car {
	constructor(brand, model, speed){
		this.brand = brand;
		this.model = model;
		this.speed = speed;
		this.CarList = [];
	}

	accelerate(){
		this.speed += 10;
	}
	turn(){
		this.speed -= 5;
	}
	addCars(){
		this.CarList.push(this.model);
		console.log(`Car ${this.model} is added to the list`);
	}
	DisplayCars(){
		console.log(`${this.brand} ${this.model} is running at ${this.speed} km/h`);
	}
}