/**
 * Created by ivans on 19-Oct-16.
 */
function calc(){
    let n1 = Number(document.getElementById('num1').value)
    let n2 = Number(document.getElementById('num2').value)
    let sumField = document.getElementById('sum')

    let sum = n1 + n2

    sumField.value = sum
}


function showText() {
    let link = document.getElementById('more')
    let span = document.getElementById('text')


    link.style.display = 'none'

    span.style.display = 'inline'
}

function extractText() {
    let listItems = Array.from(document.querySelectorAll('ul#items1 li')).map(li=>li.innerHTML)
    let textArea = document.getElementById('result1')
    for(let li of listItems){
        textArea.value += li +'\n'
    }
}

function colorize() {
    let tableRows = Array.from(document.querySelectorAll('table tr'))
    let i = 0
    for(tr of tableRows){
        if(i%2 != 0){
            tr.style.background = 'Teal'
        }
        i++
    }
}

function addItem2() {
    let ul = document.getElementById('items2')
    let text = document.getElementById('newItemText').value

    let newLi = document.createElement('li')
    newLi.innerHTML = text
    ul.appendChild(newLi)
}

function addItem() {
    let ul = document.getElementById('items')
    let text = document.getElementById('newText').value
    let newLi = document.createElement('li')
    let link = document.createElement('a')
    link.innerHTML = '[Delete]'
    link.setAttribute('href','#')
    link.addEventListener('click', deleteItem)
    newLi.innerHTML += text
    newLi.appendChild(link)
    ul.appendChild(newLi)

    function deleteItem() {
        let li = this.parentNode
        let ul = li.parentNode
        ul.removeChild(li)
    }
}

function deleteByEmail() {
    let email = document.getElementsByName('email')[0].value
    let div = document.getElementById('result2')
    if(!email){
        div.innerHTML = 'Not found.'
        return
    }
    let tds = Array.from(document.querySelectorAll('table#customers tr td'))

    let forDeletion = new Set()
    for(let td of tds){
        if(td.innerHTML == email){
            forDeletion.add(td)
        }
    }
    if(forDeletion.size == 0){
        div.innerHTML = 'Not found.'
        return
    }
    for(let td of forDeletion){
        td.parentNode.parentNode.removeChild(td.parentNode)
    }
    div.innerHTML = 'Deleted.'
}

window.onload = function() { stopwatch(); }
function stopwatch() {
    let time, intervalID;
    let startBtn = document.getElementById('startBtn');
    let stopBtn = document.getElementById('stopBtn');
    startBtn.addEventListener('click', function() {
        time = -1;
        incrementTime();
        intervalID = setInterval(
            incrementTime, 1000);
        startBtn.disabled = true;
        stopBtn.disabled = false;
    });
    stopBtn.addEventListener('click', function() {
        clearInterval(intervalID);
        startBtn.disabled = false;
        stopBtn.disabled = true;
    });
    function incrementTime() {
        time++;
        document.getElementById('time').textContent =
            ("0" + Math.trunc(time / 60)).slice(-2) +
            ':' + ("0" + (time % 60)).slice(-2);
    }
}

window.onload =
    function attachGradientEvents() {
        let gradient = document.getElementById('gradient');
        gradient.addEventListener('mousemove', gradientMove);
        gradient.addEventListener('mouseout', gradientOut);
        function gradientMove(event) {
            let power = event.offsetX / (event.target.clientWidth - 1);
            power = Math.trunc(power * 100);
            document.getElementById('result').textContent = power + "%";
        }
        function gradientOut(event) {
            document.getElementById('result').textContent = "";
        }
    }