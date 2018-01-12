var MenuController = function(serviceContext) {
    var _self = this;
    var _designController = new DesignsController(serviceContext);
    var _menuElements = [
        {
            Id: "Kitchen",
            ContainerId: "kitchenContainer",
            Controller:_designController
        },
        {
            Id: "Bathroom",
            ContainerId: "bathroomContainer",
            Controller: _designController
        },
        {
            Id: "Bedroom",
            ContainerId: "bedroomContainer",
            Controller: _designController
        },
        {
            Id: "Livingroom",
            ContainerId: "livingroomContainer",
            Controller: _designController
        },
        {
            Id: "Dressing",
            ContainerId: "dressingContainer",
            Controller: _designController
        },
        {
            Id: "Office",
            ContainerId: "officeContainer",
            Controller: _designController
        },
        {
            Id: "Library",
            ContainerId: "libraryContainer",
            Controller: _designController
        }
    ];

    this.GenerateMenu = function() {
        var jqNavBarContainer = $("#navBarContainer");
        for (var i = 0; i < _menuElements.length; i++) {
            var jqNavBarItem = $("<a id='" + _menuElements[i].Id + "'class='nav-link active' href='#'>" + _menuElements[i].Id + "</a>");
            jqNavBarContainer.append(jqNavBarItem);
        }
        jqNavBarContainer.on("click", "a", goToPage);
    };

    function goToPage() {
        var jqSelectedListItem = $(this);
        var selectedId = jqSelectedListItem.attr("id");
        var selectedContainerId;
        var menuElementId;
        for (index = 0; index < _menuElements.length; index++) {
            if (_menuElements[index].Id === selectedId) {
                selectedContainerId = _menuElements[index].ContainerId;
                menuElementId = index;
                break;
            }
        }
        if (!selectedContainerId)
            return;
        var mainContainers = $("main > div");
        $(mainContainers).empty();
        for (i = 0; i < mainContainers.length; i++) {
            if (mainContainers[i].id !== selectedContainerId) {
                $(mainContainers[i]).hide();
            }
            else {
                $(mainContainers[i]).show();
                _menuElements[menuElementId].Controller.RenderPage(_menuElements[menuElementId].Id);
            }
        }
    }
};