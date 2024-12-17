function redirectToEmail() {
    var email = 'somesh.chauhan.255@gmail.com';
    var subject = '';
    var body = '';

    var mailtoLink = 'mailto:' + encodeURIComponent(email) +
        '?subject=' + encodeURIComponent(subject) +
        '&body=' + encodeURIComponent(body);

    window.open(mailtoLink, '_blank');
}


document.addEventListener("DOMContentLoaded", function () {
    
    const dynamicWords = ["bedsheets", "covers", "furnishing"];

    let index = 0;

    const searchBox = document.getElementById("dynamicSearchBox");

    if (!searchBox) {
        console.error("Search box not found! Check your HTML.");
        return;
    }

    function updatePlaceholder() {
        const staticText = "Search"; 
        searchBox.setAttribute("placeholder", `${staticText} ${dynamicWords[index]}`);
        index = (index + 1) % dynamicWords.length; 
    }

    setInterval(updatePlaceholder, 2000);
});