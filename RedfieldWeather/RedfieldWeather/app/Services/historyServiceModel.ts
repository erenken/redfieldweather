module HistoryServicesModule {
    angular.module("redfieldWeatherApp")
        .service("historyService", [
            "$http",
            ($http: ng.IHttpService) => new HistoryServices($http)
        ]);

    export class HistoryServices {
        static $inject = ["$http"];
        intervalPromise: ng.IPromise<any>;

        private historyField: any;

        constructor(private $http: ng.IHttpService) {
            this.getWeathHistory($http);
        }

        get history() {
            return this.historyField;
        }

        private getWeathHistory($http: ng.IHttpService) {
            $http.get("/api/weatherFlash/history/last/0", { timeout: 25000 }).then(
                (response: any) => {
                    var data = response.data;
                    this.historyField = data;

                },
                (errorResponse: any) => {
                    console.error(errorResponse);
                }
            );
        };
    }
}