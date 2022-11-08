using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WasteToner
{
    public partial class wtrProperties : Form
    {
        public wtrProperties()
        {
            InitializeComponent();

            string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\WasteToner\config.txt";
            string[] lines = File.ReadAllLines(dir);


            txtFolderLocation.Text = lines[0];
            numCheck.Value = Int16.Parse(lines[1]);
            numHold.Value = Int16.Parse(lines[2]);
        }

        private void btnDB_Click(object sender, EventArgs e)
        {
           ActiveForm.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string[] lines =
            {
                txtFolderLocation.Text,
                numCheck.Value.ToString(),
                numHold.Value.ToString()
            };
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\WasteToner";
            // If directory does not exist, create it

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            File.WriteAllLines(dir + @"\config.txt", lines);
            ActiveForm.Close();
        }
    }
}
