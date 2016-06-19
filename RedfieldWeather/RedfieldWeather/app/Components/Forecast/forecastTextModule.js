var ForecastTextModule;
(function (ForecastTextModule) {
    angular.module("redfieldWeatherApp")
        .component("forecastText", {
        templateUrl: '/app/Components/Forecast/forecastText.html',
        controller: function (weatherService) { return new CurrentConditionsController(weatherService); },
        controllerAs: "forecastTxt"
    });
    var CurrentConditionsController = (function () {
        function CurrentConditionsController(weatherService) {
            this.weatherService = weatherService;
        }
        Object.defineProperty(CurrentConditionsController.prototype, "forecast", {
            get: function () {
                return this.weatherService.forecastText;
            },
            enumerable: true,
            configurable: true
        });
        CurrentConditionsController.$inject = ["weatherService"];
        return CurrentConditionsController;
    }());
})(ForecastTextModule || (ForecastTextModule = {}));
//# sourceMappingURL=forecastTextModule.js.map