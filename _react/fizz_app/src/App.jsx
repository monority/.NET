import React, { useState } from 'react'

const App = () => {
	const [display, setDisplay] = useState(1)
	const displayInput = () => {
		if (display % 15 === 0) {
			return "FizzBuzz";
		} else if (display % 5 === 0) {
			return "Buzz";
		} else if (display % 3 === 0) {
			return "Fizz";
		} else {
			return display;
		}
	}
	const increment = () => {
		if (display < 100) {
			setDisplay(display + 1);
		}
	}
	const decrement = () => {
		if (display > 1) {
			setDisplay(display - 1);
		}
	}
	return (
		<>
			<div id="app">

				<div className="flex column gap2">
					<div className="element">
						<h1>Task List</h1>
					</div>
					<div className="flex gap1">
						<button className='btn bg_color02' onClick={() => increment()}>+</button>
						<button className='btn bg_color03' onClick={() => decrement()}>-</button>
					</div>

					<div className="element">
						<p style={{fontSize : "calc(2rem + 0.3vw)" , color :"rgb(228, 228, 228)"}}>{displayInput()}</p>

					</div>
				</div>
			</div >
		</>
	)
}

export default App