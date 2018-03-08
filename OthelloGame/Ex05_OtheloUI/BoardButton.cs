using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex05_OthelloUI
{
    public class BoardButton : Button
    {
        private int m_X;
        private int m_Y;

        public BoardButton(int i_X, int i_Y)
        {
            m_X = i_X;
            m_Y = i_Y;
        }

        public int X
        {
            get
            {
                return m_X;
            }
        }

        public int Y
        {
            get
            {
                return m_Y;
            }
        }
    }
}
