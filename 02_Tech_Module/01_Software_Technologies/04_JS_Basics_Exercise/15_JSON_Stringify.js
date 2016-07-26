/**
 * Created by ivans on 25.6.2016 г..
 */

function storeObjects(arr) {
    let obj={}
    for(let i=0;i<arr.length;i++) {
        let splitted = arr[i].split(" -> ")
        obj[splitted[0]] = Number(splitted[1]) || splitted[1]
    }
    console.log(JSON.stringify(obj))
}

storeObjects(["name -> Angel","surname -> Georgiev","age -> 20","grade -> 6.00","date -> 23/05/1995","town -> Sofia"])
