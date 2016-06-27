/**
 * Created by ivans on 24.6.2016 г..
 */

function findSymetric(arr) {
    let n = Number(arr[0])
    let output ="";
    for (let i =1;i<n;i++){
        hasFoundDifference=false;;
        for (let j =0; j<(""+i).length/2;j++){
            if((""+i)[j] ==(""+i)[(""+i).length-1-j]){
                continue;
            }
            hasFoundDifference=true;
            break;
        }
        if(!hasFoundDifference){
            output+=i +" "
        }
    }
    console.log(output)
}

