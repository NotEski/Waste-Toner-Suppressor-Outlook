using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Windows.Forms;
using System.Globalization;


namespace WasteToner
{
    [ComVisible(true)]
    public class Ribbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;

        public Ribbon()
        {
        }

        public void wtrStart(Office.IRibbonControl control)
        {

            // compile list of past serial numbers

            //MessageBox.Show("Gimme a sec to do that one for ya\n(✌ﾟ∀ﾟ)☞");
            // will need to have it swapped with pulling the folder from settings

            string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\WasteToner\config.txt";
            string[] lines = File.ReadAllLines(dir);


            string folderDir = lines[0];
            int numCheck = Int16.Parse(lines[1]);
            int numHold = Int16.Parse(lines[2]);


            Outlook.Folder WholeFolder = GetFolder(folderDir);

            Outlook.Items workingItems = WholeFolder.Items;
            workingItems.Sort("[CreationTime]", true);

            List<string> SNList = new List<string>();
            List<string> FullSNList = new List<string>();
            List<string> ExportList = new List<string>();
            string seperator = "======================================================";
            string Output = "";


            string suppressionDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\WasteToner\suppression";
            string[] suppressionDirList = Directory.GetFiles(suppressionDir);

            foreach (string suppressionFile in suppressionDirList)
            {
                string[] sus = File.ReadAllLines(suppressionFile);
                foreach (string item in sus)
                {
                    FullSNList.Add(item);
                }
            }


            foreach (object item in workingItems)
            {


                Outlook.MailItem mail = item as Outlook.MailItem;
                if (mail != null)
                {
                    if (mail.CreationTime > DateTime.Today.AddDays(-(numCheck)))
                    {
                        string[] mailLines = mail.Body.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);  // had to many items opened, will need to start closing items at the end of each loop
                        Marshal.ReleaseComObject(mail);

                        string SerialNumber = (mailLines[1].Split(new string[] { ": " }, StringSplitOptions.None))[1];
                        if (!SNList.Contains(SerialNumber))
                        {
                            SNList.Add(SerialNumber);
                        }

                        if (!FullSNList.Contains(SerialNumber))
                        {
                            ExportList.Add(seperator);
                            ExportList.Add(mailLines[1] + "\n" + mailLines[3] + "\n" + mailLines[4] + " " + mailLines[5] + "\n" + mailLines[6]);
                        }

                        // add serial number to suppression list
                        // if serial number in suppression list skip to next item
                        // else add (lines[1] + "\n" + lines[2] + "\n" + lines[3] + "\n" + lines[4] + "\n" + lines[5] + "\n" + lines[6]) to string for output

                        
                        continue;
                    }
                    Output = string.Join("\n", ExportList);
                    break;
                }
            }

            string dateStamp = DateTime.Now.ToString("yyyyMMdd");
            // If directory does not exist, create it

            if (!Directory.Exists(suppressionDir))
            {
                Directory.CreateDirectory(suppressionDir);
            }
            File.WriteAllLines(suppressionDir + dateStamp + ".txt", SNList);

            CultureInfo provider = CultureInfo.InvariantCulture;

            foreach (string suppressionFile in suppressionDirList)
            {
                string fileName = Path.GetFileNameWithoutExtension(suppressionFile);
                DateTime fileDate = DateTime.ParseExact(fileName, "yyyyMMdd", provider);
                if (fileDate < (DateTime.Today.AddDays(-numHold)))
                    {
                        File.Delete(suppressionFile);
                    }
            }

            saveOutput(Output);
        }

        public class SN
        {
            public string[] SerialNumbers { get; set; }
            public DateTime date { get; set; }
        }

        public void wtrSettings(Office.IRibbonControl control)
        {
            Form frmSettings = new wtrProperties();
            frmSettings.Show();
        }

        private Outlook.Folder GetFolder(string folderPath)
        {
            Outlook.Folder folder;
            string backslash = @"\";
            try
            {
                if (folderPath.StartsWith(@"\\"))
                {
                    folderPath = folderPath.Remove(0, 2);
                }
                String[] folders = folderPath.Split(backslash.ToCharArray());
                folder = Globals.ThisAddIn.Application.Session.Folders[folders[0]] as Outlook.Folder;
                if (folder != null)
                {
                    for (int i = 1; i <= folders.GetUpperBound(0); i++)
                    {
                        Outlook.Folders subFolders = folder.Folders;
                        folder = subFolders[folders[i]]
                            as Outlook.Folder;
                        if (folder == null)
                        {
                            return null;
                        }
                    }
                }
                return folder;
            }
            catch { return null; }
        }

        private void saveOutput(String text)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    byte[] byteArray = Encoding.ASCII.GetBytes(text);
                    myStream.Write(byteArray, 0, text.Length);
                    myStream.Close();
                }
            } 
        }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("WasteToner.Ribbon.xml");
        }

        #endregion

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, visit https://go.microsoft.com/fwlink/?LinkID=271226

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        #endregion

        #region Helpers

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
