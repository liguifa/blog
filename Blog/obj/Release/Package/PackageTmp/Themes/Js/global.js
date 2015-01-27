function setNavActive(type)
{
    var num = 0;
    var title = "";
    switch (type)
    {
        case "Technology":
            num = 1;
            title = "分类:技术学习";
            break;
        case "Edit":
            num = 2;
            title = "分类:编程博文";
            break;
        case "Essay":
            num = 3;
            title = "分类:美文分享";
            break;
    }
    $(".navbar-nav li:eq(" + num + ")").addClass("active");
    $(".panel-body>h2").text(title);
}

$(document).ready(function ()
{
    $("#mp3").click(function ()
    {
        if (document.getElementById("music").paused)
        {
            document.getElementById("music").play();
            $("#mp3>span").removeClass("glyphicon-volume-off");
            $("#mp3>span").addClass("glyphicon-volume-down");
        }
        else
        {
            document.getElementById("music").pause();
            $("#mp3>span").removeClass("glyphicon-volume-down");
            $("#mp3>span").addClass("glyphicon-volume-off");
        }
    });

    $("#goTop").click(function ()
    {
        $(window).scrollTop(0);
    });
    $("#goBottom").click(function ()
    {
        $(window).scrollTop($(window).height());
    });
});