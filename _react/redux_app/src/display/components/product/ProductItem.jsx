import React from 'react'

const ProductItem = ({ name, price, id, remove, edit }) => {

	return (
		<>
			<div id="product_item">
				<div className="element">
					<p>{id}</p>
				</div>
				<div className="element">
					<p>{name}</p>
				</div>
				<div className="element">
					<p>{price}</p>
				</div>
				<div className="wrapper">
					<div className="element">
						<button className='btn' onClick={remove}>
							-
						</button>

					</div>
					<div className="element">
						<button className='btn' onClick={edit}>
						<svg viewBox="0 0 24 24" width="1.5rem" height="1.5rem" fill="none" xmlns="http://www.w3.org/2000/svg"><g id="SVGRepo_bgCarrier" stroke-width="0"></g><g id="SVGRepo_tracerCarrier" stroke-linecap="round" stroke-linejoin="round"></g><g id="SVGRepo_iconCarrier"> <path d="M20.1498 7.93997L8.27978 19.81C7.21978 20.88 4.04977 21.3699 3.32977 20.6599C2.60977 19.9499 3.11978 16.78 4.17978 15.71L16.0498 3.84C16.5979 3.31801 17.3283 3.03097 18.0851 3.04019C18.842 3.04942 19.5652 3.35418 20.1004 3.88938C20.6356 4.42457 20.9403 5.14781 20.9496 5.90463C20.9588 6.66146 20.6718 7.39189 20.1498 7.93997V7.93997Z" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"></path> </g></svg>
						</button>
					</div>
				</div>
			</div>

		</>
	)
}

export default ProductItem