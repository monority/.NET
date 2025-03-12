import { configureStore } from "@reduxjs/toolkit";
import productSlice from "./cfg/redux/ProductSlice";
export default configureStore({
	reducer: {
		product: productSlice,
	}
})