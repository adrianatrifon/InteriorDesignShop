var DesignService = function () {

    var _designs = [];
    $.ajax({
        crossDomain:true,
        url: "http://localhost:51902/api/designs",
        method: 'GET',
        dataType: "json",        
        success: function (data) {
            $.each(data, function (key, val) {
                _designs.push(val);
            });
        }
    });
    this.ReadAll = function() {
        return _designs;
    };

    this.ReadById = function(id) {
        for (var index = 0; index < _designs.lenght; index++) {
            if (_designs[index].Id === id) {
                return _designs[index];
            }
        }
        return null;
    };
};