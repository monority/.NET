import { Car } from "./classes/Car.js";
import { Moto } from "./classes/Moto.js";

let display_car = document.querySelector(".display_car");
let display_moto = document.querySelector(".display_moto");

let car1 = new Car("Bmw", "Serie 1", 120000, 2020, "Climatisée");
let moto1 = new Moto("Yamaha", "R1", 254440, 2021);

moto1.toString();
car1.toString(); 	

display_car.innerHTML = car1.toString();
display_moto.innerHTML = moto1.toString();