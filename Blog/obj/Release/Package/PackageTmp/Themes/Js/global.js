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