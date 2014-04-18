using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlatRedBall;
using FlatRedBall.Gui;
using FlatRedBall.Input;
using FlatRedBall.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FlatRedBullet.Screens
{
    public partial class GameScreen : Screen
    {
        private bool debugMode;
        private float cameraMovementSpeed = 15f;
        private float cameraRotationSpeed = 0.006f;
        private void SetUpCamera(bool _debug)
        {
            debugMode = _debug;

            Camera.Main.UpVector = new Vector3(0, 1, 0);
            Camera.Main.CameraCullMode = FlatRedBall.Graphics.CameraCullMode.None;
            Camera.Main.FarClipPlane = 5000.0f;
        }

        private void CameraActivity()
        {
            CameraMovement();
            CameraRotation();
        }

        private void CameraMovement()
        {
            if (InputManager.Keyboard.KeyDown(Keys.W))
            {
                SpriteManager.Camera.Position += SpriteManager.Camera.RotationMatrix.Forward * cameraMovementSpeed;
            }
            else if (InputManager.Keyboard.KeyDown(Keys.S))
            {
                SpriteManager.Camera.Position += SpriteManager.Camera.RotationMatrix.Forward * -cameraMovementSpeed;
            }

            if (InputManager.Keyboard.KeyDown(Keys.A))
            {
                SpriteManager.Camera.Position += SpriteManager.Camera.RotationMatrix.Right * -cameraMovementSpeed;
            }
            else if (InputManager.Keyboard.KeyDown(Keys.D))
            {
                SpriteManager.Camera.Position += SpriteManager.Camera.RotationMatrix.Right * cameraMovementSpeed;
            }

            if (InputManager.Keyboard.KeyDown(Keys.Q))
            {
                SpriteManager.Camera.Position += SpriteManager.Camera.RotationMatrix.Up * cameraMovementSpeed;
            }
            else if (InputManager.Keyboard.KeyDown(Keys.E))
            {
                SpriteManager.Camera.Position += SpriteManager.Camera.RotationMatrix.Up * -cameraMovementSpeed;
            }
        }

        private void CameraRotation()
        {
            int xMovement = GuiManager.Cursor.ScreenXChange;
            int yMovement = GuiManager.Cursor.ScreenYChange;

            Vector3 absoluteYAxis = new Vector3(0, 1, 0);
            Camera.Main.RotationMatrix *= Microsoft.Xna.Framework.Matrix.CreateFromAxisAngle(absoluteYAxis, xMovement * -cameraRotationSpeed);

            Vector3 relativeXAxis = Camera.Main.RotationMatrix.Right;
            Camera.Main.RotationMatrix *= Microsoft.Xna.Framework.Matrix.CreateFromAxisAngle(relativeXAxis, yMovement * -cameraRotationSpeed);
        }
    }
}
