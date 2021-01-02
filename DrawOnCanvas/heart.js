
	    //铺满屏幕
		var width = document.documentElement.clientWidth;
		var height = document.documentElement.clientHeight;
		document.getElementById("gycanvas").setAttribute("width",width);
        document.getElementById("gycanvas").setAttribute("height",height);
 
		//开始画
		var x0 = width/2;
		var y0 = height/2;
		var context = document.getElementById("gycanvas").getContext("2d");
		context.fillStyle = "red"; 　
        var x,y;
		for(var t=-3; t<=3; t=t+0.001)
		{
			x=16*Math.pow(Math.sin(t),3);
			y=13*Math.cos(t)-5*Math.cos(t*2)-2*Math.cos(t*3)-Math.cos(t*4);
			//增大心
			x=x*10;
			y=y*10;
			//画点    屏幕中心为原点
			context.fillRect(x+x0,y0-y,1,1);
		}