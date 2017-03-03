using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUN_AT3
{
    public class Information
    {
        private string numberofkun;
        private string dateofkun;
        private string num1board;
        private string num2board;
        private string num3board;
        private string num4board;
        private string num5board;

        public string NumberOfKUN
        {
            get { return numberofkun; }
            set { numberofkun = value; }
        }
        public string DateOfKUN
        {
            get { return dateofkun; }
            set { dateofkun = value; }
        }
        public string NumBoardAircraft1
        {
            get { return num1board; }
            set { num1board = value; }
        }
        public string NumBoardAircraft2
        {
            get { return num2board; }
            set { num2board = value; }
        }
        public string NumBoardAircraft3
        {
            get { return num3board; }
            set { num3board = value; }
        }
        public string NumBoardAircraft4
        {
            get { return num4board; }
            set { num4board = value; }
        }
        public string NumBoardAircraft5
        {
            get { return num5board; }
            set { num5board = value; }
        }
    }
}
