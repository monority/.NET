import React from 'react'
import { Link } from 'react-router-dom'

const UserCard = ({ firstName, lastName, id, phone, email }) => {
	return (

		<div id="user_card">
			<div className="element">
				<p>{firstName}</p>
			</div>
			<div className="element">
				<p>{lastName}</p>
			</div>
			<div className="element">
				<p>{phone}</p>
			</div>
			<div className="element">
				<p>{email}</p>
			</div>
			<div className="wrapper_row gap2">
				<div className="element">
					<Link className='btn btn_delete' to={`/edit/${id}?mode=delete`}>Delete</Link>
				</div>
				<div className="element">
					<Link className='btn btn_edit' to={`/edit/${id}?mode=edit`}>Edit</Link>
				</div>
			</div>
		</div >
	)
}

export default UserCard