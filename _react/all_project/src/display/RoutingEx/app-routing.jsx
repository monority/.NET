import { createBrowserRouter } from "react-router-dom"
import Home from "./pages/Home"
import Error from "./pages/Error"
import Form from "./pages/Form";
import Header from './pages/Header';

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