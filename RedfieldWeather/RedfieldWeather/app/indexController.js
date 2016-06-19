var IndexController = (function () {
    function IndexController(weatherService) {
        this.weatherService = weatherService;
    }
    Object.defineProperty(IndexController.prototype, "loaded", {
        get: function () {
            return this.weatherService.weather || this.weatherService.alerts;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(IndexController.prototype, "currentTemperature", {
        get: function () {
            if (this.weatherService.weather.conditions)
                return this.weatherService.weather.conditions.temperature.degrees;
            else
                return undefined;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(IndexController.prototype, "temperatureRateArrow", {
        get: function () {
            if (this.weatherService.weather.conditions)
                return this.weatherService.weather.conditions.temperature.rateArrow;
            else
                return undefined;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(IndexController.prototype, "hasAlerts", {
        get: function () {
            if (this.weatherService.alerts.alerts && this.weatherService.alerts.alerts.length > 0)
                return true;
            else
                return false;
        },
        enumerable: true,
        configurable: true
    });
    IndexController.$inject = ["weatherService"];
    return IndexController;
}());
angular.module("redfieldWeatherApp")
    .controller("indexController", ["weatherService", IndexController]);
//# sourceMappingURL=indexController.js.map