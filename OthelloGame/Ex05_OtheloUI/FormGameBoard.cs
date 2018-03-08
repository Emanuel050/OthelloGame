using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ex05_OthelloLogic;

namespace Ex05_OthelloUI
{
    public partial class FormGameBoard : Form
    {
        private const string k_Title = "Othello - {0} turn";
        private const int k_ButtonSize = 50;
        private const int k_SpaceBetweenButtons = 4;
        private const int k_MergeSize = 15;
        private const string k_ButtonText = "O";
        private readonly int r_BoardSize;
        private readonly BoardButton[,] r_ButtonsArray;
        private FormGameSettings m_GameSettings;
        private GameManager m_GameManager;
        private Player m_BlackPlayer;
        private Player m_WhitePlayer;
        private Player m_CurrenPlayer;

        public FormGameBoard()
        {
            InitializeComponent();
            m_GameSettings = new FormGameSettings();
            if (m_GameSettings.ShowDialog() != DialogResult.Cancel)
            {
                r_BoardSize = m_GameSettings.BoardSize;
                r_ButtonsArray = new BoardButton[r_BoardSize, r_BoardSize];
            }
            else
            {
                Environment.Exit(0);
            }

            m_GameManager = new GameManager();
            m_BlackPlayer = new Player();
            m_WhitePlayer = new Player();
            m_BlackPlayer.PlayerColor = GameBoard.eCellColor.Black;
            m_WhitePlayer.PlayerColor = GameBoard.eCellColor.White;

            buildBoard();
            runGame();
        }

        private void runGame()
        {
            m_GameManager.CreateBoardGame(r_BoardSize);
            m_GameManager.OthelloGameBoard.SetForNewGame();
            m_BlackPlayer.SetPlayerForNewGame();
            m_WhitePlayer.SetPlayerForNewGame();
            m_CurrenPlayer = m_BlackPlayer;
            m_BlackPlayer.Name = "Black's";
            m_WhitePlayer.Name = "White's";
            playNewTurn();
        }

        private void playNewTurn()
        {
            m_GameManager.SetComputerAvaibleCellsToList(m_CurrenPlayer);
            updateBoard();
            if (m_BlackPlayer.CountOfAvaiableMoves != 0 || m_WhitePlayer.CountOfAvaiableMoves != 0)
            {
                if (m_CurrenPlayer.CountOfAvaiableMoves == 0)
                {
                    MessageBox.Show(string.Format("{0} player don't have any valid move! press OK to continue", m_CurrenPlayer.Name), "No valid moves", MessageBoxButtons.OK);
                    changeTurn();
                    playNewTurn();
                }

                if (m_CurrenPlayer == m_WhitePlayer && m_GameSettings.DialogResult == DialogResult.Yes)
                {
                    if (m_CurrenPlayer.CountOfAvaiableMoves == 0)
                    {
                        MessageBox.Show(string.Format("{0} player don't have any valid move! press OK to continue", m_CurrenPlayer.Name), "No valid moves", MessageBoxButtons.OK);
                        changeTurn();
                        playNewTurn();
                    }
                    else
                    {
                        playComputerMove();
                    }
                }
            }
            else
            {
                gameOver();
            }
        }

        private void buildBoard()
        {
            int rowOffset = k_MergeSize;
            int lineOffset = k_MergeSize;
            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
                    BoardButton newButton = new BoardButton(i, j);
                    newButton.Size = new Size(k_ButtonSize, k_ButtonSize);
                    newButton.Location = new Point(rowOffset, lineOffset);
                    newButton.Enabled = false;
                    r_ButtonsArray[i, j] = newButton;
                    newButton.Click += NewButton_Click;
                    this.Controls.Add(newButton);
                    rowOffset += k_ButtonSize + k_SpaceBetweenButtons;
                }

                lineOffset += k_ButtonSize + k_SpaceBetweenButtons;
                rowOffset = k_MergeSize;
            }

            this.Size = new Size(lineOffset + 30, lineOffset + 50);
        }

        private void updateBoard()
        {
            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
                    ////Reset the buttons on board
                    r_ButtonsArray[i, j].BackColor = default(Color);
                    r_ButtonsArray[i, j].Enabled = false;
                    r_ButtonsArray[i, j].Text = null;

                    switch (m_GameManager.OthelloGameBoard.Board[i, j].CellColor)
                    {
                        case GameBoard.eCellColor.Black:
                            r_ButtonsArray[i, j].BackColor = Color.Black;
                            r_ButtonsArray[i, j].Text = k_ButtonText;
                            break;
                        case GameBoard.eCellColor.White:
                            r_ButtonsArray[i, j].BackColor = Color.White;
                            r_ButtonsArray[i, j].Text = k_ButtonText;
                            break;
                    }
   
                    this.Text = string.Format(k_Title, m_CurrenPlayer.Name);
                    setAvaibleMovesOnBoard();
                }
            }
        }

        private void setAvaibleMovesOnBoard()
        {
            foreach (GamePoint point in m_CurrenPlayer.AvaiblePlayerMoves)
            {
                r_ButtonsArray[point.Row, point.Column].BackColor = Color.Green;
                r_ButtonsArray[point.Row, point.Column].Enabled = true;
            }
        }

        private void playComputerMove()
        {
            GamePoint chosenCellOnBoard;
            Random rnd = new Random();

            m_GameManager.SetComputerAvaibleCellsToList(m_CurrenPlayer);
            int RandComputerChoose = rnd.Next(m_CurrenPlayer.AvaiblePlayerMoves.Count);
            chosenCellOnBoard = m_CurrenPlayer.AvaiblePlayerMoves[RandComputerChoose];
            m_GameManager.SetAvaibleDirectionsToList(chosenCellOnBoard.Row, chosenCellOnBoard.Column, m_CurrenPlayer);
            m_GameManager.UpdateCellsOnBoard(chosenCellOnBoard.Row, chosenCellOnBoard.Column, m_CurrenPlayer);
            m_CurrenPlayer.AvaiblePlayerDirections.Clear();
            m_CurrenPlayer.AvaiblePlayerMoves.Clear();
            changeTurn();
            setForNextTurn();
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            BoardButton currentButton = sender as BoardButton;
            m_GameManager.SetAvaibleDirectionsToList(currentButton.X, currentButton.Y, m_CurrenPlayer);
            m_GameManager.UpdateCellsOnBoard(currentButton.X, currentButton.Y, m_CurrenPlayer);
            m_CurrenPlayer.AvaiblePlayerDirections.Clear();
            m_CurrenPlayer.AvaiblePlayerMoves.Clear();
            changeTurn();
            setForNextTurn();
        }

        private void setForNextTurn()
        {
            m_GameManager.CountPlayerAvaibleMoves(m_BlackPlayer);
            m_GameManager.CountPlayerAvaibleMoves(m_WhitePlayer);
            playNewTurn();
        }

        private void gameOver()
        {
            DialogResult result = DialogResult.No;
            string winMessage =
   @"{0} Won!! ({1}/{2}) ({3}/{4})
Would you like another round?";
            string drawMessage =
   @"it's a draw!! ({0}/{1}) ({2}/{3})
Would you like another round?";

            m_GameManager.GetWinningPlayer(m_BlackPlayer, m_WhitePlayer);

            if (m_BlackPlayer.SumOfTokensOnBoard > m_WhitePlayer.SumOfTokensOnBoard)
            {
                m_BlackPlayer.GamesWon++;
                string msg = string.Format(winMessage, m_BlackPlayer.Name, m_BlackPlayer.SumOfTokensOnBoard, m_WhitePlayer.SumOfTokensOnBoard, m_WhitePlayer.GamesWon, m_BlackPlayer.GamesWon);
                result = MessageBox.Show(msg, "Othello", MessageBoxButtons.YesNo);
            }
            else if (m_BlackPlayer.SumOfTokensOnBoard < m_WhitePlayer.SumOfTokensOnBoard)
            {
                m_WhitePlayer.GamesWon++;
                string msg = string.Format(winMessage, m_WhitePlayer.Name, m_BlackPlayer.SumOfTokensOnBoard, m_WhitePlayer.SumOfTokensOnBoard, m_WhitePlayer.GamesWon, m_BlackPlayer.GamesWon);
                result = MessageBox.Show(msg, "Othello", MessageBoxButtons.YesNo);
            }
            else if (m_BlackPlayer.SumOfTokensOnBoard == m_WhitePlayer.SumOfTokensOnBoard)
            {
                string msg = string.Format(drawMessage, m_BlackPlayer.SumOfTokensOnBoard, m_WhitePlayer.SumOfTokensOnBoard, m_WhitePlayer.GamesWon, m_BlackPlayer.GamesWon);
                result = MessageBox.Show(msg, "Othello", MessageBoxButtons.YesNo);
            }

            if (result == DialogResult.Yes)
            {
                runGame();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void changeTurn()
        {
            if (m_CurrenPlayer == m_BlackPlayer)
            {
                m_CurrenPlayer = m_WhitePlayer;
            }
            else
            {
                m_CurrenPlayer = m_BlackPlayer;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormGameBoard
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FormGameBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Othello";
            this.ResumeLayout(false);
        }
    }
}
