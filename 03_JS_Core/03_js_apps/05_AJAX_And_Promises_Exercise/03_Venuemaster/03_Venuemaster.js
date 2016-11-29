/**
 * Created by ivans on 29-Nov-16.
 */
//instructuins were not clear enough to understand
//how to operate with the supplied api
let kinveyUrl = 'https://baas.kinvey.com/rpc'
let kinveyAppId = 'kid_BJ_Ke8hZg'
let kinveyAppSecret = 'b8a57242549345d7b34b71bd830e2ac7'

let baseUrl = kinveyUrl + '/' + kinveyAppId

let username = 'guest'
let password = 'pass'
let auth = { "Authorization": "Basic " + btoa(username + ":" + password) }

function renderError(error) {
    console.log('error-------')
    console.dir(error)
}
function attachEvents() {
    $('#getVenues').on('click',function () {
        let date = $('#venueDate').val()
        $.ajax({
            method: "POST",
            url: baseUrl +`/custom/calendar/?query={${Date.now()}`,
            headers: auth
        })
            .then(getVenues)
            .catch(renderError)
    })

    function getVenues(data) {
        console.dir(data)
    }
}