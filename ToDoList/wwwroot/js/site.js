// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function markItemComplete(event) {
    const url = event.target.dataset.url;
    const index = event.target.dataset.index;

    var request = new XMLHttpRequest();
    request.open("PUT", url)

    request.onload = function () {
        window.location.href = index
    }

    request.send()

}


function deleteItem(event) {

    const url = event.target.dataset.url;
    const index = event.target.dataset.index;

    var request = new XMLHttpRequest();
    request.open("DELETE", url)

    request.onload = function () {
        window.location.href = index
    }

    request.send()
    
}
