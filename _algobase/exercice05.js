// Age from categories
function informCategory(age) {
	age = Number(prompt("What's your age ?"));

	if (age < 3) {
		alert("Age must be positive ");
	}
	else if (age < 6) {
		alert("You're in babies");
	}
	else if (age < 8) {
		alert("You're in Poussin");
	}
	else if (age < 10) {
		alert("You're in Pupill");
	}
	else if (age < 12) {
		alert("You're in Minim");
	}
	else if (age >= 13) {
		alert("You're in Cadet");
	}
	else{
		alert("You're not eligible");
	}
}
informCategory();

