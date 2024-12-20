function calculateTriangle(AB, BC, AC) {
	AB = Number(prompt("What's the length of AB ?"));
	BC = Number(prompt("What's the length of BC ?"));
	AC = Number(prompt("What's the length of AC ?"));

	let isoA = AB == AC;
	let isoB = AB == BC;
	let isoC = BC == AC;

	if (isoA) {
		if (isoB) {
			return 'equilateral'
		}
	}
	if (isoA) {
		return 'Isosceles in A'
	}
	if (isoB) {
		return 'Isosceles in B'
	}
	if (isoC) {
		return 'Isosceles in C'
	}
	return 'Not Isosceles';

}


alert(`${calculateTriangle()}`);

