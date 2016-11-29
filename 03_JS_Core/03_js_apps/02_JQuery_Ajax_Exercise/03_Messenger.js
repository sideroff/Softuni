/**
 * Created by ivans on 22-Nov-16.
 */
function attachEvents() {
    let url = 'https://messenger-f2fa1.firebaseio.com/'
    $('#refresh').on('click',function () {
        $('#messages').empty()
        $.get(url + '.json')
            .then(function (data) {
                let keys = [...Object.keys(data)].sort((a,b) => Number(data[a]['timestamp'])> Number(data[b]['timestamp']))
                for(let key of keys){
                    $('#messages').append(`${data[key]['author']}: ${data[key]['content']}\n`)
                }
        })
    })
    $('#submit').on('click',function () {
        let author = $('#author').val()
        let content = $('#content').val()
        let data = {
            "author": author,
            "content" : content,
            "timetamp" : Date.now()
        }
        $('#content').text('')
        $.ajax({
            accept: "application/json",
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: url + '.json',
            data: JSON.stringify(data),
        });
    })
}