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
})


///////////////////////////////////////////////////

