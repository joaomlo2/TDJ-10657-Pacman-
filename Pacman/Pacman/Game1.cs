#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Audio;
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
        Texture2D pacsprite;
        SoundEffect waka,alert,game_over,hit,win;
        AnimatedSprite Pac;
        SpriteFont font;
        bool played=false,Pausa=false;
        int Perdeu,Level=1,Level_Progress=0,Vidas=3,sprtcnt,waka_timer=0,played_alert=0,alert_timer=0,played_goat=0,played_win=0;
        Pacman p;
        Fantasma f1, f2, f3, f4;
        int by, bx,score=0;
        byte[,] board = {{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                         {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
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
                         {0,1,0,0,0,1,0,1,0,1,0,1,0,1,0,1,1,0,1,0,1,0,1,0,1,0,1,0,0,0,1,0},
                         {0,1,0,0,0,1,0,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,0,1,0,0,0,1,0},
                         {0,1,0,1,1,1,1,1,0,1,0,0,0,0,0,1,1,0,0,0,0,0,1,0,1,1,1,1,1,0,1,0},
                         {0,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,1,1,0,1,0,1,0,1,0,1,0,1,0},
                         {0,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,1,1,0,1,0,1,0,1,0,1,0,1,0},
                         {0,1,0,1,1,1,1,1,0,1,0,0,0,0,0,1,1,0,0,0,0,0,1,0,1,1,1,1,1,0,1,0},
                         {0,1,0,0,0,1,0,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,0,1,0,0,0,1,0},
                         {0,1,0,0,0,1,0,1,0,1,0,1,0,1,0,1,1,0,1,0,1,0,1,0,1,0,1,0,0,0,1,0},
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
                         {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
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
            f1.X = 10;
            f1.Y = 160;
            f2 = new Fantasma();
            f2.X = 10;
            f2.Y = 250;
            f3 = new Fantasma();
            f3.Direcção = 4;
            f3.X = 300;
            f3.Y = 160;
            f4 = new Fantasma();
            f4.Direcção = 4;
            f4.X = 300;
            f4.Y = 250;
            Perdeu = 0;
            Vidas = 3;
            sprtcnt = 0;
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
            font = Content.Load<SpriteFont>("Arcade");
            pacsprite = Content.Load<Texture2D>("Pacman_Sheet-2");
            alert = Content.Load<SoundEffect>("MGS_Alert");
            waka = Content.Load<SoundEffect>("Waka");
            hit = Content.Load<SoundEffect>("Punch Sound Effect");
            game_over = Content.Load<SoundEffect>("Goat");
            win = Content.Load<SoundEffect>("Win");
            Pac = new AnimatedSprite(pacsprite, 1, 3);
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
                Level_Progress = ((score / Level) * 100) / 720;
                if (waka_timer==2)
                {
                    waka.Play();
                    waka_timer = 0;
                }
                waka_timer++;
                score++;
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Perdeu != 1||!Ganhou(board)&&!Pausa)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    if (p.Direcção != 1)
                    {
                        p.Direcção = 1;
                        pacsprite = Content.Load<Texture2D>("Pacman_Sheet-1");
                        Pac = new AnimatedSprite(pacsprite, 3, 1);
                    }
                    if (CanGo(p) && (!Keyboard.GetState().IsKeyDown(Keys.Left)) && (!Keyboard.GetState().IsKeyDown(Keys.Right)) && (!Keyboard.GetState().IsKeyDown(Keys.Down)))
                        p.Y--;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    if (p.Direcção != 3)
                    {
                        p.Direcção = 3;
                        pacsprite = Content.Load<Texture2D>("Pacman_Sheet-3");
                        Pac = new AnimatedSprite(pacsprite, 3, 1);
                    }
                        if (CanGo(p) && (!Keyboard.GetState().IsKeyDown(Keys.Left)) && (!Keyboard.GetState().IsKeyDown(Keys.Right)) && (!Keyboard.GetState().IsKeyDown(Keys.Up)))
                        p.Y++;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    if (p.Direcção != 4)
                    {
                        p.Direcção = 4;
                        pacsprite = Content.Load<Texture2D>("Pacman_Sheet-4");
                        Pac = new AnimatedSprite(pacsprite, 1, 3);
                    }
                    if (CanGo(p) && (!Keyboard.GetState().IsKeyDown(Keys.Right)) && (!Keyboard.GetState().IsKeyDown(Keys.Up)) && (!Keyboard.GetState().IsKeyDown(Keys.Down)))
                        p.X--;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Right) && (!Keyboard.GetState().IsKeyDown(Keys.Up)) && (!Keyboard.GetState().IsKeyDown(Keys.Down)) && (!Keyboard.GetState().IsKeyDown(Keys.Left)))
                {
                    if (p.Direcção != 2)
                    {
                        p.Direcção = 2;
                        pacsprite = Content.Load<Texture2D>("Pacman_Sheet-2");
                        Pac = new AnimatedSprite(pacsprite, 1, 3);
                    }
                    if (CanGo(p))
                        p.X++;
                }
                p.boardX = (p.X + 5) / 10;
                p.boardY = (p.Y + 5) / 10;
                if (!Pausa)
                {
                    f1.AI(board);
                }
                f1.boardX = (f1.X + 5) / 10;
                f1.boardY = (f1.Y + 5) / 10;
                if (!Pausa)
                {
                    f2.AI(board);
                }
                f2.boardX = (f2.X + 5) / 10;
                f2.boardY = (f2.Y + 5) / 10;
                if (!Pausa)
                {
                    f3.AI(board);
                }
                f3.boardX = (f3.X + 5) / 10; 
                f3.boardY = (f3.Y + 5) / 10;
                if (!Pausa)
                {
                    f4.AI(board);
                }
                f4.boardX = (f4.X + 5) / 10;
                f4.boardY = (f4.Y + 5) / 10;
                if (p.boardX == f1.boardX && p.boardY == f1.boardY)
                {
                    Perdeu = 1;
                    hit.Play();
                }
                if (p.boardX == f2.boardX && p.boardY == f2.boardY)
                {
                    Perdeu = 1;
                    hit.Play();
                }
                if (p.boardX == f3.boardX && p.boardY == f3.boardY)
                {
                    Perdeu = 1;
                    hit.Play();
                }
                if (p.boardX == f4.boardX && p.boardY == f4.boardY)
                { 
                    Perdeu = 1;
                    hit.Play();
                }
            }
            else
            {
                    Vidas--;
            }
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
            if (Perdeu == 1 || Ganhou(board))
            {
                if (Perdeu == 1)
                {
                    if (Vidas == 0)
                    {
                        spriteBatch.Begin();
                        spriteBatch.DrawString(font, "Game Over", new Vector2(125, 150), Color.White);
                        spriteBatch.DrawString(font, "Score:", new Vector2(125, 165), Color.Yellow);
                        spriteBatch.DrawString(font,score.ToString(),new Vector2(125,180),Color.Yellow);
                        spriteBatch.End();
                        if (played_goat == 0)
                        {
                            game_over.Play();
                            played_goat = 1;
                        }
                    }
                    else 
                    {
                        Vidas--;
                        p.X = 10;
                        p.Y = 10;
                        Perdeu = 0;
                    }
                }
                if(Ganhou(board))
                {
                    spriteBatch.Begin();
                    spriteBatch.DrawString(font, "Ganhou!", new Vector2(110, 125), Color.GreenYellow);
                    spriteBatch.DrawString(font, "Carregue em Enter", new Vector2(110, 150), Color.GreenYellow);
                    spriteBatch.DrawString(font, "Para Continuar", new Vector2(110, 175), Color.GreenYellow);
                    if(played_win==0)
                    {
                        win.Play();
                        played_win = 1;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    {
                        Pausa = false;
                        played_win = 0;
                        for (int i = 0; i < 42; i++)
                        {
                            for (int j = 0; j < 32; j++)
                            {
                                if (board[i, j] == 9)
                                {
                                    board[i, j] = 1;
                                }
                            }
                        }
                        Level++;
                        Level_Progress = 0;
                        p.X = 10;
                        p.Y = 10;
                    }
                        spriteBatch.End();
                }
            }
            else
            {
                spriteBatch.Begin();
                for (by = 0; by < 32; by++)
                {
                    for (bx = 0; bx < 42; bx++)
                    {
                        if (board[bx, by] == 0)
                            spriteBatch.Draw(muro, new Rectangle(by * 10, bx * 10, 10, 10), Color.White);
                        if (board[bx, by] == 1)
                            spriteBatch.Draw(comida, new Rectangle(by * 10, bx * 10, 10, 10), Color.White);
                        if (board[bx, by] == 2)
                            spriteBatch.Draw(super_comida, new Rectangle(by * 10, bx * 10, 10, 10), Color.White);
                        if (board[bx, by] == 9)
                            spriteBatch.Draw(muro, new Rectangle(by * 10, bx * 10, 10, 10), Color.Black);
                    }
                }
                //spriteBatch.Draw(pacman, new Vector2(p.X, p.Y), Color.White);
                Pac.Draw(spriteBatch,new Vector2(p.X,p.Y));
                if (sprtcnt == 5)
                {
                    Pac.Update();
                    sprtcnt = 0;
                }
                sprtcnt++;
                if (f1.boardX >= (p.boardX - 4) && f1.boardX <= (p.boardX + 4) && f1.boardY >= (p.boardY - 4) && f1.boardY <= (p.boardY + 4))
                {
                    spriteBatch.Draw(fantasma, new Vector2(f1.X, f1.Y), Color.Red);
                    if (played_alert == 0)
                    {
                        played_alert = 1;
                        if(alert_timer==40)
                        {
                            alert.Play();
                            alert_timer = 0;
                        }
                        alert_timer++;
                    }
                }
                else
                {
                    played_alert = 0;
                }
                if (f2.boardX >= (p.boardX - 4) && f2.boardX <= (p.boardX + 4) && f2.boardY >= (p.boardY - 4) && f2.boardY <= (p.boardY + 4))
                {
                    spriteBatch.Draw(fantasma, new Vector2(f2.X, f2.Y), Color.Yellow);
                    if (played_alert == 0)
                    {
                        played_alert = 1;
                        if (alert_timer == 40)
                        {
                            alert.Play();
                            alert_timer = 0;
                        }
                        alert_timer++;
                    }
                }
                else
                {
                    played_alert = 0;
                }
                if (f3.boardX >= (p.boardX - 4) && f3.boardX <= (p.boardX + 4) && f3.boardY >= (p.boardY - 4) && f3.boardY <= (p.boardY + 4))
                {
                    spriteBatch.Draw(fantasma, new Vector2(f3.X, f3.Y), Color.Cyan);
                    if (played_alert == 0)
                    {
                        played_alert = 1;
                        if (alert_timer == 40)
                        {
                            alert.Play();
                            alert_timer = 0;
                        }
                        alert_timer++;
                    }
                }
                else
                {
                    played_alert = 0;
                }
                if (f4.boardX >= (p.boardX - 4) && f4.boardX <= (p.boardX + 4) && f4.boardY >= (p.boardY - 4) && f4.boardY <= (p.boardY + 4))
                {
                    spriteBatch.Draw(fantasma, new Vector2(f4.X, f4.Y), Color.Pink);
                    if (played_alert == 0)
                    {
                        played_alert = 1;
                        if (alert_timer == 40)
                        {
                            alert.Play();
                            alert_timer = 0;
                        }
                        alert_timer++;
                    }
                }
                else
                {
                    played_alert = 0;
                }
                spriteBatch.DrawString(font, "LEVEl:", new Vector2(320, 0), Color.White);
                spriteBatch.DrawString(font, Level.ToString(), new Vector2(320, 25), Color.White);
                spriteBatch.DrawString(font, "SCORE:", new Vector2(320, 50), Color.White);
                spriteBatch.DrawString(font, score.ToString(), new Vector2(320, 75), Color.White);
                spriteBatch.DrawString(font, "LIVES:", new Vector2(320, 150), Color.White);
                spriteBatch.DrawString(font, Vidas.ToString(), new Vector2(320, 175), Color.White);
                spriteBatch.DrawString(font, Level_Progress.ToString()+'%', new Vector2(320, 250), Color.White);
                spriteBatch.End();
                // TODO: Add your drawing code here
            }
            base.Draw(gameTime);
        }
        bool Ganhou(byte[,] board)
        {
            bool encontrou = false;
            for(int i=0;i<42;i++)
            {
                for(int j=0;j<32;j++)
                {
                    if(board[i,j]==1)
                    {
                        encontrou = true;
                    }
                }
            }
            if (encontrou)
                return false;
            else
                return true;
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
                    if (p.Y <= p.boardY * 10)
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
                    if (p.Y >= p.boardY * 10)
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
                    if (p.X <= p.boardX * 10)
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
                    if (p.X >= p.boardX * 10)
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
