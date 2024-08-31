

$(document).ready(function () {


    ProductListbyid();
});
var ProductListbyid = function () {
    debugger;
    var ID = $("#hdnCategoryId").val();
    var model = {
        Id: ID
    }
    $.ajax({

        url: "/Product/ProductListByID",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            debugger
            $("#tblProductbyCategoryId").empty();
            $.each(response.model, function (index, elementvalue) {

                html += "<div class='col-sm-3' >"
                html += "<div class='card shadow-lg mb-5 bg-body-tertiary'>"
                html += " <div class='card-body'>"
                html += " <div class='mx-auto text-center ProductImage'>"
                html += "<img src='../Content/User/" + elementvalue.ProductImage + "' class='rounded-circle img-fluid w-100 h-100 mb-2' style='object-fit:cover;' />"
                html += "</div>"
                html += "<div class='text-center'>"
                html += "<div class='ProductName'> " + elementvalue.ProductName + "</div>"
                html += "<div class='badge rounded-pill bg-warning mt-2 ProductPrice'>RS " + elementvalue.Amount + " </div> <br />"
                //html += "<input type='button' class='btn btn-outline-warning btn-buy-now' onclick='/ProductDetail/ProductDetailIndex/" + elementvalue.Id + "''>Buy Now</button>"
                html += "<a id='anchor' type='button' href='/ProductDetail/ProductDetailIndex?Id=" + elementvalue.Id + "'>Buy Now</a>"
                html += " </div>"
                html += "</div>"
                html += "</div>"
                html += "</div>"


            });
            $("#tblProductbyCategoryId").append(html);

        },
        error: function (response) {

            alert(response.message)
        }

    });
}