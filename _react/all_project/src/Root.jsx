import React from 'react'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import AppContainer from './display/AppContainer'
import App from './App';
const Root = () => {
	return (
		<BrowserRouter>
			<AppContainer>
				<Routes>
					<Route exact path="/" element={<App />} />
				</Routes>
			</AppContainer>
		</BrowserRouter>
	)
}

export default Root;

