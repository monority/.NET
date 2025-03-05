import { User } from './User.js';
export function CreateUser(id, firstName, lastName, dateOfBirth, email, phone) {
    return new User(id, firstName, lastName, dateOfBirth, email, phone);
}
