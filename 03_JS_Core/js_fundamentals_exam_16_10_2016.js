/**
 * Created by ivans on 16-Oct-16.
 * EXAM AND EXERCISES CAN BE FOUND AT https://judge.softuni.bg/Contests/325/JS-Fundamentals-Exam-16-October-2016
 */

function Arithmephile(args){
    let maxProduct = Number.NEGATIVE_INFINITY;
    let hasChanged = false
    for(let i = 0;i<args.length; i++){
        let number = Number(args[i])
        if(number>=0 && number<10){
            let currentProduct = 1
            let index = i+1
            let multiplierFor = number
            while(multiplierFor>0 && index < args.length){
                hasChanged = true
                multiplierFor--
                currentProduct *= Number(args[index])
                index++

            }
            if(hasChanged && currentProduct>=maxProduct){
                maxProduct=currentProduct
                currentProduct = 1
            }
            hasChanged = false
        }
    }
    console.log(maxProduct)
}

// Arithmephile(['100',
//     '200',
//     '2',
//     '3',
//     '2',
//     '3',
//     '2',
//     '1',
//     '1'])

function Rosetta_Stone(args) {
    let encoded = []
    let decoder = []
    let decoded = []
    let rowsCols = Number(args[0])
    let lineLenght
    for(let i = 1; i<args.length && i<=rowsCols; i++){
        let decoders = args[i].split(' ').map(Number)
        decoder.push(decoders)
        lineLenght = decoders.length
    }
    for(let i = rowsCols+1; i<args.length; i++){
        let numbers = args[i].split(' ').map(Number)
        encoded.push(numbers)
        decoded.push(numbers)
    }
    for(let row = 0; row<encoded.length; row+=rowsCols){
        for(let col = 0; col<encoded[row].length; col+=lineLenght){
            let x, y
            for(let i = row,  x = 0; i < encoded.length && i<row+rowsCols; i++, x++){
                for(let j = col, y=0; j<encoded[row].length && j<col+lineLenght; j++, y++){


                    let character =(encoded[i][j] + decoder[x][y]) % 27
                    if(character==0){
                        character= ' '
                    }
                    else{
                        character =String.fromCharCode(character+64)
                    }
                    decoded[row+x][col+y] = character
                }
            }
        }
    }
    let output = ''
    for(line of decoded){
        output+= line.join('')
    }
    console.log(output)
}

// Rosetta_Stone([ '2',
//     '59 36',
//     '82 52',
//     '4 18 25 19 8',
//     '4 2 8 2 18',
//     '23 14 22 0 22',
//     '2 17 13 19 20',
//     '0 9 0 22 22' ])

// Rosetta_Stone([ '2',
//     '31 32',
//     '74 37',
//     '19 0 23 25',
//     '22 3 12 17',
//     '5 9 23 11',
//     '12 18 10 22' ])

// Rosetta_Stone(['1',
// '1 3 13',
// '12 22 14 13 25 0 4 24 23',
// '18 24 2 25 22 0 0 11 18',
// '8 25 6 26 8 23 13 4 14',
// '14 3 14 10 6 1 6 16 14',
// '11 12 2 10 24 2 13 24 0',
// '24 24 10 14 15 25 18 24 12',
// '4 24 0 8 4 22 19 22 14',
// '0 11 18 26 1 19 18 13 15',
// '8 15 14 26 24 14 26 24 14'])


function spyMater(args) {
    String.prototype.replaceAll = function(search, replacement) {
        let target = this;
        return target.replace(new RegExp(search, 'gi'), replacement);
    };

    let key = args[0]
    args.splice(0,1)
    let regex = new RegExp('(?:^|[\\s+])(?:' + key.toLowerCase() + '\\s+)([A-Z!%\\$#]{8,})(?:$|[\\s\\.,])','g')
    for(line of args){
        let replaced = line +'';
        replaced = replaced.replaceAll(key,key.toLowerCase())
        let result, indices = []
        while(result = regex.exec(replaced)){
            let innerIndex = result[0].indexOf(result[1])
            let index = replaced.indexOf(result[0]) + innerIndex
            let word = result[1]
            let modified = word.toLowerCase().replaceAll(/!/,"1")
            modified = modified.replaceAll(/%/,"2")
            modified = modified.replaceAll(/#/,"3")
            modified = modified.replaceAll(/\$/,"4")
            let arr = line.split('')
            let i = 0
            for(i; i<modified.length; i++, index++){
                arr[index] = modified.charAt(i)
            }
            line = arr.join('')

        }
        console.log(line)
    }
}

// spyMater(['specialKey',
//     'In this text the specialKey HELLOWORLD! is correct, but',
//     'the following specialKey $HelloWorl#d and spEcIaLKEy HOLLOWORLD1 are not, while',
//     'SpeCIaLkeY   SOM%%ETH$IN and SPECIALKEY ##$$##$$ are!'
// ])



function radicalMarketing(args) {
    let map = new Map()
    for(let line of args){
        let people = line.split('-')
        if(people.length==1){
            if(!map.has(people[0])){
                map.set(people[0],{})
                map.get(people[0])['subTo'] = new Set()
                map.get(people[0])['subBy'] = new Set()
            }
        }
        else if(map.has(people[0]) && map.has(people[1])){
            map.get(people[0])['subTo'].add(people[1])
            map.get(people[1])['subBy'].add(people[0])
        }

    }
    let sorted = [...map.keys()].sort((a,b) => customFn(a,b,map))
    console.log(sorted[0])
    let count = 1;
    for(let subscriber of map.get(sorted[0])['subBy']){
        console.log(count + '. ' + subscriber)
        count++;
    }

    function customFn(a, b, map) {
        if(map.get(a)['subBy'].size >map.get(b)['subBy'].size) return -1
        if(map.get(b)['subBy'].size >map.get(a)['subBy'].size) return 1
        if(map.get(a)['subTo'].size >map.get(b)['subTo'].size) return -1
        if(map.get(b)['subTo'].size >map.get(a)['subTo'].size) return 1
        return 0
    }
}

// radicalMarketing(['J',
//     'G',
//     'P',
//     'R',
//     'C',
//     'J-G',
//     'G-J',
//     'P-R',
//     'R-P',
//     'C-J'])
//

