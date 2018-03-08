using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05_OthelloLogic
{
    public class GameManager
    {
        private GameBoard m_OthelloGameBoard;

        public int BoardSize
        {
            get { return m_OthelloGameBoard.BoardSize; }
        }

        public void CreateBoardGame(int i_BoardSize)
        {
            m_OthelloGameBoard = new GameBoard(i_BoardSize);
        }

        public GameBoard OthelloGameBoard
        {
            get { return m_OthelloGameBoard; }
        }

        public bool CheckIfCellEmpty(int i_Row, int i_Col)
        {
            bool isEmpty = true;
            if (OthelloGameBoard.Board[i_Row, i_Col].CellColor != GameBoard.eCellColor.Empty)
            {
                isEmpty = false;
            }

            return isEmpty;
        }

        public bool avaibleMoveFromDownToUp(int i_Row, int i_Col, Player i_CurrentPlayer)
        {
            bool avaibleMove = false;

            if (i_Row > 1)
            {
                GameBoard.eCellColor oneCellUp = OthelloGameBoard.Board[i_Row - 1, i_Col].CellColor;
                if ((i_CurrentPlayer.PlayerColor != oneCellUp) && (oneCellUp != GameBoard.eCellColor.Empty))
                {
                    int i = i_Row - 2;
                    while ((i >= 0) && (OthelloGameBoard.Board[i, i_Col].CellColor != GameBoard.eCellColor.Empty))
                    {
                        if (OthelloGameBoard.Board[i, i_Col].CellColor == i_CurrentPlayer.PlayerColor)
                        {
                            avaibleMove = true;
                            break;
                        }

                        i--;
                    }
                }
            }

            return avaibleMove;
        }

        private bool avaibleMoveFromUpToDown(int i_Row, int i_Col, Player i_CurrentPlayer)
        {
            bool avaibleMove = false;

            if (i_Row < BoardSize - 2)
            {
                GameBoard.eCellColor oneCellDown = OthelloGameBoard.Board[i_Row + 1, i_Col].CellColor;
                if ((i_CurrentPlayer.PlayerColor != oneCellDown) && (oneCellDown != GameBoard.eCellColor.Empty))
                {
                    int i = i_Row + 2;
                    while ((i < BoardSize) && (OthelloGameBoard.Board[i, i_Col].CellColor != GameBoard.eCellColor.Empty))
                    {
                        if (OthelloGameBoard.Board[i, i_Col].CellColor == i_CurrentPlayer.PlayerColor)
                        {
                            avaibleMove = true;
                            break;
                        }

                        i++;
                    }
                }
            }

            return avaibleMove;
        }

        private bool avaibleMoveFromLeftToRight(int i_Row, int i_Col, Player i_CurrentPlayer)
        {
            bool avaibleMove = false;

            if (i_Col < BoardSize - 2)
            {
                GameBoard.eCellColor oneCellRight = OthelloGameBoard.Board[i_Row, i_Col + 1].CellColor;
                if ((i_CurrentPlayer.PlayerColor != oneCellRight) && (oneCellRight != GameBoard.eCellColor.Empty))
                {
                    int j = i_Col + 2;
                    while ((j < BoardSize) && (OthelloGameBoard.Board[i_Row, j].CellColor != GameBoard.eCellColor.Empty))
                    {
                        if (OthelloGameBoard.Board[i_Row, j].CellColor == i_CurrentPlayer.PlayerColor)
                        {
                            avaibleMove = true;
                            break;
                        }

                        j++;
                    }
                }
            }

            return avaibleMove;
        }

        private bool avaibleMoveFromRightToLeft(int i_Row, int i_Col, Player i_CurrentPlayer)
        {
            bool avaibleMove = false;

            if (i_Col > 1)
            {
                GameBoard.eCellColor oneCellLeft = OthelloGameBoard.Board[i_Row, i_Col - 1].CellColor;
                if ((i_CurrentPlayer.PlayerColor != oneCellLeft) && (oneCellLeft != GameBoard.eCellColor.Empty))
                {
                    int j = i_Col - 2;
                    while ((j >= 0) && (OthelloGameBoard.Board[i_Row, j].CellColor != GameBoard.eCellColor.Empty))
                    {
                        if (OthelloGameBoard.Board[i_Row, j].CellColor == i_CurrentPlayer.PlayerColor)
                        {
                            avaibleMove = true;
                            break;
                        }

                        j--;
                    }
                }
            }

            return avaibleMove;
        }

        private bool avaibleMoveDiagonalUpRight(int i_Row, int i_Col, Player i_CurrentPlayer)
        {
            bool avaibleMove = false;

            if (i_Row > 1 && i_Col < BoardSize - 2)
            {
                GameBoard.eCellColor oneCellDiagonalUpRight = OthelloGameBoard.Board[i_Row - 1, i_Col + 1].CellColor;
                if ((i_CurrentPlayer.PlayerColor != oneCellDiagonalUpRight) && (oneCellDiagonalUpRight != GameBoard.eCellColor.Empty))
                {
                    int i = i_Row - 2;
                    int j = i_Col + 2;

                    while (i >= 0 && j < BoardSize && OthelloGameBoard.Board[i, j].CellColor != GameBoard.eCellColor.Empty)
                    {
                        if (OthelloGameBoard.Board[i, j].CellColor == i_CurrentPlayer.PlayerColor)
                        {
                            avaibleMove = true;
                            break;
                        }

                        i--;
                        j++;
                    }
                }
            }

            return avaibleMove;
        }

        private bool avaibleMoveDiagonalUpLeft(int i_Row, int i_Col, Player i_CurrentPlayer)
        {
            bool avaibleMove = false;

            if (i_Row > 1 && i_Col > 1)
            {
                GameBoard.eCellColor oneCellDiagonalUpLeft = OthelloGameBoard.Board[i_Row - 1, i_Col - 1].CellColor;
                if ((i_CurrentPlayer.PlayerColor != oneCellDiagonalUpLeft) && (oneCellDiagonalUpLeft != GameBoard.eCellColor.Empty))
                {
                    int i = i_Row - 2;
                    int j = i_Col - 2;

                    while (i >= 0 && j >= 0 && OthelloGameBoard.Board[i, j].CellColor != GameBoard.eCellColor.Empty)
                    {
                        if (OthelloGameBoard.Board[i, j].CellColor == i_CurrentPlayer.PlayerColor)
                        {
                            avaibleMove = true;
                            break;
                        }

                        i--;
                        j--;
                    }
                }
            }

            return avaibleMove;
        }

        private bool avaibleMoveDiagonalDownRight(int i_Row, int i_Col, Player i_CurrentPlayer)
        {
            bool avaibleMove = false;

            if (i_Row < BoardSize - 2 && i_Col < BoardSize - 2)
            {
                GameBoard.eCellColor oneCellDiagonalDownRight = OthelloGameBoard.Board[i_Row + 1, i_Col + 1].CellColor;
                if ((i_CurrentPlayer.PlayerColor != oneCellDiagonalDownRight) && (oneCellDiagonalDownRight != GameBoard.eCellColor.Empty))
                {
                    int i = i_Row + 2;
                    int j = i_Col + 2;

                    while (i < BoardSize && j < BoardSize && OthelloGameBoard.Board[i, j].CellColor != GameBoard.eCellColor.Empty)
                    {
                        if (OthelloGameBoard.Board[i, j].CellColor == i_CurrentPlayer.PlayerColor)
                        {
                            avaibleMove = true;
                            break;
                        }

                        i++;
                        j++;
                    }
                }
            }

            return avaibleMove;
        }

        private bool avaibleMoveDiagonalDownLeft(int i_Row, int i_Col, Player i_CurrentPlayer)
        {
            bool avaibleMove = false;

            if (i_Row < BoardSize - 2 && i_Col > 1)
            {
                GameBoard.eCellColor oneCellDiagonalDownRight = OthelloGameBoard.Board[i_Row + 1, i_Col - 1].CellColor;
                if ((i_CurrentPlayer.PlayerColor != oneCellDiagonalDownRight) && (oneCellDiagonalDownRight != GameBoard.eCellColor.Empty))
                {
                    int i = i_Row + 2;
                    int j = i_Col - 2;

                    while (i < BoardSize && j >= 0 && OthelloGameBoard.Board[i, j].CellColor != GameBoard.eCellColor.Empty)
                    {
                        if (OthelloGameBoard.Board[i, j].CellColor == i_CurrentPlayer.PlayerColor)
                        {
                            avaibleMove = true;
                            break;
                        }

                        i++;
                        j--;
                    }
                }
            }

            return avaibleMove;
        }

        public void SetAvaibleDirectionsToList(int i_Row, int i_Col, Player i_CurrentPlayer)
        {
            if (avaibleMoveFromDownToUp(i_Row, i_Col, i_CurrentPlayer))
            {
                i_CurrentPlayer.AvaiblePlayerDirections.Add(eDirection.DownToUp);
            }

            if (avaibleMoveFromUpToDown(i_Row, i_Col, i_CurrentPlayer))
            {
                i_CurrentPlayer.AvaiblePlayerDirections.Add(eDirection.UpToDown);
            }

            if (avaibleMoveFromLeftToRight(i_Row, i_Col, i_CurrentPlayer))
            {
                i_CurrentPlayer.AvaiblePlayerDirections.Add(eDirection.LeftToRight);
            }

            if (avaibleMoveFromRightToLeft(i_Row, i_Col, i_CurrentPlayer))
            {
                i_CurrentPlayer.AvaiblePlayerDirections.Add(eDirection.RightToLeft);
            }

            if (avaibleMoveDiagonalUpRight(i_Row, i_Col, i_CurrentPlayer))
            {
                i_CurrentPlayer.AvaiblePlayerDirections.Add(eDirection.DiagonalUpRight);
            }

            if (avaibleMoveDiagonalUpLeft(i_Row, i_Col, i_CurrentPlayer))
            {
                i_CurrentPlayer.AvaiblePlayerDirections.Add(eDirection.DiagonalUpLeft);
            }

            if (avaibleMoveDiagonalDownRight(i_Row, i_Col, i_CurrentPlayer))
            {
                i_CurrentPlayer.AvaiblePlayerDirections.Add(eDirection.DiagonalDownRight);
            }

            if (avaibleMoveDiagonalDownLeft(i_Row, i_Col, i_CurrentPlayer))
            {
                i_CurrentPlayer.AvaiblePlayerDirections.Add(eDirection.DiagonalDownLeft);
            }
        }

        public bool IsValidMove(int i_Row, int i_Col, Player i_CurrentPlayer)
        {
            bool validMove = false;

            if (avaibleMoveFromDownToUp(i_Row, i_Col, i_CurrentPlayer) || avaibleMoveFromUpToDown(i_Row, i_Col, i_CurrentPlayer)
                || avaibleMoveFromLeftToRight(i_Row, i_Col, i_CurrentPlayer) || avaibleMoveFromRightToLeft(i_Row, i_Col, i_CurrentPlayer)
                || avaibleMoveDiagonalUpRight(i_Row, i_Col, i_CurrentPlayer) || avaibleMoveDiagonalUpLeft(i_Row, i_Col, i_CurrentPlayer)
                || avaibleMoveDiagonalDownLeft(i_Row, i_Col, i_CurrentPlayer) || avaibleMoveDiagonalDownRight(i_Row, i_Col, i_CurrentPlayer))
            {
                validMove = true;
            }

            return validMove;
        }

        // Functions update cells on board for each side.
        private void updateFromDownToUp(int i_Row, int i_Col, Player i_CurrentPlayer)
        {
            OthelloGameBoard.Board[i_Row, i_Col].CellColor = i_CurrentPlayer.PlayerColor;
            int i = i_Row - 1;

            while ((i >= 0) && (OthelloGameBoard.Board[i, i_Col].CellColor != GameBoard.eCellColor.Empty)
                    && (OthelloGameBoard.Board[i, i_Col].CellColor != i_CurrentPlayer.PlayerColor))
            {
                OthelloGameBoard.Board[i, i_Col].CellColor = i_CurrentPlayer.PlayerColor;
                i--;
            }
        }

        private void updateFromUpToDown(int i_Row, int i_Col, Player i_CurrentPlayer)
        {
            OthelloGameBoard.Board[i_Row, i_Col].CellColor = i_CurrentPlayer.PlayerColor;
            int i = i_Row + 1;

            while ((i < BoardSize) && (OthelloGameBoard.Board[i, i_Col].CellColor != GameBoard.eCellColor.Empty)
                     && (OthelloGameBoard.Board[i, i_Col].CellColor != i_CurrentPlayer.PlayerColor))
            {
                OthelloGameBoard.Board[i, i_Col].CellColor = i_CurrentPlayer.PlayerColor;
                i++;
            }
        }

        private void updateFromLeftToRight(int i_Row, int i_Col, Player i_CurrentPlayer)
        {
            OthelloGameBoard.Board[i_Row, i_Col].CellColor = i_CurrentPlayer.PlayerColor;
            int j = i_Col + 1;

            while ((j < BoardSize) && (OthelloGameBoard.Board[i_Row, j].CellColor != GameBoard.eCellColor.Empty)
                     && (OthelloGameBoard.Board[i_Row, j].CellColor != i_CurrentPlayer.PlayerColor))
            {
                OthelloGameBoard.Board[i_Row, j].CellColor = i_CurrentPlayer.PlayerColor;
                j++;
            }
        }

        private void updateFromRightToLeft(int i_Row, int i_Col, Player i_CurrentPlayer)
        {
            OthelloGameBoard.Board[i_Row, i_Col].CellColor = i_CurrentPlayer.PlayerColor;

            int j = i_Col - 1;

            while ((j >= 0) && (OthelloGameBoard.Board[i_Row, j].CellColor != GameBoard.eCellColor.Empty)
                     && (OthelloGameBoard.Board[i_Row, j].CellColor != i_CurrentPlayer.PlayerColor))
            {
                OthelloGameBoard.Board[i_Row, j].CellColor = i_CurrentPlayer.PlayerColor;
                j--;
            }
        }

        private void updateDiagonalUpRight(int i_Row, int i_Col, Player i_CurrentPlayer)
        {
            OthelloGameBoard.Board[i_Row, i_Col].CellColor = i_CurrentPlayer.PlayerColor;
            int i = i_Row - 1;
            int j = i_Col + 1;

            while (i >= 0 && j < BoardSize && OthelloGameBoard.Board[i, j].CellColor != GameBoard.eCellColor.Empty
                    && (OthelloGameBoard.Board[i, j].CellColor != i_CurrentPlayer.PlayerColor))
            {
                OthelloGameBoard.Board[i, j].CellColor = i_CurrentPlayer.PlayerColor;
                i--;
                j++;
            }
        }

        private void updateDiagonalUpLeft(int i_Row, int i_Col, Player i_CurrentPlayer)
        {
            OthelloGameBoard.Board[i_Row, i_Col].CellColor = i_CurrentPlayer.PlayerColor;
            int i = i_Row - 1;
            int j = i_Col - 1;

            while (i >= 0 && j >= 0 && OthelloGameBoard.Board[i, j].CellColor != GameBoard.eCellColor.Empty
                    && (OthelloGameBoard.Board[i, j].CellColor != i_CurrentPlayer.PlayerColor))
            {
                OthelloGameBoard.Board[i, j].CellColor = i_CurrentPlayer.PlayerColor;
                i--;
                j--;
            }
        }

        private void updateDiagonalDownRight(int i_Row, int i_Col, Player i_CurrentPlayer)
        {
            OthelloGameBoard.Board[i_Row, i_Col].CellColor = i_CurrentPlayer.PlayerColor;
            int i = i_Row + 1;
            int j = i_Col + 1;

            while (i < BoardSize && j < BoardSize && OthelloGameBoard.Board[i, j].CellColor != GameBoard.eCellColor.Empty
                    && (OthelloGameBoard.Board[i, j].CellColor != i_CurrentPlayer.PlayerColor))
            {
                OthelloGameBoard.Board[i, j].CellColor = i_CurrentPlayer.PlayerColor;
                i++;
                j++;
            }
        }

        private void updateDiagonalDownLeft(int i_Row, int i_Col, Player i_CurrentPlayer)
        {
            OthelloGameBoard.Board[i_Row, i_Col].CellColor = i_CurrentPlayer.PlayerColor;
            int i = i_Row + 1;
            int j = i_Col - 1;

            while (i < BoardSize && j >= 0 && OthelloGameBoard.Board[i, j].CellColor != GameBoard.eCellColor.Empty
                    && (OthelloGameBoard.Board[i, j].CellColor != i_CurrentPlayer.PlayerColor))
            {
                OthelloGameBoard.Board[i, j].CellColor = i_CurrentPlayer.PlayerColor;
                i++;
                j--;
            }
        }

        public void UpdateCellsOnBoard(int i_Row, int i_Col, Player i_CurrentPlayer)
        {
            for (int i = 0; i < i_CurrentPlayer.AvaiblePlayerDirections.Count; i++)
            {
                switch (i_CurrentPlayer.AvaiblePlayerDirections[i])
                {
                    case eDirection.DownToUp:
                        updateFromDownToUp(i_Row, i_Col, i_CurrentPlayer);
                        break;
                    case eDirection.UpToDown:
                        updateFromUpToDown(i_Row, i_Col, i_CurrentPlayer);
                        break;
                    case eDirection.LeftToRight:
                        updateFromLeftToRight(i_Row, i_Col, i_CurrentPlayer);
                        break;
                    case eDirection.RightToLeft:
                        updateFromRightToLeft(i_Row, i_Col, i_CurrentPlayer);
                        break;
                    case eDirection.DiagonalUpRight:
                        updateDiagonalUpRight(i_Row, i_Col, i_CurrentPlayer);
                        break;
                    case eDirection.DiagonalUpLeft:
                        updateDiagonalUpLeft(i_Row, i_Col, i_CurrentPlayer);
                        break;
                    case eDirection.DiagonalDownRight:
                        updateDiagonalDownRight(i_Row, i_Col, i_CurrentPlayer);
                        break;
                    case eDirection.DiagonalDownLeft:
                        updateDiagonalDownLeft(i_Row, i_Col, i_CurrentPlayer);
                        break;
                }
            }
        }

        public void CountPlayerAvaibleMoves(Player i_CurrentPlayer)
        {
            int tempAvaibleMovesCount = 0;

            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if (OthelloGameBoard.Board[i, j].CellColor == GameBoard.eCellColor.Empty)
                    {
                        if (IsValidMove(i, j, i_CurrentPlayer) == true)
                        {
                            tempAvaibleMovesCount++;
                        }
                    }
                }
            }

            i_CurrentPlayer.CountOfAvaiableMoves = tempAvaibleMovesCount;
        }
        
        public void SetComputerAvaibleCellsToList(Player i_CurrentPlayer)
        {
            GamePoint avaibleMoveCell = new GamePoint();

            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if (OthelloGameBoard.Board[i, j].CellColor == GameBoard.eCellColor.Empty)
                    {
                        if (IsValidMove(i, j, i_CurrentPlayer) == true)
                        {
                            avaibleMoveCell.Row = i;
                            avaibleMoveCell.Column = j;
                            i_CurrentPlayer.AvaiblePlayerMoves.Add(avaibleMoveCell);
                        }
                    }
                }
            }
        }

        public void GetWinningPlayer(Player i_FirstBlackPlayer, Player i_SecondWhitePlayer)
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if (OthelloGameBoard.Board[i, j].CellColor == GameBoard.eCellColor.Black)
                    {
                        i_FirstBlackPlayer.SumOfTokensOnBoard++;
                    }
                    else if (OthelloGameBoard.Board[i, j].CellColor == GameBoard.eCellColor.White)
                    {
                        i_SecondWhitePlayer.SumOfTokensOnBoard++;
                    }
                }
            }
        }
    }
}
