
using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;
namespace Ships
{
	public class TileObject
	{
		GameObject[,] tiles;
		int tile_x;
		int tile_y;
		Vector2 position = new Vector2(0,0);
		public TileObject (String imageloc, int tile_x, int tile_y)
		{
			this.tile_x=tile_x;
			this.tile_y=tile_y;
			tiles = new GameObject[tile_x, tile_y];
			for(int i = 0; i < tile_x; i++) {
				for(int r = 0; r < tile_y; r++) {
					tiles[i,r] = new GameObject(imageloc);
					tiles[i,r].CenterSprite();
				
					tiles[i,r].Position=new Vector2(
						(0-tile_x/2.0f)*tiles[i,r].TextureInfo.Texture.Width+(i+1)*(tiles[i,r].TextureInfo.Texture.Width),
					    (0-tile_y/2.0f)*tiles[i,r].TextureInfo.Texture.Height+(r+1)*(tiles[i,r].TextureInfo.Texture.Height));
				}
			}
		}
		public void SetPosition(Vector2 vector) {
			for(int i = 0; i < tile_x; i++) {
				for(int r = 0; r < tile_y; r++) {
					tiles[i,r].Position=vector+new Vector2((i-tile_x/2)*(tiles[i,r].TextureInfo.Texture.Width), (r-tile_y/2)*(tiles[i,r].TextureInfo.Texture.Height));
				}
			}
		}
		public void SetScale(Vector2 vector) {
			for(int i = 0; i < tile_x; i++) {
				for(int r = 0; r < tile_y; r++) {
					tiles[i,r].Scale=new Vector2(tiles[i,r].Scale.X*vector.X, tiles[i,r].Scale.Y*vector.Y);//.Position=vector+new Vector2((i-tile_x/2)*(tiles[i,r].TextureInfo.Texture.Width), (r-tile_y/2)*(tiles[i,r].TextureInfo.Texture.Height));
					tiles[i,r].Position=new Vector2(
						(0-tile_x/2.0f)*tiles[i,r].TextureInfo.Texture.Width*vector.X+(i+1)*(tiles[i,r].TextureInfo.Texture.Width*vector.X),
					    (0-tile_y/2.0f)*tiles[i,r].TextureInfo.Texture.Height*vector.Y+(r+1)*(tiles[i,r].TextureInfo.Texture.Height*vector.Y));
				}
			}
		}
		public void SetParent(Node node) {
			for(int i = 0; i < tile_x; i++) {
				for(int r = 0; r < tile_y; r++) {
					node.AddChild(tiles[i,r]);
				}
			}
		}
		public void Rotate(float angle) {
			for(int i = 0; i < tile_x; i++) {
				for(int r = 0; r < tile_y; r++) {
					tiles[i,r].Rotate(angle);
					
				}
			}
		}
	}
}

