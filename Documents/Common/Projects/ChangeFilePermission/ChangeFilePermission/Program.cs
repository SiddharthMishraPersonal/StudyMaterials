using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.AccessControl;
using System.IO;

namespace ChangeFilePermission
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        string fileName = "test.xml";
        fileName = args[0];

        //Console.WriteLine(string.Format("\nAdding access control entry for: \n'{0}'", args[0].Split('\\').LastOrDefault()));
        Console.WriteLine(string.Format("\nProcessing File: \"{0}\"", args[0].Split('\\').LastOrDefault()));

        foreach (string item in args.Where(s => !s.Equals(args[0])))
        {
          AddFileSecurity(fileName, item, FileSystemRights.FullControl, AccessControlType.Allow);
        }


        //// Add the access control entry to the file.
        //AddFileSecurity(fileName, @"svindcustom\IIS_WPG;svindcustom\aspnet",
        //    FileSystemRights.ReadData, AccessControlType.Allow);

        //Console.WriteLine("Removing access control entry from "
        //    + fileName);

        //// Remove the access control entry from the file.
        //RemoveFileSecurity(fileName, @"DomainName\AccountName",
        //    FileSystemRights.ReadData, AccessControlType.Allow);

        Console.WriteLine("Success!! Permission added successfully!");
      }
      catch (FileLoadException e)
      {
        Console.WriteLine(string.Format("\n*****Error: Not able to load file '{0}'", e.Message));
      }
      catch (DirectoryNotFoundException e)
      {
        Console.WriteLine(string.Format("\n*****Error: Directory is not found for '{0}'", e.Message));
      }
      catch (FileNotFoundException e)
      {
        Console.WriteLine(string.Format("\n*****Error: File not found. \nFile: {0}", e.Message));
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        Console.WriteLine(string.Format("\n*****Error: {0}", e.Message));
      }
      finally
      {
        Console.WriteLine();
      }
    }


    // Adds an ACL entry on the specified file for the specified account.
    public static void AddFileSecurity(string fileName, string account,
        FileSystemRights rights, AccessControlType controlType)
    {


      // Get a FileSecurity object that represents the
      // current security settings.
      FileSecurity fSecurity = File.GetAccessControl(fileName);

      // Add the FileSystemAccessRule to the security settings.
      fSecurity.AddAccessRule(new FileSystemAccessRule(account,
          rights, controlType));

      // Set the new access settings.
      File.SetAccessControl(fileName, fSecurity);

    }

    // Removes an ACL entry on the specified file for the specified account.
    public static void RemoveFileSecurity(string fileName, string account,
        FileSystemRights rights, AccessControlType controlType)
    {

      // Get a FileSecurity object that represents the
      // current security settings.
      FileSecurity fSecurity = File.GetAccessControl(fileName);

      // Remove the FileSystemAccessRule from the security settings.
      fSecurity.RemoveAccessRule(new FileSystemAccessRule(account,
          rights, controlType));

      // Set the new access settings.
      File.SetAccessControl(fileName, fSecurity);

    }
  }
}
