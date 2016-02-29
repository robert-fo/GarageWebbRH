//(function () {

//    var parkingGarage = function ($http) {

//        //get All Eployee
//        var getFordon = function () {
            
//            alert("i getFordon");
//            ////return $http.get("Fordons/Index2");
//            //return $http.get("Fordons/GetFordon")
//            //            .success(function (response) {
//            //                return response.data;
//            //            });
//        };

//    };

//    var module = angular.module("parkingViewer");
//    module.factory("parkingGarage", parkingGarage);

//}());

(function () {

    var parkingGarage = function ($http) {

        var getFordon = function () {
            return $http.get("Fordons/GetFordon")
                        .then(function (response) {
                            return response.data;
                        });
        };


        return {
            getFordon: getFordon
        };

    };

    var module = angular.module("parkingViewer");
    module.factory("parkingGarage", parkingGarage);

}());
