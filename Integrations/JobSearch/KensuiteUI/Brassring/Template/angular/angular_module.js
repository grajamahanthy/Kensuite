//<reference path="https://ajax.googleapis.com/ajax/libs/angularjs/1.7.5/angular.min.js"/>

var app = angular
    .module("myModule", ['ngAnimate', 'ngSanitize', 'ui.bootstrap'])
    .controller("myController", function ($scope, $http) {

        $scope.keyword = '';
        $scope.LocationName = '';
        $scope.jobTitle = '';
        $scope.FLocation = '';
        $scope.path = '.unitField'
        $scope.ctrlSearchfilter = {};
        $scope.stateOption = '';
        $scope.contryOption = '';
        $scope.showfeaturedJobs = false;
        //true for server, false for local 
        $scope.isNotPerf = false;
        $scope.productionserver = false;
        $scope.apiBase = 'https://kensuitejobsearchapi.warmcall.com';
        //$scope.apiBase = 'http://localhost:54920';




        //pagination

        //*-------------------------------------

        $scope.viewby = 5;
        $scope.totalItems = '';
        $scope.currentPage = 1;
        $scope.maxSize = 10;
        $scope.itemsPerPage = $scope.viewby;



        $scope.setPage = function (pageNo) {
            $scope.currentPage = pageNo;
        };

        $scope.pageChanged = function () {
            // console.log('Page changed to: ' + $scope.currentPage);
        };

        $scope.setItemsPerPage = function (num) {
            $scope.itemsPerPage = num;
            $scope.currentPage = 1; //reset to first paghe
        };

        //*-------------------------------------

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

            if (catArr != undefined) {
                for (var i = 0; i < catArr.length; i++) {
                    var filterArr = catArr[i].FilterItems;
                    for (var j = 0; j < filterArr.length; j++) {
                        {
                            filterArr[j].IsSelected = false;
                        }
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
            if (!$scope.isNotPerf) {
                var SearchUi = new Object();  //{ "FilterCategories": $scope.Searchfilter, "KeyWord": $scope.keyword, "Location": $scope.LocationName };
                SearchUi = $scope.Searchfilter;
                jobresult = getJobsBysearch(SearchUi, $scope.ctrlSearchQuestions, $scope.alldata, true);
                $scope.Jobs = jobresult;
                $scope.totalItems = $scope.Jobs.length


            }
            else {
                $scope.Searchfilter.IsHotJob = true;
            }
            // if (value == '') {
            //     $scope.Searchfilter.IsHotJob = (value != '') ? $scope.Searchfilter.IsHotJob : !$scope.Searchfilter.IsHotJob;
            // }
            // else {
            //     $scope.Searchfilter.IsHotJob = true;
            // }

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

                    if ($scope.Searchfilter) {
                        $scope.getFeturedJobs();
                    }
                });
            //
            $http.get('Fieldmaper.json').then(function (response) {
                // console.log(response.data);
                $scope.Locationdata = response.data.SearchLocation;
            });

        }

        $scope.getFeturedJobs = function () {
            $http.get($scope.apiBase + '/api/jobs/GetFeturedJobs')
                .then(function (response) {
                    var data = response.data;
                    $scope.Searchfilter.FeaturedFilterCategories = data.FeaturedFilterCategories;
                    $scope.Searchfilter.FilterCategories = data.FilterCategories;

                });
        }

        $scope.getSearchResults = function (SearchUi) {
            $http.post($scope.apiBase + '/api/jobs/GetAllResult', SearchUi)

                .then(function (response) {
                    $scope.Result = response.data;
                    $scope.Jobs = $scope.Result.SearchResult;
                    $scope.totalItems = $scope.Jobs.length


                    $scope.Searchfilter = $scope.Result.SearchFilter;
                    $scope.FieldMapper = $scope.Result.FieldMaper;
                });
        }


        $scope.loadsearchUiAndFeaturedJobs = function () {

            if ($scope.isNotPerf) {
                $scope.getSearchKeywords();
                // $scope.getFeturedJobs();
            }
            else {
                $scope.getallJobs();
                $scope.getSearchKeywords_local();

                // $scope.getFeturedJobs_local();

            }
        }



        $scope.SearchJob = function (filter) {
            //All Data
            // console.log(filter+'filter');

            $scope.Searchfilter.SearchQuestions = (filter == null ? $scope.ctrlSearchQuestions : $scope.Searchfilter.SearchQuestions);
            $scope.Searchfilter.IsHotJob = false;

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
            //$http.get('Fieldmapper_production.json').then(function (response) {
            $http.get('Fieldmaper.json').then(function (response) {
                //  console.log(response.data);
                $scope.Searchfilter = response.data;
                $scope.ctrlSearchQuestions = response.data.SearchKeyword;
                $scope.FieldMapper = response.data;
                $scope.Locationdata = response.data.SearchLocation;
            });

            $http.get($scope.apiBase + '/api/jobs/GetFeturedJobs')
                // $http.get('https://kensuitejobsearchapi.warmcall.com/api/default/GetSearchKeyword')
                .then(function (response) {
                    var data = response.data;
                    // console.log(data.FeaturedFilterCategories);

                    $scope.Searchfilter.FeaturedFilterCategories = data.FeaturedFilterCategories;
                    //  $scope.Searchfilter.FilterCategories = data.FilterCategories;

                });
        }

        $scope.getallJobs = function () {
            $http.get($scope.apiBase + '/api/jobs/GetAllResult').then(function (response) {
                $scope.alldata = response.data;
            });
        }

        $scope.getSearchResults_local = function (SearchUi) {

            var jobresult = getJobsBysearch(SearchUi, $scope.ctrlSearchQuestions, $scope.alldata, false)

            var isFilter = SearchUi.FilterCategories == null ? false : true;
            $scope.Jobs = jobresult;
            $scope.totalItems = $scope.Jobs.length


            if (!isFilter) {
                var searchfilter = GetLeftFilter($scope.FieldMapper, $scope.alldata, false, SearchUi);
                $scope.Searchfilter.FilterCategories = searchfilter;
                //$scope.Searchfilter = $scope.Result.SearchFilter;

            }

        }

        /* Performance */

        $scope.loadsearchUiAndFeaturedJobs();



    });


getJobsBysearch = function (SearchUi, fieldmaper, alljobs, isFeaturedJob) {

    SearchUi.IsHotJob = (isFeaturedJob == true);

    // console.log(SearchUi.IsHotJob);

    var jobs = [];
    if (SearchUi.IsHotJob) {
        var data = alljobs.filter(function (r) {
            if (r.hotJobField.toLowerCase() == 'yes') {
                jobs.push(r);
            }
        })
        alljobs = jobs;
    }

    if (SearchUi.IsHotJob && typeof SearchUi.IsHotJob != undefined) {
        // console.log(SearchUi.IsHotJob);
    } else {
        // console.log(SearchUi.IsHotJob);
    }

    var searchkeycount = 0;

    for (i = 0; i < SearchUi.SearchQuestions.length; i++) {
        if (SearchUi.SearchQuestions[i].SearchKey) {
            searchkeycount++;
        }
    }


    // console.log(searchkeycount);
    var searchKeysExist = false;
    searchKeysExist = SearchUi.SearchQuestions != null && SearchUi.SearchQuestions.length > 0 && searchkeycount > 0;
    // console.log(SearchUi.SearchQuestions);
    if (searchKeysExist) {

        for (i = 0; i < SearchUi.SearchQuestions.length; i++) {
            if (SearchUi.SearchQuestions[i].SearchKey) {
                var data = [];
                result = alljobs.filter(function (r) {

                    // for (j = 0; j < r.questionField.length; j++) {
                    r.questionField.map(function (res) {
                        //    console.log(SearchUi.SearchQuestions[i].IsSearchAll);


                        if (SearchUi.SearchQuestions[i].IsSearchAll == 'yes') {

                            // console.log((res.valueField == null ? '' : res.valueField).toLowerCase().includes(SearchUi.SearchQuestions[i].SearchKey.toLowerCase()));
                            if ((res.valueField == null ? '' : res.valueField).toLowerCase().includes(SearchUi.SearchQuestions[i].SearchKey.toLowerCase())) {
                                data.push(r);
                                // console.log(r)
                            }

                        } else {
                            if (res.idField == SearchUi.SearchQuestions[i].Id &&
                                ((res.valueField == null ? '' : res.valueField).toLowerCase().includes(SearchUi.SearchQuestions[i].SearchKey.toLowerCase()))) {
                                data.push(r);
                            }
                        }
                    })
                    // }
                })
                alljobs = data.length > 0 ? data : data;
            }
        }




        // for (i = 0; i < SearchUi.SearchQuestions.length; i++) {
        //     if (SearchUi.SearchQuestions[i].SearchKey) {
        //         var data = [];
        //         result = alljobs.filter(function (r) {

        //             for (j = 0; j < r.questionField.length; j++) {
        //                 if (r.questionField[j].idField == SearchUi.SearchQuestions[i].Id && ((r.questionField[j].valueField == null ? '' : r.questionField[j].valueField).toLowerCase().includes(SearchUi.SearchQuestions[i].SearchKey.toLowerCase()))) {
        //                     data.push(r);
        //                 }
        //             }
        //         })
        //         alljobs = data.length > 0 ? data : data;
        //     }
        // }

    }

    var IsFilterCatExist = false;
    if (SearchUi.FilterCategories != null) {
        SearchUi.FilterCategories.filter(function (r) {
            // console.log()
            var count = 0;
            for (j = 0; j < r.FilterItems.length; j++) {
                if (r.FilterItems[j].IsSelected) { count++; }
            }
            if (count > 0) { IsFilterCatExist = true; }
        })
    }
    //  console.log(IsFilterCatExist + '-------');

    if (IsFilterCatExist) {

        res = SearchUi.FilterCategories.filter(function (r) {
            var data = [];
            for (i = 0; i < r.FilterItems.length; i++) {

                result = alljobs.filter(function (k) {
                    // console.log(r.FilterItems);
                    if (r.FilterItems[i].IsSelected) {
                        // console.log(r.FilterItems[i].FilterItemTitle + '' + r.Id)

                        for (j = 0; j < k.questionField.length; j++) {
                            if (k.questionField[j].idField == r.Id && k.questionField[j].valueField == r.FilterItems[i].FilterItemTitle) {
                                data.push(k);

                            }
                        }
                    }
                })

            }
            alljobs = data.length > 0 ? data : alljobs;

        })
        // console.log(alljobs);

        for (i = 0; i < SearchUi.FilterCategories.length; i++) {
            var data = [];
            result = alljobs.filter(function (r) {
                for (j = 0; j < r.questionField.length; j++) {
                    // console.log(SearchUi.FilterCategories[i].FilterItems[j].IsSelected);

                }
            })
        }



    }


    // console.log(alljobs);

    return alljobs;
}

GetLeftFilter = function (fieldMapper, jobs, isHotJob, searchUi) {
    //  console.log(searchUi.FilterCategories);
    // console.log(fieldMapper);
    // console.log(jobs);

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

