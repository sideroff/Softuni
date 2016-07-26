/**
 * Created by ivans on 1.7.2016 г..
 */

class PostController {
    constructor (postView, requester, baseUrl,appKey){
        this._postView = postView
        this._requester = requester
        this._baseServiceUrl = baseUrl
        this._appKey = appKey
    }

    showCreatePage(fullName, isLoggedIn){
        this._postView.showCreatePage(fullName, isLoggedIn)
    }

    createNewPost(data){
        let url = this._baseServiceUrl +'/appdata/' + this._appKey +'/posts'

        this._requester.post(url,data,function (responseData) {
            showPopup('success', 'Your post has been created!')
        },function () {
            showPopup('error','Your post has not been created. Network error.')
        })
    }
}