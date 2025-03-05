export class User {
    id: string
    firstName: string
    email: string
	lastName : string
	phone : string
	dateOfBirth : string
    constructor(id: string, firstName: string, lastName: string, email: string, phone: string , dateOfBirth: string) {
		this.id = id
		this.firstName = firstName
		this.lastName = lastName
		this.email = email
		this.phone = phone
		this.dateOfBirth = dateOfBirth
	}
    // méthodes
    getDetails(): string {
      return `id : ${this.id}, firstName : ${this.firstName}, lastName : ${this.lastName}, email : ${this.email}, phone : ${this.phone}`
    }
}
