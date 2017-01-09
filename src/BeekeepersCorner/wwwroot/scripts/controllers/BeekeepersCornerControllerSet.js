
var BeekeepersController = function ($scope, $http) {

    $scope.beekeepers = [
        //test data
        {
            BeekeeperId: 1,
            FirstName: "Lee",
            LastName: "Mullen",
            Address: "5822 Pioneer Rd",
            City: "Saint Paul Park",
            State: "MN",
            Zipcode: "55071",
            Phone: "222-222-2222",
            Email: "lmullen@anymail.com"

        },
        {
            BeekeeperId: 2,
            FirstName: "Joanna",
            LastName: "Whale",
            Address: "1st St",
            City: "Saint Paul Park",
            State: "MN",
            Zipcode: "55071",
            Phone: "651-111-1111",
            Email: "jwhale@anymail.com"
        },
        {
            BeekeeperId: 3,
            FirstName: "Sarah",
            LastName: "Smith",
            Address: "3rd St",
            City: "Saint Paul Park",
            State: "MN",
            Zipcode: "55071",
            Phone: "651-444-4444",
            Email: "ssmith@anymail.com"
        }
    ];

  
    /*
    var result = $http.get("/BeekeepersAJ/GetBeekeepers");
    result.success(function (data) {
        $scope.beekeepers = data;
    });
    alert(result);
    */
}


//BeekeepersController.$inject = ['$scope', '$http'];

var BeehivesController = function ($scope) {
    $scope.models = {
        helloBeehives: 'Beehives!'
    };
}

BeehivesController.$inject = ['$scope'];

var CreateBeekeeperController = function ($scope) {
    $scope.save = function () {
        //$scope.user = angular.copy($scope.master);
    };
}

CreateBeekeeperController.$inject = ['$scope'];

var EditBeekeeperController = function ($scope) {
    $scope.edit = function () {
        //$scope.user = angular.copy($scope.master);
    };
}

EditBeekeeperController.$inject = ['$scope'];

