//Scripts For Leave Management Controller And views




function registerStudent() {
    var token = $('input[name="__RequestVerificationToken"]').val();

    var student = {     
        "FirstName": $('#fName').val(),
        "LastName": $('#lName').val(),
        "Email": $('#email').val(),
        "Phone": $('#phone').val(),
    };

   // var l = Ladda.create(this);
    //l.start();
    $.ajax({
        url: '/Student/RegisterStudent',
        type: 'POST',
        data: { __RequestVerificationToken:token,student: student,  },//JSON.stringify(student),
        dataType: 'JSON',
        //headers: {
        //  '__RequestVerificationToken': token,
        //},
        contentType:'application/x-www-form-urlencoded; charset=utf-8',
        success: function (response) {
            if (response.result == "Success") {
                alert('Student Registered Succesfully!')
            
            }

        },
        error: function (x,h,r) {
            alert('Something went wrong')
  
        }

    })
};

