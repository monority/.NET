import { createBrowserRouter } from "react-router-dom"
import Header from './display/components/ui/Header'
import App from "./App";

const router = createBrowserRouter([
	// {path: "/", element: <HomePage />, errorElement: <ErrorPage />},
	// {path: "/form", element: <FormPage />, errorElement : <ErrorPage />}
	{
		path: "/",
		element: <Header />,
		children: [
			{ path: "/", element: <App /> },
		]
	}
])

export default router