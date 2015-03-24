$(document).ready(function ()
{
    var pageIndex = 1;
    AddDemoList(pageIndex++);
});

function AddDemoList(pageIndex)
{
    $.ajax({
        type: "post",
        url: "/Home/DemoData",
        data: {
            pageIndex: pageIndex
        },
        success: function (data)
        {
            $("#CodeList").append(data);
        }
    })
}
