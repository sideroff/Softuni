/**
 * Created by ivans on 29.6.2016 г..
 */

function addToList(text) {
    let li = $('<li>')
    li.append($('<span>').text(text+" "))
    li.append('<a href="#" onclick="deleteItem(this)">[Delete]</a>')
    $("#itemList").append(li)

}

function buttonClicked() {
    let text = $('#textBox').val()
    addToList(text)
    if($('#clearTextBox').is(':checked')){
        $('#textBox').val('')
    }
}

function deleteItem(item) {
    $(item).parent().remove()
}

$(document).ready(function(){
    $('#textBox').keypress(function (e) {
        if(e.keyCode==13){
            e.preventDefault()
            $('#submitButton').click()
        }
    })
})