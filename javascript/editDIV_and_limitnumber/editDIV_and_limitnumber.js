/**
 * Created by Epulari T on 2018/4/1.
 */

function Limit_wordsnumber(limitdivid) {
    var thediv = "#" + limitdivid;
    $(thediv).unbind("dblclick").bind("dblclick", function () {
        $(thediv).removeClass("color1").addClass("change");
        $(thediv).attr("contenteditable", true);

        //Click enter to confirm the change.
        $(thediv).unbind("keydown").bind("keydown", function (event) {
            if (event.keyCode === 13) {
                EditeOver();
            }
        });
    });

    //Click elsewhere to confirm the changes.
    $(document).unbind("click").bind("click", function (e) {
        var e = e || window.event;
        var elem = e.target || e.srcElement;
        if ($("#" + limitdivid).attr("contenteditable") === "true" && elem != document.getElementById(limitdivid)) {
            $("#" + limitdivid).attr("contenteditable", false);
            $("#" + limitdivid).removeClass("change").addClass("color1");
            if($("#" + limitdivid).text().length>10){
                $("#" + limitdivid).text($("#" + limitdivid).text().substring(0,10));
            }
        }
    });

    function EditeOver() {
        $(thediv).attr("contenteditable", false);
        $(thediv).removeClass("change").addClass("color1");
        if($(thediv).text().length>10){
            $(thediv).text($(thediv).text().substring(0,10));
        }
    }
}

$("#edit_DIV").click(function(){
    Limit_wordsnumber("test");
});
