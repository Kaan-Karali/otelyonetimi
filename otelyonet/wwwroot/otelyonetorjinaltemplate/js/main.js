$(function () {

    "use strict";

    // Toggle menu
    // ------------------------------------

    $('.toggle-menu').on('click', function () {
        $(this).toggleClass('open');
        $('header').toggleClass('sticked');
        $(this).parent().find('.navigation-block').toggleClass('open');
    });

    var $box = $('.options-content .options .box');
    $box.click(function () {
        var $this = $(this),
            $boxWrapper = $this.closest('.box-wrapper');

        if ($this.hasClass('active')) {
            $boxWrapper.removeClass('box-wrapper-selected');
            $this.removeClass('active');
        }
        else {
            $boxWrapper.addClass('box-wrapper-selected');
            $this.closest('.options-content').find('.box').removeClass('active');
            $this.addClass('active');
        }
    });

    // Mobile - Dropdown menu
    // ------------------------------------

    $('.open-dropdown').on('click', function (e) {

        e.preventDefault();

        if ($(document).width() >= 992) {
            return false;
        }

        var $this = $(this),
            $li = $this.closest('li'),
            $drop = $li.find('ul');

        $li.toggleClass('expanded');

        if ($li.hasClass('expanded')) {
            $drop.slideDown();
        }
        else {
            $drop.slideUp();
        }
    });

    // Desktop - Dropdown menu
    //---------------------------

    $('.navigation-block > ul > li').on({
        mouseenter: function () {
            if ($(document).width() < 992) {
                return false;
            }
            $(this).addClass('hovered');
        },
        mouseleave: function () {
            if ($(document).width() < 992) {
                return false;
            }
            $(this).removeClass('hovered').removeAttr('class');
        }
    });

    // Wrap first word in title sections
    //----------------------------------

    $('.section-header .title').each(function () {
        var $this = $(this);
        $this.html($this.html().replace(/^(\w+)/, '<span>$1</span>'));
    });

    // Tooltip
    // ----------------------------------------------------------------

    $('[data-toggle="tooltip"]').tooltip();

    // Main popup
    // ----------------------------------------------------------------

    $('.mfp-open').magnificPopup({
        type: 'inline',
        fixedContentPos: false,
        fixedBgPos: true,
        overflowY: 'auto',
        closeBtnInside: true,
        preloader: false,
        midClick: true,
        removalDelay: 300,
        mainClass: 'my-mfp-zoom-in',
        callbacks: {
            open: function () {
                // wait on popup initalization
                // then load owl-carousel
                $('.popup-main .owl-carousel').hide();
                setTimeout(function () {
                    $('.popup-main .owl-carousel').slideDown();
                }, 500);
            }
        }
    });

    // Main popup gallery
    // ----------------------------------------------------------------

    $('.open-popup-gallery').magnificPopup({
        delegate: 'a',
        type: 'image',
        tLoading: 'Loading image #%curr%...',
        gallery: {
            enabled: true,
            navigateByImgClick: true,
            preload: [0, 1] // Will preload 0 - before current, and 1 after the current image
        },
        fixedContentPos: false,
        fixedBgPos: true,
        overflowY: 'auto',
        closeBtnInside: true,
        preloader: false,
        midClick: true,
        removalDelay: 300,
        mainClass: 'my-mfp-zoom-in'
    });

    // Rooms carousel
    // ----------------------------------------------------------------

    var arrowIcons = [
        '<span class="icon icon-chevron-left"></span>',
        '<span class="icon icon-chevron-right"></span>'
    ];

    $.each($(".owl-rooms"), function (i, n) {
        $(n).owlCarousel({
            autoHeight: false,
            pagination: true,
            navigation: true,
            navigationText: arrowIcons,
            items: 3,
            itemsDesktop: [1199, 3],
            itemsDesktopSmall: [979, 2],
            itemsTablet: [768, 2],
            itemsTabletSmall: true,
            itemsMobile: [479, 1],
            addClassActive: true,
            autoPlay: 5500,
            stopOnHover: true
        });
    });


    // Frontpage slider
    // ----------------------------------------------------------------

    $.each($(".owl-slider"), function (i, n) {

        $(n).owlCarousel({
            autoHeight: false,
            navigation: true,
            navigationText: arrowIcons,
            items: 1,
            singleItem: true,
            addClassActive: true,
            transitionStyle: "fadeUp",
            afterMove: animatetCaptions,
            autoPlay: false,
            stopOnHover: true
        });

        animatetCaptions();

        function animatetCaptions(event) {
            "use strict";
            var activeItem = $(n).find('.owl-item.active'),
                timeDelay = 100;
            $.each(activeItem.find('.animated'), function (j, m) {
                var item = $(m);
                item.css('animation-delay', timeDelay + 'ms');
                timeDelay = timeDelay + 180;
                item.addClass(item.data('animation'));
                setTimeout(function () {
                    item.removeClass(item.data('animation'));
                }, 2000);
            });
        }

        if ($(n).hasClass('owl-slider-fullscreen')) {
            $('.owl-slider-fullscreen .item').height($(window).height());
        }
    });

    // Quote carousel
    // ----------------------------------------------------------------

    $.each($(".quote-carousel"), function (i, n) {
        $(n).owlCarousel({
            navigation: true, // Show next and prev buttons
            slideSpeed: 300,
            items: 4,
            paginationSpeed: 400,
            singleItem: false,
            navigationText: arrowIcons,
            autoPlay: 8000,
            stopOnHover: true
        });
    });


    // Scroll to top
    // ----------------------------------------------------------------

    var $wrapper = $('.wrapper');
    $wrapper.append($("<div class='scroll-top'><i class='icon icon-chevron-up'></i></div>"));

    var $scrollbtn = $('.scroll-top');

    $(document).on('ready scroll', function () {
        var docScrollTop = $(document).scrollTop(),
            docScrollBottom = $(window).scrollTop() + $(window).height() === $(document).height();

        if (docScrollTop >= 150) {
            $scrollbtn.addClass('visible');
        } else {
            $scrollbtn.removeClass('visible');
        }
        if (docScrollBottom) {
            $scrollbtn.addClass('active');
        }
        else {
            $scrollbtn.removeClass('active');
        }
    });

    $scrollbtn.on('click', function () {
        $('html,body').animate({
            scrollTop: $('body').offset().top
        }, 1000);
        return false;
    });

    // Strecher accordion
    // ----------------------------------------------------------------

    var $strecherItem = $('.stretcher-item');
    $strecherItem.on({
        mouseenter: function (e) {
            $(this).addClass('active');
            $(this).siblings().addClass('inactive');
        },
        mouseleave: function (e) {
            $(this).removeClass('active');
            $(this).siblings().removeClass('inactive');
        }
    });


    // Sticky header
    // ----------------------------------------------------------------

    var navbarFixed = $('header');

    // When reload page - check if page has offset
    if ($(document).scrollTop() > 94) {
        navbarFixed.addClass('sticked');
    }
    // Add sticky menu on scroll
    $(document).on('bind ready scroll', function () {

        var docScroll = $(document).scrollTop();
        if (docScroll >= 10) {
            navbarFixed.addClass('sticked');
        } else {
            navbarFixed.removeAttr('class');
        }
    });

    // Payment options
    // ----------------------------------------------------------------

    $("#paymentCart").on('click', function () {
        if ($(this).is(":checked")) {
            $(".payment").removeClass('active');
            $(".payment-cart").addClass('active');
        }
    });

    $("#paymentPayPal").on('click', function () {
        if ($(this).is(":checked")) {
            $(".payment").removeClass('active');
            $(".payment-paypal").addClass('active');
        }
    });

    // About image caption
    // ----------------------------------------------------------------

    var $blogImage = $('.about .text-block .text img');
    $blogImage.each(function () {
        var $this = $(this);
        $this.wrap('<span class="image"></span>');
        if ($this.attr("alt")) {
            var caption = this.alt;
            var link = $this.attr('data');
            $this.after('<span class="caption">' + caption + '</span>');
        }
    });

    // Coupon code
    // ----------------------------------------------------------------

    $(".form-coupon").hide();
    $("#couponCodeID").on('click', function () {
        if ($(this).is(":checked")) {
            $(".form-coupon").fadeIn();
        } else {
            $(".form-coupon").fadeOut();
        }
    });

    // Checkout login / register
    // ----------------------------------------------------------------

    var loginWrapper = $('.login-wrapper'),
        loginBtn = loginWrapper.find('.btn-login'),
        regBtn = loginWrapper.find('.btn-register'),
        signUp = loginWrapper.find('.login-block-signup'),
        signIn = loginWrapper.find('.login-block-signin');

    loginBtn.on('click', function () {
        signIn.show();
        signUp.hide();
    });

    regBtn.on('click', function () {
        signIn.hide();
        signUp.show();
    });

    // Team members hover effect
    // ----------------------------------------------------------------

    var $member = $('.team article');
    $member.on({
        mouseenter: function (e) {
            $member.addClass('inactive');
            $(this).addClass('active');
        },
        mouseleave: function (e) {
            $member.removeClass('inactive');
            $(this).removeClass('active');
        }
    });

    // Cards article
    // ----------------------------------------------------------------

    $('.cards figure').on({
        mouseenter: function (e) {
            $(this).addClass('active');
        },
        mouseleave: function (e) {
            $(this).removeClass('active');
        }
    });

    // Toggle contact form
    // ----------------------------------------------------------------

    $('.open-form').on('click', function () {
        var $this = $(this),
            parent = $this.parent();
        parent.toggleClass('active');
        if (parent.hasClass('active')) {
            $this.text($this.data('text-close'));
            $('.contact-form').slideDown();
        }
        else {
            $this.text($this.data('text-open'));
            $('.contact-form').slideUp();
        }

    });

    // Datepicker
    // ------------------------------------------------------

    // Default calendar namespaces
    var dateFormat = "<span class='day'>d</span> <span class='month'>M</span> <span class='year'>yy</span>",
        dateArrival = '#dateArrival input',
        dateDeparture = '#dateDeparture input',
        dateArrivalVal = '#dateArrival .date-value',
        dateDepartureVal = '#dateDeparture .date-value';

    // Show arrival calendar
    $(dateArrival).datepicker({
        minDate: 'D',
        dateFormat: dateFormat,
        // get value on selected date for departure
        onSelect: function (txt, inst) {
            // get arrival value
            $(dateArrivalVal).html($(dateArrival).val());
            // set date format
            $(dateDepartureVal).html(txt);
            // set day after
            var NewDay = $(dateDepartureVal).find('.day'),
                NewDayVal = NewDay.html();
            NewDay.html(parseInt(NewDayVal) + 1);

        },
        onClose: function (selectedDate) {
            var myDate = $(this).datepicker('getDate');
            myDate.setDate(myDate.getDate() + 1);
            // Set min-date value and day after on date departure
            $(dateDeparture).datepicker("option", "minDate", myDate);
        }
    });

    // Show departure calendar
    $(dateDeparture).datepicker({
        minDate: 'D+1',
        dateFormat: dateFormat,
        // get value on selected date for return
        onSelect: function (txt, inst) {
            $(dateDepartureVal).html(txt);
            $(dateDepartureVal).html($(dateDeparture).val());
        }
    });

    // set current date
    $('.datepicker').datepicker('setDate', 'today');
    // get current value from departure 
    $(dateArrivalVal).html($(dateArrival).val());
    // get current value from return
    $(dateDepartureVal).html($(dateDeparture).val());
    // hide return input field
    updateGuestNumber();
    // update number of guest list


    // Guests 
    // -------------------------------------------------------

    var $guests = $('.guests'),
        $guestList = $('.guests .guest-list');

    // Guest list toogle event - dropdown
    $('.guests .result').on('click', function (e) {

        e.stopPropagation();
        $guests.toggleClass("show");

        if ($guests.hasClass('show')) {
            $guestList.fadeIn();
        }
        else {
            $guestList.fadeOut();
        }

    });

    // Close on page click
    $('.qty-apply').on("click", function (e) {
        $guestList.fadeOut();
        $guests.removeClass("show");
    });

    // Quantities (add remove guests numbers) 
    // -------------------------------------------------------

    $('.qty-plus').add('.qty-minus').on("click", function (e) {
        e.preventDefault();

        var $this = $(this),
            fieldName = $this.attr('data-field'),
            $input = $('input#' + fieldName);

        var currentVal = parseInt($input.data('value'), 10),
            ticketType = $input.data('tickettype');

        if (!isNaN(currentVal)) {
            var isChanged = false,
                value = 0;

            if ($this.hasClass('qty-plus') && currentVal < 12) {
                value = currentVal + 1;
                isChanged = true;
            }

            if ($this.hasClass('qty-minus') && currentVal > 0) {
                value = currentVal - 1;
                isChanged = true;
            }

            if (isChanged) {
                $input.data('value', value);
                $(ticketType).val(ticketType + '-' + value);
                $input.val(value);
                // Update guests number
                updateGuestNumber();
            }
        }
    });

    // Passangers result
    function updateGuestNumber() {
        var adult = $('#ticket-adult').val(),
            children = $('#ticket-children').val(),
            infants = $('#ticket-infants').val(),
            qty = $('#qty-result');
        qty.val(parseInt(adult, 10) + parseInt(children, 10) + parseInt(infants, 10));
        // DOM results
        $('#qty-result-text').text(qty.val());
    }


});

$(window).on('load', function () {
    setTimeout(function () {
        $('.page-loader').addClass('loaded');
    }, 1000);
});



