import { Customer, Order, OrderItem, Status } from "./interface.js";

export function createOrder(customer : Customer, items : OrderItem[], status : Status.Pending) : Order {
	return {
		id: 1,
		customer: customer,
		items: items,
		status: status,
	}
}

export function calculateTotal(order : Order) : number{
	return order.items.reduce((acc, item) => acc + item.product.price * item.quantity, 0);
}