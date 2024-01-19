    setTimeout(function () {
            $('#nofication').fadeOut('fast');
        }, 4000);
        $(document).ready(function () {
            $("#login").click(function () {
                $.ajax(
                    {
                        type: "POST", //HTTP POST Method
                        url: "/User/Login", // Controller/View
                        data: { //Passing data
                            Email: $("#userEmail").val(), //Reading text box values using Jquery
                            Password: $("#userPassword").val(),
                            url: $("#url").val()
                        },
                        success: function (data) {
                            location.reload();
                        }
                    });

            });
        });