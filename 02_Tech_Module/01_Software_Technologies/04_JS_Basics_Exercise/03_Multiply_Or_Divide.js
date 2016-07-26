/**
 * Created by ivans on 25.6.2016 г..
 */

function multiplyOrDivide(arr) {
    let num1 = Number(arr[0])
    let num2 = Number(arr[1])
    if(num2>=num1){
        console.log(num1*num2)
    }
    else{
        console.log(num1/num2)
    }
}