// function demo_loop(i, som) {

// 	i = 0;
// 	som = 0;

// 	while (som <= 100) {
// 		i++;
// 		som += i;
// 	}
// }
// alert(`La valeur cherchée est N = ${i}, et la somme est ${som}`);

// demo_loop();


// function demo_Loop(input) {
// 	input = prompt("Enter your value");

// 	while (input < 1 || input > 3) {
// 		alert("Bad");
// 		input = prompt("Enter your value");
// 	}
// 	alert("You good");
// }
// demo_Loop();


// function demo_loop_01(rate, capital, year, total) {
// 	capital = Number(prompt("What's your capital ?"));
// 	rate = Number(prompt("What's the rate ?")) / 100;
// 	gain_x2 = capital * 2;
// 	year = 0;
// 	total = Math.round(capital * Math.pow(1 + rate, year))

// 	while (total < gain_x2) {
// 		year++;
// 		total = Math.round(capital * Math.pow(1 + rate, year))
// 	}
// 	alert(`Your capital has more than double :${total} in ${year}`)
// }

function demo_loop_03(rate, capital, year) {
	capital = Number(prompt("What's your capital ?"));
	rate = Number(prompt("What's the rate ?")) / 100;
	gain_x2 = capital * 2;
	year = 0;

	while (capital < gain_x2) {
		year++;
		capital *= rate + 1;
	}
	alert(`Capital amount is XXL !!!! :  ${Math.round(capital)} in ${year} year(s)`);
}

demo_loop_03();