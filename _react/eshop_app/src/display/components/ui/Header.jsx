import React, { useState } from 'react'
import Icon from '../utils/Icon'
import Modal from './Modal'
import Cart from '../utils/Cart'
import { Outlet } from 'react-router-dom'

const Header = () => {
	const [isOpen, setIsOpen] = useState(false);
	const [newList, setNewList] = useState([])
	const [list, setList] = useState([
		{
			img: "https://example.com/images/product1.jpg",
			price: 100,
			title: "Product 1",
			desc: "A high-quality product designed for everyday use.",
			id: 1,
		},
		{
			img: "https://example.com/images/wireless_earbuds.jpg",
			price: 59.99,
			title: "Wireless Bluetooth Earbuds",
			desc: "Enjoy crystal-clear sound with these comfortable and portable earbuds.",
			id: 2,
		},
		{
			img: "https://example.com/images/water_bottle.jpg",
			price: 24.95,
			title: "Stainless Steel Water Bottle",
			desc: "Keep your drinks hot or cold for hours with this durable and eco-friendly bottle.",
			id: 3,
		},
		{
			img: "https://example.com/images/desk_lamp.jpg",
			price: 45.5,
			title: "Smart LED Desk Lamp",
			desc: "Adjustable brightness and color temperature for a perfect workspace setup.",
			id: 4,
		},
		{
			img: "https://example.com/images/tshirt.jpg",
			price: 29.99,
			title: "Organic Cotton T-Shirt",
			desc: "Soft, breathable, and sustainably made for all-day comfort.",
			id: 5,
		},
		{
			img: "https://example.com/images/hard_drive.jpg",
			price: 89.99,
			title: "Portable External Hard Drive",
			desc: "Store and transfer your files quickly with this compact and reliable hard drive.",
			id: 6,
		},
		{
			img: "https://example.com/images/coffee_grinder.jpg",
			price: 34.99,
			title: "Electric Coffee Grinder",
			desc: "Grind your coffee beans to perfection with this easy-to-use electric grinder.",
			id: 7,
		},
		{
			img: "https://example.com/images/yoga_mat.jpg",
			price: 39.99,
			title: "Yoga Mat with Carry Strap",
			desc: "Practice yoga comfortably with this non-slip, eco-friendly mat.",
			id: 8,
		},
		{
			img: "https://example.com/images/headphones.jpg",
			price: 199.99,
			title: "Noise-Cancelling Headphones",
			desc: "Immerse yourself in music with premium sound quality and noise cancellation.",
			id: 9,
		},
		{
			img: "https://example.com/images/food_bags.jpg",
			price: 19.99,
			title: "Reusable Silicone Food Bags",
			desc: "Eco-friendly and leak-proof bags for storing snacks, meals, and more.",
			id: 10,
		},
	]
	)
	const totalQuantity = newList.reduce((acc, product) => acc + (product.quantity || 1), 0)
	return (
		<>
			<header id="header">
				<div className="lyt_container h_100">
					<div className="container_between h_100">
						<div className="element">
							<h1>EShop<strong>app</strong></h1>
						</div>
						<div className="element">
							<nav>
								<ul>
									<li className='relative'><Icon type="cart" width="4rem" height="4rem" action={() => setIsOpen(!isOpen)} /><p className='quantity'>{totalQuantity}</p></li>
									<li></li>
									<li></li>
								</ul>
							</nav>
						</div>
					</div>
				</div>

			</header>
			<Outlet context={[[list, setList], [newList, setNewList]]} />

			{isOpen && <Modal closeModal={() => setIsOpen(!isOpen)}><Cart newList={newList} setNewList={setNewList} /></Modal>}
		</>
	)
}

export default Header