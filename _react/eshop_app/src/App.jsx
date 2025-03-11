import React, { useState } from 'react'
import ProductCard from './display/components/ui/ProductCard'
import { useOutletContext } from "react-router-dom";

const App = () => {
	const [[list, setList], [newList, setNewList]] = useOutletContext([]);
	const productMap = list.map(product => {
		return (
			<ProductCard
				key={product.id}
				img={product.img}
				price={product.price}
				title={product.title}
				desc={product.desc}
				action={() => {
					const existingProduct = newList.find(p => p.id === product.id);
					if (existingProduct) {
						setNewList(newList.map(p =>
							p.id === product.id ? { ...p, quantity: (p.quantity || 1) + 1 } : p
						));
					} else {
						setNewList([...newList, { ...product, quantity: 1 }]);
					}
				}}
			/>
		)
	})

	return (
		<>
			<div id="app">
				<div className="lyt_container">
					<div className="container_product">
						{productMap}
					</div>
				</div>
			</div>
		</>
	)
}

export default App
