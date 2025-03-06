import React, { useState } from 'react'
import Task from './display/components/Task';

const App = () => {
	const [list, setList] = useState(JSON.parse(localStorage.getItem('list')) || []);

	
	const taskMap = list.map((item, index) => {
		return (

			<Task key={item.id} id={item.id} name={item.name} action={(e) => removeTask(e, item.id)} />
		)
	})

	const addToList = (e) => {
		e.preventDefault();
		const task = e.target.task.value;
		const id = list.length + 1;
		const newList = [...list, { id, name: task }];
		localStorage.setItem('list', JSON.stringify(newList));
		setList(newList);
	}

	const removeTask = (e, id) => {

		e.preventDefault();
		const newList = list.filter((item) => item.id !== id);
		localStorage.setItem('list', JSON.stringify(newList));
		setList(newList);
	}
	return (
		<>
			<div id="app">
				<div className="flex column gap2">
					<div className="element">
						<h1>Listing App</h1>

					</div>
					<form action="" onSubmit={(e) => addToList(e)} className="flex gap1">
						<div className="form_group flex column gap2">
							<div className="form_element flex gap1">
								<label htmlFor="task">Task</label>
								<input type="text" name="task" id="task" />
							</div>
						</div>

						<button type="submit" className='btn'>+</button>
					</form>
					<div className="element">
						{taskMap}
					</div>
				</div>

			</div>
		</>
	)
}

export default App