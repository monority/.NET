export function createOrder(customer, items, status) {
    return {
        id: 1,
        customer: customer,
        items: items,
        status: status,
    };
}
export function calculateTotal(order) {
    return order.items.reduce((acc, item) => acc + item.product.price * item.quantity, 0);
}
