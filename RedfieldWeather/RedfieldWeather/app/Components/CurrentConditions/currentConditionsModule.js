var CurrentConditionsModule;
(function (CurrentConditionsModule) {
    angular.module("redfieldWeatherApp")
        .component("currentConditions", {
        templateUrl: '/app/Components/CurrentConditions/CurrentConditions.html',
        controller: function (weatherService) { return new CurrentConditionsController(weatherService); },
        controllerAs: "currentConditions"
    });
    var CurrentConditionsController = (function () {
        function CurrentConditionsController(weatherService) {
            this.weatherService = weatherService;
        }
        Object.defineProperty(CurrentConditionsController.prototype, "weather", {
            get: function () {
                return this.weatherService.weather;
            },
            enumerable: true,
            configurable: true
        });
        CurrentConditionsController.$inject = ["weatherService"];
        return CurrentConditionsController;
    }());
})(CurrentConditionsModule || (CurrentConditionsModule = {}));
//# sourceMappingURL=currentConditionsModule.js.map