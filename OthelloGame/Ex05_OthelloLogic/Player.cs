using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05_OthelloLogic
{
    public class Player
    {
        private readonly List<GamePoint> m_AvaiblePlayerMoves;
        private string m_Name;
        private GameBoard.eCellColor m_PlayerColor; // -1 is Black 'X' , 1 is white 'O'
        private List<eDirection> m_AvaiblePlayerDirections;
        private int m_CountOfAvaiableMoves;
        private int m_SumOfTokensOnBoard;
        private int m_GamesWon = 0;

        public Player()
        {
            m_AvaiblePlayerDirections = new List<eDirection>();
            m_AvaiblePlayerMoves = new List<GamePoint>();
        }

        public int CountOfAvaiableMoves
        {
            get { return m_CountOfAvaiableMoves; }
            set { m_CountOfAvaiableMoves = value; }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public GameBoard.eCellColor PlayerColor
        {
            get { return m_PlayerColor; }
            set { m_PlayerColor = value; }
        }

        public List<eDirection> AvaiblePlayerDirections
        {
            get { return m_AvaiblePlayerDirections; }
            set { m_AvaiblePlayerDirections = value; }
        }

        public List<GamePoint> AvaiblePlayerMoves
        {
            get { return m_AvaiblePlayerMoves; }
        }

        public int SumOfTokensOnBoard
        {
            get { return m_SumOfTokensOnBoard; }
            set { m_SumOfTokensOnBoard = value; }
        }

        public int GamesWon
        {
            get
            {
                return m_GamesWon;
            }

            set
            {
                m_GamesWon = value;
            }
        }

        public void SetPlayerForNewGame()
        {
            AvaiblePlayerDirections.Clear();
            AvaiblePlayerMoves.Clear();
            m_CountOfAvaiableMoves = 1;
            SumOfTokensOnBoard = 0;
        }
    }
}
