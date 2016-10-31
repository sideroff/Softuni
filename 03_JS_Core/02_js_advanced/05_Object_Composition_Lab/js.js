/**
 * Created by ivans on 23-Oct-16.
 */

window.onload = function onWindowLoad() {
orderRectangles()
fibonacci()
listProcessor()
createCars()
}

function orderRectangles() {
$('#orderRects').on('click', function () {
        let rectInfo = $('#rectangles').val().split('\n').map(arr=>Array.from(arr.split(' ').map(n => Number(n))))
        let ordered = order(rectInfo)
        console.dir(ordered.map(r=>r.area() + ' ' + r.width))
        function order(rectInfo) {
            let rectObjects = []
            for (let rectangle of rectInfo) {
                let rect = {
                    width: rectangle[0],
                    height: rectangle[1],
                    area: () => rect.width * rect.height,
                    compareTo: function (other) {
                        let result = other.area() - rect.area();
                        return result || (other.width - rect.width);
                    }
                };
                rectObjects.push(rect)
            }
            return rectObjects.sort((a, b) => a.compareTo(b))
        }

    })
}

function fibonacci() {
    $('#getFibonacci').on('click',function () {

        let n = Number($('#nForFib').val())
        console.log(getFibs(n))
        function getFibs(n) {
            let nextFib = (function () {
                let f0 = 0
                let f1 = 1
                return () => {
                    let oldf0 = f0, oldf1 = f1
                    f0 = oldf1
                    f1 = oldf0 + oldf1
                    return oldf1
                }
            })()
            let numbers = []
            for(let i =0; i<n; i++){
                numbers.push(nextFib())
            }
            return numbers
        }
    })
    
}

function listProcessor() {
    $('#executeCommands').on('click',function () {
        let commands = $('#commands').val().split(', ')
        let cmdExecutor = function (){
            let list = []
            return {
                add:(arg) => list.push(arg),
                remove:(arg)=> list= list.filter(e => e!= arg),
                print: ()=> console.log(list.join(','))
            }
        }()
        for(cmd of commands){
            [cmdName, arg] = cmd.split(' ')
            cmdExecutor[cmdName](arg)
        }
    })
}

