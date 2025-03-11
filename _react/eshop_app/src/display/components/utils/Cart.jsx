import React, { useEffect } from 'react'

const Cart = ({ newList, setNewList }) => {
	const deleteProduct = (id) => {
		const findIndex = newList.findIndex(product => product.id === id)
		const copyList = [...newList]
		if (copyList[findIndex].quantity > 1) {
			copyList[findIndex].quantity -= 1
		} else {
			copyList.splice(findIndex, 1)
		}
		setNewList(copyList)
	}
	const cartMap = newList.map(product => {
		return (
			<div className="cart_item" key={product.id}>
				<div className="flex column gap1">
					<h3>{product.title}</h3>
					<p>${product.price}</p>
					<p>Quantity : {product.quantity}</p>
					<button className='btn btn_delete' onClick={() => deleteProduct(product.id)}>-</button>
				</div>

				<hr />
			</div>
		)
	})
	useEffect(() => {

	}, [newList])
	const totalPrice = newList.reduce((acc, product) => acc + product.price * (product.quantity || 1), 0)
	return (
		<>
			<div id="cart">
				
				<div className="container">
					{cartMap}
				</div>
				<div className="element">
					{totalPrice > 0 && <p>Total: ${totalPrice}</p>}
				</div>
			</div>

		</>
	)
}

export default Cart