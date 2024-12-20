

// for (let i = 0; i < 6; i++) {
// 	let message = "";
// 	for (let j = 0; j <= i; j++) {
// 			message += 0;
// 	}
// 	message += "X";
// 	console.log(message);
// }

function table_of() {
	for (i = 1; i < 10; i++) {
		console.log(`Table of ${i} :`)
		for (j = 1; j <= 10; j++) {
			console.log(`Your value : ${i} * ${j} = ${i * j} `);
		}
	}
}
function tourcoing_grow() {
	let rate = 0.89;
	let habs = 96809;
	let habs_max = 120000;
	i = 0
	let year = 2019
	while (habs < habs_max) {
		habs *= 1+ rate /100;
		i++;
		console.log(`total habs : ${habs} in ${year + i} `);
		console.log(`years : ${i}`)
	}
}
tourcoing_grow();