var url = window.location.pathname;
var courseId = url.substring(url.lastIndexOf('/') + 1);

/*var DummyCourse = [
    {
        "CourseId": 1,
        "Name": "Introduction to Accounting",
        "CourseNumber": "ACC101",
    },
    {
        "CourseId": 2,
        "Name": "Applied Accounting",
        "CourseNumber": "ACC203",
    }
]*/

var Course = function (course) {
    var self = this;

    self.CourseId = ko.observable(course ? course.Id : 0);
    self.Name = ko.observable(course ? course.Name : '');
    self.CourseNumber = ko.observable(course ? course.CourseNumber : '');
    self.OrganizationId = ko.observable(course ? course.OrganizationId : '');
    self.UniversalId = ko.observable(course ? course.UniversalId : '');
    self.CreditHour = ko.observable(course ? course.CreditHour : '');
    self.ClockHour = ko.observable(course ? course.ClockHour : '');
    self.Description = ko.observable(course ? course.Description : '');
};

var CourseCollection = function () {
    var self = this;

    //if CourseId is 0, It means Create new Course
    if (courseId == 0) {
        self.course = ko.observable(new Course());
    }
    else {
        //var currentCourse = $.grep(DummyCourse, function (e) { return e.Id == courseId; });
        //self.course = ko.observable(new Course(currentCourse[0]));
        self.course = ko.observable(new Course());
    }

    self.backToCourseList = function () { window.location.href = '/course'; };

    self.saveCourse = function () {
        //alert("Date to save is new : " + JSON.stringify(ko.toJS(self.course())));
        //alert(self.course().Name._latestValue);
        // var jsonData = ko.toJSON(self.course());

        $.ajax({
            type: 'POST', url: '/Course/SaveCourse/', data:  ko.toJSON(self.course),
            dataType: 'json',
            contentType: 'application/json',
            success: function (result) {
                //self.Courses.add(course);
                window.location.href = '/course';
            },
            error: function (err) {
                //alert(err.responseText);
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
    };
};

ko.applyBindings(new CourseCollection());