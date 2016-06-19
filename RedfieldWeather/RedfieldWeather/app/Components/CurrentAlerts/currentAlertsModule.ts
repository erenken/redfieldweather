module CurrentAlertsModule {
    angular.module("redfieldWeatherApp")
        .component("currentAlerts", {
                templateUrl: '/app/Components/CurrentAlerts/CurrentAlerts.html',
                controller: (weatherService: WeatherServicesModule.WeatherServices) => new CurrentAlertsController(weatherService),
                controllerAs: "currentAlerts"
            }
        );
    
    class CurrentAlertsController {
        static $inject = ["weatherService"];

        constructor(private weatherService: WeatherServicesModule.WeatherServices) {
        }

        get alerts() {
            return this.weatherService.alerts;
        }
    }
}