using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Ships
{
	public class Ship : GameObject
	{
		
		Gun[] guns;
		
		public Ship (String imageloc) : base(imageloc)
		{
			guns = new Gun[4];
			
			guns[0] = new Gun("/Application/assets/art/gun.png");
			guns[0].ScaleUV(new Vector2(0.006f, 0.010f));
			guns[0].Translate(new Vector2(-0.3f, 0f));
			guns[0].minAngle=0;
			guns[0].maxAngle=180;
			gameObjectList.Add(guns[0]);
			AddChild(guns[0]);
			guns[1] = new Gun("/Application/assets/art/gun.png");
			guns[1].ScaleUV(new Vector2(0.006f, 0.010f));
			guns[1].Translate(new Vector2(-0.415f, -1.0f));
			guns[1].Rotate(180*FMath.DegToRad);
			guns[1].minAngle=0;
			guns[1].maxAngle=180;
			gameObjectList.Add(guns[1]);
			AddChild(guns[1]);
			guns[2] = new Gun("/Application/assets/art/gun.png");
			guns[2].ScaleUV(new Vector2(0.006f, 0.010f));
			guns[2].Translate(new Vector2(-0.6f, 0f));
			guns[2].minAngle=0;
			guns[2].maxAngle=180;
			gameObjectList.Add(guns[2]);
			AddChild(guns[2]);
			guns[3] = new Gun("/Application/assets/art/gun.png");
			guns[3].ScaleUV(new Vector2(0.006f, 0.010f));
			guns[3].Translate(new Vector2(-0.715f, -1.0f));
			guns[3].Rotate(180*FMath.DegToRad);
			guns[3].minAngle=0;
			guns[3].maxAngle=180;
			gameObjectList.Add(guns[3]);
			AddChild(guns[3]);
			
		}
		
		public override void Translate(Vector2 translateFactor) {
			//position = new Vector2(position.X+translateFactor.X*this.Rotation.X, position.Y+translateFactor.Y*this.Rotation.Y);	
			//position = new Vector2(position.X+translateFactor.X, position.Y+translateFactor.Y);	
			this.Position=new Vector2(Position.X+translateFactor.X*this.Rotation.X, Position.Y+translateFactor.Y*this.Rotation.Y);	//position;
		}
		public void Translate(Vector2 translateFactor, Vector2 angle) {
			//position = new Vector2(position.X+translateFactor.X*angle.X, position.Y+translateFactor.Y*angle.Y);	
			this.Position=new Vector2(Position.X+translateFactor.X*angle.X, Position.Y+translateFactor.Y*angle.Y);
		}
		public void Move(Vector2 moveFactor) {
			float angle = FMath.Atan2(moveFactor.X, moveFactor.Y);  
			float rotateFactor = ((0-angle-this.Angle-(FMath.PI/2.0f)));
			while(rotateFactor<-2*FMath.PI) {
				rotateFactor+=2*FMath.PI;	
			}
			while(rotateFactor>2*FMath.PI) {
				rotateFactor-=2*FMath.PI;	
			}
			if(rotateFactor>FMath.PI) {
				rotateFactor-=2*FMath.PI;
			} else if(rotateFactor<-FMath.PI) {
				rotateFactor+=2*FMath.PI;
			}
			rotateFactor/=20.0f;
			System.Console.WriteLine("rotateFactor = "+(rotateFactor*20.0f*FMath.RadToDeg)+", angle = "+(angle*FMath.RadToDeg)+", this.Angle = "+(this.Angle*FMath.RadToDeg));
			//System.Console.WriteLine("angle = "+(angle*FMath.RadToDeg)+", current rotation = "+(this.Angle*FMath.RadToDeg));
			Rotate(rotateFactor);
			
			
			
		}
		public void RotateGuns(float angle) {
			foreach(Gun gun in guns) {
				gun.RotateGun(angle);	
			}
		}
		public override void Update() {
			if(speed > maxSpeed)
				speed = maxSpeed;
			this.Translate(new Vector2(speed, speed));
			if(!moving) {
				if(rotating) {
					speed*=(0.99f);
				} else {
					speed*=(0.99f);	
				}
			} 
			
			if(speed < 0.001) {
				speed = 0;	
			}
			
			foreach(GameObject gameObject in gameObjectList) {
				gameObject.Update();	
			}
		}
	}
}

