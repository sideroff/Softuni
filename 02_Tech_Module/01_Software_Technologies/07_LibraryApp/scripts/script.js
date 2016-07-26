/**
 * Created by ivans on 30.6.2016 г..
 */

const kinveyAppID = 'kid_HkO8zIGI'
const kinveyAppSecret = '01040e3b45204c07bce99ffedd49582c'
const kinveyServiceBaseUrl= 'https://baas.kinvey.com/'

function showView(viewID) {
    $("main > section").hide()
    $("#" + viewID).show();
}

$(function buttonsLogic() {
    $("#linkHome").click(showHomeView)
    $("#linkLogin").click(showLoginView)
    $("#linkRegister").click(showRegisterView)
    $("#linkListBooks").click(showListBooksView)
    $("#linkCreateBook").click(showCreateBookView)
    $("#linkLogout").click(logout)

    $('#formLogin').submit(function(e){e.preventDefault();login()})
    $('#formRegister').submit(function(e){e.preventDefault();register()})
    $('#formCreateBook').submit(function(e){e.preventDefault();createBook()})

    showHomeView()
    showHideNavigationLinks()
})

function showHomeView() {
    showView('viewHome')
}

function showLoginView() {
    showView('viewLogin')
}

function login() {
    let authBase64 = btoa(kinveyAppID +":" + kinveyAppSecret)
    let loginUrl = kinveyServiceBaseUrl + "user/" + kinveyAppID + "/login"
    let loginData = {
        username: $('#loginUser').val(),
        password: $('#loginPass').val(),
    }
    $.ajax({
        method: "POST",
        url: loginUrl,
        data: loginData,
        headers: {"Authorization": "Basic " + authBase64},
        success: loginSuccess,
        error: showError
    })
    function loginSuccess(data, status) {
        sessionStorage.authToken = data._kmd.authtoken;
        showListBooksView()
        showHideNavigationLinks()
        showInfo("Login successful")
    }
}

function showInfo(msg, status) {
    $('#infoBox').text(msg).fadeIn()
    setTimeout(
        function()
        {
            $('#infoBox').fadeOut()
        }, 3000);
}

function showError(data, status) {
    let errorMsg= ''
    if(typeof(data.readyState) !='undefined' && data.readyState==0)
        errorMsg="Network error!"
    else if(data.responseJSON && data.responseJSON.description)
        errorMsg=data.responseJSON.description
    else
        errorMsg = "Error: " + JSON.stringify(data)
    $('#errorBox').text(errorMsg).fadeIn()
    setTimeout(
        function()
        {
            $('#errorBox').fadeOut()
        }, 3000);

}

function showRegisterView() {
    showView('viewRegister')
}

function register() {
    let authBase64 = btoa(kinveyAppID +":" + kinveyAppSecret)
    let loginUrl = kinveyServiceBaseUrl + "user/" + kinveyAppID + "/"
    let loginData = {
        username: $('#registerUser').val(),
        password: $('#registerPass').val(),
    }
    $.ajax({
        method: "POST",
        url: loginUrl,
        data: loginData,
        headers: {"Authorization": "Basic " + authBase64},
        success: registerSuccess,
        error: showError
    })
    function registerSuccess(data, status) {
        sessionStorage.authToken = data._kmd.authtoken;
        showListBooksView()
        showHideNavigationLinks()
        showInfo("User registered successfully")
    }
}

function showListBooksView() {
    showView('viewListBooks')
    $("#books").text('')
    let authBase64 = btoa(kinveyAppID +":" + kinveyAppSecret)
    let booksUrl = kinveyServiceBaseUrl + "appdata/" + kinveyAppID + "/books"

    $.ajax({
        method: "GET",
        url: booksUrl,
        headers: {"Authorization": "Kinvey " + sessionStorage.authToken},
        success: booksLoaded,
        error: showError
    })
    function booksLoaded(data, status) {

        showInfo("Books Loaded")
        let booksTable = $("<table>")
            .append($("<tr>")
                .append($("<th>Title</th>"))
                .append($("<th>Author</th>"))
                .append($("<th>Description</th>"))
            )
        for (let book of data){
            booksTable.append($("<tr>")
                .append($("<td></td>").text(book.title))
                .append($("<td></td>").text(book.author))
                .append($("<td></td>").text(book.description))
            )            
        }
        $("#books").append(booksTable)
    }
}

function showCreateBookView() {
    showView('viewCreateBook')

}

function createBook() {
    showView('viewListBooks')
    $("#books").text('')
    let authBase64 = btoa(kinveyAppID +":" + kinveyAppSecret)
    let booksUrl = kinveyServiceBaseUrl + "appdata/" + kinveyAppID + "/books"
    let newBookData = {
        title: $("#bookTitle").val(),
        author: $("#bookAuthor").val(),
        description: $("#bookDescription").val(),
        comments: [{author: "gosho", commentText:"commentText"},{author: "pesho", commentText:"newCommentText"}]
    }
    $.ajax({
        method: "POST",
        url: booksUrl,
        data: JSON.stringify(newBookData),
        headers: {
            "Authorization": "Kinvey " + sessionStorage.authToken,
            "Content-Type": "application/json"
        },
        success: bookCreated,
        error: showError
    })
    function bookCreated(data, status) {
        showListBooksView()
        showInfo("Book created")
    }
}

function logout() {
    sessionStorage.clear()
    showHideNavigationLinks()
    showHomeView()
}

function showHideNavigationLinks() {
    let loggedIn = sessionStorage.authToken !=null;
    if(loggedIn){
        $('#linkHome').show();
        $('#linkLogin').hide();
        $('#linkRegister').hide();
        $('#linkListBooks').show();
        $('#linkCreateBook').show();
        $('#linkLogout').show();
    }
    else{
        $('#linkLogin').show();
        $('#linkRegister').show();
        $('#linkListBooks').hide();
        $('#linkCreateBook').hide();
        $('#linkLogout').hide();
    }
}

$(document)
    .ajaxStart(function () {
        $("#loadingBox").show();
    })
    .ajaxStop(function () {
        $("#loadingBox").hide();
    });