import React, { useState } from 'react'

const Form = ({ contacts, setContacts }) => {
	const [name, setName] = useState('')
	const [nickname, setNickname] = useState('')
	const [lift, setLift] = useState('')
	const [id, setId] = useState('')

	const addContact = (e) => {
		e.preventDefault();
		setContacts([...contacts, { id, name, nickname, lift }])
		setName('')
		setNickname('')
		setLift('')
	}

	const handleChange = (e) => {
		const { name, value } = e.target
		if (name === 'name') setName(value)
		if (name === 'nickname') setNickname(value)
		if (name === 'lift') setLift(value)
		setId(contacts.length + 1)
	}

	return (
		<>
			<form action="" onSubmit={addContact}>
				<div className="flex column gap2 form_group">
					<div className="flex gap1 form_element">
						<label htmlFor="name">Name</label>
						<input type="text" name="name" id="name" value={name} onChange={(e) => handleChange(e)} required maxLength={12} />
					</div>
					<div className="flex gap1 form_element">
						<label htmlFor="nickname">Nickname</label>
						<input type="text" name="nickname" id="nickname" value={nickname} onChange={(e) => handleChange(e)} required maxLength={12} />
					</div>
					<div className="flex gap1 form_element">
						<label htmlFor="lift">How much you lift</label>
						<input type="text" name="lift" id="lift" value={lift} onChange={(e) => handleChange(e)} required maxLength={3} />
					</div>

				</div>
				<div className="form_element">
					<button type="submit" className='btn'>+</button>
				</div>
			</form>
		</>
	)
}

export default Form
