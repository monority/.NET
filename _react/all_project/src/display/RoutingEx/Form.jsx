import { useLayoutEffect, useState } from "react";
import { Link, useOutletContext, useParams, useSearchParams } from "react-router-dom";

const Form = () => {

	const { id } = useParams()

	const [searchParams] = useSearchParams();
	const [users, setUsers] = useOutletContext();
	const [data, setData] = useState({
		firstName: "",
		lastName: "",
		email: "",
		phone: "",
		id: id ? id : users.length + 1
	}
	)

	const modeEdit = searchParams?.get("mode");
	useLayoutEffect(() => {
		console.log(searchParams?.get("mode"));
		console.log(id)
	}, [searchParams, id]);


	const registerUser = (formData) => {
		if (modeEdit == "edit") {
			const index = users.findIndex(user => user.id == id);
			formData.forEach((name, value) => {
				data[value] = name;
			});
			users[index] = { ...users[index], ...data };
			setUsers([...users]);
			return;
		}
		else if (modeEdit == "delete") {
			const index = users.findIndex(user => user.id == id);
			users.splice(index, 1);
			setUsers([...users]);
			return;
		}
		else {

			formData.forEach((name, value) => {
				data[value] = name;
			})
			setUsers([...users, data]);
		}
	}
	const findUser = users?.find(user => user?.id == id);
	return (
		<>
			<form action={registerUser}>
				<div className="flex column gap2">
					<div className="flex row gap1">
						<label htmlFor="firstName">First Name</label>
						<input type="text" name="firstName" id="firstName" required defaultValue={findUser?.firstName} />
					</div>
					<div className="flex row gap1">
						<label htmlFor="lastName">Last Name</label>
						<input type="text" name="lastName" id="lastName" required defaultValue={findUser?.lastName} />
					</div>
					<div className="flex row gap1">
						<label htmlFor="email">Email</label>
						<input type="text" name="email" id="email" required defaultValue={findUser?.email} />

					</div>
					<div className="flex row gap1">
						<label htmlFor="phone">Phone</label>
						<input type="tel" name="phone" id="phone" required defaultValue={findUser?.phone} />
					</div>
					<button type="submit">
						{modeEdit === 'delete' ? 'Delete' : modeEdit === 'edit' ? 'Save Changes' : 'Add User'}
					</button>
				</div>
			</form>
		</>
	);
}

export default Form;