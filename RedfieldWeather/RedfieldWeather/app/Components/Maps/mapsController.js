var MapsModule;
(function (MapsModule) {
    angular.module("redfieldWeatherApp")
        .component("maps", {
        templateUrl: '/app/Components/Maps/maps.html',
        controller: function () { return new MapsController(); },
        controllerAs: "maps"
    });
    var MapsController = (function () {
        function MapsController() {
        }
        return MapsController;
    }());
})(MapsModule || (MapsModule = {}));
//# sourceMappingURL=mapsController.js.map