import { Status } from "./interface.js";
import { OrderManager } from "./OrderManager.js";


const defManager = new OrderManager();
const defCustomer = { id: 1, name: "John", email: "ok@test.fr" };
defManager.addOrder({ id: 1, customer: defCustomer, items: [{ product: { id: 1, name: "product1", price: 10, stock: 10 }, quantity: 2 }], status: Status.Pending });
const defCustomer2 = { id: 2, name: "Jane", email: "jane@test.fr" };
const defCustomer3 = { id: 3, name: "Doe", email: "doe@test.fr" };

defManager.addOrder({ id: 2, customer: defCustomer2, items: [{ product: { id: 2, name: "product2", price: 20, stock: 5 }, quantity: 1 }], status: Status.Completed });
defManager.addOrder({ id: 3, customer: defCustomer3, items: [{ product: { id: 3, name: "product3", price: 15, stock: 8 }, quantity: 3 }], status: Status.Delivered });
console.log(defManager.toString());
console.log(defManager.listOrderByStatus("pending"));