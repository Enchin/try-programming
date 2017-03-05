using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;


namespace KUN_AT3
{
    public partial class MainWindow : Form
    {
        PrintDocument printDoc = new PrintDocument();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e) //выход - закрытие приложения
        {
             Close();
        }

        public void сохранитьToolStripMenuItem_Click(object sender, EventArgs e) //сохранение данных в XML формат
        {
            try
            {

                Information info = new Information();
                info.NumberOfKUN = NumberOfKUN.Text;
                info.DateOfKUN = DateOfKUN.Text;
                info.NumBoardAircraft1 = NumBoardAircraft1.Text;
                info.NumBoardAircraft2 = NumBoardAircraft2.Text;
                info.NumBoardAircraft3 = NumBoardAircraft3.Text;
                info.NumBoardAircraft4 = NumBoardAircraft4.Text;
                info.NumBoardAircraft5 = NumBoardAircraft5.Text;
                info.TapeAirboard = TapeAirboard.Text;
                info.EngineNum1 = EngineNum1.Text;
                info.EngineNum2 = EngineNum2.Text;
                info.EngineNum3 = EngineNum3.Text;
                info.EngineNum4 = EngineNum4.Text;
                info.BoardOwner = BoardOwner.Text;
                info.Airport = Airport.Text;
                info.ReportDetails = ReportDetails.Text;
                info.checkBox1 = checkBox1.Checked;
                info.checkBox2 = checkBox2.Checked;
                info.checkBox3 = checkBox3.Checked;
                info.checkBox4 = checkBox4.Checked;
                info.checkBox5 = checkBox5.Checked;
                info.checkBox6 = checkBox6.Checked;
                info.checkBox7 = checkBox7.Checked;
                info.checkBox8 = checkBox8.Checked;
                info.checkBox9 = checkBox9.Checked;
                info.checkBox10 = checkBox10.Checked;
                info.checkBox11 = checkBox11.Checked;
                info.checkBox12 = checkBox12.Checked;
                info.checkBox13 = checkBox13.Checked;
                info.checkBox14 = checkBox14.Checked;
                info.checkBox15 = checkBox15.Checked;
                info.checkBox16 = checkBox16.Checked;
                info.checkBox17 = checkBox17.Checked;
                info.checkBox18 = checkBox18.Checked;

                SaveXML.SaveData("data.xml", info);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e) //открытие сохранённых данных в формате XML и подстановка прочитанных значений
        {
            XmlSerializer xs = new XmlSerializer(typeof(Information));
            FileStream read = new FileStream("data.xml", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            Information info = (Information)xs.Deserialize(read);
            NumberOfKUN.Text = info.NumberOfKUN;
            DateOfKUN.Text = info.DateOfKUN;
            NumBoardAircraft1.Text = info.NumBoardAircraft1;
            NumBoardAircraft2.Text = info.NumBoardAircraft2;
            NumBoardAircraft3.Text = info.NumBoardAircraft3;
            NumBoardAircraft4.Text = info.NumBoardAircraft4;
            NumBoardAircraft5.Text = info.NumBoardAircraft5;
            TapeAirboard.Text = info.TapeAirboard;
            EngineNum1.Text = info.EngineNum1;
            EngineNum2.Text = info.EngineNum2;
            EngineNum3.Text = info.EngineNum3;
            EngineNum4.Text = info.EngineNum4;
            BoardOwner.Text = info.BoardOwner;
            Airport.Text = info.Airport;
            checkBox1.Checked = info.checkBox1;
            checkBox2.Checked = info.checkBox2;
            checkBox3.Checked = info.checkBox3;
            checkBox4.Checked = info.checkBox4;
            checkBox5.Checked = info.checkBox5;
            checkBox6.Checked = info.checkBox6;
            checkBox7.Checked = info.checkBox7;
            checkBox8.Checked = info.checkBox8;
            checkBox9.Checked = info.checkBox9;
            checkBox10.Checked = info.checkBox10;
            checkBox11.Checked = info.checkBox11;
            checkBox12.Checked = info.checkBox12;
            checkBox13.Checked = info.checkBox13;
            checkBox14.Checked = info.checkBox14;
            checkBox15.Checked = info.checkBox15;
            checkBox16.Checked = info.checkBox16;
            checkBox17.Checked = info.checkBox17;
            checkBox18.Checked = info.checkBox18;


            //checkBox1.CheckState = info.checkBox1;
            ReportDetails.Text = info.ReportDetails;

        }
        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Excel.Application ObjExcel = new Excel.Application();
            Excel.Workbook ObjWorkBook;
            Excel.Worksheet ObjWorkSheet;
            //Object templatePathObj = "КУН_АТ.xltx"; //может использовать шаблон?
            ObjWorkBook = ObjExcel.Workbooks.Add(System.Reflection.Missing.Value); //Книга
            ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1]; //Таблица

            ObjWorkSheet.PageSetup.LeftMargin = 0.64;
            ObjWorkSheet.PageSetup.TopMargin = 1.91;
            ObjWorkSheet.PageSetup.RightMargin = 0.64;
            ObjWorkSheet.PageSetup.BottomMargin = 1.91;
            //
            //Задаём ширину столбцов равную 5мм в 2 клетки
            //
            int col = 1;
            while (col < 80)
            {
                ObjWorkSheet.Columns[col].ColumnWidth = 0.75;
                col++;
            }
            //
            //Задаём высоту строк равную 5мм в 2 клетки
            //
            int row = 1;
            while (row < 101)
            {
                ObjWorkSheet.Columns[row].RowHeight = 7.5;
                row++;
            }
            //
            // Выделяем диапазоны ячеек
            //
            Excel.Range _excelCells1 = ObjWorkSheet.get_Range("BK2", "BP3").Cells; //NumberOfKUN.Text
            Excel.Range _excelCells2 = ObjWorkSheet.get_Range("C2", "BJ3").Cells; // Карточка учёта неисправности авиатехники
            Excel.Range _excelCells3 = ObjWorkSheet.get_Range("C5", "N6").Cells; // Дата
            Excel.Range _excelCells4 = ObjWorkSheet.get_Range("O5", "Z6").Cells; // Борт ВС
            Excel.Range _excelCells5 = ObjWorkSheet.get_Range("AA5", "AH6").Cells; // Тип ВС
            Excel.Range _excelCells6 = ObjWorkSheet.get_Range("AI5", "AP6").Cells; // № двиг.
            Excel.Range _excelCells7 = ObjWorkSheet.get_Range("AQ5", "BJ6").Cells; // Владелец
            Excel.Range _excelCells8 = ObjWorkSheet.get_Range("BK5", "BV6").Cells; // BoardOwner.Text
            Excel.Range _excelCells9 = ObjWorkSheet.get_Range("C7", "N8").Cells; // DateOfKUN.Text
            Excel.Range _excelCells10 = ObjWorkSheet.get_Range("O7", "Z8").Cells; // NumBoardAircraft1+2+3+4+5
            Excel.Range _excelCells11 = ObjWorkSheet.get_Range("AA7", "AH8").Cells; // TapeAirboard.Text
            Excel.Range _excelCells12 = ObjWorkSheet.get_Range("AI7", "AP8").Cells; // EngineNum1+2+3+4
            Excel.Range _excelCells13 = ObjWorkSheet.get_Range("AQ7", "BJ8").Cells; // Аэропорт посадки
            Excel.Range _excelCells14 = ObjWorkSheet.get_Range("BK7", "BV8").Cells; // Airport.Text
            Excel.Range _excelCells15 = ObjWorkSheet.get_Range("C12", "BV17").Cells; // Текст
            Excel.Range _excelCells16 = ObjWorkSheet.get_Range("C10", "Y11").Cells; // Проявление неисправности
            //Excel.Range _excelCells17 = ObjWorkSheet.get_Range("BK5", "BP6").Cells;
            //Excel.Range _excelCells18 = ObjWorkSheet.get_Range("BK5", "BP6").Cells;
            //Excel.Range _excelCells19 = ObjWorkSheet.get_Range("BK5", "BP6").Cells;
            Excel.Range _excelCells20 = ObjWorkSheet.get_Range("C18", "AV19").Cells; // Этап обслуживания
            Excel.Range _excelCells21 = ObjWorkSheet.get_Range("C20", "Y21").Cells; // На земле
            Excel.Range _excelCells22 = ObjWorkSheet.get_Range("Z20", "AV21").Cells; // В полёте
            Excel.Range _excelCells23 = ObjWorkSheet.get_Range("AW20", "BV21").Cells; // Последствия
            Excel.Range _excelCells24 = ObjWorkSheet.get_Range("C22", "D23").Cells; // 11
            Excel.Range _excelCells25 = ObjWorkSheet.get_Range("C24", "D25").Cells; // 12
            Excel.Range _excelCells26 = ObjWorkSheet.get_Range("C26", "D27").Cells; // 13
            Excel.Range _excelCells27 = ObjWorkSheet.get_Range("C28", "D29").Cells; // 14
            Excel.Range _excelCells28 = ObjWorkSheet.get_Range("C30", "D31").Cells; // 15
            Excel.Range _excelCells29 = ObjWorkSheet.get_Range("C32", "D33").Cells; // 16
            Excel.Range _excelCells30 = ObjWorkSheet.get_Range("C34", "D35").Cells; // 17
            Excel.Range _excelCells31 = ObjWorkSheet.get_Range("C36", "D37").Cells; // 18
            Excel.Range _excelCells32 = ObjWorkSheet.get_Range("E22", "Y23").Cells; // 11. Подготовка к вылету
            Excel.Range _excelCells33 = ObjWorkSheet.get_Range("E24", "Y25").Cells; // 12. Буксировка
            Excel.Range _excelCells34 = ObjWorkSheet.get_Range("E26", "Y27").Cells; // 13. Запуск двигателей
            Excel.Range _excelCells35 = ObjWorkSheet.get_Range("E28", "Y29").Cells; // 14. Руление
            Excel.Range _excelCells36 = ObjWorkSheet.get_Range("E30", "Y31").Cells; // 15. Оперативное ТО
            Excel.Range _excelCells37 = ObjWorkSheet.get_Range("E32", "Y33").Cells; // 16. Периодическое ТО
            Excel.Range _excelCells38 = ObjWorkSheet.get_Range("E34", "Y35").Cells; // 17. Прочее ТО
            Excel.Range _excelCells39 = ObjWorkSheet.get_Range("E36", "Y37").Cells; // 18. Диагностирование
            //
            // Производим объединение
            //
            _excelCells1.Merge(Type.Missing); 
            _excelCells2.Merge(Type.Missing);
            _excelCells3.Merge(Type.Missing);
            _excelCells4.Merge(Type.Missing);
            _excelCells5.Merge(Type.Missing);
            _excelCells6.Merge(Type.Missing);
            _excelCells7.Merge(Type.Missing);
            _excelCells8.Merge(Type.Missing);
            _excelCells9.Merge(Type.Missing);
            _excelCells10.Merge(Type.Missing);
            _excelCells11.Merge(Type.Missing);
            _excelCells12.Merge(Type.Missing);
            _excelCells13.Merge(Type.Missing);
            _excelCells14.Merge(Type.Missing);
            _excelCells15.Merge(Type.Missing);
            _excelCells16.Merge(Type.Missing);
            //_excelCells17.Merge(Type.Missing);
            //_excelCells18.Merge(Type.Missing);
            //_excelCells19.Merge(Type.Missing);
            _excelCells20.Merge(Type.Missing);
            _excelCells21.Merge(Type.Missing);
            _excelCells22.Merge(Type.Missing);
            _excelCells23.Merge(Type.Missing);
            _excelCells24.Merge(Type.Missing);
            _excelCells25.Merge(Type.Missing);
            _excelCells26.Merge(Type.Missing);
            _excelCells27.Merge(Type.Missing);
            _excelCells28.Merge(Type.Missing);
            _excelCells29.Merge(Type.Missing);
            _excelCells30.Merge(Type.Missing);
            _excelCells31.Merge(Type.Missing);
            _excelCells32.Merge(Type.Missing);
            _excelCells33.Merge(Type.Missing);
            _excelCells34.Merge(Type.Missing);
            _excelCells35.Merge(Type.Missing);
            _excelCells36.Merge(Type.Missing);
            _excelCells37.Merge(Type.Missing);
            _excelCells38.Merge(Type.Missing);
            _excelCells39.Merge(Type.Missing);
            //
            //форматируем оформление
            //
            _excelCells1.HorizontalAlignment = Excel.Constants.xlLeft;
            _excelCells2.HorizontalAlignment = Excel.Constants.xlRight;
            _excelCells3.HorizontalAlignment = Excel.Constants.xlCenter;
            _excelCells4.HorizontalAlignment = Excel.Constants.xlCenter;
            _excelCells5.HorizontalAlignment = Excel.Constants.xlCenter;
            _excelCells6.HorizontalAlignment = Excel.Constants.xlCenter;
            _excelCells7.HorizontalAlignment = Excel.Constants.xlCenter;
            _excelCells8.HorizontalAlignment = Excel.Constants.xlRight;
            _excelCells9.HorizontalAlignment = Excel.Constants.xlCenter;
            _excelCells10.HorizontalAlignment = Excel.Constants.xlCenter;
            _excelCells11.HorizontalAlignment = Excel.Constants.xlCenter;
            _excelCells12.HorizontalAlignment = Excel.Constants.xlCenter;
            _excelCells13.HorizontalAlignment = Excel.Constants.xlCenter;
            _excelCells14.HorizontalAlignment = Excel.Constants.xlRight;
            _excelCells15.HorizontalAlignment = Excel.Constants.xlLeft;
            _excelCells16.HorizontalAlignment = Excel.Constants.xlLeft;
            //_excelCells17.HorizontalAlignment = Excel.Constants.xlCenter;
            //_excelCells18.HorizontalAlignment = Excel.Constants.xlCenter;
            //_excelCells19.HorizontalAlignment = Excel.Constants.xlCenter;
            _excelCells20.HorizontalAlignment = Excel.Constants.xlLeft;
            _excelCells21.HorizontalAlignment = Excel.Constants.xlLeft;
            _excelCells22.HorizontalAlignment = Excel.Constants.xlLeft;
            _excelCells23.HorizontalAlignment = Excel.Constants.xlLeft;
            _excelCells24.HorizontalAlignment = Excel.Constants.xlCenter;
            _excelCells25.HorizontalAlignment = Excel.Constants.xlCenter;
            _excelCells26.HorizontalAlignment = Excel.Constants.xlCenter;
            _excelCells27.HorizontalAlignment = Excel.Constants.xlCenter;
            _excelCells28.HorizontalAlignment = Excel.Constants.xlCenter;
            _excelCells29.HorizontalAlignment = Excel.Constants.xlCenter;
            _excelCells30.HorizontalAlignment = Excel.Constants.xlCenter;
            _excelCells31.HorizontalAlignment = Excel.Constants.xlCenter;
            _excelCells32.HorizontalAlignment = Excel.Constants.xlLeft;
            _excelCells33.HorizontalAlignment = Excel.Constants.xlLeft;
            _excelCells34.HorizontalAlignment = Excel.Constants.xlLeft;
            _excelCells35.HorizontalAlignment = Excel.Constants.xlLeft;
            _excelCells36.HorizontalAlignment = Excel.Constants.xlLeft;
            _excelCells37.HorizontalAlignment = Excel.Constants.xlLeft;
            _excelCells38.HorizontalAlignment = Excel.Constants.xlLeft;
            _excelCells39.HorizontalAlignment = Excel.Constants.xlLeft;
            //
            //Заполняем ячейки данными
            //
            ObjWorkSheet.Cells[2, 3] = "Карточка учёта неисправности авиатехники №";
            ObjWorkSheet.Cells[2, 63] = NumberOfKUN.Text;
            ObjWorkSheet.Cells[5, 3] = "Дата";
            ObjWorkSheet.Cells[5, 15] = "Борт ВС";
            ObjWorkSheet.Cells[5, 27] = "Тип ВС";
            ObjWorkSheet.Cells[5, 35] = "№ двиг.";
            ObjWorkSheet.Cells[5, 43] = "Предприятие - владелец ВС";
            ObjWorkSheet.Cells[5, 63] = BoardOwner.Text;
            ObjWorkSheet.Cells[7, 3] = DateOfKUN.Text;
            ObjWorkSheet.Cells[7, 15] = NumBoardAircraft1.Text + NumBoardAircraft2.Text + NumBoardAircraft3.Text + NumBoardAircraft4.Text + NumBoardAircraft5.Text;
            ObjWorkSheet.Cells[7, 27] = TapeAirboard.Text;
            ObjWorkSheet.Cells[7, 35] = EngineNum1.Text + EngineNum2.Text + EngineNum3.Text + EngineNum4.Text;
            ObjWorkSheet.Cells[7, 43] = "Аэропорт посадки";
            ObjWorkSheet.Cells[7, 63] = Airport.Text;
            ObjWorkSheet.Cells[10, 3] = "Проявление неисправности ВС";
            ObjWorkSheet.Cells[12, 3] = ReportDetails.Text;
            ObjWorkSheet.Cells[18, 3] = "Этап обслуживания";
            ObjWorkSheet.Cells[20, 3] = "На земле";
            ObjWorkSheet.Cells[20, 26] = "В полёте";
            ObjWorkSheet.Cells[20, 49] = "Последствия";
            ObjWorkSheet.Cells[22, 5] = "11. Подготовка к вылету";
            ObjWorkSheet.Cells[24, 5] = "12. Буксировка";
            ObjWorkSheet.Cells[26, 5] = "13. Запуск двигателей";
            ObjWorkSheet.Cells[28, 5] = "14. Руление";
            ObjWorkSheet.Cells[30, 5] = "15. Оперативное ТО";
            ObjWorkSheet.Cells[32, 5] = "16. Периодическое ТО";
            ObjWorkSheet.Cells[34, 5] = "17. Прочее ТО";
            ObjWorkSheet.Cells[36, 5] = "18. Диагностирование";


            //
            //Защищаем структуру книги 
            // 
            string s = "$u5erPa$$word";
            ObjWorkBook.Protect(s, true, false);
            //
            //защищаем данные от редактирования
            //
            foreach (Excel.Worksheet sheet in ObjWorkBook.Worksheets)
            {
                sheet.Protect(s, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true);
            }
            //
            //Показываем окно экселя и передаём управление пользователю
            // 
            ObjExcel.Visible = true;
            ObjExcel.UserControl = true;
        }
        private void NumberOfKUN_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // Разрешено нажатие только цифр и клавиши BackSpace
            {
                e.Handled = true;
            }
        }
        private void NumBoardAircraft1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // Разрешено нажатие только цифр и клавиши BackSpace
            {
                e.Handled = true;
            }
        }
        private void EngineNum1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // Разрешено нажатие только цифр и клавиши BackSpace
            {
                e.Handled = true;
            }
        }
        private void EngineNum2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // Разрешено нажатие только цифр и клавиши BackSpace
            {
                e.Handled = true;
            }
        }
        private void EngineNum3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // Разрешено нажатие только цифр и клавиши BackSpace
            {
                e.Handled = true;
            }
        }
        private void EngineNum4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // Разрешено нажатие только цифр и клавиши BackSpace
            {
                e.Handled = true;
            }
        }
        private void NumBoardAircraft1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                NumBoardAircraft1.Focus();
            }
            else
            {
                NumBoardAircraft2.Focus();
            }
        }
        private void NumBoardAircraft2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                NumBoardAircraft1.Focus();
            }
            else
            {
                NumBoardAircraft3.Focus();
            }
        }
        private void NumBoardAircraft3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                NumBoardAircraft2.Focus();
            }
            else
            {
                NumBoardAircraft4.Focus();
            }
        }
        private void NumBoardAircraft4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                NumBoardAircraft3.Focus();
            }
            else
            {
                NumBoardAircraft5.Focus();
            }
        }

        private void NumBoardAircraft5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                NumBoardAircraft4.Focus();
            }
        }
        private void PrinterSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog dlg = new PrintDialog();
            dlg.Document = printDoc;
        }
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox a = new AboutBox();
            a.Show();
        }
        private void EngineNum1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back) //фокус курсора при нажатии backcpace на предыдущее поле
            {
                EngineNum1.Focus();
            }
            else
            {
                EngineNum2.Focus();
            }
        }
        private void EngineNum2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back) //фокус курсора при нажатии backcpace на предыдущее поле
            {
                EngineNum1.Focus();
            }
            else
            {
                EngineNum3.Focus();
            }
        }
        private void EngineNum3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back) //фокус курсора при нажатии backcpace на предыдущее поле
            {
                EngineNum2.Focus();
            }
            else
            {
                EngineNum4.Focus();
            }
        }
        private void EngineNum4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back) //фокус курсора при нажатии backcpace на предыдущее поле
            {
                EngineNum3.Focus();
            }
        }

        //private void toolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    Excel.Application ObjExcel = new Excel.Application();
        //    Excel.Workbook ObjWorkBook;
        //    Excel.Worksheet ObjWorkSheet;
        //    Object templatePathObj = "КУН_АТ.xltx";
        //    //Книга.
        //    ObjWorkBook = ObjExcel.Workbooks.Add(System.Reflection.Missing.Value);
        //    //Таблица.
        //    ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];
        //    //Значения [y - строка,x - столбец]
        //    ObjWorkSheet.Cells[3, 1] = NumberOfKUN.Text;
        //    ObjWorkSheet.Cells[3, 2] = DateOfKUN.Text;
        //    ObjWorkSheet.Cells[3, 3] = NumBoardAircraft1.Text;
        //    //Вызываем нашу созданную эксельку.
        //    ObjExcel.Visible = true;
        //    ObjExcel.UserControl = true;
        //}
        //пример для копирования
        //private void второйЭксельToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Excel.Application oXL;
        //    Excel._Workbook oWB;
        //    Excel._Worksheet oSheet;
        //    Excel.Range oRng;
        //
        //    try
        //    {
        //        //Start Excel and get Application object.
        //        oXL = new Excel.Application();
        //       oXL.Visible = true;
        //
        //        //Get a new workbook.
        //        oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
        //        oSheet = (Excel._Worksheet)oWB.ActiveSheet;
        //        Object templatePathObj = "КУН_АТ.xltx";
        //        //Add table headers going cell by cell.
        //        oSheet.Cells[1, 1] = "Имя";
        //        oSheet.Cells[1, 2] = "Фамилия";
        //       oSheet.Cells[1, 3] = "Полное имя";
        //        oSheet.Cells[1, 4] = "Сумма";
        //        //Format A1:D1 as bold, vertical alignment = center.
        //        oSheet.get_Range("A1", "D1").Font.Bold = true;
        //        oSheet.get_Range("A1", "D1").VerticalAlignment =
        //        Excel.XlVAlign.xlVAlignCenter;
        //        // Create an array to multiple values at once.
        //        string[,] saNames = new string[5, 2];
        //       saNames[0, 0] = "Джон";
        //        saNames[0, 1] = "Смитт";
        //        saNames[1, 0] = "Том";
        //        saNames[1, 1] = "Браун";
        //        saNames[2, 0] = "Сью";
        //        saNames[2, 1] = "Томас";
        //        saNames[3, 0] = "Джэйн";
        //        saNames[3, 1] = "Джонс";
        //        saNames[4, 0] = "Адам";
        //        saNames[4, 1] = "Джонсон";
        //        //Fill A2:B6 with an array of values (First and Last Names).
        //        oSheet.get_Range("A2", "B6").Value2 = saNames;
        //        //Fill C2:C6 with a relative formula (=A2 & " " & B2).
        //        oRng = oSheet.get_Range("C2", "C6");
        //        oRng.Formula = "=A2 & \" \" & B2";
        //        //Fill D2:D6 with a formula(=RAND()*100000) and apply format.
        //        oRng = oSheet.get_Range("D2", "D6");
        //        oRng.Formula = "=RAND()*100000";
        //        oRng.NumberFormat = "$0.00";
        //        //AutoFit columns A:D.
        //        oRng = oSheet.get_Range("A1", "D1");
        //        oRng.EntireColumn.AutoFit();
        //        //Make sure Excel is visible and give the user control
        //        //of Microsoft Excel's lifetime.
        //        oXL.Visible = true;
        //        oXL.UserControl = true;
        //    }
        //    catch (Exception theException)
        //    {
        //        String errorMessage;
        //        errorMessage = "Error: ";
        //        errorMessage = String.Concat(errorMessage, theException.Message);
        //        errorMessage = String.Concat(errorMessage, " Line: ");
        //        errorMessage = String.Concat(errorMessage, theException.Source);
        //
        //        MessageBox.Show(errorMessage, "Error");
        //    }
        //}
    }
}
