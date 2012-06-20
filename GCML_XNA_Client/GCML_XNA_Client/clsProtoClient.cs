using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GCML_XNA_Client
{
    public class clsProtoClient : Microsoft.Xna.Framework.Game 
    {
        
        private Rectangle recViewport;
        private GraphicsDeviceManager objGraphDevManager;
        
        private Dictionary<string, Texture2D> dicTextures = new Dictionary<string, Texture2D>();
        
       
        private Texture2D texBackground;

        public clsProtoClient()
        {
            objGraphDevManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = ".\\Content";

        }

        protected override void LoadContent()
        {
            
            
            texBackground = Content.Load<Texture2D>("background");

            this.dicTextures.Add("cursor_bc", Content.Load<Texture2D>("cursor_bc"));
            
            recViewport = new Rectangle(0, 0, this.objGraphDevManager.GraphicsDevice.Viewport.Width, this.objGraphDevManager.GraphicsDevice.Viewport.Height);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Beige);

            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch spriteBatch = new SpriteBatch(GraphicsDevice);

            spriteBatch.Begin(/*SpriteBlendMode.AlphaBlend*/);

            spriteBatch.Draw(this.texBackground, this.recViewport, Color.White);

            MouseState msta = Mouse.GetState();

            if (msta.X > this.recViewport.X && msta.X < this.recViewport.X + this.recViewport.Width
                && msta.Y > this.recViewport.Y && msta.Y < this.recViewport.Y + this.recViewport.Height)
            {
                spriteBatch.Draw(dicTextures["cursor_bc"], new Vector2(msta.X, msta.Y), Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);

        }

       

    }
}
