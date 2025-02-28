import { Car } from "./classes/Car.js";

let car1 = new Car("Bmw", "Serie 1", 80);
let car2 = new Car("Mercerdes", "GLB", 100);


car1.accelerate();
car1.accelerate();
car1.accelerate();
car1.DisplayCars();

car2.accelerate();
car2.accelerate();
car2.turn();
car2.turn();

car2.DisplayCars();
car1.addCars();
car2.addCars();
console.table(car1.CarList);