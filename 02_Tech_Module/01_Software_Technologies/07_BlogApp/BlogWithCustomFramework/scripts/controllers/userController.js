/* Created by ivans on 1.7.2016 г.. */

class UserController {
    constructor (userView, requester, baseUrl, appKey){
        this._userView = userView
        this._requester = requester
        this._baseServiceUrl = baseUrl
        this._appKey = appKey
    }
    showLoginPage(isLoggedIn){
        this._userView.showLoginPage(isLoggedIn)
    }
    
    showRegisterPage(isLoggedIn){
        this._userView.showRegisterPage(isLoggedIn)
    }

    register(data){
        if(data.username.length <6){
            showPopup('error','Username must be atleast 6 symbols long.')
            return
        }
        if(data.fullName.length < 6) {
            showPopup('error','Full name must be atleast 6 symbols long.')
            return
        }
        if(data.password.length <8) {
            showPopup('error', 'Password must be atleast 8 symbols long.')
            return
        }
        if(data.password != data.confirmPassword){
            showPopup('error', 'Passwords did not match.')
            return
        }

        let url = this._baseServiceUrl +'/user/' + this._appKey +'/'
        delete data['confirmPassword']
        this._requester.post(url, data,
        function successCallback(response){
            showPopup('success','You have registered successfully')
            redirectUrl('#/login')
        },
        function errorCallback() {
            showPopup('error',"Something went wrong while trying to register you, try again...")

        })
    }
    
    login(data){
        let requestUrl = this._baseServiceUrl + "/user/" + this._appKey +"/login"
        this._requester.post(requestUrl,data,
            function successCallback(response){
                sessionStorage.setItem('username', response.username)
                sessionStorage.setItem('_authToken', response._kmd.authtoken)
                sessionStorage.setItem('fullName', response.fullName)
                showPopup('success','You have logged in successfully')
                redirectUrl('#/')
            },
            function errorCallback() {
                showPopup('error',"Something went wrong while trying to register you, try again...")

            })
    }
    
    logout(){
        sessionStorage.clear()
        redirectUrl('#/')
    }

}