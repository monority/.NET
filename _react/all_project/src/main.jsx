import React from 'react'
import ReactDOM from 'react-dom/client'
import './assets/sass/main.scss'
import { RouterProvider } from 'react-router-dom'
import router from './display/RoutingEx/app-routing'
ReactDOM.createRoot(document.getElementById('root')).render(
	<React.StrictMode>
		<RouterProvider router={router} />
	</React.StrictMode>
)