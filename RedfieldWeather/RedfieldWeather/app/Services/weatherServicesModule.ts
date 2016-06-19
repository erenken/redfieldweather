module WeatherServicesModule {
    angular.module("redfieldWeatherApp")
        .service("weatherService", [
            "$http", "$interval", "$sce", 
            ($http: ng.IHttpService, $interval: ng.IIntervalService, $sce: ng.ISCEService) => new WeatherServices($http, $interval, $sce)
        ]);

    export class WeatherServices {
        static $inject = ["$http", "$interval", "$sce"];
        intervalPromise: ng.IPromise<any>;

        private weatherField: any = {};
        private alertsField: any = {};
        private forecastTextField: any = {};
        private forecastSimpleField: any = {};

        constructor(private $http: ng.IHttpService, private $interval: ng.IIntervalService, private $sce: ng.ISCEService) {
            this.getLatestWeather($http, $sce);
            this.setupInterval($http, $sce);
            this.getWeatherAlerts();
            this.getForcast();
        }

        get weather() {
            return this.weatherField;
        }

        get alerts() {
            return this.alertsField;
        }

        get forecastText() {
            return this.forecastTextField;
        }

        get forecastSimple() {
            return this.forecastSimpleField;
        }

        private getForcast() {
            this.$http.get("http://api.wunderground.com/api/bb6a3189979ad2cc/forecast/q/MI/Niles.json").then(
                (response: any) => {
                    var data = response.data;

                    this.forecastTextField = data.forecast.txt_forecast.forecastday;
                    this.forecastSimpleField = data.forecast.simpleforecast.forecastday;
                },
                (errorResponse: any) => {
                    console.error(errorResponse);
                }
            );
        }

        private getWeatherAlerts() {
            this.$http.get("http://api.wunderground.com/api/bb6a3189979ad2cc/alerts/q/MI/Niles.json").then(
                (response: any) => {
                    var data = response.data;

                    if (data.alerts) {
                        data.alerts.forEach((alert: any) => {
                            alert.message = this.$sce.trustAsHtml(alert.message.replace(/\*/g, "<br/><br/>"));
                            alert.date = alert.date.replace("/", "");
                        });
                    }

                    this.alertsField = data;
                },
                (errorResponse: any) => {
                    console.error(errorResponse);
                }
            );
        }

        private getLatestWeather($http: ng.IHttpService, $sce: ng.ISCEService) {
            $http.get("/api/weatherFlash/latest", { timeout: 25000 }).then(
                (response: any) => {
                    var data = response.data;

                    if (data.conditions.temperature.degrees < 45)
                        data.conditions.temperature.feelsLike = data.conditions.temperature.windChill;
                    else
                        data.conditions.temperature.feelsLike = data.conditions.temperature.heatIndex;

                    var rateArrow = (rate: number) => {
                        var arrow: string = "";
                        if (rate > 0)
                            arrow = "&uarr;";
                        else if (rate < 0)
                            arrow = "&darr;";

                        return $sce.trustAsHtml(arrow);
                    };

                    data.conditions.temperature.rateArrow = rateArrow(data.conditions.temperature.rate);
                    data.conditions.barometer.rateArrow = rateArrow(data.conditions.barometer.rawRate);

                    this.weatherField = data;

                },
                (errorResponse: any) => {
                    console.error(errorResponse);
                }
            );
        };

        private setupInterval($http: ng.IHttpService, $sce: ng.ISCEService) {
            this.intervalPromise = this.$interval(this.getLatestWeather, 30000, 0, false, $http, $sce);
        };
    }
}