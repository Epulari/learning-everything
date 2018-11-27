/**
 * Created by Epulari T on 2018/4/2.
 */

//Get the xy analog coordinates of the points that can be used elsewhere.
var x_proportion;
var y_proportion;
function AddPicture(e) {
    var element = document.getElementById("div_picture_compare");
    var left = element.getBoundingClientRect().left;
    var top = element.getBoundingClientRect().top;
    var x = e.clientX - left + element.scrollLeft - 15;
    var y = e.clientY - top + element.scrollTop - 20;
    if( x < 0 || x > element.offsetWidth || y < 0 || y > element.offsetHeight )
    {
        alert("Please add points on the graph!");
    }
    else {
        var point_id = $("#div_picture_real").children().length;
        $("<img>", {
            id: point_id + "compare",
            src: "point.png",
            class: "point_picture",
            style: "left: " + x + "px; top: " + y + "px;"
        }).appendTo("#div_picture_compare")
        $("<img>", {
            id: point_id,
            src: "point.png",
            class: "point_picture",
            style: "left: " + x + "px; top: " + y + "px;"
        }).appendTo("#div_picture_real")

        x_proportion = x / $("#div_picture_compare").width();
        y_proportion = y / $("#div_picture_compare").height();

        Dragpicture($("#" + point_id + "compare"), $("#" + point_id), $("#div_picture_compare"), $("#img_picture_real").width() / $("#img_picture_compare").width(), $("#img_picture_real").height() / $("#img_picture_compare").height());
    }
}

function Dragpicture (compare_point, real_point, compare_div, width_proportion, height_proportion) {
    compare_point.bind("mousedown", start);
    var toppx = compare_div.css("top");
    var leftpx = compare_div.css("left");
    var top = toppx.substring(0, toppx.length-2);
    var left = leftpx.substring(0, leftpx.length-2);
    var x;
    var y;
    var gapX;
    var gapY;
    function start(event) {
        //Determine whether the left mouse button is pressed.
        if (event.button === 0) {
            gapX = event.clientX - compare_point.offset().left + compare_div.offset().left;
            gapY = event.clientY - compare_point.offset().top + compare_div.offset().top;

            //The movemove event must be bound to $(document) because the mouse is moving across the screen.
            $(document).bind("mousemove", move);
            $(document).bind("mouseup", stop);
        }
        return false; //Prevent default events or bubbling events.
    }

    function move(event) {
        x = event.clientX - gapX;
        y = event.clientY - gapY;
        //Limit images to move within range.
        if(x < 0) {
            x = 0;
        }
        else if(x > (compare_div[0].offsetWidth - compare_point[0].offsetWidth)) {
            x = compare_div[0].offsetWidth - compare_point[0].offsetWidth;
        }
        if(y < 0) {
            y = 0;
        } else if(y > ( compare_div[0].offsetHeight  - compare_point[0].offsetHeight )) {
            y = compare_div[0].offsetHeight  - compare_point[0].offsetHeight ;
        }
        compare_point.css({
            "left": x + "px",
            "top": y + "px"
        });
        x_proportion = x / compare_div.width();
        y_proportion = y / compare_div.height();
        if(width_proportion !== undefined) {
            real_point.css({
                "left": x * width_proportion + "px",
                "top": y * height_proportion + "px"
            });
        }
        else {
            real_point.css({
                "left": x  + "px",
                "top": y + "px"
            });
        }
        return false;//Prevent default events or bubbling events.
    }

    function stop() {
        //Unbinding. This step is necessary.
        $(document).unbind("mousemove", move);
        $(document).unbind("mouseup", stop);
    }
}

$("#img_picture_compare").unbind("click").bind("click", function (e) {
    AddPicture(e);
});



