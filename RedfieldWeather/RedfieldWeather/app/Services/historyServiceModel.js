var HistoryServicesModule;
(function (HistoryServicesModule) {
    angular.module("redfieldWeatherApp")
        .service("historyService", [
        "$http",
        function ($http) { return new HistoryServices($http); }
    ]);
    var HistoryServices = (function () {
        function HistoryServices($http) {
            this.$http = $http;
            this.getWeathHistory($http);
        }
        Object.defineProperty(HistoryServices.prototype, "history", {
            get: function () {
                return this.historyField;
            },
            enumerable: true,
            configurable: true
        });
        HistoryServices.prototype.getWeathHistory = function ($http) {
            var _this = this;
            $http.get("/api/weatherFlash/history/last/0", { timeout: 25000 }).then(function (response) {
                var data = response.data;
                _this.historyField = data;
            }, function (errorResponse) {
                console.error(errorResponse);
            });
        };
        ;
        HistoryServices.$inject = ["$http"];
        return HistoryServices;
    }());
    HistoryServicesModule.HistoryServices = HistoryServices;
})(HistoryServicesModule || (HistoryServicesModule = {}));
//# sourceMappingURL=historyServiceModel.js.map