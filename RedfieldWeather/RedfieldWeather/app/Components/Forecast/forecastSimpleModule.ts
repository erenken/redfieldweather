module ForecastSimpleModule {
    angular.module("redfieldWeatherApp")
        .component("forecastSimple", {
            templateUrl: '/app/Components/Forecast/forecastSimple.html',
            controller: (weatherService: WeatherServicesModule.WeatherServices) => new CurrentConditionsController(weatherService),
            controllerAs: "forecastSmp"
        }
        );

    class CurrentConditionsController {
        static $inject = ["weatherService"];

        constructor(private weatherService: WeatherServicesModule.WeatherServices) {
        }

        get forecast() {
            return this.weatherService.forecastSimple;
        }
    }
}