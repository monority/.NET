
function calculateSize(weight, length) {
	weight = Number(prompt("Give your weight : "));
	length = Number(prompt("Give your length : "));

	let size_01 = `You're in size 1`;
	let size_02 = `You're in size 2`;
	let size_03 = `You're in size 3`;

	if (weight < 43 || length < 145 || weight > 77 || length > 183) {
		return `You're not in our sizes`;
	} else {
		// Table 1
		if (weight <= 65 && length <= 160) {
			console.log("Condition 1");
			return size_01;
		}
		if (weight <= 59 && length == 163) {
			console.log("Condition 2");
			return size_01;
		}
		if (weight <= 53 && length == 166) {
			console.log("Condition 3");
			return size_01;
		}
		if (weight <= 47 && length == 169) {
			console.log("Condition 4");
			return size_01;
		}
		if (weight >= 66 && weight <= 71 && length <= 169) {
			console.log("Condition 5");
			return size_02;
		}

		if (weight >= 60 && weight <= 65 && length <= 172) {
			console.log("Condition 6");
			return size_02;
		}
		if (weight >= 54 && weight <= 59 && length <= 175) {
			console.log("Condition 7");
			return size_02;
		}
		if (weight >= 60 && weight <= 65 && length <= 178) {
			console.log("Condition 8");
			return size_02;
		}

		if (weight <= 72 && weight >= 54) {
			console.log("Condition 9");
			return size_03;

		}
		if (weight <= 71 && length <= 172) {
			console.log("Condition 10");
			return size_03;
		}
		if (weight <= 65 && length <= 175) {
			console.log("Condition 11");
			return size_03;

		}
		if (weight <= 59 && length <= 178) {
			console.log("Condition 12");
			return size_03;

		}
	}
}

alert(`${calculateSize()}`)
function calculateSizes(weight, length) {
	weight = Number(prompt("Give your weight : "));
	length = Number(prompt("Give your length : "));

	let size_01 = `You're in size 1`;
	let size_02 = `You're in size 2`;
	let size_03 = `You're in size 3`;

	// Check if the weight or length is outside the acceptable range
	if (weight < 43 || length < 145 || weight > 77 || length > 183) {
		return `You're not in our sizes`;
	}

	// Conditions for size 1
	if ((weight <= 65 && length <= 160) ||
		(weight <= 59 && length === 163) ||
		(weight <= 53 && length === 166) ||
		(weight <= 47 && length === 169)) {
		return size_01;
	}

	// Conditions for size 2
	if ((weight >= 66 && weight <= 71 && length <= 169) ||
		(weight >= 60 && weight <= 65 && length <= 172) ||
		(weight >= 54 && weight <= 59 && length <= 175) ||
		(weight >= 60 && weight <= 65 && length <= 178)) {
		return size_02;
	}

	// Conditions for size 3
	if ((weight >= 54 && weight <= 72) ||
		(weight <= 71 && length <= 172) ||
		(weight <= 65 && length <= 175) ||
		(weight <= 59 && length <= 178)) {
		return size_03;
	}

	// Default if no condition is met
	return `You're not in our sizes`;
}

