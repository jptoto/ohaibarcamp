/*
 * ohai
 * version: 0.1 
 * @requires jQuery
 *
 *
 */


var mouseoverOffsetX = 20;      
var mouseoverOffsetY = 20;


function showUserDetails(el, id) {
    var pos = $(el).position();
    $.get('/Home/User/' + id, function (data) { $('#UserDetails').html(data) });
    $('#facebox').css({
        position: 'absolute',
        zIndex: 5000,
        // backgroundColor: '#FFFFFF',
        //width: '400px',
        //height: '100px',
        left: pos.left + mouseoverOffsetX,
        top: pos.top + mouseoverOffsetY
        } );
    $('#facebox').show();
    }
  

  function hideUserDetails() {
      $('#facebox').hide();
      $('#UserDetails').html('<div class="loading"><img src="' + $.facebox.settings.loadingImage + '"/></div>');

  }

 