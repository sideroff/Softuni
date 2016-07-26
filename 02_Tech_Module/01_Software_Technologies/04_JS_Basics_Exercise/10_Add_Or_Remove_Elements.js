/**
 * Created by ivans on 25.6.2016 г..
 */

function assignValuesToIndexes(arr) {
    let array = []
    for(let command of arr){
        let splitted = command.split(" ")
        let numberOrIndex = Number(splitted[1])
        if(splitted[0]=="add"){
            array.push(numberOrIndex)
        }
        else if(splitted[0]=="remove"){
            array = array.splice(numberOrIndex-1,1)
        }
    }
    for(let number of array){
        console.log(number)
    }
}

assignValuesToIndexes(["add 3","add 5","remove 1","add 2"])