(function (app) {

    var app = angular.module("parkingModule");

    var ParkingController = function ($scope, parkingService) { //

        $scope.test = "Testar om det syns nåt";

        alert("i ParkingController");

        //$scope.divFordon = false;
        
        // To Get All Records 
        function GetAllFordon() {
            alert("i GetAllFordon");
            
            var getData = parkingService.getFordon();
            
            getData.then(function (response) {
                $scope.fordon = response.data;
            }, function () {
                alert('Error in getting records');
            });
        }

        GetAllFordon();
    };

    app.controller("ParkingController", ParkingController);

}());
