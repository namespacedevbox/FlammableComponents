function showModalDialog(dialogId) {
    $('#' + dialogId).modal('show');
}

function hideModalDialog(dialogId) {
    $('#' + dialogId).modal('hide');
}

$(document).ready(function () {
    var menu = $("#nav-bar-filter"),
        subMenu = $(".subfilter"),
        more = $("#more-nav"),
        parent = $(".filter-wrapper"),
        ww = $(window).width(),
        smw = more.outerWidth();

    menu.children("li").each(function () {
        var w = $(this).outerWidth();
        if (w > smw) smw = w + 20;
        return smw
    });
    more.css('width', smw);

    function contract() {
        var w = 0,
            outerWidth = parent.width() - smw - 50;
        for (i = 0; i < menu.children("li").size(); i++) {
            w += menu.children("li").eq(i).outerWidth();
            if (w > outerWidth) {
                menu.children("li").eq(i - 1).nextAll()
                    .detach()
                    .css('opacity', 0)
                    .prependTo(".subfilter")
                    .stop().animate({
                        'opacity': 1
                    }, 300);
                break;
            }
        }
    }

    function expand() {
        var w = 0,
            outerWidth = parent.width() - smw - 20;
        menu.children("li").each(function () {
            w += $(this).outerWidth();
            return w;
        });
        for (i = 0; i < subMenu.children("li").size(); i++) {
            w += subMenu.children("li").eq(i).outerWidth();
            if (w > outerWidth) {
                var a = 0;
                while (a < i) {
                    subMenu.children("li").eq(a)
                        .css('opacity', 0)
                        .detach()
                        .appendTo("#nav-bar-filter")
                        .stop().animate({
                            'opacity': 1
                        }, 300);
                    a++;
                }
                break;
            }
        }
    }
    contract();

    $(window).on("resize", function (e) {
        ($(window).width() > ww) ? expand() : contract();
        ww = $(window).width();
    });

});