(function () {
    function callback() {
        (function ($) {
            var jQuery = $;

            if (!document.activeElement) {
                alert('Click on the username field and then click on the bookmarklet.');
                return;
            }

            activeElement = document.activeElement;
            if (activeElement.type.toLowerCase() != 'text' && activeElement.tagName.toLowerCase() != 'textarea') {
                alert('Click on the username field and then click on the bookmarklet.');
                return;
            }

            var d = new Date();
            var url = $(location).attr('href');
            var ajaxUrl = 'http://localhost:{port}?action=autoType&url=' + url + '&favoredUserName={favoredUsername}&refresh=' + d.getTime();

            $.ajax({
                type: 'GET',
                url: ajaxUrl,
                async: false,
                jsonpCallback: 'jsonCallback',
                contentType: 'application/json',
                dataType: 'jsonp',
                success: function (json) {
                    if (json.actionResult == 'Error') {
                        alert(json.actionError);
                    }
                }
            });


        })(jQuery.noConflict(true))
    } var s = document.createElement('script'); s.src = 'https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js'; if (s.addEventListener) { s.addEventListener('load', callback, false) } else if (s.readyState) { s.onreadystatechange = callback } document.body.appendChild(s);
})()