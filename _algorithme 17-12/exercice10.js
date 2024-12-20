let number_max = 0;

for (let i = 0; i < 6; i++) {
	let number = Math.round(Math.random() * 6);
	console.log(number)
	if (number > number_max) {
		number_max = number;
	}
}

alert(`${number_max}`); 