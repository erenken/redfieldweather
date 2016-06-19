module CurrentConditionsModule {
    angular.module("redfieldWeatherApp")
        .component("currentConditions", {
                templateUrl: '/app/Components/CurrentConditions/CurrentConditions.html',
                controller: (weatherService: WeatherServicesModule.WeatherServices) => new CurrentConditionsController(weatherService),
                controllerAs: "currentConditions"
            }
    );

    class CurrentConditionsController {
        static $inject = ["weatherService"];

        constructor(private weatherService: WeatherServicesModule.WeatherServices) {
        }

        get weather() {
            return this.weatherService.weather;
        }
    }
}
