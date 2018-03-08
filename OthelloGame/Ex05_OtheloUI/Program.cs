using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05_OthelloUI
{
    public class Program
    {
        public static void Main()
        {
            FormGameBoard gameboard = new FormGameBoard();
            gameboard.ShowDialog();
        }
    }
}