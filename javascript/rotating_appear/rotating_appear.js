/**
 * Created by Epulari T on 2018/4/2.
 */

//The first layer is the center point.
//The second layer spreads out as the center.
function Animation(first_center, arr_second_level, n) {
    //如果div_frame存在则移除
    if ($("#div_frame").length > 0) {
        $("#div_frame").remove();
    }

    //Second level display content.
    CreateStyleStr(n);
    $("<div>", {
        id: "div_frame"
    }).appendTo($("#" + first_center));

    $("<div>", {
        id: "div_second_level",
        class: "radmenu"
    }).appendTo("#div_frame");

    $("<a>", {
        id: "a_center",
        class: "show",
        title: "center",
        href: "#"
    }).appendTo("#div_second_level");

    $("<ul>", {
        id: "ul_rotating"
    }).appendTo("#div_second_level");

    for (var i = 1; i < n + 1; i++) {
        $("<li>", {
            id: "li_rotating" + i
        }).appendTo("#ul_rotating");
        $("<a>", {
            id: "a_rotating" + i,
            title: rotating_pic[i]
        }).appendTo("#li_rotating" + i);
    }

    var seconde_branch = document.querySelectorAll(".radmenu a");
    seconde_branch[0].onmouseover = function (e) {
        // Refresh style.
        CreateStyleStr(n);
        this.classList.remove("show");
        this.classList.add("selected");
        return false;
    };
    for (var i = 1; i < seconde_branch.length; i++) {
        var button = seconde_branch[i];
        button.onclick = Seconde_branch_Click;
    }
    function Seconde_branch_Click(e) {
        var e = e || window.event;
        var elem = e.target || e.srcElement;
        for (var i = 1; i < seconde_branch.length; i++) {
            if (elem.id == seconde_branch[i].id) {
                $('#' + elem.id + '').css("background", "url(second_branch_select.png) no-repeat");
                window.open("https://github.com/Epulari/javascript_function");
            }
            else {
                $('#' + seconde_branch[i].id + '').css("background", "url(second_branch.png) no-repeat");
            }
        }
    }

    //Click outside the icon to retract the animation.
    $(document).bind('click', function (e) {
        try {
            var e = e || window.event;
            var elem = e.target || e.srcElement;
            for (var i = 0; i < seconde_branch.length; i++) {
                if (elem == seconde_branch[i]) {
                    return;
                }
            }
            seconde_branch[0].classList.remove("selected");
            seconde_branch[0].classList.add("show");
        } catch (err) {

        }
    });

    function CreateStyleStr(n) {
        var radius = function (n) {
            var r = (45 * Math.PI) / n;
            if (r > 45) {
                r = 45
            } else if (r < 25) {
                r = 25
            }
            return r;
        }
        var centerRadius = function (n) {
            var r = (25 * n) / Math.PI;
            if (40 > r > 20) {
                r = r
            } else if (r <= 25) {
                r = 20
            } else if (r >= 40) {
                r = 40
            }
            return r;
        }
        var m = Math.round(360 / n);
        var p = Math.round(360 / n);
        // var m_2 = 150;
        // var d_1=25;
        var r_1=36.5;//Control level when n is 2.
        var r_2=6.5;
        var r = radius(n);
        var R=centerRadius(n);//Distance from the center of the diameter.
        var d = "";
        if (r == 15) {
            d = centerRadius(n)
        } else {
            d = 30;
        }
        var strStyChild = "";
        for (var i = 1; i <= n; i++) {
            if(n==1){
                strStyChild += ".radmenu .selected + ul > li:nth-child(" + i + " ){" +
                    "-webkit-transform:rotate(" + m + "deg) translateX(" + d + "px);" +
                    "transform:rotate(" + m + "deg) translateX(" + d + "px)" +
                    "}" +
                    ".radmenu .selected + ul >li:nth-child(" + i + ") > a{" +
                    "transform:rotate(-" + m + "deg);" +
                    "-webkit-transform:rotate(-" + m + "deg);" +
                    "top: -9px;" +
                    "left:12px"+
                    "}" +
                    ".radmenu .selected + ul > li:nth-child(" + i + " ) > " +
                    "a:hover{" +
                    "}"
            }
            else if(n==2) {
                strStyChild += ".radmenu .selected + ul > li:nth-child(" + i + " ){" +
                    "-webkit-transform:rotate(" + m + "deg) translateX(" + d + "px);" +
                    "transform:rotate(" + m + "deg) translateX(" + d + "px)" +
                    "}" +
                    ".radmenu .selected + ul >li:nth-child(" + i + ") > a{" +
                    "transform:rotate(-" + m + "deg);" +
                    "-webkit-transform:rotate(-" + m + "deg);" +
                    "top: calc(50% - " + r_1+ "px);" +
                    "left: calc(50% - " + r_2 + "px)" +
                    "}" +
                    ".radmenu .selected + ul > li:nth-child(" + i + " ) > " +
                    "a:hover{" +
                    "}"
                m = m + p;
                r_1=r_1-28;
                r_2=r_2-9;
            }else{
                strStyChild += ".radmenu .selected + ul > li:nth-child(" + i + " ){" +
                    "-webkit-transform:rotate(" + m + "deg) translateX(" + d + "px);" +
                    "transform:rotate(" + m + "deg) translateX(" + d + "px)" +
                    "}" +
                    ".radmenu .selected + ul >li:nth-child(" + i + ") > a{" +
                    "transform:rotate(-" + m + "deg);" +
                    "-webkit-transform:rotate(-" + m + "deg);" +
                    "top: " + R / 2 + "px;" +
                    "left: " + R / 2 + "px" +
                    "}" +
                    ".radmenu .selected + ul > li:nth-child(" + i + " ) > " +
                    "a:hover{" +
                    "}"
                m = m + p;
            }
        }
        var strStyCenter = ".radmenu .selected{" +
            "}" +
            ".radmenu a{" +
            "position: absolute;" +
            "top:77.5px;" +
            "left:77.5px;" +
            "width: " + r + "px;" +
            "height: " + r + "px;" +
            "align-items: center;" +
            "display: none;" +
            "transition: all 1s ease;" +
            "}" +
            ".radmenu > a{" +
            "}"

        var style = document.createElement("style");
        style.setAttribute('id','radmenu_id')
        try {
            style.appendChild(document.createTextNode(strStyCenter + strStyChild
            ))
        }
        catch (ex) {
            //Compatible with IE, style node in IE is a special node, so there is a special styleSheet.styleText property.
            style.styleText = "//style code";
        }
        var head = document.getElementsByTagName("head")[0];
        if(document.getElementById('radmenu_id')) {
            head.removeChild(document.getElementById('radmenu_id'));
        }
        head.appendChild(style);
    }
}

var rotating_pic = ["pic1", "pic2", "pic3", "pic4", "pic5"];
var n = rotating_pic.length;

$("#blank_range").mouseover(function (e) {
    if (e.target.className === "rotating_center") {
        Animation(e.target.id, rotating_pic, rotating_pic.length);
    }
});
