import { createSlice } from "@reduxjs/toolkit";


const productSlice = createSlice({
	name: "product",
	initialState: {
		products: [
			{ id: 1, price: 2000, name: "AWP" },
			{ id: 2, price: 3250, name: "M16" }]
	},
	reducers: {
		addProduct(state, action) {
			const newProduct = {
				price: action.payload.price,
				name: action.payload.name,
				id: state.products.length + 1
			}
			state.products.push(newProduct)
		},
		deleteProduct(state, action) {
			state.products = state.products.filter(product => product.id !== action.payload)
		},
		editProduct(state, action) {
			const product = state.products.find(product => product.name === action.payload.name);
			product.price = action.payload.price;
			product.name = action.payload.name;
		}
	}
})
export const { addProduct, deleteProduct, editProduct } = productSlice.actions
export default productSlice.reducer