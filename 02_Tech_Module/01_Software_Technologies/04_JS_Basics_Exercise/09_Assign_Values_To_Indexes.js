/**
 * Created by ivans on 25.6.2016 г..
 */

function assignValuesToIndexes(arr) {
    let array = []
    let count = Number(arr[0])
    for(let i =0;i<count;i++){
        array.push(0)
    }
    for(let i=1;i<arr.length;i++){
        let splitted = arr[i].split(" - ")
        array[splitted[0]] = splitted[1]
    }
    for(let value of array){
        console.log(value)
    }
}

assignValuesToIndexes(["4","1 - 2", "0 - 1","0 - 2","2 - 5"])