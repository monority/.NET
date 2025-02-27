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
				result.value += key.textContent
			}
		});
		
	});
}
document.addEventListener("keydown", (e) => {
	if (e.key === "Enter") {
		try {
			result.value = eval(result.value);
		} catch (error) {
			result.value = error.message;
		}
	}
	else {
		result.value += e.key;
	}
}
);
window.onload = Calculate();