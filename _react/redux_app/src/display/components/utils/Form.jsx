import React from 'react'

const Form = ({handleSubmit, data, checkEdit}) => {
	return (
		<>
			<form action={handleSubmit}>
				<div className="form_element">
					<label htmlFor="name">Name</label>
					<input type="text" id="name" name="name" className='input_default' defaultValue={data?.name} />
				</div>
				<div className="form_element">
					<label htmlFor="price">Price</label>
					<input type="text" id="price" name="price" className='input_default' defaultValue={data?.price} />
				</div>
				<div className="form_element">
					<button className='btn'>{!checkEdit ? "Add" : "Modify"}</button>
				</div>
			</form>
		</>
	)
}

export default Form