//<reference path="https://ajax.googleapis.com/ajax/libs/angularjs/1.7.5/angular.min.js"/>

var app = angular
    .module("myModule", ['angularUtils.directives.dirPagination'])
    .controller("myController", function ($scope, $http) {

        $scope.keyword = '';
        $scope.LocationName = '';
        $scope.jobTitle = '';
        $scope.FLocation = '';
        $scope.path = '.unitField'

        //Search Filter data
        $http.get('https://kensuitejobsearchapi.warmcall.com/api/default/GetSearchKeyword')
            .then(function (response) {
                console.log(response.data);
                var data = response.data;
                // console.log(data["FilterCategories"]);
                $scope.Searchfilter = data.SearchFilter;
                // console.log($scope.Searchfilter[0]["Title"])
            });

        $scope.SearchJob = function () {
            //All Data
            var xkeyword = angular.element(document.getElementById("txtKeyword"));
            var xLocation = angular.element(document.getElementById("txtLocation"));
            $scope.keyword = xkeyword.val();
            $scope.LocationName = xLocation.val();
            var SearchUi = new Object();  //{ "FilterCategories": $scope.Searchfilter, "KeyWord": $scope.keyword, "Location": $scope.LocationName };
            SearchUi = $scope.Searchfilter;

            //console.log(SearchUi);
            $http.post('https://kensuitejobsearchapi.warmcall.com/api/default/GetAllResult', SearchUi)
                .then(function (response) {
                    $scope.Result = response.data;
                    console.log(response.data);

                    $scope.Jobs = $scope.Result.SearchResult;
                    $scope.Searchfilter = $scope.Result.SearchFilter;
                    $scope.FieldMapper = $scope.Result.FieldMaper;
                });

        };


        $scope.exists = function (el) {
            return el != null && typeof (el) != "undefined" && el.length > 0
        }


        $scope.getQuestionProp = function (id) {
            var title = '';
            $scope.FieldMapper.searchResultField.forEach(function (a) { if (a.idField == id) { title = a.titleField; } });
            return title;
        };


        ///check box show
        $scope.selection = [];
        
        $scope.collapseIt = function (id) {
            
            $scope.collapseId = ($scope.collapseId == id) ? -1 : id;
            console.log($scope.collapseId);

        }

        /*pagination code*/

      

    });
//var app = angular
//    .module("myModule", [])
//    .controller("myController", function ($scope) {

//        var employees = [
//            { firstName: "Ben", lastName: "Hastings", gender: "Male", salary: 55000 },
//            { firstName: "Sara", lastName: "Paul", gender: "Female", salary: 68000 },
//            { firstName: "Mark", lastName: "Holland", gender: "Male", salary: 57000 },
//            { firstName: "Pam", lastName: "Macintosh", gender: "Female", salary: 53000 },
//            { firstName: "Todd", lastName: "Barber", gender: "Male", salary: 60000 }
//        ];

//        $scope.employees = employees;
//    });
