"use strict";
$(document).ready(function _main() {
    $(document).on("click", "#btnHideForm", (e) => {
        $('form').hide();
    });
    $(document).on("click", "#btnShowForm", (e) => {
        $('form').show();
    });
    $(document).on("click", "#btnFadeOut", (e) => {
        $('p,table').fadeOut(1500);
    });
    $(document).on("click", "#btnFadeIn", (e) => {
        $('p,table').fadeIn(1500);
    });

    // When the image clicked then alert ‘image clicked’
    $(document).on('click', "img", (e) => {
        alert("image clicked");
    });

    $(".lonely").css("background-color", "pink");
    // When the mouse is over the element with class ‘lonely’ 
    // then change that element’s background green.
    $(document).on('mouseover', '.lonely', (e) => {
        $(e.target).css("background-color", "green");
    });
    // When the mouse moves out of the element with class ‘lonely’ 
    // then change that element’s background to pink.
    $(document).on('mouseout', '.lonely', (e) => {
        $(e.target).css("background-color", "pink");
    });

    // Create some elements and append them to the DOM
    $("article").css("background-color", "cyan");
    let txt1 = "<p>Text 1</p>";              // Create element with HTML
    let txt2 = $("<p></p>").text("Text 2");  // Create with jQuery
    let txt3 = document.createElement("p");  // Create with DOM
    txt3.innerHTML = "Text 3";
    $("article").append(txt1, txt2, txt3);   // Append the new elements

});
