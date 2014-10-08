package 
{
	import flash.display.MovieClip;
	import flash.events.Event;
	import flash.net.URLRequest;
	import flash.net.URLLoader;
	import flash.utils.*;
	import flash.events.TimerEvent;
	//public namespace animate
	public class Motion extends MovieClip  //实例化了铁轨和车厢，车厢的叠放次序，以及车厢的运动方式
	{

		var myXML:XML = new XML;
		var XML_URL:String = "1234.xml";
		var myXMLURL:URLRequest = new URLRequest(XML_URL);
		public var myLoader:URLLoader = new URLLoader(myXMLURL);

		public function Motion()
		{
			// constructor code
			
			
			myLoader.addEventListener("complete",xmlLoaded);
		}
		
		
		private function xmlLoaded(event:Event):void
		{
			myXML = XML(myLoader.data);
			//trace(myXML);
			//trace(myXML.单次[0].@ 车厢);
			
			var len:Number = 0;
			if ((myLoader != null))        //输出XML文件中“单次”结点的个数，即为车厢的运动次数，目的是知道有几个“单次”，好比较车厢号的大小
			{
				var nodes:XMLList = myXML.child("单次");
				len = nodes.length() - 1;
				//trace(len);
			}
			
			var n:int = myXML.单次[0].@ 车厢;
			for(var i:int = 0;i<len;i++)           //一个比较“myXML.单次[i].@ 车厢”大小的循环，得出有几节车厢
			{
				if(myXML.单次[i].@ 车厢>n)
				{
					n = myXML.单次[i].@ 车厢;     //n为车厢总数
				}
			}
			trace(n);
			
			
			var m:int = myXML.单次[0].@ 铁轨;
			for(var z:int = 0;z<len;z++)           //一个比较“myXML.单次[i].@ 铁轨”大小的循环，得出有几个铁轨
			{
				if(myXML.单次[z].@ 铁轨>m)
				{
					m = myXML.单次[z].@ 铁轨;     //m为铁轨总数
				}
			}
			trace(m);
			
			//载入时动态生成横向铁轨
			graphics.lineStyle(1, 0xff0000,1);
			graphics.moveTo(-1000,90);
			//graphics.moveTo代表起始点位置，x，y;
			graphics.lineTo(1000,90);
			//graphics.lineTo代表仙另一端位置，x，y;
			
			if(m==1)
			{
				graphics.moveTo(-1000,140);
				//graphics.lineTo(1000,140);
				graphics.lineTo(250,140);
				graphics.moveTo(310,140);
				graphics.lineTo(1000,140);
				graphics.endFill();
			}
			if(m==2)
			{
				graphics.moveTo(-1000,140);
				//graphics.lineTo(1000,140);
				graphics.lineTo(250,140);
				graphics.moveTo(310,140);
				graphics.lineTo(350,140);
				graphics.moveTo(410,140);
				graphics.lineTo(1000,140);
				graphics.endFill();
			}
			if(m==3)
			{
				graphics.moveTo(-1000,140);
				//graphics.lineTo(1000,140);
				graphics.lineTo(250,140);
				graphics.moveTo(310,140);
				graphics.lineTo(350,140);
				graphics.moveTo(410,140);
				graphics.lineTo(450,140);
				graphics.moveTo(510,140);
				graphics.lineTo(1000,140);
				graphics.endFill();
			}
			
			//载入时动态生成纵向铁轨
			for(var k:int = 0;k<m;k++){
 				var mytrack:Track_test = new Track_test();
 				addChild(mytrack);
 				mytrack.x = 250+k*100
 				mytrack.y = 140
			}
			
			//载入时动态生成铁轨和车厢
			//声明实例
			/*var mycoach:Array = new Array();
			for(var i:int = 0;i<n;i++)
			{	
			    var mycoach[i]=new Coach_test();
			    mycoach[i].x = 50+10*i;
				mycoach[i].y = 50+10*i;
				//var mycoach[i]:Coach_test = new Coach_test();
				//添加到显示列表
				addChild(mycoach[i]);
				//myhaw位置(x,y坐标)
				
			}*/
			
			var coachExist:Array = new Array(n);       //此数组用于存放车厢的编号，用以判定车厢是否实例化
			for(var r:int = 0;r<len;r++)               //此数组的特点是几号车厢对应的数组编号就为几
			{
				coachExist[r] = 0;
			}
			var Coach:Array = new Array(n);           //Coach数组保存实际的车厢实例,千万别在循环里声明
			
			var num:int = new int;                 //计数，现在舞台上有几节车厢
			num = 0;
			
			//载入时动态生成车厢
			for(var j:int = 0;j<len;j++)          //这个循环的目的是把所有编号的车厢放到舞台的同一位置
			{
				var coachNum:String = new String;
				coachNum = myXML.单次[j].@ 车厢      //congXML文件中读取车厢的编号
				var trackNum:String = new String;
				trackNum =  myXML.单次[j].@ 铁轨      //congXML文件中读取相应的铁轨
				var motionStyle:String = new String;
				motionStyle =  myXML.单次[j].@ 出入      //congXML文件中读取车厢的运动方式(出-1入1)				
				
				if(coachExist[int(coachNum)] == 0)   // 表明这个车厢在舞台上还未出现过（未实例化）
				{
					
					var mycoach:Coach_test = new Coach_test(myXML.单次[j].@ 车厢);
					mycoach.x = 0;                  //255  出铁轨的参数
 					mycoach.y = 100;                //100
					addChildAt(mycoach,0);            //addChildAt（a，num：uint）；num制定他们所放置的层级数字最大的，越在上面
													  //0表明新增加的车厢都放在最底下
					//Coach.splice(int(coachNum),0,mycoach);
					//Coach[int(coachNum)] = new Object();
					Coach[int(coachNum)] = mycoach;
					
					coachExist[int(coachNum)] = int(coachNum);
					//Coach.push()
					num = num + 1;
					trace(num)
				}
 			}
			
			var coachInTrack:Array = new Array(0,0,0,0);  //用于记录各个铁轨中已经有的车厢数
			
			//实例化车厢的运动方式
			var q:int = new int;
			q = 0;
			var timer:Timer = new Timer(4000, len);
			timer.addEventListener(TimerEvent.TIMER,handler);
			timer.start();
			function handler():void
			{	
				coachNum = myXML.单次[q].@ 车厢      //congXML文件中读取车厢的编号
				trackNum =  myXML.单次[q].@ 铁轨      //congXML文件中读取相应的铁轨
				motionStyle =  myXML.单次[q].@ 出入      //congXML文件中读取车厢的运动方式(出-1入1)
				if(trackNum == "1" && motionStyle == "-1") coachInTrack[1] -= 1;
				if(trackNum == "2" && motionStyle == "-1") coachInTrack[2] -= 1;
				if(trackNum == "3" && motionStyle == "-1") coachInTrack[3] -= 1;
				
				Coach[int(coachNum)].Coach_Motion(coachNum,trackNum, motionStyle, coachInTrack[int(trackNum)]);  //和C#很类似
				
				if(trackNum == "1" && motionStyle == "1") coachInTrack[1] += 1;
				if(trackNum == "2" && motionStyle == "1") coachInTrack[2] += 1;
				if(trackNum == "3" && motionStyle == "1") coachInTrack[3] += 1;
				
				if(q<len){q++;}
			}
				
				
				
			}
			
			
		}

		//animate function Motion():Motion;
	}

