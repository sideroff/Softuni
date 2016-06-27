/**
 * Created by ivans on 25.6.2016 г..
 */

function parseJSON(arr) {
    let array = []
    for(let json of arr){
        let newObj = JSON.parse(json)
        array.push(newObj)
    }
    for( let obj of array){
        console.log("Name: " + obj["name"] + "\nAge: " + obj["age"] + "\nDate: " + obj["date"] )
    }
}

parseJSON(['{"name":"Gosho","age":10,"date":"19/06/2005"}','{"name":"Tosho","age":11,"date":"04/04/2005"}'])
