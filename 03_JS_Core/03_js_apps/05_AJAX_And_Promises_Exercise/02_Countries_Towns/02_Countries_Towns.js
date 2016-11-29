/**
 * Created by ivans on 28-Nov-16.
 */

let kinveyUrl = 'https://baas.kinvey.com/appdata'
let kinveyAppId = 'kid_BJAaKyqfl'
let kinveyAppSecret = 'b8a57242549345d7b34b71bd830e2ac7'

let baseUrl = kinveyUrl + '/' + kinveyAppId

let username = 'guest'
let password = 'guest'
let auth = { "Authorization": "Basic " + btoa(username + ":" + password) }

window.onload = function () {
    initPage()
    attachEvents()
}

function renderError(error) {
    console.log('error------')
    console.dir(error)
}

function attachEvents() {
    $('#addCountryAndTown').on('click',function () {
        let countryName = $('#countryName').val()
        let countryId
        let townName = $('#townName').val()

        $.ajax({
            method: "GET",
            url: baseUrl +`/countries?query={"name":"${countryName}"}`,
            headers: auth,
        })
            .then(addCountryIfNeeded)
            .catch(renderError)

        function addTownIfNeeded(data) {
            let countryId = data['_id']
            let newTown = {'country_id': countryId,'name': townName}
            $.ajax({
                method: "POST",
                url: baseUrl +'/towns',
                headers: auth,
                contentType: "application/json",
                data: JSON.stringify(newTown)
            })
                .then(initPage)
                .catch(renderError)
        }

        function addCountryIfNeeded(data) {

            if(data.length==0){
                $.ajax({
                    method: "POST",
                    url: baseUrl + "/countries",
                    headers: auth,
                    contentType: "application/json",
                    data: JSON.stringify({name: countryName})
                })
                    .then(addTownIfNeeded)
                    .catch(renderError)
            }
            else{
                addTownIfNeeded({'_id':data[0]['_id']})
            }
        }
    })


}

function initPage() {
    let countriesAjax = $.ajax({
        method: 'GET',
        url: baseUrl + '/countries',
        headers: auth
    })

    let townsAjax = $.ajax({
        method:'GET',
        url: baseUrl +'/towns',
        headers: auth
    })

    Promise.all([countriesAjax,townsAjax])
        .then(renderData)
        .catch(renderError)

    function renderData([countries,towns]) {
        $('#countriesAndTowns').remove()
        let ul = $('<ul>').attr('id','countriesAndTowns')

        //group towns by country_id
        let newTowns = {}
        for(let t of towns){
            if(!newTowns[t['country_id']]){
                newTowns[t['country_id']] = []
            }
            newTowns[t['country_id']].push(t)
        }
        for(let country of countries){
            let li = $('<li>').attr('id',country['_id']).text(country['name'])
            li.append($('<button>').addClass('removeCountryBtn').text('[remove]'))

            let innerUl = $('<ul>')
            let shouldAppendUl = false
            if(newTowns[country['_id']]){
                for(let t of newTowns[country['_id']]){
                    shouldAppendUl = true
                    let tLi = $('<li>').attr('id',t['_id']).text(t['name'])
                    tLi.append($('<button>').addClass('removeTownBtn').text('[remove]'))
                    innerUl.append(tLi)
                }
            }
            if(shouldAppendUl){
                li.append(innerUl)
            }
            ul.append(li)
        }
        $('body').append(ul)

        $('.removeCountryBtn').on('click',function () {
            let id = $(this).parent().attr('id')
            $(this).text('Loading...').attr('disabled','disabled')

            let removeCountries = $.ajax({
                method: "DELETE",
                url: baseUrl +'/countries/' + id,
                headers: auth,
            })

            let removeTowns = $.ajax({
                method: "DELETE",
                url: baseUrl +`/towns/?query={"country_id":"${id}"}`,
                headers: auth,
            })

            Promise.all([removeCountries,removeTowns])
                .then(initPage)
                .catch(renderError)
        })

        $('.removeTownBtn').on('click',function () {
            let id = $(this).parent().attr('id')
            $(this).text('Loading...').attr('disabled','disabled')

            $.ajax({
                method: "DELETE",
                url: baseUrl +'/towns/' + id,
                headers: auth,
            })
                .then(initPage)
                .catch(renderError)
        })
    }
}