using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Ships
{
	public class Game
	{
		public static Game Instance;
		public Scene scene { get; set; }
		public Vector2 TitleCameraCenter { get; set; }
		public Vector2 CameraTarget { get; set; }
		
		public Node background;
		public Node foreground;
		
		List<GameObject> gameObjectList;
		
		Ship ship;
		Camera2D camera;
		
		public int width = 960;
		public int height = 544;
		
		public Game () {
			scene = new Sce.PlayStation.HighLevel.GameEngine2D.Scene();
			
			background = new Node();
			foreground = new Node();
			
			gameObjectList = new List<GameObject>();
			
			scene.AddChild(background);
			scene.AddChild(foreground);
			
			TileObject backgroundImage = new TileObject(
				"/Application/assets/art/water_1.png", 8,4);
			backgroundImage.SetParent(background);
			backgroundImage.SetScale(new Vector2(0.5f,0.5f));
			
			Vector2 ideal_screen_size = new Vector2(960.0f, 544.0f);
			camera = scene.Camera as Camera2D;
			camera.SetViewFromHeightAndCenter(1000, new Vector2(0,0));
			TitleCameraCenter = camera.Center;
			CameraTarget = TitleCameraCenter;
			
			ship = new Ship("/Application/assets/art/boat.png");
			ship.ScaleUV(new Vector2(0.5f, 0.5f));
			ship.Rotate(FMath.DegToRad*90);
			ship.Pivot = new Vector2(-0.30f, 0.0f);
			foreground.AddChild(ship);
			
			gameObjectList.Add(ship);
			
			Director.Instance.RunWithScene(scene, true);
		}
		public void Input() {

			if(Input2.GamePad0.Dpad.Y==1 && ship.speed < ship.maxSpeed) {
				if(ship.speed==0) {
					ship.speed=0.15f;	
				} else {
					ship.speed*=1.05f;
				}
				ship.moving = true;
			} else {
				ship.moving = false;
			}
			if(Input2.GamePad0.Dpad.X != 0) {
				ship.rotating=true;
				ship.Rotate(ship.speed*-0.0075f*Input2.GamePad0.Dpad.X);
			} else {
				ship.rotating=false;	
			}
			
			if(Input2.Touch00.Down) {
				ship.rotating=true;
				ship.Move(new Vector2(
					(ship.Position.X-(Input2.Touch00.Pos.X*width)),
					(ship.Position.Y-(Input2.Touch00.Pos.Y*height))
					));
				//System.Console.WriteLine("touch = "+Input2.Touch00.Pos);
				//System.Console.WriteLine("diff = "+(ship.Position.X-Input2.Touch00.Pos.X)+
				//	", "+(ship.Position.Y-Input2.Touch00.Pos.Y));
				if(ship.speed==0) {
					ship.speed=0.15f;	
				} else {
					ship.speed*=1.05f;
				}
			} else {
				ship.rotating=false;
			}
					
			//ship.Move(new Vector2(Input2.GamePad0.AnalogLeft.X, Input2.GamePad0.AnalogLeft.Y));
			
		}
		public void FrameUpdate() {
			Input();
			foreach(GameObject gameObject in gameObjectList) {
				gameObject.Update();	
			}
		}
	}
}

