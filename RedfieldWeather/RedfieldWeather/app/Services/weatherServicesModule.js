var WeatherServicesModule;
(function (WeatherServicesModule) {
    angular.module("redfieldWeatherApp")
        .service("weatherService", [
        "$http", "$interval", "$sce",
        function ($http, $interval, $sce) { return new WeatherServices($http, $interval, $sce); }
    ]);
    var WeatherServices = (function () {
        function WeatherServices($http, $interval, $sce) {
            this.$http = $http;
            this.$interval = $interval;
            this.$sce = $sce;
            this.weatherField = {};
            this.alertsField = {};
            this.forecastTextField = {};
            this.forecastSimpleField = {};
            this.getLatestWeather($http, $sce);
            this.setupInterval($http, $sce);
            this.getWeatherAlerts();
            this.getForcast();
        }
        Object.defineProperty(WeatherServices.prototype, "weather", {
            get: function () {
                return this.weatherField;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(WeatherServices.prototype, "alerts", {
            get: function () {
                return this.alertsField;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(WeatherServices.prototype, "forecastText", {
            get: function () {
                return this.forecastTextField;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(WeatherServices.prototype, "forecastSimple", {
            get: function () {
                return this.forecastSimpleField;
            },
            enumerable: true,
            configurable: true
        });
        WeatherServices.prototype.getForcast = function () {
            var _this = this;
            this.$http.get("http://api.wunderground.com/api/bb6a3189979ad2cc/forecast/q/MI/Niles.json").then(function (response) {
                var data = response.data;
                _this.forecastTextField = data.forecast.txt_forecast.forecastday;
                _this.forecastSimpleField = data.forecast.simpleforecast.forecastday;
            }, function (errorResponse) {
                console.error(errorResponse);
            });
        };
        WeatherServices.prototype.getWeatherAlerts = function () {
            var _this = this;
            this.$http.get("http://api.wunderground.com/api/bb6a3189979ad2cc/alerts/q/MI/Niles.json").then(function (response) {
                var data = response.data;
                if (data.alerts) {
                    data.alerts.forEach(function (alert) {
                        alert.message = _this.$sce.trustAsHtml(alert.message.replace(/\*/g, "<br/><br/>"));
                        alert.date = alert.date.replace("/", "");
                    });
                }
                _this.alertsField = data;
            }, function (errorResponse) {
                console.error(errorResponse);
            });
        };
        WeatherServices.prototype.getLatestWeather = function ($http, $sce) {
            var _this = this;
            $http.get("/api/weatherFlash/latest", { timeout: 25000 }).then(function (response) {
                var data = response.data;
                if (data.conditions.temperature.degrees < 45)
                    data.conditions.temperature.feelsLike = data.conditions.temperature.windChill;
                else
                    data.conditions.temperature.feelsLike = data.conditions.temperature.heatIndex;
                var rateArrow = function (rate) {
                    var arrow = "";
                    if (rate > 0)
                        arrow = "&uarr;";
                    else if (rate < 0)
                        arrow = "&darr;";
                    return $sce.trustAsHtml(arrow);
                };
                data.conditions.temperature.rateArrow = rateArrow(data.conditions.temperature.rate);
                data.conditions.barometer.rateArrow = rateArrow(data.conditions.barometer.rawRate);
                _this.weatherField = data;
            }, function (errorResponse) {
                console.error(errorResponse);
            });
        };
        ;
        WeatherServices.prototype.setupInterval = function ($http, $sce) {
            this.intervalPromise = this.$interval(this.getLatestWeather, 30000, 0, false, $http, $sce);
        };
        ;
        WeatherServices.$inject = ["$http", "$interval", "$sce"];
        return WeatherServices;
    }());
    WeatherServicesModule.WeatherServices = WeatherServices;
})(WeatherServicesModule || (WeatherServicesModule = {}));
//# sourceMappingURL=weatherServicesModule.js.map