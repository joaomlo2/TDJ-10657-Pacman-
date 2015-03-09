#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Pacman
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D muro;
        Texture2D pacman;
        Texture2D comida;
        Texture2D super_comida;
        SpriteFont font;
        Pacman p,pcoord;
        int by, bx,posgrelhaX,posgrelhaY;
        byte[,] board = {{9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,  6, 9,9,9, 6, 6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,6, 9,9,6,6,6,6,6,6,6,6,6,6, 6, 9,9,9, 6, 6,6,6,6,6,6,6,6,6,6,9,9,6,9},
                         {9,7, 9,6,6,6,6,6,6,6,6,6,6,6, 6, 9,9,9, 6, 6,6,6,6,6,6,6,6,6,6,6,9,6,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,7,6,6,6,6,6,6,6,6,6,6,6,6,6,9,9,9,6,6,6,6,6,6,6,6,6,6,6,6,6,7,9},
                         {9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9}};
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 430;
            graphics.PreferredBackBufferWidth = 330;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            p = new Pacman();
            pcoord = new Pacman();
            pcoord.X = p.Y;
            pcoord.Y = p.X;
            /*
            for (by = 0; by < 33; by++)
            {
                for (bx = 0; bx < 43; bx++)
                {
                    if (by == 0 || bx == 0 || bx == 42 || by == 32)
                        board[by, bx] = 9;
                }
            }
             */
                base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            pacman = Content.Load<Texture2D>("Pacman");
            muro = Content.Load<Texture2D>("muro");
            comida = Content.Load<Texture2D>("comida");
            super_comida=Content.Load<Texture2D>("super_comida");
            font = Content.Load<SpriteFont>("MyFont");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            pacman.Dispose();
            muro.Dispose();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    if(CanGo_Up(p.X,p.Y))
                        p.Y--;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    if (CanGo_Down(p.X, p.Y))
                        p.Y++;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    if (CanGo_Left(p.X, p.Y))
                        p.X--;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    if (CanGo_Right(p.X, p.Y))
                        p.X++;
                }
            // TODO: Add your update logic here
                pcoord.X = (p.X / 10) * 10;
                pcoord.Y = (p.Y / 10) * 10;
                posgrelhaX = pcoord.X / 10;
                posgrelhaY = pcoord.Y / 10;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Transparent);
            spriteBatch.Begin();
            for (by = 0; by < 33;by++ )
            {
                for (bx = 0; bx < 43; bx++)
                {
                    if (board[bx, by] == 9)
                        spriteBatch.Draw(muro, new Rectangle(by * 10, bx * 10, 10, 10), Color.White);
                    if(board[bx,by]==6)
                        spriteBatch.Draw(comida, new Rectangle(by * 10, bx * 10, 10, 10), Color.White);
                    if (board[bx, by] == 7)
                        spriteBatch.Draw(super_comida, new Rectangle(by * 10, bx * 10, 10, 10), Color.White);
                }
            }
            spriteBatch.Draw(muro, new Rectangle(pcoord.X, pcoord.Y, 10, 10), Color.White);
            spriteBatch.Draw(pacman, new Rectangle(p.X, p.Y, 10, 10), Color.White);
                spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        bool CanGo_Up(int pX,int pY)
        {
            if (pY-1 < 10)
                return false;
            else
                return true;
        }
        bool CanGo_Down(int pX, int pY)
        {
            if (pY + 21 > 425)
                return false;
            else
                return true;
        }
        bool CanGo_Left(int pX, int pY)
        {
            if (pX - 1 < 10)
                return false;
            else
                return true;
        }
        bool CanGo_Right(int pX, int pY)
        {
            if (pX + 21 > 325)
                return false;
            else
                return true;
        }
    }
}
