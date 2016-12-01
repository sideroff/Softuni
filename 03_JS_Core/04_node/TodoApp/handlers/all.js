

let db = require('./db').getDb()

module.exports = (req, res) => {
    let headers = require('./headers')('All Todos')
    let footers = require('./footers')()
    let content = ''

    db.forEach((value,index) => {
        content += 
        `<li data-todo-id=${index}>Title: ${value.title}, Description: ${value.description}
            <button class='editTodo'>Edit</button>
        </li>`
    })
    if (content != '') {
        content = `<ul>` + content + `</ul>`
    } else {
        content = 'No saved todos. :('
    }

    res.writeHead(200, {
        'Content-Type': 'text/html'
    })
    res.write(headers + content + footers)
    res.end()
}