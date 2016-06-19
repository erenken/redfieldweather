var ForecastSimpleModule;
(function (ForecastSimpleModule) {
    angular.module("redfieldWeatherApp")
        .component("forecastSimple", {
        templateUrl: '/app/Components/Forecast/forecastSimple.html',
        controller: function (weatherService) { return new CurrentConditionsController(weatherService); },
        controllerAs: "forecastSmp"
    });
    var CurrentConditionsController = (function () {
        function CurrentConditionsController(weatherService) {
            this.weatherService = weatherService;
        }
        Object.defineProperty(CurrentConditionsController.prototype, "forecast", {
            get: function () {
                return this.weatherService.forecastSimple;
            },
            enumerable: true,
            configurable: true
        });
        CurrentConditionsController.$inject = ["weatherService"];
        return CurrentConditionsController;
    }());
})(ForecastSimpleModule || (ForecastSimpleModule = {}));
//# sourceMappingURL=forecastSimpleModule.js.map