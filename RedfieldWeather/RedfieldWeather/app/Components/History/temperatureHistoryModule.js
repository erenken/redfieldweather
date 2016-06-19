var TemperatureHistoryModule;
(function (TemperatureHistoryModule) {
    angular.module("redfieldWeatherApp")
        .component("temperatureHistory", {
        templateUrl: '/app/Components/History/temperatureHistory.html',
        controller: function (historyService) { return new CurrentConditionsController(historyService); },
        controllerAs: "tempHistory",
        bindings: {
            title: "@"
        }
    });
    var CurrentConditionsController = (function () {
        function CurrentConditionsController(historyService) {
            this.historyService = historyService;
        }
        Object.defineProperty(CurrentConditionsController.prototype, "history", {
            get: function () {
                return this.historyService.history;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(CurrentConditionsController.prototype, "historyData", {
            get: function () {
                var data;
                var label;
                this.historyService.history.forEach(function (history) {
                    data.push(history.conditions.temperature.degrees);
                    label.push(history.timeOfUpdate);
                });
                return { labels: label, datasets: [{ data: data }] };
            },
            enumerable: true,
            configurable: true
        });
        CurrentConditionsController.$inject = ["historyService"];
        return CurrentConditionsController;
    }());
})(TemperatureHistoryModule || (TemperatureHistoryModule = {}));
//# sourceMappingURL=temperatureHistoryModule.js.map