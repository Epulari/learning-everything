/**
 * Created by Epulari T on 2018/4/1.
 */

function RenameBasePicture(theulname) {
    var renamediv;
    $("#" + theulname + " .picturename").unbind("dblclick").bind("dblclick", function () {
        //Set the height of the div text so that it will not disappear after the text is completely deleted.
        var thisheight = $(this).css("height");
        $(this).css({
            "height": thisheight,
            "width": "97%",
            "background-color": "rgba(230, 224, 194, .8)",
            "border": "1.5px solid rgba(255, 0, 0, .5)"
        });
        $(this).attr("contenteditable", true);
        renamediv = this;

        //Click enter to confirm the change.
        $(renamediv).unbind("keydown").bind("keydown", function (event) {
            if (event.keyCode == 13) {
                RenameOver(theulname, $(this).parent().index());
            }
        });
    });

    //Click elsewhere to confirm the changes.
    $(document).unbind("click").bind("click", function (e) {
        var e = e || window.event;
        var elem = e.target || e.srcElement;
        for (var i = 0; i < $("#" + theulname + " li").length; i++) {
            if ($("#" + theulname + " .picturename:eq(" + i + ")").attr("contenteditable") === "true" && elem != renamediv) {
                RenameOver(theulname, i);
            }
        }
    });

    // Rename over
    function RenameOver(theulname, renameliindex) {
        $("#" + theulname + " .picturename").css({
            "width": "100%",
            "background-color": "rgba(245, 245, 220, .5)",
            "border": "0"
        });
        $("#" + theulname + " .picturename").attr("contenteditable", false);
        $("#" + theulname + " li").removeClass("picchange");

        if ($("#" + theulname + " .picturename:eq(" + renameliindex + ")").text() === "") {
            $("#" + theulname + " li:eq(" + renameliindex + ")").addClass("picchange");
            alert("Please name the picture in the red box.");
            return;
        }

        if(renamediv.innerText.length > 8){
            renamediv.innerText = renamediv.innerText.substring(0, 8);
        }
    }
}

$("#rename_picture").click(function(){
    RenameBasePicture("ul_picture");
});
