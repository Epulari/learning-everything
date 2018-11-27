/**
 * Created by Epulari T on 2018/4/14.
 */

function EmergeJQuery() {
	var t, tt;
	var emerge_box = $(".emergebox");
	var len = emerge_box.length;
	$(".emergecontent").css("bottom", "-50px");

	var emerge_content;
	var change = function() {
		var emerge_content_h = parseInt(emerge_content.css("bottom"));
		if(emerge_content_h < 0) {
			emerge_content.css("bottom", (emerge_content_h + Math.floor((0 - emerge_content_h) * 0.1)) + "px");
		}
		else {
			clearInterval(t);
		}
	}
	var back = function() {
		var emerge_content_hh = parseInt(emerge_content.css("bottom"));
		if(emerge_content_hh > -50) {
			emerge_content.css("bottom", (emerge_content_hh + Math.floor((-50 - emerge_content_hh) * 0.1)) + "px");
		}
		else {
			clearInterval(tt);
		}
	}

	$(".emergebox").mouseover(function() {
		emerge_content = $(this).children(".emergecontent");
		clearInterval(tt);
		t = setInterval(change, 10);
	});
	$(".emergebox").mouseout(function() {
		emerge_content = $(this).children(".emergecontent");
		clearInterval(t);
		tt = setInterval(back, 10);
	});
}

function EmergeDOM() {
	var t, tt;
	var emerge_box = document.getElementsByClassName("emergebox_dom");
	var len = emerge_box.length;
	for(var i = 0; i < len; i++) {
		var emerge_content = emerge_box[i].getElementsByTagName('h2')[0];
		emerge_content.style.bottom = "-50px";
		var change = function() {
			var emerge_content_h = parseInt(emerge_content.style.bottom);
			if(emerge_content_h < 0) {
				emerge_content.style.bottom=(emerge_content_h + Math.floor((0 - emerge_content_h) * 0.1)) + "px";
			}
			else {
				clearInterval(t);
			}
		}
		var back = function() {
			var emerge_content_hh = parseInt(emerge_content.style.bottom);
			if(emerge_content_hh > -50) {
				emerge_content.style.bottom=(emerge_content_hh+Math.floor((-50 - emerge_content_hh) * 0.1)) + "px";
			}
			else {
				clearInterval(tt);
			}
		}
		emerge_box[i].onmouseover = function() {
			clearInterval(tt);
			t = setInterval(change,10);
		}
		emerge_box[i].onmouseout = function() {
			clearInterval(t);
			tt = setInterval(back,10);
		}
	}
}

window.onload=function(){
	EmergeJQuery();
	EmergeDOM();
}
