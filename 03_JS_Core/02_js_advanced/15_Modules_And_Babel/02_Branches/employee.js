/**
 * Created by ivans on 10-Nov-16.
 */

class Employee{
    constructor(name,age,position){
        this.name = name
        this.age = age
        this.position = position
    }

    toString(){
        return `${this.name}, ${this.age} (${this.position})`
    }
}


module.exports = Employee