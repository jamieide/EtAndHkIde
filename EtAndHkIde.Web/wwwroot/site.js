(function () {
    lightbox.option({
        wrapAround: true
    });

})();

var etandhkide = (function () {
    function getState() {
        return JSON.parse(window.localStorage.getItem('site-state'));
    }
    function setState(siteState) {
        window.localStorage.setItem('site-state', JSON.stringify(siteState));
    }

    var siteState = getState();
    if (!siteState) {
        siteState = {
            "home": {
                "pagesTab": undefined
            }
        }
        setState(siteState);
    }

    return {
        getState: getState,
        setState: setState
    }
})();

