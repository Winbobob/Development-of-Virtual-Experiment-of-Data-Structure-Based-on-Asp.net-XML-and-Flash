package 
{
	import flash.display.Sprite;
	import fl.transitions.*;
	import fl.transitions.easing.*;
	import flash.geom.Rectangle;
	import flash.text.*;
     //定义了车厢的属性以及各种运动方式！！！！
	 //(AS3.0的数组可以存储任意数据类型的数据，因为它是松散数组，所以没有严格的限制)
	public class Coach_test extends Sprite
	{//AS文件与元件绑定
		//车厢类
		//public var num:Number;  //车厢编号
		//public var Rect:RectShape;
		public var mySprite:Sprite;
		//public var Textbox:Text;
		public var xTween:Tween;
		public var xTween1:Tween;
		public var xTween2:Tween;
		public var xTween3:Tween;
		public var xTween4:Tween;
		var motionLen:int =  new int;
		
		public function Coach_test(coachNum:String)
		{
			mySprite = new Sprite();
			mySprite.graphics.beginFill(0xFF0000);
			mySprite.graphics.drawRect(0,0,50,26);
			var myTextBox:TextField = new TextField(); //建立文本框
			var myformat:TextFormat = new TextFormat(); //设置文本框格式
			//myformat.color = 0xFF0000; 
			myformat.size = 18; 
			myformat.underline = false;
			
		    var myText:String = coachNum; //给文本框赋值
			myTextBox.text = myText;
			myTextBox.width = 50;//文本框宽度
			myTextBox.height = 26;//文本框高度
			myTextBox.setTextFormat(myformat,-1,-1);  //应用文本框格式
			//Rect = new RectShape();
			//Textbox = new Text();
			//addChild(Rect);
			//mySprite.addChild(Rect);
			mySprite.addChild(myTextBox);
			this.addChild(mySprite);
			//addChild(Textbox);
		}
		
		public function Coach_Motion(coachNum:String,trackNum:String, motionStyle:String, coachInTrack:int)
		{   //coachInTrack用于记录各个铁轨中已经有的车厢数
			//var mySprite:RectShape = new RectShape(coachNum,trackNum,motionStyle);
			
			motionLen = 255 + 100 * (int(trackNum)-1);          //根据铁轨编号，定义车厢移动的距离
			
			if(motionStyle == "1" && trackNum != "-1")         //车厢进入铁轨
			{
				if(trackNum == "1")                       //车厢入铁轨
				{
					//运动方式是：Elastic.easeOut指定的就是弹性缓出运动；None.easeNone指匀速运动
					xTween = new Tween(mySprite,"x",None.easeNone,0,motionLen,2,true);
					xTween.addEventListener(TweenEvent.MOTION_FINISH, turnRound1);
					xTween1 = new Tween(mySprite,"y",None.easeNone,0,220 - 40 * coachInTrack ,2,true);
					xTween1.stop();
					//xTween1.start();
				}
				else if(trackNum == "2")                 //车厢入铁轨
				{
					//运动方式是：Elastic.easeOut指定的就是弹性缓出运动；None.easeNone指匀速运动
					xTween = new Tween(mySprite,"x",None.easeNone,0,motionLen,2,true);
					xTween.addEventListener(TweenEvent.MOTION_FINISH, turnRound1);
					xTween1 = new Tween(mySprite,"y",None.easeNone,0,220 - 40 * coachInTrack,2,true);;
					xTween1.stop();
					//xTween1.start();
				}
				else if(trackNum == "3")                //车厢入铁轨
				{
					//运动方式是：Elastic.easeOut指定的就是弹性缓出运动；None.easeNone指匀速运动
					xTween = new Tween(mySprite,"x",None.easeNone,0,motionLen,2,true);
					xTween.addEventListener(TweenEvent.MOTION_FINISH, turnRound1);
					xTween1 = new Tween(mySprite,"y",None.easeNone,0,220 - 40 * coachInTrack,2,true);
					xTween1.stop();
					//xTween1.start();
				}
				
			}
			else if(motionStyle == "-1" && trackNum == "-1")   //车厢不进入铁轨直接出
			{
				//运动方式是：Elastic.easeOut指定的就是弹性缓出运动；None.easeNone指匀速运动
				xTween3 = new Tween(mySprite,"x",None.easeNone,0,500,3,true);
				//xTween3.addEventListener(TweenEvent.MOTION_FINISH, turnRound1);
				
			}
			else if(motionStyle == "-1" && trackNum == "1")              //车厢出铁轨
			{
				xTween2 = new Tween(mySprite,"y",None.easeNone,220 - 40 * coachInTrack,0,2,true);
				xTween2.addEventListener(TweenEvent.MOTION_FINISH, turnRound2);
				xTween4 = new Tween(mySprite,"x",None.easeNone,motionLen,500,2,true);
				xTween4.stop();
			}    
			else if(motionStyle == "-1" && trackNum == "2")              //车厢出铁轨
			{
				xTween2 = new Tween(mySprite,"y",None.easeNone,220 - 40 * coachInTrack,0,2,true);
				xTween2.addEventListener(TweenEvent.MOTION_FINISH, turnRound2);
				xTween4 = new Tween(mySprite,"x",None.easeNone,motionLen,500,2,true);
				xTween4.stop();
			}    
			else if(motionStyle == "-1" && trackNum == "3")              //车厢出铁轨
			{
				xTween2 = new Tween(mySprite,"y",None.easeNone,220 - 40 * coachInTrack,0,2,true);
				xTween2.addEventListener(TweenEvent.MOTION_FINISH, turnRound2);
				xTween4 = new Tween(mySprite,"x",None.easeNone,motionLen,500,2,true);
				xTween4.stop();
			}    
		}

		private function turnRound1(evt:TweenEvent):void
		{
			if (mySprite.x == motionLen)
			{
				xTween1.start();
			}

		}
		
		private function turnRound2(evt:TweenEvent):void
		{
			if (mySprite.y == 0)
			{
				xTween4.start();
			}

		}

	}

}