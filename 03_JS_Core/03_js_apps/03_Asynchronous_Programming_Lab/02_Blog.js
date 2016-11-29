/**
 * Created by ivans on 25-Nov-16.
 */

function attachEvents() {
    let defUsername = 'peter'
    let defPass = 'p'
    let base = 'https://baas.kinvey.com/appdata/'
    let kinveyAppId = 'kid_B1dpMsHfl'
    let baseUrl = base + kinveyAppId
    let queryPreText = '?query='
    let auth = { "Authorization": "Basic " + btoa(defUsername + ":" + defPass) }

    $('#btnLoadPosts').on('click',function () {
        $('#posts').empty()
        $.ajax({
            method: 'GET',
            url: baseUrl + '/posts',
            headers: auth,
            success:listPosts,
            error: listError
        })
    })
    function listPosts(data) {
        for(let piece of data){
            console.dir(piece)
            let option = $(`<option value="${piece['_id']}">${piece['title']}</option>`);
            $('#posts').append(option)
        }
    }
    function listError(error) {
        console.dir(error)
    }

    $('#btnViewPost').on('click',function () {
        let id = $('#posts :selected').first().attr('value')
        $.ajax({
            method: "GET",
            url: baseUrl + `/posts/${id}`,
            headers: auth,
            success: listPostDetails,
            error: listError
        })
        let queryJson = JSON.stringify({post_id:id})
        $.ajax({
            method: "GET",
            url: baseUrl +`/comments/${queryPreText}${queryJson}`,
            headers: auth,
            success: listComments,
            erro:listError
        })
    })

    function listPostDetails(data) {
        console.log('postDetails')
        console.dir(data)
        $('#post-title').text(data['title'])
        $('#post-body').text(data['body'])
    }

    function listComments(data) {
        $('#post-comments').empty()
        for(let piece of data){
            let li = $(`<li>${piece['body']}</li>`)
            $('#post-comments').append(li)
        }
    }
}