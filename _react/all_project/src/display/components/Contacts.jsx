import React from 'react'
import ContactCard from './ContactCard'

const Contacts = ({ contacts }) => {

	const displayContact = () => {
		return (
			<>
				{contacts && contacts.map((contact) => (
					<ContactCard key={contact.id} name={contact.name} nickname={contact.nickname} lift={contact.lift} />
				))}
			</>
		)
	}
	return (
		<>
			<div className="container">
				<table id="contactcard" className='w_100'>

					<thead className='w_100 flex'>
						<tr className='flex gap1 between w_100'>
							<th>Name</th>
							<th>Nickname</th>
							<th>Lift</th>
						</tr>
					</thead>
					{displayContact()}
				</table>
			</div>
		</>
	)
}

export default Contacts