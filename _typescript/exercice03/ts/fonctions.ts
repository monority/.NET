import { User } from './User.js';

export function CreateUser( id: string, firstName: string, lastName: string, dateOfBirth: string, email: string, phone: string): User {
	return new User(id, firstName, lastName, dateOfBirth, email, phone);
}

