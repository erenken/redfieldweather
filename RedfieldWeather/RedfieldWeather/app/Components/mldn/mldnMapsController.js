var mldnMapsModule;
(function (mldnMapsModule) {
    angular.module("redfieldWeatherApp")
        .component("mldnMaps", {
        templateUrl: '/app/Components/mldn/mldnMaps.html',
        controller: function () { return new mldnMapsController(); },
        controllerAs: "mldnMaps",
        bindings: {
            timelapse: "<"
        }
    });
    var mldnMapsController = (function () {
        function mldnMapsController() {
            this.timelapse = false;
        }
        Object.defineProperty(mldnMapsController.prototype, "mapUrl", {
            get: function () {
                if (this.timelapse)
                    return "/mldn/timelapse_viewer";
                else
                    return "/mldn";
            },
            enumerable: true,
            configurable: true
        });
        return mldnMapsController;
    }());
})(mldnMapsModule || (mldnMapsModule = {}));
//# sourceMappingURL=mldnMapsController.js.map