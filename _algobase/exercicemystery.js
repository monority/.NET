let max = 100; // Max random
let tries = 10; // max tries
let random = Math.floor(Math.random() * max);


function check_input(input) {
	if (!input || input > 100 || input < 1) {
		alert("Enter a valid value")
		return false;
	}
	else {
		return true;
	}
}

function tries_left(triesleft) {
	if (triesleft > 0) {
		return `tries left : ${triesleft}`
	}
	else {
		return 'No more tries, you lose'
	}
}

function win_lose(input, random) {
	if (input) {
		return "You win"
	}
	else {
		return `You lose, Number was ${random}`
	}
}

function wanna_retry() {
	while (true) {
		let check = prompt("Wanna retry ? y or n").toLowerCase();
		if (check === "y") {
			ask_player();
			return true
		}
		else if (check === "n") {
			alert("Ok")
			return false
		}
		else {
			alert("Enter a valid value");
			return true;
		}
	}
}


function compare_numbers(random_number, player_number) {
	checkdistance = random_number - player_number;
	if (player_number == random_number) {
		return `You won, number was ${random_number}`
	}
	else {
		if (player_number > random_number) {
			if (checkdistance <= 5) {
				return "You're close from 5 under"
			}
			return `Number is under`;
		}
		else {
			if (checkdistance <= 5) {
				return "You're close from 5 above"
			}
			return "Number is above";
		}

	}
}

function ask_player() {

	for (let i = 0; i < tries; i++) {
		let triesleft = tries;
		let guess_number = Number(prompt("Guess a number between 1 & 100 :"));
		let boolean_input = check_input(guess_number);
		let win_number = guess_number == random;
		if (win_number) {
			let display = win_lose(true, null);
			alert(display);
			wanna_retry();
			break
		} else {
			if (boolean_input) {
				triesleft--;
				if (triesleft > 0) {
					let result = `${compare_numbers(random, guess_number)} \n \n ${tries_left(triesleft)}`;
					alert(result);
				}
				else {
					let result = win_lose(false, random);
					alert(result);
					wanna_retry();
				}
			}
			else {
				tries++
			}
		}
	}

}

ask_player();