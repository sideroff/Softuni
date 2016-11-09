/**
 * Created by ivans on 09-Nov-16.
 */
let arr = require('./data')
function sorting(property) {
    return Array.from([...arr.sort((a,b) => a[property].toString().localeCompare(b[property].toString()))])
}
function filter(property, value) {
    return Array.from([...arr.filter(a => a[property] == value)])
}

module.exports = {sorting,filter}