import React from 'react'
import ContactCard from './ContactCard'

const Contacts = ({ contacts }) => {

	const displayContact = () => {
		return (
			<>
				{contacts && contacts.map((contact, index) => (
					<>

						<ContactCard key={index} name={contact.name} nickname={contact.nickname} lift={contact.lift} />
					</>
				))}
			</>
		)
	}
	return (
		<>
			<div className="container">
				<div className="wrapper">
					<thead className='w_100 flex'>
						<tr className='flex gap1 between w_100'>
							<th>Name</th>
							<th>Nickname</th>
							<th>How much you lift</th>
						</tr>
					</thead>
					{displayContact()}
				</div>
			</div>
		</>
	)
}

export default Contacts