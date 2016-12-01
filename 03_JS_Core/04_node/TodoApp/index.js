let http = require('http')

let port = 8080

http.createServer((req,res) => {
    require('./handlers/master')(req,res)
}).listen(port)

console.log('listening on port ' + port)
