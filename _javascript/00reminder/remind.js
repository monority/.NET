//* 1. Déclaration de variables

let name = "John";
let admin = "ok";

//* 2. Variables non modifiables
const EMAIL = "example@email.fr";

//* 3. Ancienne façon 
var town = "Paris";

//* 4. Conditions 

let age = 20;

if (age >= 18) {
	console.log("Vous êtes majeur");
}
else if (age >= 21) {
	console.log("Vous êtes majeur et vous pouvez boire");

} else {
	console.log("Vous êtes mineur");
}

// * 5. Boucles

for (let i = 0; i < 5; i++) {
	console.log(i);
}

let j = 0;

while (j < 5) {
	console.log(j);
	j++;
}


do {
	console.log(j);
	j++;
} while (j < 5);

//* 6. Fonctions

function sayHello(name) {
	console.log(`Hello ${name}`);
}
sayHello("John");


const sayHello2 = (name) => {
	console.log(`Hello ${name}`);
}

const multiply = (a, b) => a * b;

let fruits = ["Apple", "Banana", "Orange"];

fruits.push("Kiwi");
console.table(fruits);

fruits.forEach(fruit => {
	console.log(fruit);
});
