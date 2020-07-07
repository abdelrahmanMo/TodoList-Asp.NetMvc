
    var events = [];
    $.ajax({
        type: "GET",
        url: "/TodoList/GetCalender",
        success: function (data) {

            $.each(data,
                function (i, v) {
                    events.push({
                        description: v.describtion,
                        start: moment(v.TaskDate).set({ hour: moment(v.TaskTime).hour(), minute: moment(v.TaskTime).minutes() }),
                        end: moment(v.TaskDate).set({ hour: moment(v.TaskTime).hour(), minute: moment(v.TaskTime).minutes() }),

                    });
                });
            GenerateCalender(events);
        },
        error: function (error) {
            alert('failed');
        }
});

    function GenerateCalender(events) {
        $('#calender').fullCalendar('destroy');
        $('#calender').fullCalendar({
            contentHeight: 600,
            textColor: '#378006',
            defaultDate: new Date(),
            timeFormat: 'h(:mm)a',
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,basicWeek,basicDay,agenda'
            },
            eventLimit: true,
            eventColor: '#378006',

            events: events,
            eventClick: function (calEvent, jsEvent, view) {
                $('#myModal #eventTitle').text(calEvent.description);
                var $description = $('<div/>');
                $description.append($('<p/>')
                    .html('<b>Start: </b>' + calEvent.start.format("DD-MMM-YYYY HH:mm a")));

                $description.append($('<p/>').html('<b>Description: </b>' + calEvent.description));
                $('#myModal #pDetails').empty().html($description);
                $('#myModal').modal();
            }
        });
    }
