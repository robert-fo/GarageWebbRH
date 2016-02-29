(function () {

    var parkingGarage = function ($http) {

        //get All Eployee
        this.getEmployees = function () {
            debugger;
            return $http.get("Fordons/Index2");
        };

    };

    var module = angular.module("parkingViewer");
    module.factory("parkingGarage", parkingGarage);

}());