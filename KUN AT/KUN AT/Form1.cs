using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace KUN_AT
{
    public partial class MainWindow : Form
    {
        public class PropsFields
        {
            public String XMLFileName = Environment.CurrentDirectory + "\\settings.xml";
            //Чтобы добавить настройку в программу просто добавьте туда строку вида -
            //public ТИП ИМЯ_ПЕРЕМЕННОЙ = значение_переменной_по_умолчанию;
            public String TextValue = @"File Settings";
            public DateTime DateValue = new DateTime(2011, 1, 1);
            public Decimal DecimalValue = 555;
            public Boolean BoolValue = true;
        }
        //Класс работы с настройками
        public class Props
        {
            public PropsFields Fields;

            public Props()
            {
                Fields = new PropsFields();
            }
            //Запись настроек в файл
            public void WriteXml()
            {
                XmlSerializer ser = new XmlSerializer(typeof(PropsFields));

                TextWriter writer = new StreamWriter(Fields.XMLFileName);
                ser.Serialize(writer, Fields);
                writer.Close();
            }
            //Чтение насроек из файла
            public void ReadXml()
            {
                if (File.Exists(Fields.XMLFileName))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(PropsFields));
                    TextReader reader = new StreamReader(Fields.XMLFileName);
                    Fields = ser.Deserialize(reader) as PropsFields;
                    reader.Close();
                }
                else
                {
                    //можно написать вывод сообщения если файла не существует
                }
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "%UserProfile%/Documents";
            openFileDialog1.Filter = "XML (*.xml)|*.xml";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            MessageBox.Show("Фаил прочитан.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: Невозможно прочитать фаил. Original error: " + ex.Message);
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Props.WriteXml();

        }

        private void NumberOfKUT_TextChanged(object sender, EventArgs e)
        {
            PreparationForDeparture.Text = "This is a TextBox control.";
        }

        private void PreparationForDeparture_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
