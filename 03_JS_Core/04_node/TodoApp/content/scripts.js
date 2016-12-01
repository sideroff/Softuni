window.onload = function () {
    attachEvents()
}

function attachEvents() {
    let buttons = document.getElementsByClassName('editTodo')

    function redirectToEditPage() {
        let id = this.parentElement.getAttribute('data-todo-id')
        
        window.location.replace('/edit/' + id)
    }

    for (let btn of buttons) {
        btn.addEventListener('click', redirectToEditPage)
    }


}