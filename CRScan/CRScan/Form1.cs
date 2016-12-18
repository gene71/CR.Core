using CodeRecon.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRScan
{
    public partial class Form1 : Form
    {
        string projectDir = Environment.CurrentDirectory + "\\CRScanProjects";
        
        CRScanProject crScanproj;
        public Form1()
        {
            InitializeComponent();
            InitCRScanProject();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
              
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog1.SelectedPath;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (crScanproj == null)
            {
                crScanproj = new CRScanProject();
            }

            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter a directory to scan", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("Enter a directory for report", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("Enter a name for the scan", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //do the scan
            Cursor.Current = Cursors.WaitCursor;
            crScanproj.ProjectName = textBox3.Text;//make the object if null
            crScanproj.ScanDirectory = textBox1.Text;
            crScanproj.ReportDirectory = textBox2.Text;
            crScanproj.Save(projectDir + "\\" + crScanproj.ProjectName + ".xml" );
            CRScaner crs = new CRScaner();
            crs.Scan(crScanproj);
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Scan Complete", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start("explorer.exe", textBox2.Text);
            Application.Exit();

        }

        private void InitCRScanProject()
        {
            //create the project directory if it doesnt exist
            if (!Directory.Exists(projectDir)) { Directory.CreateDirectory(projectDir); }

            FileLister fl = new FileLister();
            var files = fl.GetFiles(projectDir);
            if (files.Count == 0)
            {
                crScanproj = new CRScanProject();
                crScanproj.CreateDate = DateTime.Now;
            }
            else
            {
                //add files to drop down
                foreach (var f in files)
                {
                    recentProjectToolStripMenuItem.DropDownItems.Add(f, null, 
                        new EventHandler(recentMenuItem_Click));
                    
                }
            }

        }

        private void recentMenuItem_Click(object sender, EventArgs e)
        {
            
            crScanproj = CRScanProject.Load(sender.ToString());
            //set TextBoxes
            textBox2.Text = crScanproj.ReportDirectory;
            textBox1.Text = crScanproj.ScanDirectory;
            textBox3.Text = crScanproj.ProjectName;
           

        }

        
    }
}
