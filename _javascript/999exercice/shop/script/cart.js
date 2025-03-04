const displayArray = () => {
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
			if (item.type == "charisma"){
				listItem.classList.add("bg_color01")
			}
			if (item.type == "wisdom"){
				listItem.classList.add("bg_color02")
			}
			if (item.type == "strenght"){
				listItem.classList.add("bg_color03")
			}
			if (item.type == "constitution"){
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
window.onload = () => {
	displayArray();
	displayCount();
};