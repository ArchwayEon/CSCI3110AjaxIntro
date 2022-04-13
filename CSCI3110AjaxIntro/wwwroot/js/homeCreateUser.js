"use strict";
(function _homeCreateUser() {
    console.log("here");
    const formCreateUser = document.querySelector("#formCreateUser");
    formCreateUser.addEventListener('submit', e => {
        e.preventDefault();
        const url = formCreateUser.getAttribute('action') + "ajax";
        const method = formCreateUser.getAttribute('method');
        const formData = new FormData(formCreateUser);
        console.log(`${url} ${method}`);

        fetch(url, {
            method: method,
            body: formData
        })
        .then(response => {
            if (!response.ok) {
                throw new Error('There was a network error!');
            }
            return response.json();
        })
        .then(result => {
            if (result === "created") {
                console.log('Success: the user was created');
                window.location.replace("/home/listusers"); // redirect
            }
            else {
                processErrorResponse(result);
            }
        })
        .catch(error => {
            console.error('Error:', error);
        });
    });
})();

function processErrorResponse(response) {
    for (let key in response) {
        if (response[key].errors.length > 0) {
            for (let error of response[key].errors) {
                console.log(key + " : " + error.errorMessage);
                const selector = `span[data-valmsg-for="${key}"]`
                const errMessageSpan = document.querySelector(selector);
                if (errMessageSpan !== null) {
                    errMessageSpan.textContent = error.errorMessage;
                }
            }
        }
    }
}
