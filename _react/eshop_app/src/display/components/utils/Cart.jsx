import React, { useEffect } from 'react'
import Icon from './Icon'

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
					<div className="element">
						<h3>{product.title}</h3>
					</div>
					<div className="element">
						<p>${product.price}</p>
					</div>
					<div className="element">
						<p>Quantity : {product.quantity}</p>
					</div>
					<div className="element_bin">
						<Icon type="bin" width="2rem" height="2rem" action={() => deleteProduct(product.id)} />
					</div>
				</div>

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
					{totalPrice > 0 && <p>Total: <strong className='text_color02'>{totalPrice}</strong> $</p>}
				</div>
				<div className="element">
					<button className='btn btn_remove' onClick={() => setNewList([])}>Remove All</button>
				</div>
			</div>

		</>
	)
}

export default Cart