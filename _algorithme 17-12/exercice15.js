// let table = [];

// table.put(12);
// table.put(15);
// table.put(20);

// let value = table[2];
// length = table.length;
// for (let i = 0; i < length; i++) {
// 	console.log(table[i]);
// }

function ten_table() {
	let inventory = [];
	for (let i = 0; i < 10; i++) {
		let number_rdm = Math.floor(Math.random() * 1000);
		inventory.push(number_rdm);
	}
	alert(`Table is : ${inventory} \n\n Element nine : ${inventory[9]}`)

}

function fifteen_notes() {
	let inventory = [];
	for (let i = 0; i < 15; i++) {
		let number_rdm = Math.floor(Math.random() * 20);
		inventory.push(number_rdm);
	}
	for (let j = 0; j < inventory.length; j++) {
		console.log(inventory[j]);
	}
	
	console.log(inventory)
}
fifteen_notes();
