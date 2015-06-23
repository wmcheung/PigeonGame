﻿using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PigeonGame
{
	public class Level
	{
		Game1 _game;
		private Vector2 _offSetIntro;

		List<Background> _levelBG1 = new List <Background>();
		List<Background> _levelBG2 = new List <Background>();
		List<Background> _levelBG3 = new List <Background>();
		List<Background> _levelBG4 = new List <Background>();
		List<Background> _levelBG5 = new List <Background>();

		List<Enemy> _level1 = new List <Enemy>();
		List<Enemy> _level2 = new List <Enemy>();
		List<Enemy> _level3 = new List <Enemy>();
		List<Enemy> _level4 = new List <Enemy>();
		List<Enemy> _level5 = new List <Enemy>();
		Vector2 _position;
		KeyboardState _keyboard;
		World _world;

		public Vector2 GetPosition()
		{
			return _position;
		}

		public Level (Game1 g, World world)
		{
			//_background = new Background(_game, this, Assets.Level1Map, new Vector2(0, 0));
			_position = new Vector2 (0, 0);
			_offSetIntro = new Vector2 (0, -100);
			_game = g;
			_world = world;	

			_levelBG1.Add (new Background (_game, _world, Assets.Level1Map, new Vector2 (0, 0)));
			_level1.Add (new Enemy (_game, _world, Assets.EagleTexture, new Vector2 (150, 50), 1, 0.2f, 8, 2, "Eagle"));
			_level1.Add (new Enemy (_game, _world, Assets.EagleTexture, new Vector2 (30, 20), 1, 0.2f, 8, 2, "Eagle"));
			_level1.Add (new Enemy (_game, _world, Assets.FoxTexture, new Vector2 (500, 500), 1, 0.2f, 11, 2, "Fox"));
			_level1.Add (new Enemy (_game, _world, Assets.EagleTexture, new Vector2 (1200, 20), 1, 0.2f, 8, 2, "Eagle"));

			_levelBG2.Add (new Background (_game, _world, Assets.Level2Map, new Vector2 (0, 0)));
			_level2.Add (new Enemy (_game, _world, Assets.EagleTexture, new Vector2 (150, 50), 1, 0.2f, 8, 2, "Eagle"));
			_level2.Add (new Enemy (_game, _world, Assets.EagleTexture, new Vector2 (900, 90), 1, 0.2f, 8, 2, "Eagle"));
			_level2.Add (new Enemy (_game, _world, Assets.EagleTexture, new Vector2 (500, 120), 1, 0.2f, 8, 2, "Eagle"));
			_level2.Add (new Enemy (_game, _world, Assets.EagleTexture, new Vector2 (1400, 60), 1, 0.2f, 8, 2, "Eagle"));
			_level2.Add (new Enemy (_game, _world, Assets.EagleTexture, new Vector2 (1800, 200), 1, 0.2f, 8, 2, "Eagle"));
			_level2.Add (new Enemy (_game, _world, Assets.FoxTexture, new Vector2 (500, 500), 1, 0.2f, 11, 2, "Fox"));
			_level2.Add (new Enemy (_game, _world, Assets.FoxTexture, new Vector2 (2000, 500), 1, 0.2f, 11, 2, "Fox"));
			_level2.Add (new Enemy (_game, _world, Assets.FoxTexture, new Vector2 (5500, 500), 1, 0.2f, 11, 2, "Fox"));
			_level2.Add (new Enemy (_game, _world, Assets.FoxTexture, new Vector2 (4300, 500), 1, 0.2f, 11, 2, "Fox"));
			_level2.Add (new Enemy (_game, _world, Assets.FoxTexture, new Vector2 (3000, 500), 1, 0.2f, 11, 2, "Fox"));
			_level2.Add (new Enemy (_game, _world, Assets.GorillaTexture, new Vector2 (900, 450), 0, 0.2f, 8, 2, "Gorilla"));
			_level2.Add (new Enemy (_game, _world, Assets.KangerooTexture, new Vector2 (1300, 450), 1, 0.2f, 2, 2, "Kangeroo"));

			_levelBG3.Add (new Background (_game, _world, Assets.Level3Map, new Vector2 (0, 0)));
			_level3.Add (new Enemy (_game, _world, Assets.EagleTexture, new Vector2 (150, 50), 1, 0.2f, 8, 2, "Eagle"));
			_level3.Add (new Enemy (_game, _world, Assets.FoxTexture, new Vector2 (30, 20), 1, 0.2f, 11, 2, "Fox"));
			_level3.Add (new Enemy (_game, _world, Assets.GorillaTexture, new Vector2 (200, 150), 0, 0.2f, 8, 2, "Gorilla"));
			_level3.Add (new Enemy (_game, _world, Assets.KangerooTexture, new Vector2 (300, 50), 1, 0.2f, 2, 2, "Kangeroo"));

			_levelBG4.Add (new Background (_game, _world, Assets.Level4Map, new Vector2 (0, 0)));
			_level4.Add (new Enemy (_game, _world, Assets.EagleTexture, new Vector2 (150, 50), 1, 0.2f, 8, 2, "Eagle"));
			_level4.Add (new Enemy (_game, _world, Assets.FoxTexture, new Vector2 (30, 20), 1, 0.2f, 11, 2, "Fox"));
			_level4.Add (new Enemy (_game, _world, Assets.GorillaTexture, new Vector2 (200, 150), 0, 0.2f, 8, 2, "Gorilla"));
			_level4.Add (new Enemy (_game, _world, Assets.KangerooTexture, new Vector2 (300, 50), 1, 0.2f, 2, 2, "Kangeroo"));

			_levelBG5.Add (new Background (_game, _world, Assets.Level5Map, new Vector2 (0, 0)));
			_level5.Add (new Enemy (_game, _world, Assets.BossTexture, new Vector2 (385, 30), 1, 0.4f, 1, 1, "Boss"));
		}


		public void Update(GameTime gameTime, Pidgy pidgy) 
		{
			//_background.Update (gameTime);

			if (Assets.LevelComplete) {
				Assets.LevelIntro = true;
				//Console.WriteLine (gameTime.TotalGameTime);
				//Console.WriteLine (Assets.IntervalNewLevel);
				if (gameTime.TotalGameTime >= Assets.IntervalNewLevel) {
					//Console.WriteLine ("DELAY IS OVER");
					Assets.LevelComplete = false;
					Assets.LevelIntro = false;
				}	
			} else {
				switch (_world.LevelState) {
				case 1:
					foreach (Background bg in _levelBG1) {
						bg.Update (gameTime);
					}

					foreach (Enemy e in _level1) {
						e.Update (gameTime, pidgy);
					}
					break;
				case 2:
					foreach (Background bg in _levelBG2) {
						bg.Update (gameTime);
					}

					foreach (Enemy e in _level2) {
						e.Update (gameTime, pidgy);
					}
					break;
				case 3:
					foreach (Background bg in _levelBG3) {
						bg.Update (gameTime);
					}

					foreach (Enemy e in _level3) {
						e.Update (gameTime, pidgy);
					}
					break;
				case 4:
					foreach (Background bg in _levelBG4) {
						bg.Update (gameTime);
					}

					foreach (Enemy e in _level4) {
						e.Update (gameTime, pidgy);
					}
					break;
				case 5:
					foreach (Background bg in _levelBG5) {
						bg.Update (gameTime);
					}

					foreach (Enemy e in _level5) {
						e.Update (gameTime, pidgy);
					}
					break;
				}
			}
//			_keyboard = Keyboard.GetState ();
//			if (_world.GetPidgyPosition().X > _game.GraphicsDevice.Viewport.Width/2 && _keyboard.IsKeyDown (Keys.Right) && _position.X > (Assets.Level1Map.Width * _world.Scaling() - _game.GraphicsDevice.Viewport.Width) *-1)
//			{
//				_position -= new Vector2 (3, 0);
//			}
//
//			if (_world.GetPidgyPosition().X < _game.GraphicsDevice.Viewport.Width/8 && _keyboard.IsKeyDown (Keys.Left) && _position.X > 0)
//			{
//				_position += new Vector2 (3, 0);
//			}

		}

		public void Draw(SpriteBatch spriteBatch)
		{
			if (Assets.LevelIntro) {
				switch (_world.LevelState) {
				case 1:
					spriteBatch.Draw (Assets.Level1Intro, _offSetIntro , null, Color.White, 0f, Vector2.Zero, 1.1f, SpriteEffects.None, 0f);
					break;
				case 2:
					spriteBatch.Draw (Assets.Level2Intro, _offSetIntro , null, Color.White, 0f, Vector2.Zero, 1.1f, SpriteEffects.None, 0f);
					break;
				case 3:
					spriteBatch.Draw (Assets.Level3Intro, _offSetIntro , null, Color.White, 0f, Vector2.Zero, 1.1f, SpriteEffects.None, 0f);
					break;
				case 4:
					spriteBatch.Draw (Assets.Level4Intro, _offSetIntro , null, Color.White, 0f, Vector2.Zero, 1.1f, SpriteEffects.None, 0f);
					break;
				case 5:
					spriteBatch.Draw (Assets.Level5Intro, _offSetIntro , null, Color.White, 0f, Vector2.Zero, 1.1f, SpriteEffects.None, 0f);
					break;
				}
			} else {
				// BACKGROUND DRAW
				//_background.Draw (spriteBatch);

				switch (_world.LevelState) {
				case 1:
					// _background = new Background (_game, _world, Assets.Level1Map, new Vector2 (0, 0));
					foreach (Background bg in _levelBG1) {
						bg.Draw (spriteBatch);
					}

					foreach (Enemy e in _level1) {
						e.Draw (spriteBatch);
					}
					break;
				case 2:
					// _background = new Background (_game, _world, Assets.Level2Map, new Vector2 (0, 0));
					foreach (Background bg in _levelBG2) {
						bg.Draw (spriteBatch);
					}

					foreach (Enemy e in _level2) {
						e.Draw (spriteBatch);
					}
					break;
				case 3:
					// _background = new Background (_game, _world, Assets.Level3Map, new Vector2 (0, 0));
					foreach (Background bg in _levelBG3) {
						bg.Draw (spriteBatch);
					}

					foreach (Enemy e in _level3) {
						e.Draw (spriteBatch);
					}
					break;
				case 4:
					// _background = new Background (_game, _world, Assets.Level4Map, new Vector2 (0, 0));
					foreach (Background bg in _levelBG4) {
						bg.Draw (spriteBatch);
					}

					foreach (Enemy e in _level4) {
						e.Draw (spriteBatch);
					}
					break;
				case 5:
					// _background = new Background (_game, _world, Assets.Level5Map, new Vector2 (0, 0));
					foreach (Background bg in _levelBG5) {
						bg.Draw (spriteBatch);
					}

					foreach (Enemy e in _level5) {
						e.Draw (spriteBatch);
					}
					break;
				}
			}
		}


	}
}

