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
const displayArray = () => {
	if (window.location.pathname === '/pages/cart.html') {
		const container = document.querySelector('.display');
		const sessionData = localStorage.getItem('session');
		const retrievedArray = JSON.parse(sessionData);
		if (retrievedArray && retrievedArray.length > 0) {
			container.innerHTML = '';
			const list = document.createElement('ul');

			retrievedArray.forEach(item => {
				const listItem = document.createElement('li');
				const button = document.createElement('button');
				button.textContent = 'Remove';
				listItem.classList.add('list_item');
				list.classList.add("list")
				const type = item.type;
				const count = item.count;
				if (item.type == "charisma") {
					listItem.classList.add("bg_color01")
				}
				if (item.type == "wisdom") {
					listItem.classList.add("bg_color02")
				}
				if (item.type == "strenght") {
					listItem.classList.add("bg_color03")
				}
				if (item.type == "constitution") {
					listItem.classList.add("bg_color04")
				}
				listItem.textContent = `Type: ${type}, Count: ${count}`;
				listItem.appendChild(button);
				list.appendChild(listItem);

				button.addEventListener('click', () => {
					const findItem = retrievedArray.find((item) => item.type === type);
					const count = findItem.count;

					if (count > 1) {
						findItem.count--;
						localStorage.setItem('session', JSON.stringify(retrievedArray));

					}
					else {
						const index = retrievedArray.indexOf(findItem);
						retrievedArray.splice(index, 1);
						localStorage.setItem('session', JSON.stringify(retrievedArray));

					}
					displayCount();
					displayArray();
				});
			});

			container.appendChild(list);
		} else {
			container.textContent = 'No items found in localStorage.';
		}
	}
}
const init = () => {
	const bodyElement = document.body;
	const theme = localStorage.getItem('theme') || 'light';
	bodyElement.setAttribute('data-theme', theme);
}
const thememode = () => {
	const bodyElement = document.body;
	const oldtheme = localStorage.getItem('theme') || 'light';
	const newTheme = oldtheme === 'light' ? 'dark' : 'light';
	bodyElement.setAttribute('data-theme', newTheme);
	localStorage.setItem('theme', newTheme);
}
window.onload = () => {
	init();
	displayArray();
	displayCount();
};
