/**
 * Created by Epulari T on 2018/4/1.
 */

// DOM
function WordsFollowMouseDOM(hintwords) {
    document.addEventListener("mousemove", function (e) {
        var myhint = document.getElementById("hint");
        myhint.style.left = e.clientX + 8 + "px";
        myhint.style.top = e.clientY + 2 + "px";
        switch (hintwords) {
            case 1:
                myhint.innerHTML = "I am words follow mouse 1.";
                myhint.style.display = 'block';
                break;
            case 2:
                myhint.innerHTML = "I am words follow mouse 2.";
                myhint.style.display = 'block';
                break;
            default:
                myhint.innerHTML = "";
                myhint.style.display = 'none';
                break;
        }
    });
}

// JQuery
function WordsFollowMouseJQuery(hintwords) {
    document.addEventListener("mousemove", function (e) {
        var myhint = $("#hint");
        $(myhint).css({
            "left": e.clientX + 8 + "px",
            "top": e.clientY + 2 + "px"
        });
        switch (hintwords) {
            case 1:
                $(myhint).text("I am words follow mouse 3.");
                $(myhint).css({"display":  "block"});
                break;
            case 2:
                $(myhint).text("I am words follow mouse 4.");
                $(myhint).css({"display":  "block"});
                break;
            default:
                $(myhint).text("");
                $(myhint).css({"display":  "none"});
                break;
        }
    });
}

$("#clickme_DOM").click(function(){
    WordsFollowMouseDOM(1);
});
$("#clickme_JQuery").click(function(){
    WordsFollowMouseJQuery(1);
});