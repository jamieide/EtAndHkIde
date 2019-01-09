(function($) {
    $(document).ready(function() {
        // add noopener to all target=_blank links, see https://www.jitbit.com/alexblog/256-targetblank---the-most-underestimated-vulnerability-ever/
        $("a[target=_blank]").attr("rel", "noopener");
    });
}(jQuery));