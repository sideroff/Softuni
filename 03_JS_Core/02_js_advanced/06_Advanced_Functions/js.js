/**
 * Created by ivans on 28-Oct-16.
 */
window.onload = function onWindowLoad() {
    sortArray()
    argumentInfo()
    functionalSum()
    personalBMI()
}
function sortArray() {
    $('#sortArr').on('click',function () {
        let numbers = Array.from($('#arr').val().split(' ').map(n => Number(n)))
        let method = $('#method').val()
        console.log(actualSort(numbers,method))
    })
    function actualSort(numbers, method) {
        if(method == 'asc'){
            numbers.sort((a,b) => a-b)
        }
        else if(method =='desc'){
            numbers.sort((a,b) => b-a)
        }
        return numbers
    }
}

function argumentInfo() {
    $('#execArgInfo').on('click',function () {
        //this one is a bit buggy because of eval
        let args = Array.from($('#args').val().split(',').map(e=>eval(e.trim())))
        //this gives correct result
        //let args = [42,'str',function () { console.log('hello world!') }]
        logArgs.apply(this,args)
    })

    function logArgs (...names) {
        let summary = {}
        for (let i = 0; i < names.length; i++) {
            let type = typeof names[i]
            if (!summary[type]) {
                summary[type] = 1
            } else {
                summary[type]++
            }
            console.log(typeof names[i] + ': ' + names[i])
        }
        let sortedTypes = []
        for (let curr in summary) {
            sortedTypes.push([curr, summary[curr]])
            sortedTypes.sort(
                function(a, b) { return b[1] - a[1] })
        }
        for (let summ of sortedTypes) {
            console.log(summ[0] + ' = ' + summ[1])
        }
    }

}

function functionalSum(){
    $('#execFunc').on('click',function () {
        let add = (() => {
            let sum = 0
            return function func(num){
                sum+=Number(num)
                func.toString =  () => sum
                return func
            }
        })()
        console.log(eval($('#func').val()))
    })
}

function personalBMI() {
    $('#execBMI').on('click',function () {
        let args = Array.from($('#bmi').val().split(' ').map(a=>Number(a)||a))
        console.log(createObj.apply(this,args))
        function createObj(name, age, weight, height) {
            let bmi = weight/(height/100*height/100)
            let status
            if(bmi<18.5){
                status = 'underweight'
            }
            else if (bmi < 25){
                status = 'normal'
            }
            else if(bmi<30){
                status = 'overweight'
            }
            else if (bmi>=30){
                status = 'obese'
            }
            let obj = {
                'name': name,
                'personalInfo': {
                    'age': Math.round(age),
                    'weight': Math.round(weight),
                    'height': height
                },
                'BMI': Math.round(bmi),
                'status': status }
            if(status == 'obese'){
                obj['recommendation'] = 'admission required'
            }
            return obj
        }
    })
}

let v = (function vector(){
    return {
        add: (v1,v2) => [v1[0]+v2[0],v1[1]+v2[1]],
        multiply: (v1,s) => [v1[0]*s,v1[1]*s],
        length: (v1) => Math.sqrt(v1[0]*v1[0] + v1[1]*v1[1]),
        dot: (v1,v2) => v1[0]*v2[0]+v1[1]*v2[1],
        cross: (v1,v2) => v1[0]*v2[1]-v1[1]*v2[0]
    }
})()
console.log('vectors')
console.log(v.add([1,1],[1,0]))
console.log(v.multiply([3.5,-2],2))
console.log(v.length([3,-4]))
console.log(v.dot([1, 0], [0, -1]))
console.log(v.cross([3, 7], [1, 0]))

let r = (function () {
    let robot = {
        'protein' : 0,
        'carbohydrate' : 0,
        'fat' : 0,
        'flavour' : 0
    }
    let recipes = {
        'apple': {carbohydrate: 1, flavour: 2},
        'coke': {carbohydrate: 10, flavour: 20},
        'burger': {carbohydrate: 5, fat: 7, flavour: 3},
        'omelet': {protein: 5, fat: 1, flavour: 1},
        'cheverme': {protein: 10, carbohydrate: 10, fat: 10, flavour: 10}
    }
    return function processCmd(command){
        let [cmd, arg, quantity] = command.split(' ').map(a=>Number(a) || a)
        if(cmd == 'restock'){
            robot[arg] +=quantity
            return 'Success'
        }
        else if(cmd == 'report'){
            return [...Object.keys(robot)]
                .map(c => c + '=' + robot[c])
                .join(' ')
        }
        else if(cmd == 'prepare'){
            let keys = [...Object.keys(recipes[arg])]
            for(let key of keys){
                if(robot[key]< recipes[arg][key] * Number(quantity)){
                    return `Error: not enough ${key} in stock`
                }
            }
            for(let key of [...Object.keys(recipes[arg])]){
                robot[key]-= recipes[arg][key] * quantity
            }
            return 'Success'
        }
    }
})()
console.log('robot')
console.log(r('report'))
console.log(r('restock carbohydrate 1'))
console.log(r('report'))
console.log(r('restock flavour 2'))
console.log(r('report'))
console.log(r('prepare apple 1'))
console.log(r('report'))

function votingSystem (action) {
    let that = this
    let patcher = (() => {
        function upvote () {
            that.upvotes++
        }

        function downvote () {
            that.downvotes++
        }

        function fakeRecords (num) {
            return 0.25 * num
        }

        function calcRating () {
            let votes = that.upvotes + that.downvotes
            if (votes >= 10) {
                if (that.upvotes / votes > 0.66) {
                    return 'hot'
                } else if (that.upvotes - that.downvotes >= 0 &&
                    that.upvotes > 100 || that.downvotes > 100) {
                    return 'controversial'
                } else if (that.upvotes - that.downvotes < 0) {
                    return 'unpopular'
                }
            }

            return 'new'
        }

        let rating = calcRating()

        function score () {
            let ups = that.upvotes
            let downs = that.downvotes

            let total = that.upvotes - that.downvotes
            if (that.downvotes + that.upvotes > 50) {
                let moreVotes = fakeRecords(Math.max(that.upvotes, that.downvotes))
                ups = Math.ceil(that.upvotes + moreVotes)
                downs = Math.ceil(that.downvotes + moreVotes)
            }

            return [ups, downs, total, rating]
        }

        return { upvote, downvote, score }
    })()

    return patcher[action]()
}

function gcd(a, b) {
    if (!b) return a
    return gcd(b, a % b)
}
console.log(gcd(30,180))