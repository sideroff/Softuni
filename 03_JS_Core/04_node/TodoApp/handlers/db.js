let db = []

module.exports = {
    push: (obj) => {
        db.push(obj)
    },
    getDb: () =>{
        return db
    }
}
