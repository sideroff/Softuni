/**
 * Created by ivans on 28.6.2016 г..
 */


$('li').click(function () {
    alert('hei')
})

function addToList() {
    $('li').css('background','#DDD')
    let list = document.getElementById('itemList')
    let li = document.createElement('li')
    let textBox = document.getElementById('textBox')
    if(textBox.value !=""){
        li.appendChild(document.createTextNode(textBox.value))
        list.appendChild(li)

        let radioButton = document.getElementById('clearTextBox')
        if(radioButton.checked){
            textBox.value=""
        }
    }

}