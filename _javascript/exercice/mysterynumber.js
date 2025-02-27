
let mysteryNumber = Math.floor(Math.random() * 100) + 1;

let input = document.querySelector(".mystery");
let result = document.querySelector(".result");
let triesleft = document.querySelector(".triesleft");
document.addEventListener("keydown", (e) => {
	if (e.key === "Enter") {
		validate();
	}
})
const validate = () => {
	triesleft.innerHTML = parseInt(triesleft.innerHTML) - 1;
	if (parseInt(triesleft.innerHTML) == 0) {
		result.innerHTML = "<p>Game over</p>"
		alert("You lost");
		location.reload();
	}
	let value = input.value;
	if (value == mysteryNumber) {
		result.innerHTML = `<p class="success">Good job, you won</p>`
		setTimeout(() => {
			location.reload();

		}, 2000);
	} else if (value < mysteryNumber) {
		result.innerHTML = "<p>The mystery number is bigger</p>"
	} else {
		result.innerHTML = "<p>The mystery number is smaller</p>"
	}
}
window.onload() = validate();