module mldnMapsModule {
    angular.module("redfieldWeatherApp")
        .component("mldnMaps", {
				templateUrl: '/app/Components/mldn/mldnMaps.html',
				controller: () => new mldnMapsController(),
				controllerAs: "mldnMaps",
				bindings: {
					timelapse: "<"
				}
		}
	);

    class mldnMapsController {
		private timelapse: boolean = false;

        constructor() {
        }

		get mapUrl() {
			if (this.timelapse)
				return "/mldn/timelapse_viewer";
			else
				return "/mldn";
        } 
    }
}
