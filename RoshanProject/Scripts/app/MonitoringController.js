app.controller("monitoringController", function ($scope, AppCRUDService) {
    $scope.pageHeader = "Wind Monitoring System";

    var promiseGetStates = AppCRUDService.getStates();
    promiseGetStates.then(
        function (response) { $scope.states = response.data },
        function (resError) { $scope.error = 'Failure loading State List', resError; }
    );

    var promiseGetCities = AppCRUDService.getCities();
    promiseGetCities.then(
        function (response) { $scope.cityList = response.data },
        function (resError) { $scope.error = 'Failure loading City List', resError; }
    );

    var promiseGetStations = AppCRUDService.getStations();
    promiseGetStations.then(
        function (response) { $scope.stationList = response.data },
        function (resError) { $scope.error = 'Failure loading Station List', resError; }
    );

    $scope.getStateCities = function () {
        $scope.cities = AppCRUDService.getStateCity($scope.cityList, $scope.state.Code);
    }
    $scope.getCityStation = function () {
        if ($scope.city.Code != '' && $scope.city.Code != undefined) {
            $scope.stationCode = AppCRUDService.getCityStation($scope.stationList, $scope.state.Code, $scope.city.Code);

            var promiseGetPredictedSpeed = AppCRUDService.getPredictedSpeed($scope.stationCode);
            promiseGetPredictedSpeed.then(
                function (response) { $scope.predictedSpeed = response.data },
                function (resError) { $scope.error = 'Failure loading Predicted Speed', resError; }
            );
        }
    }
    $scope.getVariance = function () {
        $scope.variance = $scope.predictedSpeed - $scope.actualSpeed;
        if ($scope.variance <= 1 && $scope.variance >= -1)
            $scope.varianceColor = "black";
        else if ($scope.variance <= 3 && $scope.variance >= -3)
            $scope.varianceColor = "purple";
        else if ($scope.variance > 5 || $scope.variance < -5)
            $scope.varianceColor = "red";
        else
            $scope.varianceColor = "black";
    };
    
    $scope.datepickerOptions ={
        format: 'yyyy-mm-dd',
        //language: 'en',
        autoclose: true,
        weekStart: 0
    };
    
    $scope.date = '';
    $scope.visible = false;
    var counter = 1;

    $scope.toggleTable = function () {
        $scope.visible = !($scope.visible);
        var dataLength = localStorage.length;
        $scope.tableData = [];
        for (var i = dataLength; i > 0; i--)
            $scope.tableData.push(JSON.parse(localStorage.getItem('WindData' + i)));
    };
    $scope.clearData = function () {
        clearForm();
    };
    $scope.saveData = function () {
        saveForm();
        alert('Wind Monitoring data saved successfully');
    };

    function clearForm() {
        $scope.state.Code = '';
        $scope.cities = '';
        $scope.stationCode = '';
        $scope.variance = '';
        $scope.predictedSpeed = '';
        $scope.actualSpeed = '';
        $scope.varianceColor = "black";
    };
    
    function saveForm() {
        var obj = {
            "state":$scope.state.Code,
            "city":$scope.city.Code,
            "station":$scope.stationCode,
            "date":$scope.date,
            "predictedSpeed":$scope.predictedSpeed,
            "actualSpeed":$scope.actualSpeed,
            "variance": $scope.variance
        };

        localStorage.setItem('WindData'+(counter++), JSON.stringify(obj));
    };
});
