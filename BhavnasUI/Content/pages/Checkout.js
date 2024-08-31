


$(document).ready(function () {
    AddtocartList();
});

var AddtocartList = function () {
    debugger
    //var CustomerID = $("#hdnCategoryId").val();


    var model = {

    }
    $.ajax({
        
        url: "/CheckOut/CartList",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            debugger
            $("#CartDetails").empty();
            $.each(response.model, function (index, elementvalue) {

                html += " <p><a href='#'>" + elementvalue.ProductName + "</a> <span class='price'>" + elementvalue.Amount + "</span></p>";
               

            });
            $("#CartDetails").append(html);

        },
        error: function (response) {

            alert(response.message)
        }

    });
}







var Save = function () {
    debugger;
   
    var deliverydate = $("#txtdate").val();
   
    var model = {
        DeliveryDate:deliverydate
    }
    $.ajax({
        url: "/CheckOut/Saveorder",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.model);
            
        },
        error: function (response) {



            alert(response.message)
        }
    });
}