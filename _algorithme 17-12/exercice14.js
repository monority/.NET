

function division(a, b) {
	let result = 0;
	if (b != 0) {
		result = a / b;
	}
	else {
		console.log("Divide by 0 is impossible");
		return null;
	}
	return result;
}

function calculateMax(x, y) {
	x = Number(prompt("Give the first number :"))
	y = Number(prompt("Give the second number :"))

	if (x > y) {
		alert(x)
	}
	else {
		alert(y)
	}
}

function calculate_perimeter(x, y, perimeter) {
	x = Number(prompt("Give the first number :"))
	y = Number(prompt("Give the second number :"))

	perimeter = 2 * (x + y);
	return perimeter
}
