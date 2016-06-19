module MapsModule {
    angular.module("redfieldWeatherApp")
        .component("maps", {
				templateUrl: '/app/Components/Maps/maps.html',
				controller: () => new MapsController(),
				controllerAs: "maps"
		}
	);

    class MapsController {

        constructor() {
        }
    }
}
