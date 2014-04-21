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
        public bool UpdateEveryFrame
        {
            get { return true; }
        }

        public GuiDrawableBatch()
        {
            spriteBatch = new SpriteBatch(FlatRedBallServices.GraphicsDevice);
            crosshairTexture = FlatRedBallServices.Load<Texture2D>("Content/GlobalContent/Textures/Crosshair.png");
        }

        public void Update()
        {

        }

        public void Destroy()
        {

        }

        public void Draw(Camera camera)
        {
            spriteBatch.Begin(SpriteSortMode.Texture, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone);
            spriteBatch.Draw(crosshairTexture, new Rectangle(FlatRedBallServices.GraphicsDevice.Viewport.Width / 2, FlatRedBallServices.GraphicsDevice.Viewport.Height / 2, crosshairTexture.Width, crosshairTexture.Height), Color.White);
            spriteBatch.End();
        }
    }
}
