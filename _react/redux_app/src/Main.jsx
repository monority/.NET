import React from 'react'
import ReactDOM from 'react-dom/client'
import Root from './Root'
import './assets/sass/main.scss'
import { Provider } from 'react-redux'
import store from './store'
ReactDOM.createRoot(document.getElementById('root')).render(
	<React.StrictMode>
		<Provider store={store} >
			<Root />
		</Provider>
	</React.StrictMode>,
)