var CardController = function(containerId, Design) {
    this.RenderCard = function () {        
        var jqCardDivContainer = $("#" + containerId+ "Cards");   
        var jqCardDiv = $("<div class='card col-sm-2 col-md-3 col-lg-5 mt-4 clearfix'>");
        var jqImageCard = $("<img class='card-img-top'>").attr({ src: Design.Photos, alt: Design.Name });
        jqCardDiv.append(jqImageCard);
        var jqCardBody = $("<div class='card-body'>").append("<h4 class='card-title text-bold'>" + Design.Name + "</h4>").append("<p class='card-text'>" + Design.Description + "</p>")
            .append("<a href='#' class='btn btn-primary'>" + "Discover More" + "</a>");
        jqCardDiv.append(jqCardBody);
        jqCardDivContainer.append(jqCardDiv);
    };
};

