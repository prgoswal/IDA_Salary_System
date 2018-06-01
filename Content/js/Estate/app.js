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
});
$(window).resize(function () {
    var windowwidth = $(window).width();
    if (windowwidth < 768) {
        $('.collapse-menu').addClass('active');
        $('body').addClass('sidebar-collapsed');
    }
});