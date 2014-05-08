//var DummyCourse = [
//    {
//        "CourseId": 1,
//        "Name": "Introduction to Accounting",
//        "CourseNumber": "ACC101",
//    },
//    {
//        "CourseId": 2,
//        "Name": "Applied Accounting",
//        "CourseNumber": "ACC203",
//    }
//]

//var CoursesViewModel = function () {
//    var self = this;
//    var refresh = function () {
//        self.Courses(DummyCourse);
//    };


//var script = document.createElement('script');
//script.src = "http://ajax.googleapis.com/ajax/libs/jqueryui/1.10.3/jquery-ui.js";
//document.getElementsByTagName('script')[0].parentNode.appendChild(script);

$(function () {

    var CoursesViewModel = function () {
    var self = this;
    var url = "/course/GetAllCourses";

  

    var refresh = function () {
        $.getJSON(url, {}, function (data) {
            self.Courses(data);
        });
    };

    // Public data properties
    self.Courses = ko.observableArray([]);

    self.createCourse = function () {
        //alert("Create a new course");
        window.location.href = '/Course/CreateEdit/0';
    };

    self.editCourse = function (course) {
        alert("Edit this course with course id as :" + course.Id);
        window.location.href = '/Course/CreateEdit/' + course.Id;
    }; 

    self.removeCourse = function (course) {
        if (confirm("Are you sure you want to delete this course?")) {
            var id = course.Id;
            //waitingDialog({});
            $.ajax({
                type: 'DELETE', url: 'Course/DeleteCourse/' + id,
                success: function () {
                    self.Courses.remove(course);
                },
                error: function (err) {
                    var error = JSON.parse(err.responseText);
                    $("<div></div>").html(error.Message).dialog({
                        modal: true,
                        title: "Error", buttons: {
                            "Ok":
                            function () { $(this).dialog("close"); }
                        }
                    }).show();
                },
                complete: function () {
                    //closeWaitingDialog();
                }
            });
        }
    };

    self.importFromFile = function () {
        window.location.href = '/Course/Import/';
    };

    function waitingDialog(waiting) { // I choose to allow my loading screen dialog to be customizable, you don't have to
        $("#loadingScreen").html(waiting.message && '' != waiting.message ? waiting.message : 'Please wait...');
        //$("#loadingScreen").dialog('option', 'title', waiting.title && '' != waiting.title ? waiting.title : 'Loading');
        $("#loadingScreen").dialog('open');
    }
    function closeWaitingDialog() {
        $("#loadingScreen").dialog('close');
    }

    refresh();
};

ko.applyBindings(new CoursesViewModel());
});




//function waitingDialog(waiting) { // I choose to allow my loading screen dialog to be customizable, you don't have to
//    $("#loadingScreen").html(waiting.message && '' != waiting.message ? waiting.message : 'Please wait...');
//    $("#loadingScreen").dialog('option', 'title', waiting.title && '' != waiting.title ? waiting.title : 'Loading');
//    $("#loadingScreen").dialog('open');
//}

//function closeWaitingDialog() {
//    //$("#loadingScreen").dialog('close');
//}

//function openModalDiv(divname) {
//    $('#' + divname).dialog({ autoOpen: false, bgiframe: true, modal: true });
//    $('#' + divname).dialog('open');
//    $('#' + divname).parent().appendTo($("form:first"));
//}

//function closeModalDiv(divname) {
//    $('#' + divname).dialog('close');
//}

