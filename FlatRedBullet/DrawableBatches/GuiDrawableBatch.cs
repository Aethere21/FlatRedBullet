using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlatRedBall;
using FlatRedBall.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FlatRedBullet.DrawableBatches;

namespace FlatRedBullet.DrawableBatches
{
    public class GuiDrawableBatch : PositionedObject, IDrawableBatch
    {
        SpriteBatch spriteBatch;
        Texture2D crosshairTexture;
        SpriteFont font;

        public bool GameOver = false;

        public bool UpdateEveryFrame
        {
            get { return true; }
        }

        public GuiDrawableBatch()
        {
            spriteBatch = new SpriteBatch(FlatRedBallServices.GraphicsDevice);
            crosshairTexture = FlatRedBallServices.Load<Texture2D>("Content/GlobalContent/Textures/Crosshair.png");
            font = FlatRedBallServices.Load<SpriteFont>("Content/GlobalContent/Textures/Font");
        }

        public void Update()
        {

        }

        public void Destroy()
        {

        }

        public void Draw(Camera camera)
        {
            spriteBatch.Begin(SpriteSortMode.Texture, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone);
            spriteBatch.Draw(crosshairTexture, new Rectangle(FlatRedBallServices.GraphicsDevice.Viewport.Width / 2, FlatRedBallServices.GraphicsDevice.Viewport.Height / 2, crosshairTexture.Width, crosshairTexture.Height), Color.White);
            spriteBatch.DrawString(font, "Score: " + GlobalData.PlayerData.score + "\nHealth: " + GlobalData.PlayerData.Health, new Vector2(10, 10), Color.Red);
            spriteBatch.End();

            if (GameOver)
            {
            spriteBatch.Begin(SpriteSortMode.Texture, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);

            spriteBatch.DrawString(font, "GAME OVER!", new Vector2(FlatRedBallServices.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("GAME OVER!").X, FlatRedBallServices.GraphicsDevice.Viewport.Height / 2 - font.MeasureString("GAME OVER!").Y), Color.Red);
             spriteBatch.DrawString(font, "Final Score: " + GlobalData.PlayerData.score, new Vector2(FlatRedBallServices.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Final Score: " + GlobalData.PlayerData.score).X, FlatRedBallServices.GraphicsDevice.Viewport.Height / 2 + font.MeasureString("Final Score:").Y), Color.Red);
            spriteBatch.End();
            }
        }
    }
}
