var CurrentAlertsModule;
(function (CurrentAlertsModule) {
    angular.module("redfieldWeatherApp")
        .component("currentAlerts", {
        templateUrl: '/app/Components/CurrentAlerts/CurrentAlerts.html',
        controller: function (weatherService) { return new CurrentAlertsController(weatherService); },
        controllerAs: "currentAlerts"
    });
    var CurrentAlertsController = (function () {
        function CurrentAlertsController(weatherService) {
            this.weatherService = weatherService;
        }
        Object.defineProperty(CurrentAlertsController.prototype, "alerts", {
            get: function () {
                return this.weatherService.alerts;
            },
            enumerable: true,
            configurable: true
        });
        CurrentAlertsController.$inject = ["weatherService"];
        return CurrentAlertsController;
    }());
})(CurrentAlertsModule || (CurrentAlertsModule = {}));
//# sourceMappingURL=currentAlertsModule.js.map