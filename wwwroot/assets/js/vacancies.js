function GetCadidates() {

    var RequisitionId = $("#requisitionId").val();

    var url = "/Candidate/Index?requisitionId=" + RequisitionId;

    $.get(url, function (data) {
        console.log(data.val);

        $('#nodata').html('');

        //$('#nodata').html(data);
    });

}

