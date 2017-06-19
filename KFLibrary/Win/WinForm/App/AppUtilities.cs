//<auto-generated />

#region "Author"
/****************************************************************************************
 * Solution     : CUSC His Framework
 * Project code : APP1105
 * Author       : Dương Nguyễn Phú Cường
 * Company      : Cusc Software
 * Version      : 1.0.0.1
 * Created date : 29/03/2013
 ***************************************************************************************/
#endregion

using System;
using System.Deployment.Application;
//using IWshRuntimeLibrary;

namespace KFLibrary.Win.WinForm.App
{
    public static class AppUtilities
    {
        public static Version GetCurrentVersion(bool executingAssembly = false)
        {
            Version currentVersion = null;
            // Lấy version hiện tại lúc build
            if (executingAssembly)
            {
                // Lấy version từ chứa code thực thi hàm GetCurrentVersion
                // Hiện tại là: Library.Core
                currentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            }
            else
            {
                // Lấy version từ assembly gọi hàm GetCurrentVersion
                currentVersion = System.Reflection.Assembly.GetCallingAssembly().GetName().Version;
            }

            // Kiểm tra version khi build bằng ClickOnce
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                currentVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion;
            }

            return currentVersion;
        }

        //public static string[] GetArguments()
        //{
        //    if (ApplicationDeployment.IsNetworkDeployed &&
        //        ApplicationDeployment.CurrentDeployment.ActivationUri != null)
        //    {
        //        string query = HttpUtility.UrlDecode(
        //            ApplicationDeployment.CurrentDeployment.ActivationUri.Query);
        //        if (!string.IsNullOrEmpty(query) && query.StartsWith("?"))
        //        {
        //            string[] arguments = query.Substring(1).Split(' ');
        //            string[] commandLineArgs = new string[arguments.Length + 1];
        //            commandLineArgs[0] = Environment.GetCommandLineArgs()[0];
        //            arguments.CopyTo(commandLineArgs, 1);
        //            return commandLineArgs;
        //        }
        //    }
        //    return Environment.GetCommandLineArgs();
        //}

        // Checks to see if shortcut exists. It is highly recommended to call this sub first.
        public static void CheckShortcut()
        {
            //// If the shortcut file doesn't exists, a message box will prompt the user if they want to continue creating the shortcut.
            //if (!System.IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.Desktop + "\\" + Application.ProductName + ".lnk"))
            //{
            //    if (MessageBox.Show("Continue with creating desktop shortcut for" + Strings.Chr(32) + Application.ProductName + "?", "Desktop Shortcut", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        // If they want to continue by clicking yes, the CreateShortcut sub will be called.
            //        CreateShortcut();

            //    }
            //    else
            //    {
            //        // If they click no, then nothing happens.
            //    }
            //}
            //else
            //{
            //    // If the shortcut file does exist, then we do nothing. (Why would we want a duplicate shortcut?)
            //    //MessageBox.Show("The shortcut for" + Strings.Chr(32) + Application.ProductName + Strings.Chr(32) + "already exists.", "Shortcut not created", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        // Creates a desktop shortcut.
        public static void CreateShortcut()
        {
            //object objShell = null;
            //object objLink = null;

            //try
            //{
            //    objShell = Interaction.CreateObject("WScript.Shell");

                
            //    // Automatically creates a shortcut on the desktop with the product name of the application.
            //    objLink = objShell.CreateShortcut(My.Computer.FileSystem.SpecialDirectories.Desktop + "\\" + Application.ProductName + ".lnk");

            //    // Sets the shortcut's link to the application's main executable file.
            //    objLink.TargetPath = Application.StartupPath + "\\" + Application.ProductName + ".exe";

            //    objLink.WindowStyle = 1;

            //    objLink.Save();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }


        //public static void CreateSC()
        //{
        //    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //    string des = "Diễn giải về chương trình";
        //    WshShell shell = new WshShell();
        //    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(
        //         desktopPath + "\\test.lnk");
        //    shortcut.TargetPath = Application.ExecutablePath;
        //    //shortcut.IconLocation = 'Location of  iCon you want to set";
        //    // add Description of Short cut
        //    shortcut.Description = des;
        //    shortcut.Arguments = @"-helloworld";

        //    // save it / create
        //    shortcut.Save();

        //}

        //public static void CreateSCUsingShell()
        //{
        //    string destPath = @"c:\temp";
        //    string shortcutName = @"नमस्ते.lnk";

        //    // Create empty .lnk file
        //    string path = System.IO.Path.Combine(destPath, shortcutName);
        //    System.IO.File.WriteAllBytes(path, new byte[0]);
        //    // Create a ShellLinkObject that references the .lnk file
        //    Shell32.Shell shl = new Shell32.ShellClass();
        //    Shell32.Folder dir = shl.NameSpace(destPath);
        //    Shell32.FolderItem itm = dir.Items().Item(shortcutName);
        //    Shell32.ShellLinkObject lnk = (Shell32.ShellLinkObject)itm.GetLink;
        //    // Set the .lnk file properties
        //    lnk.Path = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\notepad.exe";
        //    lnk.Description = "nobugz was here";
        //    lnk.Arguments = "sample.txt";
        //    lnk.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //    lnk.Save(path);
        //}


    
    }
}