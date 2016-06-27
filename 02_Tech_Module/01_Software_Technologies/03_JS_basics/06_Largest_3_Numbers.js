/**
 * Created by ivans on 24.6.2016 г..
 */

function largest3Numbers(arr) {
    let sorted = arr.sort((a,b) => b-a)
    let count = Math.min(3, arr.length)
    for( let i =0; i < count; i++){
        console.log(sorted[i])
    }
}