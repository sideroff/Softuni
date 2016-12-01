const url = require('url')
let fs = require('fs')

module.exports = (req, res) => {
    let pathname = url.parse(req.url).pathname

    if (req.method == "GET") {
        console.log(pathname)
        if (pathname.startsWith('/content/')) {
            require('./loadContent.js')(req, res, pathname)
        } else if (pathname == '/') {
            require('./index')(req, res)
        } else if (pathname == '/create') {
            require('./create')(req, res)
        } else if (pathname == '/all') {
            require('./all')(req, res)
        } else {
            require('./index')(req, res)
        }
    } else if (req.method == "POST") {
        if (pathname == "/create") {
            require('./addTodo')(req, res)
        }
    }
}