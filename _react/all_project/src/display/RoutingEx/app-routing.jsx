import { createBrowserRouter } from "react-router-dom"
import Home from "./Home"
import Error from "./Error"
import Form from "./Form";
import Header from './Header';
import Profil from './Profil';
const router = createBrowserRouter([
	// {path: "/", element: <HomePage />, errorElement: <ErrorPage />},
	// {path: "/form", element: <FormPage />, errorElement : <ErrorPage />}
	{
		path: "/",
		element: <Header />,
		errorElement: <Error />,
		children: [
			{ path: "/", element: <Home /> },
			{ path: "/edit/:id", element: <Form /> },
		]
	}
])

export default router