/**
 * Created by ivans on 1.7.2016 г..
 */

class HomeController {
    constructor (homeView, requester, baseUrl,appKey){
        this._homeView = homeView
        this._requester = requester
        this._baseServiceUrl = baseUrl
        this._appKey = appKey
    }

    showGuestPage(){
        let _that = this
        let recentPosts = []
        let url = this._baseServiceUrl + '/appdata/' + this._appKey + '/posts'
        this._requester.get(url,
        function (response) {
            showPopup('success','Data collected!')

            let currentId = 1

            response.sort(function (e1, e2) {
                let date1= new Date(e1._kmd.ect)
                let date2= new Date(e2._kmd.ect)
                return date2-date1
            })
            for(let i =0; i<5; i++){
                recentPosts.postId = currentId
                currentId++
                recentPosts.push(response[i])
            }
            _that._homeView.showGuestPage(response, recentPosts)
        },
        function (data) {
            showPopup('error','Data could not be collected!')
        })
        this._homeView.showGuestPage()
    }

    showUserPage(){
        let _that = this
        let recentPosts = []
        let url = this._baseServiceUrl + '/appdata/' + this._appKey + '/posts'
        this._requester.get(url,
            function (response) {
                showPopup('success','Data collected!')

                let currentId = 1

                response.sort(function (e1, e2) {
                    let date1= new Date(e1._kmd.ect)
                    let date2= new Date(e2._kmd.ect)
                    return date2-date1
                })
                for(let i =0; i<5; i++){
                    recentPosts.postId = currentId
                    currentId++
                    recentPosts.push(response[i])
                }
                _that._homeView.showUserPage(response, recentPosts)
            },
            function (data) {
                showPopup('error','Data could not be collected!')
            })
    }
}