using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace CounterCliks
{
    public partial class Form1 : Form
    {
        public string per1 { get; private set; }
        public string LastMonth = "0";
        public Form1()
        {
            
            DateTime now = DateTime.Now;
           

            InitializeComponent();
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            


        // имя файла
        string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "1.txt"); ;
              FileStream fileStream = null;
            
            // проверяем существует ли файл файл 
            if (!File.Exists(filePath))
            {
                fileStream = File.Create(filePath); // создаем файл 
                                                    // текст запишем в файл 
                string text1 = ( now.ToString("D") + "\r\n") +
                     " 0 " + "\r\n" +
                     ("За неделю " + "\r\n") +
                     " 0 " + "\r\n" +
                     ("За текущий календарный месяц " + "\r\n") +
                     " 0 " + "\r\n" +
                     ("За предыдущий календарный месяц " + "\r\n") +
                     "0" + "\r\n" +
                     ("Всего " + "\r\n") +
                     " 0 " + "\r\n";
                // получаем поток 
                StreamWriter output = new StreamWriter(fileStream);

                // записываем текст в поток 
                output.Write(text1);

                // закрываем поток 
                output.Close();
            }
            

           
            
            string x, x2, y, y2, z,z1, z2, v, v2, v3,e;
            
            // var fileInfo = new FileInfo (@"D:\1.txt");
            // DateTime first = new DateTime();
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
           
            using (StreamReader sr = new StreamReader( "1.txt"))
            {
                z = sr.ReadLine();
                
                z1 = sr.ReadLine();
                z2 = sr.ReadLine();
                x = sr.ReadLine();
                x2 = sr.ReadLine();
                y = sr.ReadLine();
                y2 = sr.ReadLine();
                v = sr.ReadLine();
                v2 = sr.ReadLine();
                v3 = sr.ReadLine();
                e = sr.ReadLine();
                if (e == null)
                {
                    e = endDate.ToString("D");
                }
                
            }

            textBox1.Text = z1;
            textBox2.Text = x;
            textBox3.Text = y;
            textBox4.Text = v3;
            string LastMonth = v;
            
            //готово обнуление месяца
            if (  DateTime.Now > DateTime.Parse(e))
            {
                textBox1.Text = "0";

                LastMonth = textBox3.Text;

                textBox3.Text = "0";
                


            }
            // обнуление счетчика дня
            if ( z.ToString() != DateTime.Now.ToString("D"))
            {
                textBox1.Text = "0";
            }
            DateTime weeks1 = DateTime.Parse(z.ToString());
           
            


            // FileInfo file;
            if (DateTime.Parse(z.ToString()) <= DateTime.Now.AddDays(-7)/*| weeks1.DayOfWeek = DateTime.Now.DayOfWeek(Day.Monday)*/)
            {
                textBox2.Text = "0";
            }

            if ( weeks1.DayOfWeek == DayOfWeek.Monday & z.ToString() != DateTime.Now.ToString("D"))
            {
                textBox2.Text = "0";
            }


            
            //textBox5.Text = endDate.ToString("D");
            ////textBox5.Text = DateTime.Now.ToString("D");
            //textBox5.Text = z.ToString();
            //textBox5.Text = weeks1.AddDays(-7).ToString("D");

        }

        public void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            
            
        }


        public void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text != String.Empty)
            {
                textBox1.Text = (Int32.Parse(textBox1.Text) + 1).ToString();
                per1 = textBox1.Text;
            }
            textBox4.Text = (Int32.Parse(textBox4.Text) + 1).ToString();
            textBox2.Text = (Int32.Parse(textBox2.Text) + 1).ToString();
            textBox3.Text = (Int32.Parse(textBox3.Text) + 1).ToString();
            Save();
        }


        private void Save ()
        {
            DateTime now = DateTime.Now;
            string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "1.txt");
            FileStream fileStream;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);


            fileStream = File.Open(filePath, FileMode.OpenOrCreate); // открываем файл и в конец будут добавлены данные 


            string text = (now.ToString("D") + "\r\n") +
                     (textBox1.Text) + "\r\n" +
                     ("За неделю " + "\r\n") +
                     textBox2.Text + "\r\n" +
                     ("За текущий календарный месяц " + "\r\n") +
                     textBox3.Text + "\r\n" +
                     ("За предыдущий календарный месяц " + "\r\n") +
                     LastMonth + "\r\n" +
                     ("Всего " + "\r\n") +
                     textBox4.Text + "\r\n" +
                      endDate.ToString("D") + "\r\n";

            // получаем поток 
            StreamWriter output = new StreamWriter(fileStream);

            // записываем текст в поток 
            output.Write(text);

            // закрываем поток 
            output.Close();
        }

        
    }
}
