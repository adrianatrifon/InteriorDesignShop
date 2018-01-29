var PhotoService = function() {
    _photos = [
        {
            Id: "pic1",
            Photo: "Resources/bathroom/baie1.png"
        },
        {
            Id: "pic2",
            Photo: "Resources/bathroom/baie2.png"
        },
        {
            Id: "pic3",
            Photo: "Resources/bathroom/baie3.png"
        },
        {
            Id: "pic4",
            Photo: "Resources/bathroom/baie4.png"
        },
        {
            Id: "pic5",
            Photo: "Resources/kitchen/kit1.png"
        },
        {
            Id: "pic6",
            Photo: "Resources/kitchen/kit2.png"
        },
        {
            Id: "pic7",
            Photo: "Resources/kitchen/kit3.png"
        },
        {
            Id: "pic8",
            Photo: "Resources/livingroom/liv1.png"
        },
        {
            Id: "pic9",
            Photo: "Resources/livingroom/liv3.png"
        },
        {
            Id: "pic10",
            Photo: "Resources/livingroom/liv5.png"
        },
        {
            Id: "pic11",
            Photo: "Resources/livingroom/liv71.png"
        },
        {
            Id: "pic12",
            Photo: "Resources/bedroom/dor11.png"
        },
        {
            Id: "pic13",
            Photo: "Resources/bedroom/dor21.png"
        },
        {
            Id: "pic14",
            Photo: "Resources/bedroom/dor31.png"
        },
        {
            Id: "pic15",
            Photo: "Resources/bedroom/dor41.png"
        }
    ];

    this.ReadAll = function() {
        return _photos;
    };

    this.ReadById = function(id) {
        for (var index = 0; index < _photos.length; index++) {
            if (_photos[index].Id === id) {
                return _photos[index];
            }
        }
    };    
};