/**
 * Created by ivans on 25.6.2016 г..
 */

function assignValuesToIndexes(arr) {
    let array = {}
    for(let i=0;i<arr.length-1;i++) {
        let splitted = arr[i].split(" ")
        array[splitted[0]] = splitted[1]
    }
    if(array[arr[arr.length-1]]==undefined){
        console.log("None")
    }
    else{
        console.log(array[arr[arr.length-1]])
    }
}
