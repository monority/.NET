// * 1. Dom manipulation

const myBtn = () => {
	alert("Hello");
}

const onMouseOver = () => {
	alert("Mouse over");
}

const onDbClick = () => {
	alert("Double click");
}


const functionArg = (arg) => {
	switch (arg) {
		case 1: alert("Hello");
			break;
		case 2: alert("Mouse over");
			break;
		default: alert("Double click");
	}
}

document.addEventListener("keydown", (e) => {
	if (e.key === "F12") {

		let message = document.querySelector(".input_text");
		message.value = "Hello";
	}
})

document.addEventListener("click", (e) => {
	let message = document.querySelector(".input_text");
	console.log(e.target.dataset.key);
	message.value = e.target.dataset.key;
}
)