//var util = {
//    mobileMenu() {
//        $("#nav").toggleClass("nav-visible");
//    },
//    windowResize() {
//        if ($(window).width() > 800) {
//            $("#nav").removeClass("nav-visible");
//        }
//    },
//    scrollEvent() {
//        var scrollPosition = $(document).scrollTop();

//        $.each(util.scrollMenuIds, function (i) {
//            var link = util.scrollMenuIds[i],
//                container = $(link).attr("href"),
//                containerOffset = $(container).offset().top,
//                containerHeight = $(container).outerHeight(),
//                containerBottom = containerOffset + containerHeight;

//            if (scrollPosition < containerBottom - 20 && scrollPosition >= containerOffset - 20) {
//                $(link).addClass("active");
//            } else {
//                $(link).removeClass("active");
//            }
//        });
//    }
//};

//$(document).ready(function () {

//    util.scrollMenuIds = $("a.nav-link[href]");
//    $("#menu").click(util.mobileMenu);
//    $(window).resize(util.windowResize);
//    $(document).scroll(util.scrollEvent);

//});

// Highlight Current Page link in the Navbar
document.addEventListener('DOMContentLoaded', () => {
    const $navLinks = Array.prototype.slice.call(document.querySelectorAll('.nav-link'), 0);

    if ($navLinks.length > 0) {
        $navLinks.forEach(el => {
            if (window.location.pathname == el.getAttribute("href")) {
                el.className += " current";
            }
        })
    }
});
// End of Highlight Current Page link in the Navbar