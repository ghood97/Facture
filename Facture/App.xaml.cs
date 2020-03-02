using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Facture
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static string databaseName = "Facture.db";
        static string subFolderPath = "Facture";
        static string docFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string folderPath = System.IO.Path.Combine(docFolderPath, subFolderPath);
        public static string databasePath = System.IO.Path.Combine(folderPath, databaseName);
    }
}
