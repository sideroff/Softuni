/**
 * Created by ivans on 22-Nov-16.
 */
function attachEvents() {
    let url = 'https://phonebook-nakov.firebaseio.com/phonebook/'
    $('#btnLoad').on('click', getData)
    $('#btnCreate').on('click', postData)

    function postData() {
        let person = $('#person').val();
        let phone = $('#phone').val();
        console.log(person)
        console.log(phone)
        let data = {
            person: person,
            phone: phone,
        }
        $.ajax({
            accept: "application/json",
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: url + '.json',
            data: JSON.stringify(data),
            success: getData()
        });
    }
    function getData() {
        $('#phonebook').empty()
        $.ajax({
            method: "GET",
            url: url + '.json',
            success: displayData
        })
    }

    function displayData(data){
        let keys  = [...Object.keys(data)]
        for(let key of keys){
            let obj = data[key]
            $('#phonebook').append($(`<li data-key="${key}">${obj['person']}: ${obj['phone']} <button class="btnDelete">[Delete]</button> `))
        }
        $('.btnDelete').on('click',function () {
            let key = $(this).parent().attr('data-key')

            $.ajax({
                method: 'DELETE',
                url: url + key + '/.json',
                success: getData()
            })
        })
    }
}