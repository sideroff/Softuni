/**
 * Created by ivans on 02-Nov-16.
 */

class Person {
    constructor(firstName, lastName, age, email){
        this.firstName = firstName
        this.lastName = lastName
        this.age = age
        this.email = email
    }
    toString(){
        return `${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})`
    }
}

function getPeople() {
    //for judge => define class inside this func
    return [new Person('Maria','Petrova',22,'mp@yahoo.com'),
    new Person('SoftUni'),
    new Person('Stephan','Nikolov',25),
    new Person('Peter','Kolev',24,'ptr@gmail.com')]
}