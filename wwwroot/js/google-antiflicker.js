// https://developers.google.com/optimize
/**
        * Adds a class to the <html> element that hides the page until the Optimize
            * container is loaded and the experiment is ready. Once Optimize is ready
            * (or 4 seconds has passed), the class is removed from the <html> element
                * and the page becomes visible again.
                *
                * @param {Window} a The global object.
                * @param {HTMLHtmlElement} s The <html> element.
                    * @param {string} y The name of the class used to hide the <html> element.
                        * @param {string} n The name of property that references the dataLayer object.
                        * @param {number} c The max time (in milliseconds) the page will be hidden.
                        * @param {Object} h An object whose keys are Optimize container IDs.
                        * @param {undefined} i (unused parameter).
                        * @param {undefined} d (unused parameter).
                        * @param {undefined} e (unused parameter).
                        */
                        (function(a, s, y, n, c, h, i, d, e) {
                            // Adds a class (defaulting to 'async-hide') to the <html> element.
                            s.className += ' ' + y;

                        // Keeps track of the exact time that the snippet executes.
                        h.start = 1*new Date;

  // Creates a function and assigns it to a local variable `i` as well as
  // the `end` property of the Optimize container object. Once Optimize is
  // loaded it will call this function, which will remove the 'async-hide'
  // class from the <html> element, causing the page to become visible again.
                            h.end = i = function() {
                                s.className = s.className.replace(RegExp(' ?' + y), '');
  };

                            // Initializes the dataLayer as an empty array if it's not already initialized
                            // and assigns the passed Optimize container object to the dataLayer's `hide`
                            // property. This makes the function defined above accessible globally at the
                            // path `window.dataLayer.hide.end`, so it can be called by Optimize.
                            (a[n] = a[n] || []).hide = h;

                            // Creates a timeout that will call the page-showing function after the
                            // timeout amount (defaulting to 4 seconds), in the event that Optimize has
                            // not already loaded. This ensures your page will not stay hidden in the
                            // event that Optimize takes too long to load.
                            setTimeout(function() {
                                i();
                            h.end = null
  }, c);
                            h.timeout = c;
})(
                            window, // The initial value for local variable `a`.
                            document.documentElement, // The initial value for local variable `s`.
                            'async-hide', // The initial value for local variable `y`.
                            'dataLayer', // The initial value for local variable `n`.
                            4000, // The initial value for local variable `c`.
                            {'OPT-XXXXXX': true} // The initial value for local variable `h`.
                            );