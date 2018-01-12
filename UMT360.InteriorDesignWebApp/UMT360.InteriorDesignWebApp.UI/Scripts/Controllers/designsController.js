var DesignsController = function(serviceContext) {
    this.RenderPage = function(menuCategory) {
        var allDesigns = serviceContext.DesignService().ReadAll();
        var allCategories = serviceContext.CategoryService().ReadAll();
        var allPhotos = serviceContext.PhotoService().ReadAll();
        var allDesignPhotos = serviceContext.DesignPhotoService().ReadAll();
        var categoryId;
        for (var j = 0; j < allCategories.length; j++) {
            if (allCategories[j].Name === menuCategory) {
                categoryId = allCategories[j].Id;
                break;
            }
        }
        for (var i = 0; i < allDesigns.length; i++) {
            if (allDesigns[i].CategoryId === categoryId) {
                var pictureId;
                for (var l = 0; l < allDesignPhotos.length; l++) {
                    if (allDesignPhotos[l].DesignId === allDesigns[i].Id) {
                        pictureId = allDesignPhotos[l].PhotoId;
                        break;
                    }
                }
                var pictureCard;
                for (var k = 0; k < allPhotos.length; k++) {
                    if (allPhotos[k].Id === pictureId) {
                        pictureCard = allPhotos[k].Photo;
                        break;
                    }
                }
                var categoryName = menuCategory.charAt(0).toLowerCase() + menuCategory.slice(1).toLowerCase();
                containerId = categoryName + "Container";
                var designCardController = new CardController(containerId, allDesigns[i],pictureCard);
                designCardController.RenderCard();
            }

        }         
            
    };
};