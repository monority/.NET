import { Order, Status } from "./interface.js";

export class OrderManager {
	private orders: Order[] = []


	addOrder(order: Order) {
		this.orders.push(order)
	}
	getOrderById(id: number)  {
		return this.orders.find(order => order.id === id) 
	}
	updateOrderStatus(id: number, status: Status) {
		const order = this.getOrderById(id);
		if (order) {
			order.status = status;
		}
		else {
			return "Order not found"
		}
	}
	listOrderByStatus(status: "pending" | "completed" | "delivered") {
		return this.orders.filter(order => order.status === status);
	}
	removeOrder(id: number) {
		const index = this.orders.findIndex(order => order.id === id);
		if (index !== -1) {
			this.orders.splice(index, 1);
		}
		else {
			return "Order not found"
		}
	}
	toString() {
		return this.orders.map(order => `Order n°${order.id} - ${order.status}`).join("\n");
	}
}