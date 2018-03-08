using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05_OthelloLogic
{
    public struct GamePoint
    {
        private int m_Row;
        private int m_Column;

        public int Row
        {
            get { return m_Row; }
            set { m_Row = value; }
        }

        public int Column
        {
            get { return m_Column; }
            set { m_Column = value; }
        }
    }
}
