/*
 * ohai
 * version: 0.1 
 * @requires jQuery
 *
 *
 */



$(document).ready(function () {

    var t = null;

    $('#facebox').mouseenter(function (e) {
        clearTimeout(t); 
    });

    $('#userImg').mouseenter(function (e) {
        clearTimeout(t); 
    });

    $('#facebox').mouseleave(function (e) {
        t = setTimeout("hideUserDetails()", 500);
    });

    $('#userImg').mouseleave(function (e) {
        t = setTimeout("hideUserDetails()", 500);
    });

});



var mouseoverOffsetX = 50;      
var mouseoverOffsetY = 50;
var ohaiAjaxQueue = 0;


function showUserDetails(el, id) {
    var pos = $(el).position();

    ohaiAjaxQueue++;
    $('#UserDetails').html('<div class="loading"><img src="' + $.facebox.settings.loadingImage + '"/></div>');
    $.get('/Home/User/' + id, function (data) {displayUserDetails(pos,data)});

    $('#facebox').css({
        position: 'absolute',
        zIndex: 5000,
        left: pos.left + mouseoverOffsetX,
        top: pos.top + mouseoverOffsetY
        } );
    $('#facebox').show();
}


function displayUserDetails(pos, data) {
    ohaiAjaxQueue--;
    if (ohaiAjaxQueue == 0) { $('#UserDetails').html(data); }
}


function hideUserDetails() {
      $('#facebox').hide();
      $('#UserDetails').html('<div class="loading"><img src="' + $.facebox.settings.loadingImage + '"/></div>');

}

 