using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testWVoceOutBound;

namespace TextManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Dictionary<string, string>> _list = new List<Dictionary<string, string>>();



            _list.Add(new Dictionary<string, string>() {
                { "host", "http://wvoce-sviluppo.optimaitalia.com:8090/" },
                { "login", "testoper" }, { "password", "test" } ,
                { "_Chiamata", "Libero" }
            });

            _list.Add(new Dictionary<string, string>() {
                { "host", "http://wvoce-sviluppo.optimaitalia.com:8090/" },
                { "login", "testoper" }, { "password", "test" } ,
                { "_Chiamata", "test2" }
            });


            for (int i = 0; i < _list.Count; i++)
            {
                testWVoceOutBound.testOutBound oT = new testWVoceOutBound.testOutBound();
                oT.LoadProperties(_list[i]);
                oT.Execute();
                oT.TearDownTest();// stop opening as much chrome drivers;
            }
            
        }
    }
}
