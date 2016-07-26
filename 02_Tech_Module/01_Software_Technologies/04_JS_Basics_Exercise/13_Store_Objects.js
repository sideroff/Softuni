/**
 * Created by ivans on 25.6.2016 г..
 */

function storeObjects(arr) {
    let array = []
    for(let i=0;i<arr.length;i++) {
        let splitted = arr[i].split(" -> ")
        let newObj = {}
        newObj[0] = splitted[0]
        newObj[1] = splitted[1]
        newObj[2] = splitted[2]
        array.push(newObj)
    }
    for( let obj of array){
        console.log("Name: " + obj[0] + "\nAge: " + obj[1] + "\nGrade: " + obj[2])
    }
}

storeObjects(["gosho -> 15 -> 6.00","pesho -> 13 -> 6.00","icko -> 13 -> 3.00","pecko -> 18 -> 4.00"])