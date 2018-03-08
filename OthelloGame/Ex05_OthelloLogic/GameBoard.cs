using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05_OthelloLogic
{
    public struct Cell
    {
        private GameBoard.eCellColor m_CellColor; // Black represented by -1 ('X' on the board), White represented by 1 ('O' on the board).

        public GameBoard.eCellColor CellColor
        {
            get { return m_CellColor; }
            set { m_CellColor = value; }
        }
    }

    public class GameBoard
    {
        private const int k_SixOnSixBoard = 6;
        private const int k_EightOnEightBoard = 8;
        private readonly int r_BoardSize;
        private readonly Cell[,] m_Board;

        public GameBoard(int i_BoardSize)
        {
            r_BoardSize = i_BoardSize;
            m_Board = new Cell[r_BoardSize, r_BoardSize];
        }

        public static int SixOnSixBoard
        {
            get { return k_SixOnSixBoard; }
        }

        public static int EightOnEightBoard
        {
            get { return k_EightOnEightBoard; }
        }

        public enum eCellColor : int
        {
            Black = -1,
            White = 1,
            Empty = 0
        }

        public int BoardSize
        {
            get { return r_BoardSize; }
        }

        public Cell[,] Board
        {
            get { return m_Board; }
        }

        public void SetForNewGame()
        {
            m_Board[(r_BoardSize / 2) - 1, (r_BoardSize / 2) - 1].CellColor = eCellColor.White;
            m_Board[(r_BoardSize / 2) - 1, r_BoardSize / 2].CellColor = eCellColor.Black;
            m_Board[r_BoardSize / 2, (r_BoardSize / 2) - 1].CellColor = eCellColor.Black;
            m_Board[r_BoardSize / 2, r_BoardSize / 2].CellColor = eCellColor.White;
        }

        public bool CheckIfCellInRange(int i_Row, int i_Column)
        {
            bool inRange = true;

            if (i_Row > BoardSize || i_Row < 1 || i_Column > BoardSize || i_Column < 1)
            {
                inRange = false;
            }

            return inRange;
        }
    }
}
