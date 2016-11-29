/**
 * Created by ivans on 27-Nov-16.
 */

console.log('most outer')
function attachEvents(){
    let kinveyUrl = 'https://baas.kinvey.com/appdata'
    let kinveyAppId = '/kid_BJz65zOzg'
    let baseUrl = kinveyUrl + kinveyAppId + '/biggestCatches'
    let username = 'peter'
    let password = 'p'
    let auth = { "Authorization": "Basic " + btoa(username + ":" + password) }
    console.log('outer')
    $('.load').on('click',function () {
        console.log('here')
        $.ajax({
            method: 'GET',
            url: baseUrl,
            headers: auth
        })
            .then(function (data) {
                console.dir(data)
            })
            .catch(function (error) {
                console.log('error')
                console.dir(error)
            })
    })
}