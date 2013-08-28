using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Ships
{
	public class GameObject : SpriteUV
	{
		public Vector2 position {get; set;}
		private String imageloc;
		public float speed = 0.0f;
		public float maxSpeed = 2.0f;
		public bool rotating = false;
		public bool moving = false;
		
		public List<GameObject> gameObjectList = new List<GameObject>();
		
		public GameObject ()
		{
			
		}
		public GameObject (String imageloc)
		{
			this.imageloc = imageloc;
			this.TextureInfo = new TextureInfo(new Texture2D(imageloc,false));
			this.Scale = this.TextureInfo.TextureSizef;
            this.Pivot = new Sce.PlayStation.Core.Vector2(0.5f,0.5f);
			this.CenterSprite();
			Scheduler.Instance.ScheduleUpdateForTarget(this,0,false);
		}
		public void ScaleUV(Vector2 scaleFactor) {
			this.Scale = new Vector2(scaleFactor.X*this.Scale.X, scaleFactor.Y*this.Scale.Y);
		}
		public virtual void Translate(Vector2 translateFactor) {
			position = new Vector2(position.X+translateFactor.X, position.Y+translateFactor.Y);	
			this.Position=position;
		}
		public virtual void Update() {
			foreach(GameObject gameObject in gameObjectList) {
				gameObject.Update();	
			}
		}
	}
}

