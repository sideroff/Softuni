/**
 * Created by ivans on 30-Oct-16.
 */

(function extend() {
    Array.prototype.last = function () {
        return this[this.length-1]
    }
    Array.prototype.skip = function (n) {
        let newArr = []
        for(let i = n;i < this.length; i++){
            newArr.push(this[i])
        }
        return newArr
    }
    Array.prototype.take = function (n) {
        let newArr = []
        for(let i = 0;i < n && i<this.length; i++){
            newArr.push(this[i])
        }
        return newArr
    }
    Array.prototype.sum = function () {
        return this.reduce((a,b) => a+b)
    }
    Array.prototype.average = function () {
        return this.sum()/this.length
    }
})()

function workers(obj) {
    if(!obj['handsShaking']){
        return obj
    }
    obj['bloodAlcoholLevel'] += obj['weight']/10 * obj['experience']
    obj['handsShaking'] = false
    return obj
}

function carMaker(obj) {
    let engines = [{power:90,volume:1800},
        {power:120,volume:2400},
        {power:200,volume:3500}]
    obj['engine'] = engines.filter(e=>obj['power'] <= e['power'])[0]
    delete obj['power']
    obj['carriage'] = {type:obj['carriage'], color:obj['color']}
    obj['wheelsize'] = Math.floor(obj['wheelsize'])
    if(obj['wheelsize']%2==0){
        obj['wheelsize']--
    }
    obj['wheels'] = [obj['wheelsize'],obj['wheelsize'],obj['wheelsize'],obj['wheelsize']]
    delete obj['wheelsize']
    return obj
}
// console.log(carMaker({
//     model: 'Opel Vectra',
//     power: 110,
//     color: 'grey',
//     carriage: 'coupe',
//     wheelsize: 17
// }
// ))

function getExtendableObj() {
    let me = {
        extend: (other) => {
            for(let key of [...Object.keys(other)]){
                if(typeof (other[key]) == 'function'){
                    me.__proto__[key] = other[key]
                }
                else{
                    me[key] = other[key]
                }
            }
        }
    }
    return me
}

// let obj = getExtendableObj()
// let other = {func: function () {
//     let a = 5
// },variable: 'string'}
// obj.extend(other)
// console.log(obj.__proto__)
// console.log(obj)

(function extendStr() {
    String.prototype.ensureStart = function (str) {
        let newStr = this
        if (!this.startsWith(str)) {
            newStr = str + this
        }
        return newStr.toString()
    }

    String.prototype.ensureEnd = function (str) {
        let newStr = this
        if (!this.endsWith(str)) {
            newStr = this + str
        }
        return newStr.toString()
    }

    String.prototype.isEmpty = function () {
        if (this.length === 0) {
            return true
        }
        return false
    }

    String.prototype.truncate = function (n) {
        if(this.length <= n){
            return this.toString()
        }
        let tokens = this.split(' ')
        let result = tokens[0]

        for(let i = 1; i < tokens.length;i++){
            if(result.length + tokens[i].length + 4 > n){
                return result + '...'
            }
            result += ` ${tokens[i]}`
        }
    }

    String.format = function () {
        // console.log(arguments)
        var argsRaw = Array.prototype.slice.call(arguments)
        var args = argsRaw.slice(1, argsRaw.length)
        let str = Array.prototype.slice.call(arguments)[0]
        return str.replace(/{(\d+)}/g, function (match, number) {
            if (number <= argsRaw.length) {
                return typeof args[number] != 'undefined'
                    ? args[number]
                    : match
            } else {
                return ''
            }
        })
    }
})()

function generateLinkedList() {
    return (function () {
        let storage = []

        function getSize() {
            return storage.length
        }

        function add(element) {
            storage.push(element)
            reSort()
        }

        function remove(index) {
            if (isValidIndex(index)) {
                storage.splice(index, 1)
                reSort()
            } else {
                throw new Error
            }
        }

        function reSort() {
            storage = storage.sort((a, b) => a - b)
        }

        function isValidIndex(index) {
            return index >= 0 && index < storage.length

        }

        function get(index) {
            if (isValidIndex(index)) {
                return storage[index]
            } else {
                throw new Error
            }
        }

        let a = {add, remove, get}
        a.__defineGetter__('size', getSize)
        return a
    })()
}

function colorize(selector) {
    let element = $(selector);

    let bestDepth = -1;
    let bestSelector;

    findDeepestChild(0, element);

    function findDeepestChild(depth, selector) {
        if (depth > bestDepth) {
            bestDepth = depth;
            bestSelector = selector;
        }

        let children = selector.children();
        for (let child of children) {
            findDeepestChild(depth + 1, $(child));
        }
    }

    while (true) {
        bestSelector.addClass('highlight');
        if (bestSelector.attr('id') == element.attr('id')) {
            return;
        }

        bestSelector = bestSelector.parent();
    }
}

function generateBugManager() {
    let id = 0
    let bugs = []
    let printer = undefined

    function report(author, description, reproducible, severity) {
        let newReport = {
            ID: id++,
            author: author,
            description: description,
            reproducible: reproducible,
            severity: severity,
            status: 'Open'
        }

        bugs.push(newReport)
        sort()
    }

    function setStatus(id, newStatus) {
        bugs.filter(r => r.ID == id)[0].status = newStatus
        sort()
    }

    function remove(id) {
        bugs = bugs.filter(r => r.ID != id)
        sort()
    }

    function sort(method = 'ID') {
        switch (method) {
            case 'ID':
                bugs = bugs.sort((a, b) => a.ID - b.ID)
                break
            case 'author':
                bugs = bugs.sort((a, b) => a.author.toString().localeCompare(b.author.toString()))
                break
            default: // severity
                bugs = bugs.sort((a, b) => a.severity - b.severity)
        }

        updateScreen()
    }

    function output(selector) {
        printer = selector
    }

    function updateScreen() {
        if (printer) {
            let parent = $(printer)
            parent.text('')
            for (let bug of bugs) {
                let html = formatBug(bug)
                parent.append(html)
            }
        }
    }

    function formatBug(bug) {
        return $('<div>')
            .attr('id', 'report_' + bug.ID)
            .addClass('report')
            .append($('<div>')
                .addClass('body')
                .append($('<p>')
                    .text(bug.description)))
            .append($('<div>')
                .addClass('title')
                .append($('<span>')
                    .addClass('author')
                    .text('Submitted by: ' + bug.author))
                .append($('<span>')
                    .addClass('status')
                    .text(bug.status + ' | ' + bug.severity)))
    }

    return {report, setStatus, remove, sort, output}
}