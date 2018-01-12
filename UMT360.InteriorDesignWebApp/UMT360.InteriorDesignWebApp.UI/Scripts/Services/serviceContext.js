var ServiceContext = function() {
    var _designService;
    var _photoService;
    var _categoryService;
    var _designPhotoService;
    this.DesignService = function() {
        if (!_designService) {
            _designService = new DesignService();
        }
        return _designService;
    };
    this.PhotoService = function() {
        if (!_photoService) {
            _photoService = new PhotoService();
        }
        return _photoService;
    };
    this.CategoryService = function() {
        if (!_categoryService) {
            _categoryService = new CategoryService();
        }
        return _categoryService;
    };
    this.DesignPhotoService = function() {
        if (!_designPhotoService) {
            _designPhotoService = new DesignPhotoService();
        }
        return _designPhotoService;
    };

};