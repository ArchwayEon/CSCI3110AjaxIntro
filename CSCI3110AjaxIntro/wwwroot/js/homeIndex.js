'use strict';
(function _main() {
    const gifImg = document.createElement('img');
    gifImg.setAttribute('src', '/images/ajax-loader.gif');

    const btnGetRandom = document.querySelector('#btnGetRandom');
    btnGetRandom.addEventListener('click', e => {
        showLoadingGif("#outputArea", gifImg);
        getRandomNumbers();
    });

})();

function showLoadingGif(parentSelector, gifImg) {
    setChildElement(parentSelector, gifImg);
}

function getRandomNumbers() {
    fetch('/home/getrandomnumbers/')
        .then(response => response.json())
        .then(data => showResult('#outputArea', data))
        .catch(error => showResult('#outputArea', error));
}

function setChildElement(parentSelector, childElement) {
    let parentElement = document.querySelector(parentSelector);
    removeAllChildren(parentElement);
    parentElement.appendChild(childElement);
}

function removeAllChildren(parentElement) {
    // Remove all children
    while (parentElement.firstChild) {
        parentElement.removeChild(parentElement.firstChild);
    }
}

function showResult(parentSelector, data) {
    const textNode = document.createTextNode(data);
    setChildElement(parentSelector, textNode);
}
