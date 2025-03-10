import React, { useState } from 'react'
import Form from './display/components/Form'
import Contacts from './display/components/Contacts'

const App = () => {
	const [contacts, setContacts] = React.useState([])

	return (
		<>
			<div id="app">
				<Form contacts={contacts} setContacts={setContacts} />
				<Contacts contacts={contacts} />
			</div >
		
		</>
	)
}

export default App