import React from 'react'

const ContactCard = ({ name, nickname, lift }) => {
	return (
	
			<tbody className='flex gap1 between w_100'>
				<tr>

					<td>{name}</td>
				</tr>
				<tr>

					<td>{nickname}</td>
				</tr>
				<tr>

					<td>{lift}</td>
				</tr>
			</tbody>
	)
}

export default ContactCard