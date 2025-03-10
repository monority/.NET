import Auth from "./display/components/Auth";
import LoginForm from "./display/components/LoginForm";
import React from 'react'

function Login() {

	const logUserInfos = (username, password) => {
		console.log(username);
		console.log(password);
	}

	return (
		<>
			<Auth logUserInfos={logUserInfos} />
		</>
	)
}

export default Login
