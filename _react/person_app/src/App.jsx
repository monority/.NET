import { useState } from 'react'
import './App.css'
import Person from './Person'

function App() {
	const [persons, setPersons] = useState([
		{
			id: 1,
			firstname: 'John',
			lastname: 'Doe'
		},
		{
			id: 2,
			firstname: 'Jane',
			lastname: 'Doe'
		},
		{
			id : 3,
			firstname: 'James',
			lastname: 'Smith'
		}
	])

	const personMap = persons.map(person => {
		return (
			<Person
				key={person.id}
				id={person.id}
				firstname={person.firstname}
				lastname={person.lastname}
			/>
		)
	})
	return (
		<>
			<div className="container">
				<table>
					<thead>
						<tr>
							<th>#</th>
							<th>Firstname</th>
							<th>Lastname</th>
						</tr>
					</thead>
					{personMap}
				</table>
			</div>
		</>
	)
}

export default App
