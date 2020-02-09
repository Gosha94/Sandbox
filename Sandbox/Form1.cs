using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddBindingSource
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // инициализируем коллекцию
            ListData = new BindingList<MyData>();
        }
        /// <summary>
        /// Коллекция значений для источника данных
        /// </summary>
        public BindingList<MyData> ListData { get; private set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            // текстовое поле
            TextBox tbEdit = new TextBox()
            {
                Dock = DockStyle.Bottom
            };
            // список
            ListBox lbList = new ListBox()
            {
                Dock = DockStyle.Fill,
                DisplayMember = "Value"
            };
            // Источник привязки данных
            BindingSource bs = new BindingSource(this, "ListData");
            for (int i = 0; i < 10; i++)
                ListData.Add(new MyData() { Value = "Значение " + i });
            // задаём источник привязки в качестве источника данных для списка
            lbList.DataSource = bs;
            // связываем свойство Text у текстового поля со свойством Value (класс MyData)
            // DataSourceUpdateMode.OnPropertyChanged - моментальная реакция на изменение значения в текстовом поле
            tbEdit.DataBindings.Add("Text", bs, "Value", false, DataSourceUpdateMode.OnPropertyChanged);

            // кладём контролы на форму
            Controls.AddRange(new Control[] { lbList, tbEdit });
        }
        public class MyData
        {
            public string Value { get; set; }
        }
    }
}
