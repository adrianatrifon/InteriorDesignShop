var CategoryService = function() {
    _categories = [
        {
            Id: "cat1",
            Parent: "",
            Name: "Bathroom"
        },
        {
            Id: "cat2",
            Parent: "",
            Name: "Bedroom"
        },
        {
            Id: "cat3",
            Parent: "",
            Name: "Kitchen"
        },
        {
            Id: "cat4",
            Parent: "",
            Name: "Livingroom"
        }
    ];

    this.ReadAll = function() {
        return _categories;
    };

    this.ReadById = function(id) {
        for (var index = 0; index < _categories.length; index++) {
            if (_categories[index].Id === id) {
                return _categories[index];
            }
        }
    };
};