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
        Texture2D fantasma;
        Texture2D comida;
        Texture2D super_comida;
        SpriteFont font;
        Pacman p;
        Fantasma f1, f2, f3, f4;
        int by, bx,score=0;
        byte[,] board = {{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                         {0,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,0},
                         {0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,0},
                         {0,1,0,1,1,1,0,1,1,1,1,1,1,0,1,1,1,1,0,1,1,1,1,1,1,0,1,1,1,0,1,0},
                         {0,1,0,1,0,1,1,1,0,0,0,0,1,1,1,0,0,1,1,1,0,0,0,0,1,1,1,0,1,0,1,0},
                         {0,1,0,1,1,1,0,1,1,1,1,1,1,0,1,1,1,1,0,1,1,1,1,1,1,0,1,1,1,0,1,0},
                         {0,1,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,1,0},
                         {0,1,0,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,0,1,0},
                         {0,1,0,1,0,1,0,1,0,0,1,0,0,1,0,1,1,0,1,0,0,1,0,0,1,0,1,0,1,0,1,0},
                         {0,1,0,1,0,1,0,1,0,1,1,1,0,1,0,1,0,0,1,0,1,1,1,0,1,0,1,0,1,0,1,0},
                         {0,1,0,1,0,1,0,1,1,1,0,1,1,1,0,1,1,0,1,1,1,0,1,1,1,0,1,0,1,0,1,0},
                         {0,1,0,1,0,1,0,1,0,1,1,1,0,1,0,0,1,0,1,0,1,1,1,0,1,0,1,0,1,0,1,0},
                         {0,1,0,1,1,1,0,1,0,0,1,0,0,1,0,1,1,0,1,0,0,1,0,0,1,0,1,1,1,0,1,0},
                         {0,1,0,0,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,0,0,1,0},
                         {0,1,1,1,1,1,1,1,0,0,0,1,0,1,0,1,1,0,1,0,1,0,0,0,1,1,1,1,1,1,1,0},
                         {0,0,0,0,1,0,0,1,0,1,0,1,0,1,0,1,1,0,1,0,1,0,1,0,1,0,0,1,0,0,0,0},
                         {0,1,1,1,1,1,1,1,0,1,1,1,0,1,0,1,1,0,1,0,1,1,1,0,1,1,1,1,1,1,1,0},
                         {0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0},
                         {0,1,0,0,0,1,0,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,0,1,0,0,0,1,0},
                         {0,1,0,1,1,1,1,1,0,1,0,0,0,0,0,1,1,0,0,0,0,0,1,0,1,1,1,1,1,0,1,0},
                         {0,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,1,1,0,1,0,1,0,1,0,1,0,1,0},
                         {0,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,1,1,0,1,0,1,0,1,0,1,0,1,0},
                         {0,1,0,1,1,1,1,1,0,1,0,0,0,0,0,1,1,0,0,0,0,0,1,0,1,1,1,1,1,0,1,0},
                         {0,1,0,0,0,1,0,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,0,1,0,0,0,1,0},
                         {0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0},
                         {0,1,1,1,1,1,1,1,0,1,1,1,0,1,0,1,1,0,1,0,1,1,1,0,1,1,1,1,1,1,1,0},
                         {0,0,0,0,1,0,0,1,0,1,0,1,0,1,0,1,1,0,1,0,1,0,1,0,1,0,0,1,0,0,0,0},
                         {0,1,1,1,1,1,1,1,0,0,0,1,0,1,0,1,1,0,1,0,1,0,0,0,1,1,1,1,1,1,1,0},
                         {0,1,0,0,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,0,0,1,0},
                         {0,1,0,1,1,1,0,1,0,0,1,0,0,1,0,1,1,0,1,0,0,1,0,0,1,0,1,1,1,0,1,0},
                         {0,1,0,1,0,1,0,1,0,1,1,1,0,1,0,0,1,0,1,0,1,1,1,0,1,0,1,0,1,0,1,0},
                         {0,1,0,1,0,1,0,1,1,1,0,1,1,1,0,1,1,0,1,1,1,0,1,1,1,0,1,0,1,0,1,0},
                         {0,1,0,1,0,1,0,1,0,1,1,1,0,1,0,1,0,0,1,0,1,1,1,0,1,0,1,0,1,0,1,0},
                         {0,1,0,1,0,1,0,1,0,0,1,0,0,1,0,1,1,0,1,0,0,1,0,0,1,0,1,0,1,0,1,0},
                         {0,1,0,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,0,1,0},
                         {0,1,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,1,0},
                         {0,1,0,1,1,1,0,1,1,1,1,1,1,0,1,1,1,1,0,1,1,1,1,1,1,0,1,1,1,0,1,0},
                         {0,1,0,1,0,1,1,1,0,0,0,0,1,1,1,0,0,1,1,1,0,0,0,0,1,1,1,0,1,0,1,0},
                         {0,1,0,1,1,1,0,1,1,1,1,1,1,0,1,1,1,1,0,1,1,1,1,1,1,0,1,1,1,0,1,0},
                         {0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,0},
                         {0,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,0},
                         {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}};
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 420;
            graphics.PreferredBackBufferWidth = 420;
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
            f1 = new Fantasma();
            f2 = new Fantasma();
            f3 = new Fantasma();
            f4 = new Fantasma();
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
            fantasma = Content.Load<Texture2D>("fantasma");
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
            comida.Dispose();
            super_comida.Dispose();
            fantasma.Dispose();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if(board[p.boardY,p.boardX]==1)
            {
                board[p.boardY, p.boardX] = 9;
                score++;
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    p.Direcção=1;
                    if (CanGo(p) && (!Keyboard.GetState().IsKeyDown(Keys.Left)) && (!Keyboard.GetState().IsKeyDown(Keys.Right)) && (!Keyboard.GetState().IsKeyDown(Keys.Down)))
                        p.Y--;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    p.Direcção=3;
                    if (CanGo(p)&&(!Keyboard.GetState().IsKeyDown(Keys.Left)) && (!Keyboard.GetState().IsKeyDown(Keys.Right)) && (!Keyboard.GetState().IsKeyDown(Keys.Up)))
                        p.Y++;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    p.Direcção=4;
                    if (CanGo(p) && (!Keyboard.GetState().IsKeyDown(Keys.Right)) && (!Keyboard.GetState().IsKeyDown(Keys.Up)) && (!Keyboard.GetState().IsKeyDown(Keys.Down)))
                        p.X--;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Right) && (!Keyboard.GetState().IsKeyDown(Keys.Up)) && (!Keyboard.GetState().IsKeyDown(Keys.Down))&&(!Keyboard.GetState().IsKeyDown(Keys.Left)))
                {
                    p.Direcção=2;
                    if(CanGo(p))
                        p.X++;
                }
                p.boardX = (p.X+5)/10;
                p.boardY = (p.Y+5)/10;
                f1.boardX = (f1.X + 5) / 10;
                f1.boardY = (f1.Y + 5) / 10;

            // TODO: Add your update logic here
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
            for (by = 0; by < 32;by++ )
            {
                for (bx = 0; bx < 42; bx++)
                {
                    if (board[bx, by] == 0)
                        spriteBatch.Draw(muro, new Rectangle(by * 10, bx * 10, 10, 10), Color.White);
                    if(board[bx,by]==1)
                        spriteBatch.Draw(comida, new Rectangle(by * 10, bx * 10, 10, 10), Color.White);
                    if (board[bx, by] == 2)
                        spriteBatch.Draw(super_comida, new Rectangle(by * 10, bx * 10, 10, 10), Color.White);
                    if(board[bx,by]==9)
                        spriteBatch.Draw(muro, new Rectangle(by * 10, bx * 10, 10, 10), Color.Black);
                }
            }
            spriteBatch.Draw(pacman, new Vector2(p.X, p.Y), Color.White);
            spriteBatch.Draw(fantasma, new Vector2(f1.X, f1.Y), Color.Blue);
            spriteBatch.DrawString(font, score.ToString(), new Vector2(350, 50), Color.Red);
            spriteBatch.DrawString(font, f1.X.ToString(), new Vector2(320, 250), Color.Red);
            spriteBatch.DrawString(font, f1.Y.ToString(), new Vector2(320, 300), Color.Red);
            f1.X = p.X;
            f1.Y = p.Y;
            spriteBatch.DrawString(font, f1.Esta_Centrado().ToString(), new Vector2(350, 150), Color.Red);
                spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        bool CanGo(Pacman p)
        {
            switch(p.Direcção)
            {
                case 1:
                    return CanGo_Up(p);
                case 2:
                    return CanGo_Right(p);
                case 3:
                    return CanGo_Down(p);
                case 4:
                    return CanGo_Left(p);
                default:
                    return true;
            }
        }

        bool CanGo_Up(Pacman p)
        {
            if (p.Y - 1 == 9)
                return false;
            else 
            {
                if (board[p.boardY-1,p.boardX] == 0)
                {
                    if (p.Y == p.boardY * 10)
                        return false;
                    else
                        return true;
                }
                else
                    return true;
            }
        }
        bool CanGo_Down(Pacman p)
        {
            if (p.Y + 1 == 9)
                return false;
            else
            {
                if (board[p.boardY+1, p.boardX] == 0)
                {
                    if (p.Y == p.boardY * 10)
                        return false;
                    else
                        return true;
                }
                else
                    return true;
            }
        }
        bool CanGo_Left(Pacman p)
        {
            if (p.X - 1 == 9)
                return false;
            else
            {
                if (board[p.boardY, p.boardX-1] == 0)
                {
                    if (p.X == p.boardX * 10)
                        return false;
                    else
                        return true;
                }
                else
                    return true;
            }
        }
        bool CanGo_Right(Pacman p)
        {
            if (p.X + 1 == 9)
                return false;
            else
            {
                if (board[p.boardY, p.boardX + 1] == 0)
                {
                    if (p.X == p.boardX * 10)
                        return false;
                    else
                        return true;
                }
                else
                    return true;
            }
        }
    }
}
