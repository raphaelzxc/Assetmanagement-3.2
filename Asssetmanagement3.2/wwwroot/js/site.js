// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.


// successfull popup

QueryAjaxDelete = form => {

    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {

            }
                
        })


    } catch (e) {
        console.log(e);
    }

        //to prevent submit event 
        return false;
}





// delete popup
jQueryAjaxDelete = form => {
    if (confirm('Are you sure you want to delete this record')) {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
              
                success: function (res) {
                    $("#view-all").html(res.html);
                },
                error: function (err) {
                    console.log(err);
                }

            })
        } catch (e) {
            console.log(e);
        }
    }
   ///to prevent submit event 
    return false;
}

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#blah')
                .attr('src', e.target.result)
                .width(150)
                .height(200);
        };

        reader.readAsDataURL(input.files[0]);
    }
}