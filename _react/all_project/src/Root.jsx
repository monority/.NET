import React from 'react'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import AppContainer from './display/AppContainer'
import App from './App';
import LoginForm from './display/LoginEx/components/LoginForm';
const Root = () => {
	return (
		<BrowserRouter>
			<AppContainer>
				<Routes>
					<Route exact path="/" element={<App />} />
					<Route exact path="/login" element={<LoginForm />} />
				</Routes>
			</AppContainer>
		</BrowserRouter>
	)
}

export default Root;

