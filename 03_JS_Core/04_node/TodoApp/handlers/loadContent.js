let fs = require('fs')

let contentType = {
    'ico': 'image/x-icon',
    'css': 'text/css',
    'js': 'text/javascript'
}

module.exports = (req, res, pathname) => {

    let file
    fs.readFile('.' + pathname, (err, data) => {
        let code
        if (err) {
            code = 400
            data = 'Not Found.' + err
        } else {
            code = 200
        }

        let fileExtention = pathname.split('.').pop()

        res.writeHead(code, { 'Content-Type': contentType[fileExtention] })
        res.write(data)
        res.end()
    })
}