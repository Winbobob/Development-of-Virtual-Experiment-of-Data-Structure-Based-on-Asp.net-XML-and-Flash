package 
{
	import flash.display.Sprite;
	//定义了铁轨的属性！！！！
	public class Track_test extends Sprite
	{

		public var n:Number = 4;//根据实际情况，每个铁轨中的车厢个数个数不会超过3个，所以n=4足矣
		public var num:Number;//铁轨（堆栈）编号
		//public var X:String;//堆栈横坐标
		//public var depth:Number = 9;//堆栈可容纳的深度
		//public var current:Number;//堆栈现在的深度

		public function Track_test()
		{
			// constructor code
			initial();
		}
		public function initial():void
		{

			graphics.lineStyle(1, 0xff0000,1);
			graphics.moveTo(0,0);
			//graphics.moveTo代表起始点位置，x，y;
			graphics.lineTo(0,210);
			//graphics.lineTo代表仙另一端位置，x，y;
			graphics.lineTo(60,210);
			graphics.lineTo(60,0);
			graphics.endFill();
		}

        
		
		/*public function IsFull():Boolean
		{//判断堆栈是否为满
		
		if (depth == current)
		{
		return false;
		}
		return true;
		}*/




	}

}