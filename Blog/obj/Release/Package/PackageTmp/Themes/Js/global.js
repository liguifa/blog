function setNavActive(type)
{
    var num = 0;
    var title = "";
    switch (type)
    {
        case "Undex":
            num = 0;
            break;
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
        case "Study":
            num = 4;
            break;
        case "Demo":
            num = 5;
            break;
        case "Person":
            num = 6;
            break;
    }
    $(".navbar-nav li:eq(" + num + ")").addClass("active");
    $(".panel-body>h2").text(title);
}

function setTime()
{
    var t = new Date();
    var timeString = t.getFullYear() + "年" + ToDubleNumber((t.getMonth() + 1)) + "月" + ToDubleNumber(t.getDate()) + "日" + " " + ToDubleNumber(t.getHours()) + ":" + ToDubleNumber(t.getMinutes()) + ":" + ToDubleNumber(t.getSeconds()) + "," + "星期" + ToCharacterDay(t.getDay());
    $("#header_top_right_top").text(timeString);
}

function ToCharacterDay(day)
{
    switch (day)
    {
        case 1: return "一";
        case 2: return "二";
        case 3: return "三";
        case 4: return "四";
        case 5: return "五";
        case 6: return "六";
        case 0: return "日";
    }
}

function ToDubleNumber(num)
{
    if (num < 10)
    {
        num = "0" + num;
    }
    return num;
}

function Joke()
{
    $.ajax({
        type: "post",
        url: "/Home/Joke",
        success: function (data)
        {
            data = JSON.parse(data);
            $(".joke").html(data[0].content);
        }
    });
}

function SetCalendar()
{
    var t = new Date();
    var year = t.getFullYear();
    var month = t.getMonth();
    var scl_title = year + "年" + ToCapital(month + 1) + "月";
    $("#wp-calendar>caption").text(scl_title);
    $.ajax({
        type: "post",
        url: "/Home/GetCalendarData",
        data: {
            month: month + 1,
            year: year
        },
        success: function (data)
        {
            var typeArr = new Array("Technology", "Edit", "Essay");
            data = JSON.parse(data);
            var dayNumArr = new Array(31, year / 4 == 0 ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);
            var scl_body = "<tr>";
            var firstMonth = new Date(year + "-" + month + "-" + 1).getDay() == 0 ? 7 : new Date(year + "-" + month + "-" + 1).getDay();
            scl_body += firstMonth - 1 == 0 ? "" : "<td colspan='" + (firstMonth - 1) + "' class='pad'>&nbsp;</td>";
            var positionDay = firstMonth;
            for (var i = 1; i <= dayNumArr[month + 1]; i++)
            {
                if (positionDay == 8)
                {
                    scl_body += "</tr><tr>";
                    positionDay = 1;
                }
                var isHaveArticle = false;
                for (var y in data.data)
                {
                    var dataTime = new Date(data.data[y].time);
                    if (dataTime.getDate() == i)
                    {
                        scl_body += "<td><a href='/Home/Content/" + typeArr[data.data[y].type - 1] + "/" + data.data[y].url + "' title='" + data.data[y].title + "' target='_blank'>" + i + "</a></td>";
                        isHaveArticle = true;
                        break;
                    }
                }
                if (!isHaveArticle)
                {
                    scl_body += "<td>" + i + "</td>";
                }
                positionDay++;
            }
            if (positionDay != 8)
            {
                scl_body += "<td class='pad' colspan='" + (8 - positionDay) + "'>&nbsp;</td></tr>";
            }
            $("#wp-calendar>tbody").html(scl_body);
        }
    });
}

function ToCapital(month)
{
    switch (month)
    {
        case 1: return "一";
        case 2: return "二";
        case 3: return "三";
        case 4: return "四";
        case 5: return "五";
        case 6: return "六";
        case 7: return "七";
        case 8: return "八";
        case 9: return "九";
        case 10: return "十";
        case 11: return "十一";
        case 12: return "十二";
    }
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
    Joke();
    setTime();
    SetCalendar();
    setInterval("setTime()", 1000);

    //多说公共JS代码 start (一个网页只需插入一次)
    var duoshuoQuery = { short_name: "liguifablog" };
    (function ()
    {
        var ds = document.createElement('script');
        ds.type = 'text/javascript'; ds.async = true;
        ds.src = (document.location.protocol == 'https:' ? 'https:' : 'http:') + '//static.duoshuo.com/embed.js';
        ds.charset = 'UTF-8';
        (document.getElementsByTagName('head')[0]
        || document.getElementsByTagName('body')[0]).appendChild(ds);
    })();
    //多说公共JS代码 end
});