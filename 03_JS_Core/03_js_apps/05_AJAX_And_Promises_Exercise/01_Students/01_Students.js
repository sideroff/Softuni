/**
 * Created by ivans on 28-Nov-16.
 */

let kinveyUrl = 'https://baas.kinvey.com/appdata'
let kinveyAppId = 'kid_BJXTsSi-e'
let kinveyAppSecret = '447b8e7046f048039d95610c1b039390'
let kinveyCollectionName = 'students'

let baseUrl = kinveyUrl + '/' + kinveyAppId + '/' + kinveyCollectionName

let username = 'guest'
let password = 'guest'
let auth = { "Authorization": "Basic " + btoa(username + ":" + password) }

window.onload = function onWindowLoad() {
    initTable('#results')
    attachEvents();
}

function initTable(tableSelector) {
    let tBody = $('<tbody>')
    let headerTr = $('<tr>')
    headerTr.append($('<th>ID</th>'))
    headerTr.append($('<th>First Name</th>'))
    headerTr.append($('<th>Last Name</th>'))
    headerTr.append($('<th>Faculty Number</th>'))
    headerTr.append($('<th>Grade</th>'))
    headerTr.append($('<th>Actions</th>'))
    tBody.append(headerTr)
    $(tableSelector).append(tBody)
}
function attachEvents() {
    let loadData = function () {
        $.ajax({
            method: 'GET',
            url: baseUrl,
            headers: auth,
        })
            .then(renderData)
            .catch(renderError)
    }

    function renderError(error) {
        console.log('error------')
        console.dir(error)
    }

    let createStudent = function () {
        let newStudent = {
            ID: Number($('#ID').val()),
            FirstName: $('#FirstName').val(),
            LastName: $('#LastName').val(),
            FacultyNumber: $('#FacultyNumber').val(),
            Grade: Number($('#Grade').val()),
        }

        $.ajax({
            method: 'POST',
            url: baseUrl,
            headers: auth,
            contentType : 'application/json',
            data: JSON.stringify(newStudent)
        })
            .then(loadData)
            .catch(renderError)
    }

    $('#loadStudentsBtn').on('click',loadData)
    $('#createStudentBtn').on('click',createStudent)

    function renderData(data) {
        let table = $('#results')
        table.empty()
        initTable('#results')

        for(let piece of data){
            let tr = $('<tr>').attr('data-id',piece['_id'])
            tr.append($('<td>').text(piece['ID']))
            tr.append($('<td>').text(piece['FirstName']))
            tr.append($('<td>').text(piece['LastName']))
            tr.append($('<td>').text(piece['FacultyNumber']))
            tr.append($('<td>').text(piece['Grade']))
            tr.append($('<button>').addClass('removeTdBtn').text('[Delete]'))
            table.append(tr)
        }
        $('.removeTdBtn').on('click',function () {
            let id = $(this).parent().attr('data-id')
            $.ajax({
                method: 'DELETE',
                url: baseUrl +'/' + id,
                headers: auth
            })
                .then(loadData)
                .catch(renderError)
        })
    }
}