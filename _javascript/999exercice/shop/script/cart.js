const displayArray = () => {
	const container = document.querySelector('.display');
	const displayArray = localStorage.getItem('session');
	let count = document.querySelector('.count');
	const retrievedArray = JSON.parse(displayArray);
	if (retrievedArray && retrievedArray.length > 0) {
		const list = document.createElement('ul');

		retrievedArray.forEach(item => {
			const listItem = document.createElement('li');
			listItem.classList.add('list_item');
			if (count[item]) {
				count[item]++;
			} else {
				const type = item.type;
				const count = item.count;
				listItem.textContent = `Type: ${type}, Count: ${count}`;
				
				list.appendChild(listItem);
			}


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