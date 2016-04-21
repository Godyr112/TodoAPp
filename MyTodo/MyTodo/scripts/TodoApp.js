var TodoApp = angular.module('TodoApp', ['ngRoute']);

TodoApp.config(["$routeProvider", '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider
        .when("/CategoryList", {
            templateUrl: "Template/CategoryList.html",
            controller: "mainController"
        })
        .when("/TodoList", {
            templateUrl: "Template/TodoList.html",
            controller: "mainController"
        })
        .otherwise({
            redirectTo: "/CategoryList"
        })
    $locationProvider.html5Mode(true);

}]);













TodoApp.controller("mainController", function ($scope, $http, $location) {
    

    //Show categorys
    $http.get('/Home/GetTodoCategorys')
        .success(function (result) {
            $scope.CategoryList = result;

        })
        .error(function (data) {
            console.log(data)
    });

    //show to do items
   
   
        $http.get('/Home/GetTodoList')
         .success(function (result) {
             
             $scope.TodoList = result;

         })
         .error(function (data) {
             console.log(data)
         });

       
    
  

    //Add new ategory
    $scope.newCategory = "";
    $scope.addCategory = function () {
        $http.post("/Home/AddCategory", { newCategory: $scope.newCategory })
        .success(function (result) {
            $scope.CategoryList = result;
            $scope.newCategory = "";
        })
        .error(function (data) {
            console.log(data)
        });
    }

   //Delete category
    $scope.deleteCategory = function (CategoryList) {
        $http.post("/Home/DeleteCategory", { delCategory: CategoryList })
        .success(function (result) {
            $scope.CategoryList = result;
            
        })
        .error(function (data) {
            console.log(data)
        });
    }



   // $scope.search();
  


    $scope.goToTodoList = function (hash) {
        

        $location.path(hash)
    };




    $scope.newTodoText = "";
    $scope.newTodoNote = "";
    $scope.addTodo = function () {
        $http.post("/Home/AddTodo", { newTodoText: $scope.newTodoText, newTodoNote: $scope.newTodoNote })
        .success(function (result) {
            $scope.TodoList = result;

           
        })
        .error(function (data) {
            console.log(data)
        });
    }


    $scope.deleteTodo = function (TodoList) {
        $http.post("/Home/DeleteTodo", { delTodo: TodoList })
        .success(function (result) {
            $scope.TodoList = result;

        })
        .error(function (data) {
            console.log(data)
        });
    }

});

