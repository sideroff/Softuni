/**
 * Created by ivans on 10-Nov-16.
 */
class Post {
    constructor(title,body,author) {
        this.title = title
        this.body = body
        this.author = author
    }
    addToSelector(selector){
        let obj = $('<div>')
        obj.addClass(`post ${this.author}`)
        obj.append($('<h3>').addClass('title').text(this.title))
        obj.append($('<p>').addClass('body').text(this.body))
        obj.append($('<p>').addClass(`author ${this.name}`).text(this.author))
        $(selector).append(obj)
    }
}

module.exports = Post