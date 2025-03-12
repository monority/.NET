import React, { useState } from 'react'
import { useDispatch, useSelector } from "react-redux";
import ProductItem from './display/components/product/ProductItem';
import { addProduct, deleteProduct, editProduct } from './cfg/redux/ProductSlice';
import Form from './display/components/utils/Form';

const App = () => {
	const [data, setData] = useState({ name: '', price: '' });

	const [checkEdit, setCheckEdit] = useState(false);
	const editData = (name, price) => {
		setCheckEdit(true);
		setData({ name: name, price: price });
	}

	const handleSubmit = (formData) => {
		const name = formData.get("name");
		const price = formData.get("price");
		const findproduct = products.find(product => product.name === name);
		if (!findproduct) {
			dispatch(addProduct({ name, price }));
			return
		}
		else {
			dispatch(editProduct({ name, price }));
			setData({ name: '', price: '' });
			setCheckEdit(false);
			return
		}
	}
	const products = useSelector(state => state.product.products);
	const dispatch = useDispatch();
	const productsMap = products.map(product => (
		<ProductItem key={product.id} name={product.name} price={product.price} remove={() => dispatch(deleteProduct(product.id))} edit={() => editData(product.name, product.price)} />
	))
	return (
		<>
			<div id="app">
				<div className="flex column gap8">
					<div className="element">
						<h1>Product Management React</h1>
					</div>
					<div className="flex column gap2">
						{productsMap}
					</div>
					<div className="flex column gap2">
						<Form handleSubmit={handleSubmit} data={data} checkEdit={checkEdit} />
					</div>
				</div>
			</div>
		</>
	)
}

export default App