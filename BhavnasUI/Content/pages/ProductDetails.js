$(document).ready(function () {


    ProductListbyProductid();
});
var ProductListbyProductid = function () {
    debugger
    var ID = $("#hdnProductId").val();
  

    var model = {
        Id: ID
    }
    $.ajax({

        url: "/ProductDetail/ListByProductID",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            debugger
            $("#Details").empty();
            
                html += "    <div class='col-sm-6'>";
                html += "        <div class='mb-3 d-flex justify-content-center'>";
            html += "            <a data-fslightbox='mygalley' class='rounded-4' target='_blank' data-type='image' href='https://unsplash.com/photos/chocolate-cookie-frappe-4FujjkcI40g'>";
            html += "                <img style='width: 100%; height: 500px; margin: auto;' class='rounded-4 fit'  src='../Content/User/" + response.model.ProductImage + "' />";
                html += "            </a>";
                html += "        </div>";
                html += "    </div>";
                html += "    <div class='col-sm-6'>";
                html += "        <div class='ps-lg-3'>";
                html += "            <h4 class='title text-dark'>";
                html += "               " + response.model.ProductName + "";
                html += "            </h4>";
                html += "            <div class='d-flex flex-row my-3'>";
                html += "                <div class='text-warning mb-1 me-2'>";
                html += "                    <i class='fa fa-star'></i>";
                html += "                    <i class='fa fa-star'></i>";
                html += "                    <i class='fa fa-star'></i>";
                html += "                    <i class='fa fa-star'></i>";
                html += "                    <i class='fas fa-star-half-alt'></i>";
                html += "                    <span class='ms-1'>4.5</span>";
                html += "                </div>";
                html += "                <span class='text-muted'><i class='fas fa-shopping-basket fa-sm mx-1'></i></span>";
                html += "                <span class='text-success ms-2'>In stock</span>";
                html += "            </div>";
            html += "            <div class='mb-3'>";
            html += "                <span class='h5'>Rs." + response.model.Amount + "</span>";
            html += "                <span class='text-muted'>/per item</span>";
            html += "           </div>";
            html += "            <div class='mb-3'>";
            html += "                <span class='h5'>Shipping Charge: Rs." + response.model.Shipping + "</span>";
            html += "                <span class='text-muted'>/per item</span>";
            html += "           </div>";
                html += "            <p>";
            html += "       " + response.model.Description + " ";
                html += "            </p>";
                html += "            <hr />";
                html += "            <div class='row mb-4'>";
                html += "                <div class='col-md-4 col-6'>";
                html += "                    <label class='mb-2'>Size: " + response.model.Size + " </label>";
                html += "                </div>";
                html += "                <!-- col.// -->";
                html += "                <div class='col-md-4 col-6 mb-3'>";
                html += "                    <label class='mb-2 d-block'>Quantity</label>";
                html += "                    <div class='input-group mb-3' style='width: 170px;'>";
                html += "                        <button class='btn btn-white border border-secondary px-3' type='button' id='button-addon1' data-mdb-ripple-color='dark'>";
                html += "                            <i class='fas fa-minus'></i>";
                html += "                        </button>";
                html += "                        <input type='text' value='1' id='txtqty' class='form-control text-center border border-secondary' placeholder='14' aria-label='Example text with button addon' aria-describedby='button-addon1' />";
                html += "                        <button class='btn btn-white border border-secondary px-3' type='button' id='button-addon2' data-mdb-ripple-color='dark'>";
                html += "                            <i class='fas fa-plus'></i>";
                html += "                        </button>";
                html += "                    </div>";
                html += "                </div>";
                html += "            </div>";
                html += "            <div class='row'>";
                html += "                <div class='col-sm-4'>";
                html += "                    <a href='/CheckOut/CheckoutIndex' class='btn btn-warning shadow-0'> Buy now </a>";
                html += "                </div>";
            html += "                <div class='col-sm-4'>";
            html += "                    <input type='button' value='Add To Cart' class='btn btn-primary shadow-0' onclick='SaveAddtocart(" + response.model.Id + "," + response.model.Amount + "," + response.model.Size + "," + response.model.Shipping + ")'/>";
                html += "                </div>";
                html += "                <div class='col-sm-4'>";
                html += "                    <a href='#' class='btn btn-light border border-dark icon-hover'> <i class='fa fa-heart fa-lg'></i> Save </a>";
                html += "                </div>";
                html += "            </div>";
                html += "        </div>";
                html += "    </div>";
               
            $("#Details").append(html);

        },
        error: function (response) {

            alert(response.message)
        }

    });         
}

var SaveAddtocart = function (ID,Amount,Size,Shipping) {
    debugger;
    var CustomerIP = $("#hdnCategoryId").val();
    var Quantity = $("#txtqty").val();
    var GrandTotal = (Amount * Quantity) + Shipping;

    var model = {
        CustomerIP: CustomerIP, ProductID: ID, Quantity: Quantity, Size: Size, Amount: Amount, GrandTotal: GrandTotal, Shipping: Shipping
    }
    $.ajax({
        url: "/AddtoCart/SaveCart",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.model);
            window.location.href = '/AddtoCart/CartIndex';
            /*AddtocartList();*/
        },
        error: function (response) {


            alert(response.message)
        }
    });
}
