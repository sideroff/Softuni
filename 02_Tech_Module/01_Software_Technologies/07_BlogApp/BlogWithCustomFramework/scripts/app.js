(function () {

    // Create your own kinvey application

    let baseUrl = "https://baas.kinvey.com";
    let appKey = "kid_rkUKl4NI"; // Place your appKey from Kinvey here...
    let appSecret = "a80bfb43edac419d875121adecace925"; // Place your appSecret from Kinvey here...
    let _guestCredentials = "31848882-d0f4-45bb-ae12-4feaa91d2c60.DQbnXw9mEoxITWYnoPuWkul/WlOFzs9OAzs8q5ORDvo="; // Create a guest user using PostMan/RESTClient/Fiddler and place his authtoken here...

    //Create AuthorizationService and Requester
    let authService = new AuthorizationService(baseUrl,appKey,appSecret,_guestCredentials)
    let requester = new Requester(authService)
    
    authService.initAuthorizationType("Kinvey")

    let selector = ".wrapper";
    let mainContentSelector = ".main-content";

    // Create HomeView, HomeController, UserView, UserController, PostView and PostController
    let homeView = new HomeView(mainContentSelector,selector)
    let homeController = new HomeController(homeView,requester,baseUrl,appKey)

    let userView = new UserView(mainContentSelector,selector)
    let userController = new UserController(userView,requester,baseUrl,appKey)

    let postView = new PostView(mainContentSelector,selector)
    let postController = new PostController(postView,requester,baseUrl,appKey)

    initEventServices();

    onRoute("#/", function () {
        // Check if user is logged in and if its not show the guest page, otherwise show the user page...
        if(authService.isLoggedIn()){
            homeController.showUserPage()
        }
        else{
            homeController.showGuestPage()
        }
    });

    onRoute("#/post-:id", function () {
        // Create a redirect to one of the recent posts...
        alert('ei')
        let top = $('#post-' + this.params['id'].position().top)
        $(window).scrollTop(top)
    });

    onRoute("#/login", function () {
        // Show the login page...
        userController.showLoginPage(authService.isLoggedIn())
    });

    onRoute("#/register", function (){
        // Show the register page...
        userController.showRegisterPage(authService.isLoggedIn())
    });

    onRoute("#/logout", function () {
        // Logout the current user...
        userController.logout()
    });

    onRoute('#/posts/create', function () {
        // Show the new post page...
        let fullName = sessionStorage.getItem('fullName')
        postController.showCreatePage(fullName,authService.isLoggedIn())
    });

    bindEventHandler('login', function (ev, data) {
        // Login the user...
        userController.login(data)
    });

    bindEventHandler('register', function (ev, data) {
        // Register a new user...
        userController.register(data)
    });

    bindEventHandler('createPost', function (ev, data) {
        // Create a new post...
        console.log(data)
        postController.createNewPost(data)
    });

    run('#/');
})();
