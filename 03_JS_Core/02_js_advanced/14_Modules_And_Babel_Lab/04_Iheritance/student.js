/**
 * Created by ivans on 09-Nov-16.
 */
let Person = require('./person')

class Student extends Person{
    constructor(name,phrase,dog,id){
        super(name,phrase,dog)
        this.id = id
    }
    saySomething(){
        return `Id: ${this.id} ${this.name} says: ${this.phrase}${this.dog.name} barks!`
    }
}
module.exports = Student