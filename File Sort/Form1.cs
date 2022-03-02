/* 
 * File Sort
 * Start of development on february 23rd, 2022
 * Made by Kevstrosky
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Sort
{
    public partial class Form1 : Form
    {
        //I created these two FolderBrowserDialog, one for the source folder that we are gonna grab the files what we want and the other one for put all of them 
        FolderBrowserDialog sourceFolder = new FolderBrowserDialog();
        FolderBrowserDialog targetFolder = new FolderBrowserDialog();

        public Form1()
        {
            InitializeComponent();
        }

        private void selectSourceFolder(object sender, EventArgs e) //This method show us the folder browser dialog to select the source folder
        {
                if (sourceFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(sourceFolder.SelectedPath))
                {
                    label3.Text = sourceFolder.SelectedPath;
                }
            
         }

        private void selectTargetFolder(object sender, EventArgs e) //This method show us the folder browser dialog to select the target folder
        {
            
                if (targetFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(targetFolder.SelectedPath))
                {
                    label5.Text = targetFolder.SelectedPath;
                }
                
        }

        private void sortFileButton(object sender, EventArgs e) //This method sends the files selected by the data type in the combo box from the source folder to the target folder
        {
            String command = "move " + sourceFolder.SelectedPath+@"\"+"*"+"."+ comboBox1.Text +" "+ targetFolder.SelectedPath + @"\";
            ExecuteCommand(command);
            MessageBox.Show("All files have been transferred!");

        }
        static void ExecuteCommand(String command) //This method execute the command line that we send to it
        {
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = false; //This line of code does not allow the cmd window to open
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            string result = proc.StandardOutput.ReadToEnd();
            Console.WriteLine(result);

        }
    }
}
