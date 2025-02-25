(function ($) { "use strict"; $(window).on('load', function () { $('#preloader').fadeOut(); $(window).on('scroll', function () { if ($(window).scrollTop() > 100) { $('.scrolling-navbar').addClass('top-nav-collapse'); } else { $('.scrolling-navbar').removeClass('top-nav-collapse'); } }); $('.mobile-menu').slicknav({ prependTo: '.navbar-header', parentTag: 'liner', allowParentLinks: true, duplicate: true, label: '', closedSymbol: '<i class="lni-chevron-right"></i>', openedSymbol: '<i class="lni-chevron-down"></i>', }); var wow = new WOW({ mobile: false }); wow.init(); $('.lightbox').nivoLightbox({ effect: 'fadeScale', keyboardNav: true, }); $('.counterUp').counterUp({ delay: 10, time: 1000 }); $('.search-query .form-control').on('click', function (e) { e.stopPropagation(); $(this).parent().toggleClass('query-focus'); }); $('body').on('click', function () { if ($('.search-query').hasClass('query-focus')) { $('.search-query').removeClass('query-focus'); } }); $('.search-suggestion').on('click', function (e) { e.stopPropagation(); }); var owl = $("#testimonials"); owl.owlCarousel({ navigation: false, pagination: true, slideSpeed: 1000, stopOnHover: true, autoPlay: true, items: 2, itemsDesktop: [1199, 2], itemsDesktopSmall: [980, 2], itemsTablet: [768, 1], itemsTablet: [767, 1], itemsTabletSmall: [480, 1], itemsMobile: [479, 1], }); $("#new-products").owlCarousel({ navigation: true, pagination: false, slideSpeed: 1000, stopOnHover: true, autoPlay: false, items: 4, itemsDesktop: [1199, 3], itemsDesktopSmall: [980, 2], itemsTablet: [768, 1], itemsTablet: [767, 1], itemsTabletSmall: [480, 1], itemsMobile: [479, 1], }); $("#categories-icon-slider").owlCarousel({ navigation: false, pagination: false, slideSpeed: 1000, stopOnHover: true, autoPlay: true, items: 5, itemsDesktop: [1199, 3], itemsDesktopSmall: [980, 4], itemsTablet: [768, 3], itemsTablet: [767, 3], itemsTabletSmall: [480, 2], itemsMobile: [479, 2], }); var newProducts = $('.new-products'); newProducts.find('.owl-prev').html('<i class="lni-chevron-left"></i>'); newProducts.find('.owl-next').html('<i class="lni-chevron-right"></i>'); var testiCarousel = $('.testimonials-carousel'); testiCarousel.find('.owl-prev').html('<i class="lni-chevron-left"></i>'); testiCarousel.find('.owl-next').html('<i class="lni-chevron-right"></i>'); $('#new-products').find('.owl-prev').html('<i class="lni-chevron-left"></i>'); $('#new-products').find('.owl-next').html('<i class="lni-chevron-right"></i>'); var owl; $(document).ready(function () { owl = $("#owl-demo"); owl.owlCarousel({ navigation: false, slideSpeed: 300, paginationSpeed: 400, singleItem: true, afterInit: afterOWLinit, afterUpdate: afterOWLinit }); function afterOWLinit() { $('.owl-controls .owl-page').append('<a class="item-link" />'); var pafinatorsLink = $('.owl-controls .item-link'); $.each(this.owl.userItems, function (i) { $(pafinatorsLink[i]).css({ 'background': 'url(' + $(this).find('img').attr('src') + ') center center no-repeat', '-webkit-background-size': 'cover', '-moz-background-size': 'cover', '-o-background-size': 'cover', 'background-size': 'cover' }).click(function () { owl.trigger('owl.goTo', i); }); }); $('.owl-pagination').prepend('<a href="#prev" class="prev-owl"/>'); $('.owl-pagination').append('<a href="#next" class="next-owl"/>'); $(".next-owl").click(function () { owl.trigger('owl.next'); }); $(".prev-owl").click(function () { owl.trigger('owl.prev'); }); } }); $('#summernote').summernote({ height: 250, minHeight: null, maxHeight: null, focus: false }); var offset = 200; var duration = 500; $(window).scroll(function () { if ($(this).scrollTop() > offset) { $('.back-to-top').fadeIn(400); } else { $('.back-to-top').fadeOut(400); } }); $('.back-to-top').on('click', function (event) { event.preventDefault(); $('html, body').animate({ scrollTop: 0 }, 600); return false; }); var itemList = $('.item-list'); var gridStyle = $('.grid'); var listStyle = $('.list'); $('.list,switchToGrid').on('click', function (e) { e.preventDefault(); itemList.addClass("make-list"); itemList.removeClass("make-grid"); itemList.removeClass("make-compact"); gridStyle.removeClass("active"); listStyle.addClass("active"); }); gridStyle.on('click', function (e) { e.preventDefault(); listStyle.removeClass("active"); $(this).addClass("active"); itemList.addClass("make-grid"); itemList.removeClass("make-list"); itemList.removeClass("make-compact"); }); }); }(jQuery));

function uploadprogressstart(filename) {
    var bar = $('.progress-bar');
    var percent = $('.progress-bar');
    var status = $('#status');
    var header = $('#alert_message');
    header.html(filename);
    $("#uploadpopup").show();

    var percentValue = '0%';
    $.each(new Array(102),
        function (n) {
            bar.width(percentValue);
            percent.html(percentValue);
            percentValue = n + '%';
        }
    );

    setTimeout(function () { $("#uploadpopup").hide(); percent.empty(); }, 2000);
}

var $formElements = $('form').find(':input').filter(function () {
    return $(this).attr('data-val-required');
});

$formElements.addClass('mandatory');

$(document).ready(function () {
    $("input, select").change(function () {
        if ($(this).val() != "") {
            $(this).removeClass('mandatory');
        }
    });

    $("textarea").focusout(function () {
        if ($(this).val() != "") {
            $(this).removeClass('mandatory');
        }
    });
});