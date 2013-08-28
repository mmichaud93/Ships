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
	public class AppMain
	{
		public static void Main (string[] args)
		{
			Sce.PlayStation.HighLevel.GameEngine2D.Director.Initialize( 1024*4 );
			
			Game.Instance = new Game();
            var game = Game.Instance;
			
			while (true) {
				Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.GL.SetBlendMode(BlendMode.Normal);
                Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.Update();
				
				game.FrameUpdate();
				
                Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.Render();
                Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.GL.Context.SwapBuffers();
                Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.PostSwap();
			}
		}
	}
}
