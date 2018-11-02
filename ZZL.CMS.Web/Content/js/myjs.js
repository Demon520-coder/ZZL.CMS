// JavaScript Document

//首页产品切换显示
function s(n)
{
	var i=1;
	for(i=1;i<=10;i++)
	{
		document.getElementById(i).className="";
		document.getElementById("u"+i).style.display="none";
	}
	document.getElementById(n).className="hover1";
	document.getElementById("u"+n).style.display="block";
}


//用户反馈表单验证
function comment_check()
{
	if (document.form1.name.value == '' ) 
	{
		window.alert("用户名不能为空！");
		document.form1.name.focus();
		return false;
	}

	if (document.form1.email.value == '')
		
	{
		window.alert('请输入Email地址，如:mikl@163.com ');
		document.form1.email.focus();
		return false;
	}
	
	if(document.form1.qq.value == '')   
    {
		  window.alert("请输入QQ!");
		  document.form1.qq.focus();
		  return false;
	}
	  
	if (document.form1.content.value == '' ) 
	{
		window.alert('请输入留言内容^_^');
		document.form1.content.focus();
		return false;
	}
	
	if ( document.form1.verycode.value == '') 
	{
		window.alert('请输入验证码^_^');
		document.form1.verycode.focus();
		return false;
	}
	
	return true;
}

//弹窗显示和隐藏
function show()
{
	document.getElementById("pop").style.display="block";
}
function hide()
{
	document.getElementById("pop").style.display="none";
}

window.onload = function()
{
	document.getElementById("submit").onclick = comment_check;
}