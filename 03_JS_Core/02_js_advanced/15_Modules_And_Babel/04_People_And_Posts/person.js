/**
 * Created by ivans on 10-Nov-16.
 */
class Person {
    constructor(name,age){
        this.name = name
        this.age = age
    }
    addToSelector(selector){
        let obj = $('<div>')
        obj.addClass(`person ${this.name}`)
        obj.append($('<p>').addClass('name').text(this.name))
        obj.append($('<p>').addClass('age').text(this.age))
        obj.append($('<div>').addClass(`posts ${this.name}`))
        $(selector).append(obj)
    }

}

module.exports = Person