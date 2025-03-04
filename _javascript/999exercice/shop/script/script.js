let array = [];
let arraySkill = JSON.parse(localStorage.getItem('session')) || [];
const buttons = document.querySelectorAll('.btn');
buttons.forEach((button) => {
	button.addEventListener('click', (event) => {
		const type = event.target.getAttribute('data-type');
		const object = {
			type: type,
			count: 1,
		}
		const findType = arraySkill.find((item) => item.type === type);
		if (findType) {
			findType.count++;
			localStorage.setItem('session', JSON.stringify(arraySkill));
			console.log(arraySkill)
			displayCount();
			return;
		}
		arraySkill.push(object);
		displayCount();

		localStorage.setItem('session', JSON.stringify(arraySkill));
		console.log(arraySkill);
	});
});

const displayCount = () => {
	const count_cart = document.querySelector('.count_cart');
	const displayArray = localStorage.getItem('session');

	const retrievedArray = JSON.parse(displayArray);
	let totalCount = 0;
	retrievedArray.forEach((item) => {
		totalCount += item.count;
	});
	if (retrievedArray && retrievedArray.length > 0) {
		count_cart.innerHTML = `<p>${totalCount}</p>`;
	}
}
window.onload = displayCount;
