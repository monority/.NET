export class User {
    constructor(id, firstName, lastName, email, phone, dateOfBirth) {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.phone = phone;
        this.dateOfBirth = dateOfBirth;
    }
    // méthodes
    getDetails() {
        return `id : ${this.id}, firstName : ${this.firstName}, lastName : ${this.lastName}, email : ${this.email}, phone : ${this.phone}`;
    }
}
