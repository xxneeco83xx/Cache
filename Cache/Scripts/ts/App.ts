/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/typings.d.ts" />
/// <reference path="../typings/es6-promise/es6-promise.d.ts" />
/// <reference path="../typings/bootstrap/index.d.ts" />

//Document ready
$(document).ready(() => {
    $('#data').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": "/Home/Get",
        "columns": [
            { "title": "Event Name", "data": "EventName", "searchable": true },
            { "title": "Start Date", "data": "StartDate", "searchable": true },
            { "title": "End Date", "data": "EndDate", "searchable": true }
        ],
        "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100]]
    });
});

$(document).ajaxStart(() => {
    //
});

$(document).ajaxStop(() => {
    //
});