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
        private float cameraMovementSpeed = 50f;
        private float cameraRotationSpeed = 0.006f;

        MouseState originalMouseState;
        private void SetUpCamera(bool _debug)
        {
            debugMode = _debug;

            Camera.Main.UpVector = new Vector3(0, 1, 0);
            Camera.Main.CameraCullMode = FlatRedBall.Graphics.CameraCullMode.None;
            Camera.Main.FarClipPlane = 5000.0f;

            if(!debugMode)
            {
                Camera.Main.AttachTo(PlayerInstance, false);
                Camera.Main.RelativePosition.Y = 4;
                Microsoft.Xna.Framework.Input.Mouse.SetPosition(FlatRedBallServices.GraphicsDevice.Viewport.Width / 2, FlatRedBallServices.GraphicsDevice.Viewport.Height / 2);
                originalMouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
            }
        }

        private void CameraActivity()
        {
            CameraMovement();
            CameraRotation();
        }

        private void CameraMovement()
        {
            if (debugMode)
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
            else
            {
                PlayerInstance.YVelocity = -10;
                Vector3 right = PlayerInstance.RotationMatrix.Right;
                Vector3 projectedForward = PlayerInstance.RotationMatrix.Forward;

                projectedForward.Y = 0;
                if(projectedForward.LengthSquared() != 0)
                {
                    projectedForward.Normalize();
                }

                PlayerInstance.XVelocity = 0;
                PlayerInstance.ZVelocity = 0;

                if (InputManager.Keyboard.KeyDown(Keys.W))
                {
                    PlayerInstance.Velocity += projectedForward * cameraMovementSpeed;
                }
                else if (InputManager.Keyboard.KeyDown(Keys.S))
                {
                    PlayerInstance.Velocity += projectedForward * -cameraMovementSpeed;
                }

                if (InputManager.Keyboard.KeyDown(Keys.A))
                {
                    PlayerInstance.Velocity += right * -cameraMovementSpeed;
                }
                else if (InputManager.Keyboard.KeyDown(Keys.D))
                {
                    PlayerInstance.Velocity += right * cameraMovementSpeed;
                }
            }
        }

        private void CameraRotation()
        {
            if (debugMode)
            {
                //int xMovement = GuiManager.Cursor.ScreenXChange;
                //int yMovement = GuiManager.Cursor.ScreenYChange;

                //Vector3 absoluteYAxis = new Vector3(0, 1, 0);
                //Camera.Main.RotationMatrix *= Microsoft.Xna.Framework.Matrix.CreateFromAxisAngle(absoluteYAxis, xMovement * -cameraRotationSpeed);

                //Vector3 relativeXAxis = Camera.Main.RotationMatrix.Right;
                //Camera.Main.RotationMatrix *= Microsoft.Xna.Framework.Matrix.CreateFromAxisAngle(relativeXAxis, yMovement * -cameraRotationSpeed);
            }
            else
            {
                MouseState currentMouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();

                float xMovement = currentMouseState.X - originalMouseState.X;
                //float yMovement = currentMouseState.Y - originalMouseState.Y;

                Vector3 absoluteYAxis = new Vector3(0, 1, 0);
                PlayerInstance.RotationMatrix *= Matrix.CreateFromAxisAngle(absoluteYAxis, xMovement * -cameraRotationSpeed);
                //Vector3 relativeXAxis = PlayerInstance.RotationMatrix.Right;
                //PlayerInstance.RotationMatrix *= Matrix.CreateFromAxisAngle(relativeXAxis, yMovement * -cameraRotationSpeed);

                Microsoft.Xna.Framework.Input.Mouse.SetPosition(FlatRedBallServices.GraphicsDevice.Viewport.Width / 2, FlatRedBallServices.GraphicsDevice.Viewport.Height / 2);
            }
        }

        private void SetUpSpawners()
        {
            for (int i = 0; i < 13; i++)
            {
                Entities.ZombieSpawner spawner = new Entities.ZombieSpawner();
                switch (i)
                {
                    case 0:
                        spawner.Position = new Vector3(-260, 45, 6);
                        break;
                    case 1:
                        spawner.Position = new Vector3(-380, 45, -190);
                        break;
                    case 2:
                        spawner.Position = new Vector3(-310, 45, -356);
                        break;
                    case 3:
                        spawner.Position = new Vector3(-410, 45, 330);
                        break;
                    case 4:
                        spawner.Position = new Vector3(-315, 45, 330);
                        break;
                    case 5:
                        spawner.Position = new Vector3(-220, 45, 220);
                        break;
                    case 6:
                        spawner.Position = new Vector3(75, 45, -60);
                        break;
                    case 7:
                        spawner.Position = new Vector3(53, 45, -300);
                        break;
                    case 8:
                        spawner.Position = new Vector3(170, 45, -305);
                        break;
                    case 9:
                        spawner.Position = new Vector3(240, 45, -140);
                        break;
                    case 10:
                        spawner.Position = new Vector3(440, 45, -65);
                        break;
                    case 11:
                        spawner.Position = new Vector3(440, 45, 120);
                        break;
                    case 12:
                        spawner.Position = new Vector3(340, 45, 280);
                        break;
                    case 13:
                        spawner.Position = new Vector3(430, 45, 390);
                        break;
                }
                ZombieSpawnerList.Add(spawner);
            }
        }
    }
}
