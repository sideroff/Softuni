/**
 * Created by ivans on 25.6.2016 г..
 */

function productOf3Numbers(arr) {
    let numbers = arr.map(Number)
    let negativeNumbers = numbers.filter(n => n<0).length
    if(negativeNumbers%2==0){
        console.log("Positive")
    }
    else{
        console.log("Negative")
    }
}

multiplyBy2(["-1","2","-3"])