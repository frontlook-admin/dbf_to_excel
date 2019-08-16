using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbf
{
    public class helper
    {
        /*public void getDataTable(string dbf_filepath, DataTable dt)
        {
            FileInfo fileInfo = new FileInfo(dbf_filepath);
            string dbf_directory_filepath = fileInfo.DirectoryName;
            string x = Path.GetDirectoryName(dbf_filepath);
            OperatingSystem os = Environment.OSVersion;
            //Get version information about the os.
            Version vs = os.Version;

            //Variable to hold our return value
            string operatingSystem = "";
            string dbf_constring1 = "";
            string dbf_filename = "";

            if (os.Platform == PlatformID.Win32Windows)
            {
                //This is a pre-NT version of Windows
                switch (vs.Minor)
                {
                    case 0:
                        operatingSystem = "95";
                        break;
                    case 10:
                        if (vs.Revision.ToString() == "2222A")
                            operatingSystem = "98SE";
                        else
                            operatingSystem = "98";
                        break;
                    case 90:
                        operatingSystem = "Me";
                        break;
                    default:
                        break;
                }
            }
            else if (os.Platform == PlatformID.Win32NT)
            {
                switch (vs.Major)
                {
                    case 3:
                        operatingSystem = "NT 3.51";
                        break;
                    case 4:
                        operatingSystem = "NT 4.0";
                        break;
                    case 5:
                        if (vs.Minor == 0)
                            operatingSystem = "2000";
                        else
                            operatingSystem = "XP";
                        break;
                    case 6:
                        if (vs.Minor == 0)
                            operatingSystem = "Vista";
                        else if (vs.Minor == 1)
                            operatingSystem = "7";
                        else if (vs.Minor == 2)
                            operatingSystem = "8";
                        else
                            operatingSystem = "8.1";
                        break;
                    case 10:
                        operatingSystem = "10";
                        break;
                    default:
                        break;
                }
            }

            if (operatingSystem != "")
            {
                operatingSystem = "Windows " + operatingSystem;
            }

            switch (operatingSystem)
            {
                case "Windows XP":
                    dbf_constring1 = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + @dbf_directory_filepath + ";Extended Properties=dBase IV;User ID=;Password=";
                    break;
                case "Windows 7":
                    dbf_constring1 = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + @dbf_directory_filepath + ";Extended Properties=dBase IV;User ID=;Password=";
                    break;
                case "Windows Vista":
                    dbf_constring1 = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + @dbf_directory_filepath + ";Extended Properties=dBase IV;User ID=;Password=";
                    break;
                case "Windows 8":
                    dbf_constring1 = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + @dbf_directory_filepath + ";Extended Properties=dBase IV;User ID=;Password=";
                    break;
                case "Windows 8.1":
                    dbf_constring1 = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + @dbf_directory_filepath + ";Extended Properties=dBase IV;User ID=;Password=";
                    break;
                case "Windows 10":
                    dbf_constring1 = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + @dbf_directory_filepath + ";Extended Properties=dBase IV;User ID=;Password=";
                    break;
                default:
                    dbf_constring1 = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + @dbf_directory_filepath + ";Extended Properties=dBase IV;User ID=;Password=";
                    break;
            }
            string excelFilename = ""; string xml = ""; string xml_schema = ""; string s_without_ext = "";
            string s = "";

            
            s = dbf_filepath;
            excelFilename = "";
            s_without_ext = "";
            excelFilename = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + s + ".xlsx";
            s_without_ext = Path.GetFileNameWithoutExtension(s);

            try
            {

                OleDbConnection connection = new OleDbConnection(dbf_constring1);
                string sql = "SELECT * FROM " + s_without_ext;

                OleDbCommand cmd1 = new OleDbCommand(sql, connection);
                connection.Open();
                OleDbDataAdapter DA = new OleDbDataAdapter(cmd1);
                DA.Fill(dt);
                //DA.Update(dt);
                connection.Close();
                //BackgroundWorker bgw = new BackgroundWorker();

                
            }
            catch (OleDbException e)
            {
                MessageBox.Show("Error : " + e.Message);
            }
        }*/
    }
}
