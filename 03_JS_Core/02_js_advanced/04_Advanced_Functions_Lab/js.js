/**
 * Created by ivans on 23-Oct-16.
 */

window.onload = function onWindowLoad() {
    aggregate();
    processCmd();
    max();
}

function aggregate() {
    $('#aggregate').on('click',function () {
        let numbers = Array.from($('#numbersForAggregation').val().split(' ').map(n=>Number(n)))
        calcAggregates(numbers)
        function calcAggregates(arr) {
            console.log("Sum = " +
                arr.reduce((a,b) => Number(a) + Number(b)))
            console.log("Min = " +
                arr.reduce((a,b) => Math.min(a, b)))
            console.log("Max = " +
                arr.reduce((a,b) => Math.max(a,b)))
            console.log("Join = " +
                arr.reduce((a,b) => '' + a + b))
        }
    })
}

function processCmd() {
    $('#processCmd').on('click',function () {
        let commandProcessor = (function () {
            let closureString = ''
            return {
                append: (text) => closureString+=text,
                removeStart:(count)=> closureString = closureString.slice(Number(count)),
                removeEnd: (count) =>closureString =
                    closureString.slice(0, closureString.length - Number(count)),
                print: () => console.log(closureString)
            }
        })()
        let commands = $('#commands').val().split('\n')
        processCommands(commands)
        function processCommands(commands) {
            for(let cmd of commands){
                let [cmdName, arg] = cmd.split(' ');
                commandProcessor[cmdName](arg)
            }
        }
    })
}

function max() {
    $('#findMaxBtn').on('click',function () {
        let numbers = Array.from($('#findMax').val().split(' ').map(n=>Number(n)))
        let max = (numbers) => Math.max.apply(null, numbers);
        console.log(max(numbers))
    })
}