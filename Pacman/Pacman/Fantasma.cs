using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    class Fantasma:Pacman
    {
        public Fantasma() { }
        public void Movimento()
        {
            if(Direcção==1)
                Y--;
            else
            {
                if(Direcção==2)
                    X++;
                else 
                {
                    if (Direcção == 3)
                        Y++;
                    else
                    {
                        if (Direcção == 4)
                            X--;
                    }
                }
            }
        }
        public int Get_Vizinhança(byte[,] board)
        {
            if (board[boardY, boardX - 1] == 0 && board[boardY, boardX + 1] == 0 && board[boardY - 1, boardX] != 0 && board[boardY + 1, boardX] != 0)
                return 11;
            if (board[boardY, boardX - 1] != 0 && board[boardY, boardX + 1] != 0 && board[boardY - 1, boardX] == 0 && board[boardY + 1, boardX] == 0)
                return 12;
            if (board[boardY, boardX - 1] == 0 && board[boardY, boardX + 1] != 0 && board[boardY - 1, boardX] == 0 && board[boardY + 1, boardX] != 0)
                return 21;
            if (board[boardY, boardX - 1] != 0 && board[boardY, boardX + 1] == 0 && board[boardY - 1, boardX] == 0 && board[boardY + 1, boardX] != 0)
                return 22;
            if (board[boardY, boardX - 1] == 0 && board[boardY, boardX + 1] != 0 && board[boardY - 1, boardX] != 0 && board[boardY + 1, boardX] == 0)
                return 23;
            if (board[boardY, boardX - 1] != 0 && board[boardY, boardX + 1] == 0 && board[boardY - 1, boardX] != 0 && board[boardY + 1, boardX] == 0)
                return 24;
            if (board[boardY, boardX - 1] != 0 && board[boardY, boardX + 1] != 0 && board[boardY - 1, boardX] == 0 && board[boardY + 1, boardX] != 0)
                return 31;
            if (board[boardY, boardX - 1] != 0 && board[boardY, boardX + 1] != 0 && board[boardY - 1, boardX] != 0 && board[boardY + 1, boardX] == 0)
                return 32;
            if (board[boardY, boardX - 1] == 0 && board[boardY, boardX + 1] != 0 && board[boardY - 1, boardX] != 0 && board[boardY + 1, boardX] != 0)
                return 33;
            if (board[boardY, boardX - 1] != 0 && board[boardY, boardX + 1] == 0 && board[boardY - 1, boardX] != 0 && board[boardY + 1, boardX] != 0)
                return 34;
            if (board[boardY, boardX - 1] != 0 && board[boardY, boardX + 1] != 0 && board[boardY - 1, boardX] != 0 && board[boardY + 1, boardX] != 0)
                return 4;
            else
                return 0;
        }
        public bool Esta_Centrado()
        {
            if (X+5 == ((boardX * 10) + 5) || Y+5 == ((boardY * 10) + 5))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int AI(byte[,] board)
        {
            int vizinhança = Get_Vizinhança(board);
            if (vizinhança == 21 && Esta_Centrado())
            {
                if (Direcção == 1)
                {
                    Direcção = 2;
                }
                else
                    Direcção = 3;
            }
            else
            {
                if(vizinhança == 22 && Esta_Centrado())
                {
                    if (Direcção == 1)
                    {
                        Direcção = 4;
                    }
                    else
                    {
                        Direcção = 3;
                    }
                }
                else
                {
                    if(vizinhança == 23 && Esta_Centrado())
                    {
                        if (Direcção == 4)
                        {
                            Direcção = 2;
                        }
                        else
                        {
                            Direcção = 1;
                        }
                    }
                    else
                    {
                        if(vizinhança==24 && Esta_Centrado())
                        {
                            if (Direcção == 2)
                                Direcção = 1;
                            else
                                Direcção = 4;
                        }
                    }
                }
            }

            return Direcção;
        }
    }
}
