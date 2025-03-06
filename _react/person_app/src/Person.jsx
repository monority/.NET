import React from 'react'

const Person = ({firstname, lastname, id}) => {
	return (
		<>
		
				<tbody>
					<tr>
						<td>{id}</td>
						<td>{firstname}</td>
						<td>{lastname}</td>
					</tr>
				</tbody>
			
		</>
	)
}

export default Person