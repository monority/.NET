import React from 'react'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import App from './App';
import Footer from './display/components/ui/Footer';
import Header from './display/components/ui/Header';
const Root = () => {
	return (
		<BrowserRouter>
				<Header />
				<Routes>
					<Route exact path="/" element={<App />} />
				</Routes>
			<Footer></Footer>
		</BrowserRouter>
	)
}

export default Root;

