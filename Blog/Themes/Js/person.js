$(document).ready(function(){
	var position=0;

	$(".change_bottom").click(function(){
		position++;
		setClass(position);
	});

	$(".change_top").click(function(){
		position--;
		setClass(position);
	})
});

function setClass(position)
{
	var panelList=document.getElementsByClassName("pojection");
	for(var i in panelList)
	{
		if(i==position)
		{
			$(panelList[i]).removeClass("noDisplay");
		}
		else
		{
			$(panelList[i]).addClass("noDisplay");
		}
	}
}