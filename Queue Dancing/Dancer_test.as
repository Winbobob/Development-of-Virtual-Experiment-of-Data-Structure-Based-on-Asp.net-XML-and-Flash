package 
{
	import flash.display.*;
	import fl.transitions.*;
	import fl.transitions.easing.*;
	import flash.geom.Rectangle;
	import flash.text.*;
	import flash.utils.Timer;
	import flash.events.TimerEvent;
	//定义了舞者的属性以及运动方式！！！！
	public class Dancer_test extends Sprite
	{//AS文件与元件绑定       
		public var mySprite1:Sprite;
		public var mySprite2:Sprite;
		var container:Sprite = new Sprite();

		public function Dancer_test(girlName:String, boyName:String)
		{
			//mySprite1女生（圆圈）
			mySprite1 = new Sprite();
			mySprite1.graphics.beginFill(0xFF0000);
			//x坐标，y坐标，半径;
			mySprite1.graphics.drawCircle(75, 12, 25);
			mySprite1.graphics.endFill();

			var myTextBox1:TextField = new TextField();//建立文本框
			var myformat1:TextFormat = new TextFormat();//设置文本框格式
			myformat1.size = 14;
			myformat1.underline = false;
			myTextBox1.text = girlName;//给文本框赋值
			myTextBox1.width = 80;//文本框宽度
			myTextBox1.height = 30;//文本框高度
			myTextBox1.x = 53;
			myTextBox1.y = 3;
			myTextBox1.setTextFormat(myformat1,-1,-1);
			//应用文本框格式;

			//mySprite2男生（圆角矩形）
			mySprite2 = new Sprite();
			mySprite2.graphics.beginFill(0xFF0000);
			//x坐标，y坐标，长，宽，圆角椭圆宽度，圆角椭圆高度;
			mySprite2.graphics.drawRoundRect(-3, -17, 50, 50, 20, 20);
			mySprite2.graphics.endFill();

			var myTextBox2:TextField = new TextField();//建立文本框
			var myformat2:TextFormat = new TextFormat();//设置文本框格式
			myformat2.size = 14;
			myformat2.underline = false;
			myTextBox2.text = boyName;//给文本框赋值
			myTextBox2.width = 80;//文本框宽度
			myTextBox2.height = 30;//文本框高度
			myTextBox2.setTextFormat(myformat2,-1,-1);
			//应用文本框格式;

			mySprite1.addChild(myTextBox1);
			mySprite2.addChild(myTextBox2);
			//container.addChild(mySprite1);
			mySprite2.addChild(mySprite1);
			//当执行A.addChild(B)时，A与B即形成了父子级关系;
			this.addChildAt(mySprite2,0);
			//this.addChild(container);
			//container容器;
			//addChild(Textbox);
		}

		public function Dancer_Motion()
		{
			var radians = 0;//弧长
			var speed = 0;//速度
			var radius = 5;//半径
			var q:int = 0;//计数
			//初始化运动的速度
			speed = 0.02 + 0.5 * Math.random();
			//初始化转动半径
			radius = 2 + 4 * Math.random();
			//Rectangle对象是按其位置（由它左上角的点 (x, y) 确定）以及宽度和高度定义的区域
			var boundary:Rectangle = new Rectangle(0,0,stage.stageWidth - 200,stage.stageHeight);

			var timer:Timer = new Timer(60);
			timer.start();
			//每当 Timer 对象达到根据 Timer.delay 属性指定的间隔时执行的函数。
			timer.addEventListener(TimerEvent.TIMER,run);
	
			function run(e:TimerEvent):void
			{
				if (mySprite2.x <= boundary.left || mySprite2.x >= boundary.right)
				{
					mySprite2.x -= Math.round(radius * Math.sin(radians));
				}
				if (mySprite2.y <= boundary.top || mySprite2.y >= boundary.bottom)
				{
					mySprite2.y -= Math.round(radius * Math.cos(radians));
				}
				//弧长改变
				radians +=  speed;
				//改变位置，实现转动
				mySprite2.x += Math.round(radius * Math.sin(radians));
				mySprite2.y += Math.round(radius * Math.cos(radians));
			}

		}

	}

}