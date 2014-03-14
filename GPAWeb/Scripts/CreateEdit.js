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
};

var CourseCollection = function () {
    var self = this;

    //if ProfileId is 0, It means Create new Profile
    if (courseId == 0) {
        self.course = ko.observable(new Course());
    }
    else {
        var currentCourse = $.grep(DummyCourse, function (e) { return e.Id == courseId; });
        self.course = ko.observable(new Course(currentCourse[0]));
    }

    self.backToCourseList = function () { window.location.href = '/course'; };

    self.saveCourse = function () {
        alert("Date to save is : " + JSON.stringify(ko.toJS(self.course())));
    };
};

ko.applyBindings(new CourseCollection());