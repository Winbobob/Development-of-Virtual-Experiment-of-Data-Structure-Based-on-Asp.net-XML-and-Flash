package 
{
	import flash.display.MovieClip;
	import flash.events.Event;
	import flash.net.URLRequest;
	import flash.net.URLLoader;
	import flash.utils.*;
	import flash.events.TimerEvent;
	import flash.display.Sprite;
	import flash.system.fscommand;

	public class Motion extends MovieClip
	{//实例化了舞者，以及舞者的运动方式

		var timerOver:Timer = new Timer(12000,1);
		var myXML:XML = new XML  ;
		var XML_URL:String = "1234.xml";
		var myXMLURL:URLRequest = new URLRequest(XML_URL);
		public var myLoader:URLLoader = new URLLoader(myXMLURL);
		public var myStage:Sprite;

		public function Motion()
		{
			timerOver.start();
			timerOver.addEventListener(TimerEvent.TIMER,TimeOver);
			myLoader.addEventListener("complete",xmlLoaded);
		}

		private function TimeOver(e:TimerEvent):void
		{
			fscommand("quit");//打开.fla文件的时候是看不出关闭窗口效果的
		}


		private function xmlLoaded(event:Event):void
		{
			myXML = XML(myLoader.data);

			var len,len1,len2:Number = 0;
			if ((myLoader != null))
			{//输出XML文件中“等待”和“跳舞”结点的个数，即为队列中的总队数
				var nodes1:XMLList = myXML.child("等待");
				len1 = nodes1.length();
				var nodes2:XMLList = myXML.child("跳舞");
				len2 = nodes2.length();
				len = len1 + len2;
				//trace(len);
			}

			var allDancersname:Array = new Array();//所有跳舞舞者姓名的数组
			var allDancers:Array = new Array();//所有跳舞舞者的数组
			var allwaitDancersname:Array = new Array();//所有等待舞者姓名的数组
			//var allwaitDancers:Array = new Array();//所有等待舞者的数组

			//填充右侧表格
			for (var n:int = 0; n < len2; n++)
			{
				allDancersname[n] = myXML.跳舞[n];//eg."陈章靓，陈宏"
				var myDancerlist:Dancer_list = new Dancer_list("跳舞",allDancersname[n]);
				myDancerlist.x = 412;
				myDancerlist.y = 15 + 40 * n;
				this.addChild(myDancerlist);
			}

			for (var m:int = 0; m < 10 - len2; m++)
			{//10表示舞台上最多可以放10个list单元格，是舞台上永远有10个单元格
				if (m <= len1 - 1)
				{//m是从0开始计数的
					allwaitDancersname[m] = myXML.等待[m];
					var myWaitlist:Dancer_list = new Dancer_list("等待",allwaitDancersname[m]);
					myWaitlist.x = 412;
					myWaitlist.y = 15 + 40 * (len2 + m);
					this.addChild(myWaitlist);
				}
				else
				{
					var myWaitlist1:Dancer_list = new Dancer_list("等待","waitin' 4 u");
					myWaitlist1.x = 412;
					myWaitlist1.y = 15 + 40 * (len2 + m);
					this.addChild(myWaitlist1);
				}

			}

			//载入时生成每一对舞者
			for (var j:int = 0; j < len2; j++)
			{
				var substr:Array = allDancersname[j].split("，");
				var girlname:String = substr[0];
				var boyname:String = substr[1];
				var mydancer:Dancer_test = new Dancer_test(girlname,boyname);
				mydancer.x = 50;
				mydancer.y = 80 + 100 * j;
				addChildAt(mydancer,0);//addChildAt（a，num：uint）；num制定他们所放置的层级数字最大的，越在上面
				//0表明新增加的都放在最底下
				allDancers[j] = mydancer;
			}

			//实例化舞者的运动方式
			handler(allDancers, len2);

			//画出舞台
			DrawStage();

		}
		//实例化舞者的运动方式
		private function handler(allDancers:Array, len2:Number):void
		{
			for (var k:int = 0; k < len2; k++)
			{
				allDancers[k].Dancer_Motion();
			}
		}

		//画出舞台
		private function DrawStage():void
		{
			myStage = new Sprite();
			myStage.graphics.beginFill(0x999999);
			//x坐标，y坐标，长，宽，圆角椭圆宽度，圆角椭圆高度;
			myStage.graphics.drawRoundRect(0, 0, 400, 400, 20, 20);
			myStage.graphics.endFill();

			this.addChildAt(myStage,0);
		}
	}
}