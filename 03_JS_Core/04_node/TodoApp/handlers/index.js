let fs = require('fs')

module.exports = (req, res) => {
    let headers = require('./headers')('Todos')
    let footers = require('./footers')()
    let content = `<h1>Welcome to my simple todo-making app :)</h1>`
    
    res.writeHead(200, {
        'Content-Type': 'text/html'
    })
    res.write(headers + content + footers)
    res.end()
}
