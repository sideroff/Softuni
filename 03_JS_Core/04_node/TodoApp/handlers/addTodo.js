const multiparty = require('multiparty')

module.exports = (req, res) => {
    let form = new multiparty.Form()
    form.parse(req, (err, fields, files) => {
        if (err) console.log(err)
        console.dir(files)
        if (!fields.title || !fields.description || !files.avatar[0]) {
            let html = 'Go <a href="/create">back</sa> to create form, sorry!'
            res.send(html)
            return
        }
        let newTodo = {}
        newTodo.title = fields.title
        newTodo.description = fields.description
        newTodo.avatar = files.avatar[0].path

        require('./db').push(newTodo)
        
        res.writeHead(302, {location:'/all'})
        res.end()
    })
}