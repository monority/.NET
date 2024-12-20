let inventory = [
	{ "name": "coca", "quantity": 50, "price": 1.5 },
	{ "name": "sprite", "quantity": 30, "price": 3.0 },
	{ "name": "redbull", "quantity": 10, "price": 25.0 }
]

function display_inventory(inventory) {
	for (let i = 0; i < inventory.length; i++) {
		console.log(`Nom :${inventory[i].name}, quantity : ${inventory[i].quantity}, price : ${inventory[i].price}`);
	}
}

function add_product() {
	let added_name = prompt("What's the name of the product ?");
	let added_quantity = Number(prompt("How many ?"));
	let added_price = Number(prompt("Price ?"));
	inventory.push({ name: added_name, quantity: added_quantity, price: added_price });
}

function delete_product() {
	for (let i = 0; i < inventory.length; i++) {
		let ask_delete = prompt("Type the name you want to delete :");
		if (ask_delete == inventory[i].name) {
			inventory.splice(i, 1);
			alert("Product deleted");
			break;
		} else {
			alert(`Product doesn't exist`);
		}
	}
}


function change_quantity(product, ask_product) {
	do {
		ask_product = prompt("What's the product ?");
		product = inventory.find(item => item.name == ask_product);
		if (!product) {
			alert("Wrong product")
		}
		else {
			ask_quantity = Number(prompt("What's the quantity ?"));
			product["quantity"] = ask_quantity;
			display_inventory();

		}
	} while (ask_product !== product.name)
}

function search_product(ask_product, product) {

	do {
		ask_product = prompt("What's the product ?");
		product = inventory.find(item => item.name == ask_product);
		if (!product) {
			alert("Wrong product")
		}
		else {
			alert(`name : ${product.name}, quantity : ${product.quantity}, price : ${product.price}`)
		}
	} while (ask_product != product)
}

function calculate_value(total) {
	for (let i = 0; i < inventory.length; i++) {
		total = inventory[i].quantity * inventory[i].price
	}
}

function leave() {
	alert("You're done");
	startloop = false;
}

function display_menu(displaymenu) {
	displaymenu = [
		`1. Show inventory`,
		`2. Add product`,
		`3. Delete product`,
		`4. Change quantity`,
		`5. Search product`,
		`6. Calculate value`,
		`7. Exit`,
	]
	let question = prompt(`What's your choice \n \n ${displaymenu.join("\n \n")}`)
	
		switch (question) {
			case '1':
				display_inventory();
				break;
			case '2':
				add_product();
				break;
			case '3':
				delete_product();
				break;
			case '4':
				change_quantity();
				break;
			case '5':
				search_product();
				break;
			case '6':
				calculate_value();
				break;
			case '7':
				leave(startloop)
				break;
			default:
				display_menu();
		}
}


display_menu();
