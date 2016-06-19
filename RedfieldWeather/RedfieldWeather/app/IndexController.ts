class IndexController {
    static $inject = ["weatherService"];

    constructor(private weatherService: WeatherServicesModule.WeatherServices) {
    }

    get loaded() {
        return this.weatherService.weather || this.weatherService.alerts;
    }

    get currentTemperature() {
        if (this.weatherService.weather.conditions)
            return this.weatherService.weather.conditions.temperature.degrees;
        else
            return undefined;
    }

    get temperatureRateArrow() {
        if (this.weatherService.weather.conditions)
            return this.weatherService.weather.conditions.temperature.rateArrow;
        else
            return undefined;
    }

    get hasAlerts() {
        if (this.weatherService.alerts.alerts && this.weatherService.alerts.alerts.length > 0)
            return true;
        else
            return false;
    }
}

angular.module("redfieldWeatherApp")
    .controller("indexController", ["weatherService", IndexController]);