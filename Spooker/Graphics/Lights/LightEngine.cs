//-----------------------------------------------------------------------------
// LightEngine.cs
//
// Spooker Open Source Game Framework
// Copyright (C) Indie Armory. All rights reserved.
// Website: http://indiearmory.com
// Other Contributors: None
// License: MIT
//-----------------------------------------------------------------------------

using System.Collections.Generic;
using SFML.Graphics;

namespace Spooker.Graphics.Lights
{
	public class LightEngine : Drawable
	{
		private List<Light> _lights;
		private SFML.Graphics.Sprite _lightSprite;
		private RenderTexture _lightTexture;
		private Camera _camera;

		public Color ClearColor = Color.Black;

		public LightEngine (Camera camera, Texture texture)
		{
			_lights = new List<Light>();
			_lightTexture = new RenderTexture (1024, 1024);
			_camera = camera;
			ChangeTexture (texture);
		}

		public void Add (Light light)
		{
			_lights.Add (light);
		}

		public void Remove (Light light)
		{
			_lights.Remove (light);
		}

		public void ChangeTexture(Texture texture)
		{
			_lightSprite = new SFML.Graphics.Sprite (texture.ToSfml ());

			_lightSprite.Origin = new SFML.Window.Vector2f (
				_lightSprite.GetLocalBounds().Width / 2,
				_lightSprite.GetLocalBounds().Height / 2);
		}

		public void Draw(RenderTarget graphicsDevice, RenderStates states)
		{
			_lightTexture.Clear (ClearColor.ToSfml ());

			foreach(var light in _lights)
			{
				var rect = new Rectangle ((int)light.Position.X, (int)light.Position.Y, (int)_lightSprite.GetLocalBounds ().Width, (int)_lightSprite.GetLocalBounds ().Height);
				_lightSprite.Position = light.UseCamera ? _camera.Transform (light.Position).ToSfml () : light.Position.ToSfml ();
				_lightSprite.Color = light.Color.ToSfml();
				_lightSprite.Scale = new SFML.Window.Vector2f (light.Ratio, light.Ratio);
				_lightTexture.Draw(_lightSprite, new RenderStates(BlendMode.Add));
			}

			_lightTexture.Display();
			graphicsDevice.Draw (
				new SFML.Graphics.Sprite (_lightTexture.Texture),
				new RenderStates(BlendMode.Multiply));
		}
	}
}