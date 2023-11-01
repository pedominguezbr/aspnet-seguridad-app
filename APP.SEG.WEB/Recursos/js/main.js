// JavaScript Document
//para el menu principal
function initMenu() {
	$('#lmenu ul').hide();
	$('#lmenu li a').click(
		function() {
			$(this).next().slideToggle('normal');
		}
		);
}
$(document).ready(function() { initMenu(); });