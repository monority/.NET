import React from 'react'

const Task = ({ id, name, action }) => {
	return (
		<>
			<div className="flex gap1">
				<div className="element">
					{id}
				</div>
				<div className="element">
					{name}
				</div>
				<div className="element">
					<button className='btn' onClick={action}>-</button>
				</div>
			</div>
		</>
	)
}

export default Task