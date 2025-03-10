import React from 'react';
import { Link, useOutletContext } from 'react-router-dom';
import UserCard from '../components/ui/UserCard';

const Home = () => {
	const [users, setUsers] = useOutletContext();

	const usersDisplay = users.map((user) => {
		return (
			<li key={user.id}>
				<UserCard
					firstName={user.firstName}
					lastName={user.lastName}
					phone={user.phone}
					email={user.email}
					id={user.id}
				/>
			</li>
		);
	});

	return (
		<>
			<section id="home">
				<div className="container">
					<div className="wrapper">
						<ul className="wrapper_column gap2">
							{usersDisplay}
						</ul>
					</div>
				</div>
			</section>
		</>
	);
}

export default Home;