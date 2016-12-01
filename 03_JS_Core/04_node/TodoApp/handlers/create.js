let fs = require('fs')

module.exports = (req,res) => {
    let headers = require('./headers')('Create Todo')
    let footers = require('./footers')()
    let content = 
    `<form action="/create" method="POST" enctype="multipart/form-data">
        <input type="text" name="title" placeholder="Title" required="required">
        <br />
        <input type="text" name="description" placeholder="Description" required="required">
        <br />        
        <input type="file" name="avatar" placeholder="choose a file..." required="required">
        <br />        
        <input type="submit" value="Submit">
    </form>`
    
    res.writeHead(200, {
        'Content-Type': 'text/html'
    })
    res.write(headers + content + footers)
    res.end()

}