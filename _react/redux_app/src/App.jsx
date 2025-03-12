import React, { useState } from 'react'
import { useDispatch, useSelector } from "react-redux";
import ProductItem from './display/components/product/ProductItem';
import { addProduct, deleteProduct, editProduct } from './cfg/redux/ProductSlice';

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
						<form action={handleSubmit}>
							<div className="form_element">
								<label htmlFor="name">Name</label>
								<input type="text" id="name" name="name" className='input_default' defaultValue={data?.name} />
							</div>
							<div className="form_element">
								<label htmlFor="price">Price</label>
								<input type="text" id="price" name="price" className='input_default' defaultValue={data?.price} />
							</div>
							<div className="form_element">
								<button className='btn'>{!checkEdit ? "Add" : "Modify"}</button>
							</div>
						</form>
					</div>
				</div>
			</div>
		</>
	)
}

export default App