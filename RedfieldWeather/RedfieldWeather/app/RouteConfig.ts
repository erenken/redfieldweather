/// <reference path="../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../scripts/typings/angularjs/angular-route.d.ts" />

"use strict";

angular.module("redfieldWeatherApp")
    .config([
        "$routeProvider", ($routeProvider: ng.route.IRouteProvider) => {
            $routeProvider
                .when("/", { templateUrl: "/app/Views/CurrentConditions.html" })
                .when("/About", { templateUrl: "/app/Views/About.html" })
                .when("/Forecast", { templateUrl: "/app/Views/Forecast.html" })
				.when("/Maps", { templateUrl: "/app/Views/Maps.html" })
                .otherwise({ redirectTo: "/" });
        }
    ]);