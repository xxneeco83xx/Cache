//Document ready
$(document).ready(function () {
    $('#data').DataTable({
        "oLanguage": {
            "sLoadingRecords": "Please wait - loading records...",
            "sZeroRecords": "No records to display.",
            "sProcessing": "Processing...",
            "sInfoEmpty": "No entries to display."
        },
        "iDisplayLength": 5,
        "sPaginationType": "full_numbers",
        "aaSorting": [[1, "asc"]],
        "sServerMethod": "GET",
        "bServerSide": true,
        "sAjaxSource": "/Home/Get",
        "aoColumnDefs": [
            { "sTitle": "Event Name", "sType": "string", "sClass": "right", "mData": "EventName", "aTargets": [0] },
            { "sTitle": "Start Date", "sType": "date-us", "sClass": "right", "mData": "StartDate", "aTargets": [1] },
            { "sTitle": "End Date", "sType": "date-us", "sClass": "right", "mData": "EndDate", "aTargets": [2] }
        ]
    });
});
