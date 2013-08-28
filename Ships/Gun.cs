using System;

namespace Ships
{
	public class Gun : GameObject
	{
		public float minAngle {get; set;}
		public float maxAngle {get; set;}
		
		public Gun (String imageloc) : base(imageloc) {
			
		}
		public void RotateGun(float angle) {
				this.Rotate(angle);
		}
		public override void Update() {
			
		}
	}
}

