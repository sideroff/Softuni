/**
 * Created by ivans on 25.6.2016 г..
 */

function printLines(arr) {
    for(let command of arr){
        if(command=="Stop"){
            break;
        }
        console.log(command)
    }
}
