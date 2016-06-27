/**
 * Created by ivans on 24.6.2016 г..
 */

function main(arr) {
    let nums = arr[0].split(' ').map(Number)
    console.log(
        checkNumbers(nums[0], nums[1], nums[2]) ||
        checkNumbers(nums[0], nums[2], nums[1]) ||
        checkNumbers(nums[2], nums[1], nums[0]) || "No")


    function checkNumbers(a, b, c) {
        if(a+b!=c){
            return false;
        }
        if(a<b){
            [a,b] = [b,a]
        }
        return '${a} + ${b} = ${c}'

    }
}

function threeIntegersSum(arr) {
    let nums = arr[0].split(' ').map(Number);
    console.log(
        check(nums[0], nums[1], nums[2]) ||
        check(nums[0], nums[2], nums[1]) ||
        check(nums[1], nums[2], nums[0]) || 'No');
    function check(num1, num2, sum) {
        if (num1 + num2 != sum)
            return false;
        if (num1 > num2)
            [num1, num2] = [num2, num1]; // Swap num1 and num2
        return `${num1} + ${num2} = ${sum}`;
    }
}
