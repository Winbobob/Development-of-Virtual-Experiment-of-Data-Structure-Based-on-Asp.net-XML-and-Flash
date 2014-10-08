package 
{
	import flash.display.MovieClip;
	import flash.events.*;
	import flash.text.*;
	import flash.display.Shape;

	public class Dancer_list extends MovieClip
	{
		//新定义的控件一定要new一下，否则无法使用！！
		public var stateTextbox:TextField = new TextField();//状态   
		public var nameTextbox:TextField = new TextField();//姓名   
		public function Dancer_list(dancerState:String ,dancerName:String)
		{
			//设置状态文本框的格式
			var myformat1:TextFormat = new TextFormat();//设置文本框格式
			myformat1.size = 14;
			myformat1.underline = false;
			stateTextbox.text = dancerState;//给文本框赋值
			stateTextbox.width = 80;//文本框宽度
			stateTextbox.height = 30;//文本框高度
			stateTextbox.x = 0;
			stateTextbox.y = 0;
			stateTextbox.setTextFormat(myformat1,-1,-1);
			//应用文本框格式;

			//设置姓名文本框的格式
			var myformat2:TextFormat = new TextFormat();//设置文本框格式
			myformat2.size = 14;
			myformat2.underline = false;
			nameTextbox.text = dancerName;//给文本框赋值
			nameTextbox.width = 120;//文本框宽度
			nameTextbox.height = 30;//文本框高度
			nameTextbox.x = 34;
			nameTextbox.y = 0;
			nameTextbox.setTextFormat(myformat2,-1,-1);
			//应用文本框格式;
			nameTextbox.addEventListener(MouseEvent.MOUSE_OVER,onOver);
			nameTextbox.addEventListener(MouseEvent.MOUSE_OUT,onOut);

			this.addChild(stateTextbox);
			this.addChild(nameTextbox);
			DrawLine();//画线   

		}
		private function DrawLine():void
		{
			var shape1:Shape=new Shape();
			var shape2:Shape=new Shape();
			shape1.graphics.lineStyle(0.5,0,1);
			shape2.graphics.lineStyle(0.5,0,1);
			shape1.graphics.moveTo(0,20);
			shape1.graphics.lineTo(150,20);
			shape2.graphics.moveTo(32,-20);
			shape2.graphics.lineTo(32,20);
			this.addChild(shape1);
			this.addChild(shape2);
		}
		private function onOver(event:MouseEvent):void
		{

			nameTextbox.textColor = 0xFF0000;
		}
		private function onOut(event:MouseEvent):void
		{
			nameTextbox.textColor = 0x000000;
		}
	}
}