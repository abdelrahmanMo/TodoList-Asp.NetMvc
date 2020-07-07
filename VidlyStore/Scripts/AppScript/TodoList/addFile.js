var task = new FormData();
//add image and generate image list 
$("#customFile").on('change', function() {
    var files = $(this).get(0).files;
   
    task.append("Images", files[0]);
    console.log(task.Images);
    $("#images").append("<li class='list-group-item'>" + files[0].name + "</li>");
});

$('#TodoListForm').submit(function(e) {
    e.preventDefault();
});

// add new task
var validator = $('#TodoListForm').validate({
    submitHandler: function () {
        task.append('describtion', $('#note').val());
        task.append('TaskDate', $('#Tdate').val());
        task.append('Tasktime', $('#Ttime').val());
        console.log(task);
        $.ajax({
            url: "/api/task/CreateNewtask",
                 method: "post",
                data: task,
                processData: false,
                contentType: false


        })
            .done(function () {
                toastr.success("Rentals successfully recorded .");
                $("#images").empty();
                $('#note').val("");
                task = { Images: [] };
                validator.resetForm();
            })
            .fail(function () {
                toastr.error("Something unexpected happened.");
            });
        return false;
    }
});