(function (app) {

    var app = angular.module("parkingModule");

    var ParkingController = function ($scope, $log, $http) { 
        //$scope.test = "Testar om det syns nåt";

        $scope.fordon = [];

        //alert("Controller.js -> i ParkingController");

        // To Get All Records 
        function GetAllFordon() {
            //alert("Controller.js -> i GetAllFordon");

            //var getData = parkingService.getFordon(); 
            // fungerare ej att köra http.get via en service...?
            $http.get("/Fordons/GetFordon")
                        .then(function (response) {
                            $log.log("Get Fordon: "+response.data);
                            $scope.fordon = response.data;
                        }, function () {
                            alert('http.get /Fordons/GetFordon gick fel');
                        });

            $log.log("1");
            $log.log($scope.fordon);
            $log.log("2");
        }

        $scope.orderByMe = function (x) {
            $scope.myOrderBy = x;
        }

        GetAllFordon();
    };

    app.controller("ParkingController", ParkingController);

}());