var BeekeepersCornerMVCApp = angular.module('BeekeepersCornerMVCApp', []);

BeekeepersCornerMVCApp.controller('BeekeepersController', BeekeepersController);

/*
BeekeepersCornerMVCApp.controller('BeekeepersController', ['$scope', '$http', function ($scope, $http) {
    //This model works
    $scope.models = {
        helloBeekeepers: 'Beekeepers!'
    };
    /*  $http is not working in this
    var result = $http.get("/BeekeepersAJ/GetBeekeepers");
    result.success(function (data) {
        $scope.beekeepers = data;
    });

    
}]);
*/
BeekeepersCornerMVCApp.controller('BeehivesController', BeehivesController);

BeekeepersCornerMVCApp.controller('CreateBeekeeperController', CreateBeekeeperController);

BeekeepersCornerMVCApp.controller('EditBeekeeperController', EditBeekeeperController);

/*
var configFunction = function ($routeProvider, $locationProvider) {

    $locationProvider.hashPrefix('!').html5Mode(true);


    $routeProvider.
        when('/routeOne', {
            templateUrl: 'HomeAJ/One'
        })
        .when('/routeTwo', {
            templateUrl: 'HomeAJ/Two'
        })
        .when('/routeThree', {
            templateUrl: 'HomeAJ/Three'
        });
}
configFunction.$inject = ['$routeProvider', '$locationProvider'];

BeekeepersCornerMVCApp.config(configFunction);

*/