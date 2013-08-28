
using System;
using System.Threading;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Audio;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Imaging;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Ships
{
	public class Support
	{
		public static TextureFilterMode DefaultTextureFilterMode = TextureFilterMode.Linear;
    	public static Dictionary<string, Texture2D> TextureCache = new Dictionary<string, Texture2D>();
    	public static Dictionary<string, TextureInfo> TextureInfoCache = new Dictionary<string, TextureInfo>();
		
		public static Sce.PlayStation.HighLevel.GameEngine2D.SpriteUV SpriteUVFromFile(string filename)
        {
        	if (TextureCache.ContainsKey(filename) == false)
			{
	            TextureCache[filename] = new Texture2D(filename, false);
				TextureInfoCache[filename] = new TextureInfo(TextureCache[filename]);
			}
			
            var tex = TextureCache[filename];
            var info = TextureInfoCache[filename];
            var result = new Sce.PlayStation.HighLevel.GameEngine2D.SpriteUV() { TextureInfo = info };
            
			result.Quad.S = new Vector2(info.Texture.Width, info.Texture.Height);
			
			tex.SetFilter(DefaultTextureFilterMode);
			
            return result;
        }
		public static Sce.PlayStation.HighLevel.GameEngine2D.SpriteTile TiledSpriteFromFile(string filename, int x, int y)
        {
        	if (TextureCache.ContainsKey(filename) == false)
			{
	            TextureCache[filename] = new Texture2D(filename, false);
				TextureInfoCache[filename] = new TextureInfo(TextureCache[filename], new Vector2i(x, y));
			}
			
            var tex = TextureCache[filename];
            var info = TextureInfoCache[filename];
            var result = new Sce.PlayStation.HighLevel.GameEngine2D.SpriteTile() { TextureInfo = info };

			result.TileIndex2D = new Vector2i(0, 0);

			result.Quad.S = new Vector2(info.Texture.Width / x, info.Texture.Height / y);
			
			tex.SetFilter(DefaultTextureFilterMode);
			
            return result;
        }
	}
}

