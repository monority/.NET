import React from 'react'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import AppContainer from './display/AppContainer'
import App from './App';
import Login from './Login';
const Root = () => {
	return (
		<BrowserRouter>
			<AppContainer>
				<Routes>
					<Route exact path="/" element={<App />} />
					<Route exact path="/login" element={<Login />} />
				</Routes>
			</AppContainer>
		</BrowserRouter>
	)
}

export default Root;

