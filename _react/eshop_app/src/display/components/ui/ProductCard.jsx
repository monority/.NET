import React from 'react'

const ProductCard = ({ img, price, title, desc, action }) => {
	return (
		<>
			<div id="product_card">
				<div className="container">
					<div className="element">
						<img src={`/img/${img}`} alt="" />
					</div>
					<div className="element">
						<p>{title}</p>
					</div>
					<div className="element">
						<p className='text_color02'>{desc}</p>
					</div>
					<div className="element">
						<p>{price} $</p>
					</div>
					<div className="element">
						<button onClick={action} className='btn btn_buy'>Add to cart</button>
					</div>
				</div>
			</div>
		</>
	)
}

export default ProductCard