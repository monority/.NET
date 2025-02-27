const keys = [...document.querySelectorAll(".button")];
let result = document.querySelector(".result");

const Calculate = () => {
	keys.forEach(key => {
		key.addEventListener("click", () => {
			if (key.textContent === "C") {
				result.value = "";
			} else if (key.textContent === "=") {
				try {
					result.value = eval(result.value);
				} catch (error) {
					result.value = error.message;
				}
			} else {
				result.value += key.textContent;
			}
		});
	});
}

document.addEventListener("keydown", (e) => {
	const numpadKeys = [
		"0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
		"+", "-", "*", "/", ".", "Enter", "Backspace"
	];

	if (!numpadKeys.includes(e.key)) {
		alert("Please use the numpad keys.");
		return;
	}

	if (e.key === "Enter") {
		try {
			result.value = eval(result.value);
		} catch (error) {
			result.value = error.message;
		}
	} else if (e.key === "Backspace") {
		result.value = result.value.slice(0, -1);
	} else {
		result.value += e.key;
	}
});

window.onload = Calculate();