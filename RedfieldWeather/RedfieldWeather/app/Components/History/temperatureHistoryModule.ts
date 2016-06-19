module TemperatureHistoryModule {
    angular.module("redfieldWeatherApp")
        .component("temperatureHistory", {
                templateUrl: '/app/Components/History/temperatureHistory.html',
                controller: (historyService: HistoryServicesModule.HistoryServices) => new CurrentConditionsController(historyService),
                controllerAs: "tempHistory",
                bindings: {
                    title: "@"
                }
            }
        );

    class CurrentConditionsController {
        static $inject = ["historyService"];

        title: string;

        constructor(private historyService: HistoryServicesModule.HistoryServices) {
        }

        get history() {
            return this.historyService.history;
        }

        get historyData() {
            var data: number[];
            var label: string[];

            this.historyService.history.forEach((history: any) => {
                data.push(history.conditions.temperature.degrees);
                label.push(history.timeOfUpdate);
            });

            return { labels: label, datasets: [{ data: data }] };
        }
    }
}