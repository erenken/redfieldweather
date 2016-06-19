module ForecastTextModule {
    angular.module("redfieldWeatherApp")
        .component("forecastText", {
            templateUrl: '/app/Components/Forecast/forecastText.html',
            controller: (weatherService: WeatherServicesModule.WeatherServices) => new CurrentConditionsController(weatherService),
            controllerAs: "forecastTxt"
        }
        );

    class CurrentConditionsController {
        static $inject = ["weatherService"];

        constructor(private weatherService: WeatherServicesModule.WeatherServices) {
        }

        get forecast() {
            return this.weatherService.forecastText;
        }
    }
}