$(document).ready(function () {
    $('a[href="#"]').each(function () {
        this.href = 'javascript:void(0);';

    });
    var windowheight = $(window).height();
    var windowwidth = $(window).width();

    $('.collapse-menu').click(function () {
        $(this).toggleClass('active');
        $('body').toggleClass('sidebar-collapsed');
    });

    var url = window.location.href;
    var page = (url.split('/').slice(-1)[0]);
     
    $('.sidenav a').each(function () {
        var hyper = $(this).attr('href');
        var hyperlink = (hyper.split('/').slice(-1)[0]);       
        if (hyperlink == page) {
            $(this).parents('.collapse').addClass('in');
            $(this).parent('li').addClass('active');
            $(this).parents('.dropdown').addClass('active');
        }
    });

});

$(window).resize(function () {
    var windowwidth = $(window).width();
    if (windowwidth < 768) {
        $('.collapse-menu').addClass('active');
        $('body').addClass('sidebar-collapsed');
    }
});


//--start-- systes
$(document).ready(function () {
    $('.before-part').click(function () {
        $('.change-part:not(.pre).active').addClass('in-active');
        $('.change-part:not(.pre).active').removeClass('active');
        $(this).parents('.change-part:not(.pre)').addClass('active');
        $(this).parents('.change-part:not(.pre)').removeClass('in-active');
        if ($(this).parents('.change-part').hasClass('pre')) {
            var loc = $(this).parents('.change-part').data('href');
            window.location.href = loc;
        }
    });


    $('.part-close').click(function () {
        $(this).parents('.change-part:not(.pre)').removeClass('active');
        $(this).parents('.change-part:not(.pre)').addClass('in-active');
        return false;
    });
});


///////////////////////////////////////////////////
//--start-- systes
$(document).ready(function () {
$('.toggle').click(function () {
    alert('aa');
});
});