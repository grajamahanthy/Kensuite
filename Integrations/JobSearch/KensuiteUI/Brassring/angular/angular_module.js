//<reference path="https://ajax.googleapis.com/ajax/libs/angularjs/1.7.5/angular.min.js"/>

var app = angular
    .module("myModule", ['angularUtils.directives.dirPagination'])
    .controller("myController", function ($scope, $http) {

        $scope.keyword = '';
        $scope.LocationName = '';
        $scope.jobTitle = '';
        $scope.FLocation = '';
        $scope.path = '.unitField'
        $scope.ctrlSearchfilter = {};
        $scope.stateOption = '';
        $scope.contryOption = '';
        $scope.isNotPerf = false;
        $scope.productionserver = false;
        $scope.apiBase = 'https://kensuitejobsearchapi.warmcall.com';
        $scope.apiBase = 'http://localhost:54920';

        $scope.onchange = function (ketType, key) {
            // console.log(ketType);
            // console.log(key);
            if (ketType == 1)
                $scope.stateOption = key;
            else
                $scope.contryOption = key;
        }

        $scope.exists = function (el) {
            return el != null && typeof (el) != "undefined" && el.length > 0
        }


        $scope.getQuestionProp = function (id) {
            var title = '';
            if ($scope.isNotPerf) {
                $scope.FieldMapper.searchResultField.forEach(function (a) { if (a.idField == id) { title = a.titleField; } });
            }
            else {
                $scope.FieldMapper.SearchResult.forEach(function (a) {
                    if (a.Id == id) { title = a.Title; }

                });

            }

            return title;
        };

        $scope.clearFilter = function () {

            //Clearing Filter
            var catArr = $scope.Searchfilter.FilterCategories;
            for (var i = 0; i < catArr.length; i++) {
                var filterArr = catArr[i].FilterItems;
                for (var j = 0; j < filterArr.length; j++) {
                    {
                        filterArr[j].isSelected = false;
                    }
                }
            }

            //Search Results update after clearing Filter
            $scope.SearchJob();
        }


        $scope.featuredjobs = function (id, value) {
            $scope.idField = id;
            $scope.valuefield = value;
            $scope.clearFilter();
            if (value == '') {
                $scope.Searchfilter.IsHotJob = (value != '') ? $scope.Searchfilter.IsHotJob : !$scope.Searchfilter.IsHotJob;
            }
            else {
                $scope.Searchfilter.IsHotJob = true;
            }
        }

        ///check box show
        $scope.selection = [];

        $scope.collapseIt = function (id) {

            $scope.collapseId = ($scope.collapseId == id) ? -1 : id;
            // console.log($scope.collapseId);

        }

        /*Country ,state and city */




        $scope.contryoption = "";
        $scope.stateoption = "";
        $scope.cityoption = "";

        $scope.Countrys = [
            { "name": "US" },
            { "name": "UK" },
            { "name": "India" },
        ]

        $scope.states = {
            "US": [
                { "name": "Colorado", "shortname": "CO" },
                { "name": "Pennsylvania", "shortname": "PA" },
                { "name": "South Dakota", "shortname": "SD" },
                { "name": "Texas", "shortname": "TX" },
            ]
        }
        $scope.Cities = {
            "CO": [{ "name": "Denver" }],
            "PA": [{ "name": "Philadelphia" }],
            "SD": [{ "name": "Sioux Falls" }],
            "TX": [{ "name": "Indianola" }],
        }

        $scope.getSearchKeywords = function () {
            //Search Filter data
            //https://kensuitejobsearchapi.warmcall.com/api/default/
            $http.get($scope.apiBase + '/api/jobs/GetSearchKeyword')
                .then(function (response) {
                    var data = response.data;
                    // console.log(data);
                    $scope.Searchfilter = data.SearchFilter;
                    $scope.ctrlSearchQuestions = $scope.Searchfilter.SearchQuestions;

                });
        }

        $scope.getFeturedJobs = function () {
            $http.get($scope.apiBase + '/api/jobs/GetFeturedJobs')
                // $http.get('https://kensuitejobsearchapi.warmcall.com/api/default/GetSearchKeyword')
                .then(function (response) {
                    var data = response.data;
                    // console.log(data.FeaturedFilterCategories);

                    $scope.Searchfilter.FeaturedFilterCategories = data.FeaturedFilterCategories;
                    $scope.Searchfilter.FilterCategories = data.FilterCategories;

                });
        }

        $scope.getSearchResults = function (SearchUi) {
            // $http.post('https://kensuitejobsearchapi.warmcall.com/api/default/GetAllResult', SearchUi)
            $http.post($scope.apiBase + '/api/jobs/GetAllResult', SearchUi)

                .then(function (response) {
                    // console.log(response.data);
                    $scope.Result = response.data;

                    $scope.Jobs = $scope.Result.SearchResult;

                    $scope.Searchfilter = $scope.Result.SearchFilter;
                    $scope.FieldMapper = $scope.Result.FieldMaper;
                });
        }



        $scope.loadsearchUiAndFeaturedJobs = function () {

            if ($scope.isNotPerf) {
                $scope.getSearchKeywords();
                $scope.getFeturedJobs();
            }
            else {
                $scope.getallJobs();
                $scope.getSearchKeywords_local();
                // $scope.getFeturedJobs_local();

            }
        }



        $scope.SearchJob = function (filter) {
            //All Data
            //console.log(filter);

            $scope.Searchfilter.SearchQuestions = (filter == null ? $scope.ctrlSearchQuestions : $scope.Searchfilter.SearchQuestions);

            var SearchUi = new Object();  //{ "FilterCategories": $scope.Searchfilter, "KeyWord": $scope.keyword, "Location": $scope.LocationName };
            SearchUi = $scope.Searchfilter;

            if ($scope.isNotPerf) {
                $scope.getSearchResults(SearchUi);
            }
            else {
                //local methods 
                $scope.getSearchResults_local(SearchUi);


            }
        };

        /* Performance */
        $scope.getSearchKeywords_local = function () {

            // var fieldmapperName=($scope.isNotPerf)?'Fieldmaper.json':'Fieldmaper.json';
            // console.log(fieldmapperName);
            $http.get('Fieldmaper.json').then(function (response) {
                // console.log(response.data);
                $scope.Searchfilter = response.data.SearchFilter;
                $scope.ctrlSearchQuestions = response.data.SearchKeyword;
                $scope.FieldMapper = response.data;

            });

        }

        $scope.getallJobs = function () {
            $http.get($scope.apiBase + '/api/jobs/GetAllResult').then(function (response) {
                $scope.alldata = response.data;
            });
        }

        $scope.getSearchResults_local = function (SearchUi) {

            var jobresult = getJobsBysearch(SearchUi, $scope.ctrlSearchQuestions, $scope.alldata)

            var isFilter = SearchUi.FilterCategories == null ? false : true;
            $scope.Jobs = jobresult;
            if (!isFilter) {
                var searchfilter = GetLeftFilter($scope.FieldMapper, $scope.alldata, false, SearchUi);
                $scope.Searchfilter.FilterCategories = searchfilter;
                //$scope.Searchfilter = $scope.Result.SearchFilter;
            }
        }

        /* Performance */

        $scope.loadsearchUiAndFeaturedJobs();

    });


getJobsBysearch = function (SearchUi, fieldmaper, alljobs) {

    //console.log(SearchUi.FilterCategories);

    var searchkeycount = 0;

    for (i = 0; i < SearchUi.SearchQuestions.length; i++) {
        if (SearchUi.SearchQuestions[i].SearchKey) {
            searchkeycount++;
        }
    }


    // console.log(searchkeycount);
    var searchKeysExist = false;
    searchKeysExist = SearchUi.SearchQuestions != null && SearchUi.SearchQuestions.length > 0 && searchkeycount > 0;

    if (searchKeysExist) {
        for (i = 0; i < SearchUi.SearchQuestions.length; i++) {
            if (SearchUi.SearchQuestions[i].SearchKey) {
                var data = [];
                result = alljobs.filter(function (r) {
                    for (j = 0; j < r.questionField.length; j++) {
                        if (r.questionField[j].idField == SearchUi.SearchQuestions[i].Id && ((r.questionField[j].valueField == null ? '' : r.questionField[j].valueField).toLowerCase().includes(SearchUi.SearchQuestions[i].SearchKey.toLowerCase()))) {
                            data.push(r);
                        }
                    }
                })
                alljobs = data.length > 0 ? data : data;
            }
        }
    }

    var IsFilterCatExist = false;
    if (SearchUi.FilterCategories != null) {
        SearchUi.FilterCategories.filter(function (r) {
            console.log()
            var count = 0;
            for (j = 0; j < r.FilterItems.length; j++) {
                if (r.FilterItems[j].IsSelected) { count++; }
            }
            if (count > 0) { IsFilterCatExist = !IsFilterCatExist; }
        })
    }
    console.log(IsFilterCatExist);    

    if (IsFilterCatExist) {
        for (i = 0; i < SearchUi.FilterCategories.length; i++) {
            console.log(SearchUi.FilterCategories);
            console.log(SearchUi.FilterCategories[i]);

            result = alljobs.filter(function (r) {
                
                for (j = 0; j < r.questionField.length; j++) {
                    if (SearchUi.FilterCategories[i].FilterItems[j].IsSelected) {
                        console.log(SearchUi.FilterCategories[i].FilterItems[j].FilterItemTitle);
                        console.log(SearchUi.FilterCategories[i].Id);

                    }
                   
                }

            })

        }



    }




    return alljobs;
}

GetLeftFilter = function (fieldMapper, jobs, isHotJob, searchUi) {
    //  console.log(searchUi.FilterCategories);


    var filterjob = [];
    if (isHotJob) {

        var data = jobs.filter(function (r) {
            if (r.hotJobField.toLowerCase() == 'yes') {
                filterjob.push(r);
            }
        })
        jobs = filterjob;
    }

    var Filter_data = [];

    for (i = 0; i < fieldMapper.SearchFilter.length; i++) {
        var filteritems = [];

        // console.log(fieldMapper.SearchFilter[i]);
        jobs.filter(function (r) {

            for (j = 0; j < r.questionField.length; j++) {

                if (r.questionField[j].idField == fieldMapper.SearchFilter[i].Id) {

                    filteritems.push(r.questionField[j].valueField);
                    //  console.log(r.questionField[j].valueField);

                }
            }

        })


        filteritems.sort();
        filteritemsarray = [];
        var current = null;
        var cnt = 0;
        for (var z = 0; z < filteritems.length + 1; z++) {
            if (filteritems[z] != current) {
                if (cnt > 0) {
                    //   console.log(current + ' comes --> ' + cnt + ' times<br>');
                    filteritemsarray.push({ "FilterItemTitle": current, "FilterItemResultCount": cnt, "IsSelected": false })
                }
                current = filteritems[z];

                cnt = 1;
            } else {
                cnt++;
            }
        }
        Filter_data.push({
            "Title": fieldMapper.SearchFilter[i].Title,
            "FilterItems": filteritemsarray,
            "Id": fieldMapper.SearchFilter[i].Id
        })

    }
    // console.log(Filter_data);
    return Filter_data;

}
