
$(document).ready(function () {
    AddtocartList();
});

var AddtocartList = function () {
    debugger;
    //var CustomerID = $("#hdnCategoryId").val();


    var model = {
        
    }
    $.ajax({

        url: "/AddtoCart/CartList",
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
            html += "<div class='card mb-3'>";
            html += "    <div class='card-body'>";
            html += "        <div class='d-flex justify-content-between'>";
            html += "            <div class='d-flex flex-row align-items-center'>";
            html += "                <div>";

                html += "                    <img src='/Content/User/" + elementvalue.ProductImage + "' class='img-fluid rounded-3' alt='Shopping item' style='width: 65px;'>";
            html += "                </div>";
                html += "                <div class='ms-3'>";
                html += "                    <h5>" + elementvalue.ProductName + "</h5>";
            html += "                    <p class='small mb-0'>Test</p>";
            html += "                </div>";
            html += "            </div>";
            html += "            <div class='d-flex flex-row align-items-center'>";
            html += "                <div style='width: 50px;'>";
                html += "                    <h5 class='fw-normal mb-0'>" + elementvalue.Quantity + "</h5>";
            html += "                </div>";
            html += "                <div style='width: 80px;'>";
                html += "                    <h5 class='mb-0'>$" + elementvalue.Amount + "</h5>";
            html += "                </div>";
            html += "                <a href='#!' style='color: #cecece;'><i class='fas fa-trash-alt'></i></a>";
            html += "            </div>";
            html += "        </div>";
            html += "    </div>";
            html += "</div>";

            });
            $("#CartDetails").append(html);

        },
        error: function (response) {

            alert(response.message)
        }

    });
}