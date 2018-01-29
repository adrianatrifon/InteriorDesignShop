var DesignsController = function(serviceContext) {
    this.RenderPage = function (menuCategory) {        
        var allDesigns = serviceContext.DesignService().ReadAll();        
        for (var i = 0; i < allDesigns.length; i++) {
           // var designPhotos = serviceContext.photoService.ReadDesignPhotos(allDesigns[i]);
            if (allDesigns[i].Category === menuCategory) {               
                var categoryName = menuCategory.charAt(0).toLowerCase() + menuCategory.slice(1).toLowerCase();
                containerId = categoryName + "Container";
                var designCardController = new CardController(containerId, allDesigns[i]);
                designCardController.RenderCard();
               
            }
        }     
    };
};