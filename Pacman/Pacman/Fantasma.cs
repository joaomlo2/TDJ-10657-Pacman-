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
            if (X+5 == ((boardX * 10) + 5) && Y+5 == ((boardY * 10) + 5))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AI(byte[,] board)
        {
            Movimento();
            if (Esta_Centrado())
            {
                if (Get_Vizinhança(board) == 21)
                {
                    if(Direcção==4)
                    {
                        Direcção=3;
                    }
                    if(Direcção==1)
                    {
                        Direcção = 2;
                    }
                }
                if (Get_Vizinhança(board) == 22)
                {
                    if (Direcção == 2)
                    {
                        Direcção = 3;
                    }
                    if (Direcção == 1)
                    {
                        Direcção = 4;
                    }
                }
                if (Get_Vizinhança(board) == 23)
                {
                    if (Direcção == 4)
                    {
                        Direcção = 1;
                    }
                    if (Direcção == 3)
                    {
                        Direcção = 2;
                    }
                }
                if (Get_Vizinhança(board) == 24)
                {
                    if (Direcção == 2)
                    {
                        Direcção = 1;
                    }
                    if (Direcção == 3)
                    {
                        Direcção = 4;
                    }
                }
                if (Get_Vizinhança(board) == 31)
                {
                    if(Direcção==2)
                    {
                        int aux = new Random().Next(1, 3);
                        if(aux==1)
                        {
                            Direcção = 3;
                        }
                        else
                        {
                            Direcção = 2;
                        }
                    }
                    if(Direcção==1)
                    {
                        int aux = new Random().Next(1, 3);
                        if (aux == 1)
                        {
                            Direcção = 4;
                        }
                        else
                        {
                            Direcção = 2;
                        }
                    }
                    if (Direcção == 4)
                    {
                        int aux = new Random().Next(1, 3);
                        if (aux == 1)
                        {
                            Direcção = 4;
                        }
                        else
                        {
                            Direcção = 3;
                        }
                    }
                }
                if (Get_Vizinhança(board) == 32)
                {
                    if (Direcção == 2)
                    {
                        int aux = new Random().Next(1, 3);
                        if (aux == 1)
                        {
                            Direcção = 1;
                        }
                        else
                        {
                            Direcção = 2;
                        }
                    }
                    if (Direcção == 3)
                    {
                        int aux = new Random().Next(1, 3);
                        if (aux == 1)
                        {
                            Direcção = 4;
                        }
                        else
                        {
                            Direcção = 2;
                        }
                    }
                    if (Direcção == 4)
                    {
                        int aux = new Random().Next(1, 3);
                        if (aux == 1)
                        {
                            Direcção = 4;
                        }
                        else
                        {
                            Direcção = 1;
                        }
                    }
                }
                if (Get_Vizinhança(board) == 33)
                {
                    if (Direcção == 3)
                    {
                        int aux = new Random().Next(1, 3);
                        if (aux == 1)
                        {
                            Direcção = 3;
                        }
                        else
                        {
                            Direcção = 2;
                        }
                    }
                    if (Direcção == 1)
                    {
                        int aux = new Random().Next(1, 3);
                        if (aux == 1)
                        {
                            Direcção = 1;
                        }
                        else
                        {
                            Direcção = 2;
                        }
                    }
                    if (Direcção == 4)
                    {
                        int aux = new Random().Next(1, 3);
                        if (aux == 1)
                        {
                            Direcção = 1;
                        }
                        else
                        {
                            Direcção = 3;
                        }
                    }
                }
                if (Get_Vizinhança(board) == 34)
                {
                    if (Direcção == 2)
                    {
                        int aux = new Random().Next(1, 3);
                        if (aux == 1)
                        {
                            Direcção = 3;
                        }
                        else
                        {
                            Direcção = 1;
                        }
                    }
                    if (Direcção == 1)
                    {
                        int aux = new Random().Next(1, 3);
                        if (aux == 1)
                        {
                            Direcção = 4;
                        }
                        else
                        {
                            Direcção = 1;
                        }
                    }
                    if (Direcção == 3)
                    {
                        int aux = new Random().Next(1, 3);
                        if (aux == 1)
                        {
                            Direcção = 4;
                        }
                        else
                        {
                            Direcção = 1;
                        }
                    }
                }
                if (Get_Vizinhança(board) == 4)
                {
                    if(Direcção==1)
                    {
                        int aux = new Random().Next(1, 4);
                        if(aux==1)
                        {
                            Direcção = 1;
                        }
                        else
                        {
                            if(aux==2)
                            {
                                Direcção = 2;
                            }
                            else
                            {
                                Direcção = 4;
                            }
                        }
                    }
                    if (Direcção == 2)
                    {
                        int aux = new Random().Next(1, 4);
                        if (aux == 1)
                        {
                            Direcção = 1;
                        }
                        else
                        {
                            if (aux == 2)
                            {
                                Direcção = 2;
                            }
                            else
                            {
                                Direcção = 3;
                            }
                        }
                    }
                    if (Direcção == 3)
                    {
                        int aux = new Random().Next(1, 4);
                        if (aux == 1)
                        {
                            Direcção = 4;
                        }
                        else
                        {
                            if (aux == 2)
                            {
                                Direcção = 2;
                            }
                            else
                            {
                                Direcção = 3;
                            }
                        }
                    }
                    if (Direcção == 4)
                    {
                        int aux = new Random().Next(1, 4);
                        if (aux == 1)
                        {
                            Direcção = 1;
                        }
                        else
                        {
                            if (aux == 2)
                            {
                                Direcção = 4;
                            }
                            else
                            {
                                Direcção = 3;
                            }
                        }
                    }
                }
            }
        }
    }
}
