var ModalController = function (Design) {
    this.RenderModal=function()
    {        
        var jqDivCarousel = $("<div id='" + Design.Id + "Carousel' class='image-carousel' style='display:none'>");
        var jqInnerDiv = $("<div class='inner'>").append("<img src='"+Design.Photos+"'>");
        var jqDivBubbles = $("<div class='bubbles'>");
        var jqDivPrev = $("<div class='prev'>");
        var jqDivNext = $("<div class='next'>");
        jqDivCarousel.append(jqInnerDiv);
        jqDivCarousel.append(jqDivBubbles);
        jqDivCarousel.append(jqDivPrev);
        jqDivCarousel.append(jqDivNext);
        $('.wp-content').append(jqDivCarousel);
        $("#button-close-popup").click(function () {
            $(".window-popup").fadeOut(300);
            $("#" + Design.Id+"Carousel").hide();
        });
    };
};
