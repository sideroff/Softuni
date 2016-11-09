/**
 * Created by ivans on 06-Nov-16.
 */
//classes are in 1 file because of the automated judge system ->
// it accepts a function that returns both classes
function solve() {
    class Person {
        constructor(name,email){
            this.name = name
            this.email = email
        }
    }

    class Teacher extends Person{
        constructor(name,email,subject){
            super(name,email)

            this.subject = subject
        }
    }

    return {Person,Teacher}
}