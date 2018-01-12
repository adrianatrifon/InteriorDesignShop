var CardController = function(containerId, Design,pictureCard) {
    this.RenderCard = function() {
        var jqCardDivContainer = $("#" + containerId);
        var jqCardDiv = $("<div class='card pull-left'>");
        var jqImageCard = $("<img class='card-img-top'>").attr({ src: pictureCard, alt: Design.Name });
        jqCardDiv.append(jqImageCard);
        var jqCardBody = $("<div class='card-body'>").append("<h4 class='card-title'>" + Design.Name + "</h4>").append("<p class='card-text'>" + Design.Description + "</p>")
            .append("<a href='#' class='btn btn-primary'>" + "Discover More" + "</a>");
        jqCardDiv.append(jqCardBody);
        jqCardDivContainer.append(jqCardDiv);
    };
};