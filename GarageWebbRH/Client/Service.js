(function () {

    var parkingService = function ($http, $log) {

        // To Get All Records 
        var getFordon = function () {
            //alert("Service.js -> i getFordon servicen");
            return $http.get("/Fordons/GetFordon")
                        .then(function (response) {
                            $log.log("Get Fordon: "+response.data);
                            return response.data;
                        });
        };

        return {
            getFordon: getFordon
        };
    };

    var module = angular.module("parkingModule");
    module.factory("parkingService", parkingService);

}());