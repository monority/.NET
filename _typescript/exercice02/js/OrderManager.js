export class OrderManager {
    constructor() {
        this.orders = [];
    }
    addOrder(order) {
        this.orders.push(order);
    }
    getOrderById(id) {
        return this.orders.find(order => order.id === id);
    }
    updateOrderStatus(id, status) {
        const order = this.getOrderById(id);
        if (order) {
            order.status = status;
        }
        else {
            return "Order not found";
        }
    }
    listOrderByStatus(status) {
        return this.orders.filter(order => order.status === status);
    }
    removeOrder(id) {
        const index = this.orders.findIndex(order => order.id === id);
        if (index !== -1) {
            this.orders.splice(index, 1);
        }
        else {
            return "Order not found";
        }
    }
    toString() {
        return this.orders.map(order => `Order n°${order.id} - ${order.status}`).join("\n");
    }
}
