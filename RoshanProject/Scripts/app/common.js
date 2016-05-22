$(document).ajaxStart(function () {
    // show loader on start
    $('.loader').show();
    
}).ajaxSuccess(function () {
    // hide loader on success
    $('.loader').hide();
}).ajaxError(function (event, request, settings) {
    $('.loader').hide();
    $.RMessage("Oops! something went wrong");;
});

$(document).ready(function () {
    $.ajaxSetup({ cache: false });
});

$(document).on('click', '.user-options ul> li', function (e) {
    var urlReq = $(this).find('a').data().action;
    if (urlReq == "/")
        urlReq = "/Home";

    var _clickedLI = $(this);
    var _siblings = $(this).siblings();
    var hasc = _clickedLI.hasClass('menu-selected');
    if (urlReq != "#") {
        if (_siblings.size() > 0) {
            $('.user-options ul> li ').each(function (i) {
                $(this).removeClass('menu-selected'); // This is your rel value
            });
        }
        $(this).addClass('menu-selected');
        $.ajax({
            type: 'GET',
            async: true,
            url: urlReq,
            cache: false,
            success: function (data) {
                $('#body').html(data);
            }
        });
    }
    else {
        $('.user-options ul> li ').each(function (i) {
            $(this).removeClass('menu-selected'); // This is your rel value
        });
        $(this).addClass('menu-selected');
    }
    e.stopImmediatePropagation();
});