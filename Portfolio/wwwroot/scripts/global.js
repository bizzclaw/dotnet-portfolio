$(document).ready(function () {
    var datedivs = $(".timestamp")
    for (var i = 0; i < datedivs.length; i++) {
        var datediv = datedivs[i];
        var stringDate = $(datediv).attr("value")

        var date = new Date(stringDate + " UTC")
        var localeString = date.toLocaleString()
        localeString = localeString.replace(", ", " - ")
        $(datediv).append(localeString);
    }
});
