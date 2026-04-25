$(function () {

    // ── People: jQuery UI Tabs ──────────────────────────────────────────
    if ($("#peopletabs").length) {
        $("#peopletabs").tabs({
            hide: { effect: "fadeOut", duration: 200 },
            show: { effect: "fadeIn", duration: 200 }
        });
    }

    // ── Degrees: jQuery UI Accordion ────────────────────────────────────
    // (initialized inline in Degrees.cshtml @section Scripts)

    // ── Nav: active link highlight ───────────────────────────────────────
    var path = window.location.pathname.toLowerCase();
    $(".nav-links a").each(function () {
        var href = $(this).attr("href") ? $(this).attr("href").toLowerCase() : "";
        if (href && href !== "/" && path.indexOf(href) === 0) {
            $(this).addClass("active");
        }
        if (href === "/" && path === "/") {
            $(this).addClass("active");
        }
    });

    // ── Fade-in on scroll ───────────────────────────────────────────────
    function revealOnScroll() {
        $(".fade-up").each(function () {
            var top = $(this).offset().top;
            var winBottom = $(window).scrollTop() + $(window).height();
            if (winBottom > top + 40) {
                $(this).addClass("visible");
            }
        });
    }
    $(window).on("scroll", revealOnScroll);
    revealOnScroll(); // run once on load
});

    // ── Cycle2 Carousel (homepage) ───────────────────────────────────────
    // Cycle2 auto-initialises from data-cycle-* attributes on .cycle-slideshow
    // No extra JS needed — but you can override options here if desired:
    // if ($(".cycle-slideshow").length) {
    //     $(".cycle-slideshow").cycle({ timeout: 5000, fx: "fade" });
    // }