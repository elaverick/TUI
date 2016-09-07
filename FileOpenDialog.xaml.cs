using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TUI
{
    /// <summary>
    /// Interaction logic for FileOpenDialog.xaml
    /// </summary>
    public partial class FileOpenDialog : Window
    {
        //private Dictionary<string, string> directories = new Dictionary<string, string>();
        private ObservableDictionary<string, string> directories = new ObservableDictionary<string, string>();
             
        public string FileName
        {
            get { return (string)GetValue(FileNameProperty); }
            set { SetValue(FileNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FileName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FileNameProperty =
            DependencyProperty.Register("FileName", typeof(string), typeof(FileOpenDialog), new PropertyMetadata(String.Empty));

        public string InitialDirectory
        {
            get { return (string)GetValue(InitialDirectoryProperty); }
            set { SetValue(InitialDirectoryProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InitialDirectory.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InitialDirectoryProperty =
            DependencyProperty.Register("InitialDirectory", typeof(string), typeof(FileOpenDialog), new PropertyMetadata(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)));

        private string CurrentDirectory;
        
        public FileOpenDialog()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CurrentDirectory = (string)GetValue(InitialDirectoryProperty);
            lstDirectory.DataContext = directories;
            populateDirectoryList();
        }

        private void populateDirectoryList()
        {
            directories.Clear();
            string currPath = System.IO.Path.GetDirectoryName(CurrentDirectory);
            if (CurrentDirectory != System.IO.Path.GetPathRoot(CurrentDirectory))
            {
                directories.Add(".",System.IO.Path.GetPathRoot(CurrentDirectory));
                directories.Add("..", System.IO.Directory.GetParent(CurrentDirectory).FullName);
                Console.Write("TST");
            }
            try
            {
                DirectoryInfo[] directoriesInfo = new DirectoryInfo(CurrentDirectory).GetDirectories();

                foreach (DirectoryInfo directory in directoriesInfo)
                {
                    directories.Add(directory.Name, directory.FullName);
                }
            }
            catch(UnauthorizedAccessException)
            {
                MessageBox.Show("Access denied","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                directories.Add("[ - " + drive.Name.Remove(1, 2) + " - ]",drive.Name);
            }
            populateFileList();
        }

        private void populateFileList()
        {
            lstFiles.Items.Clear();

            try
            {
                FileInfo[] files = new DirectoryInfo(CurrentDirectory).GetFiles();

                foreach (FileInfo file in files)
                {
                    if (!file.Attributes.HasFlag(FileAttributes.System) && !file.Attributes.HasFlag(FileAttributes.Hidden))
                        lstFiles.Items.Add(file.Name);
                }
            }
            catch (UnauthorizedAccessException)
            { }
        }

        private void directoryClick(object sender, MouseButtonEventArgs e)
        {
             CurrentDirectory = ((KeyValuePair<string,string>)((ListBoxItem)sender).DataContext).Value;
            populateDirectoryList();
        }

        private void fileSelected(object sender, SelectionChangedEventArgs e)
        {
            txtFilename.Text = (string)e.AddedItems[0];
        }

    }
}
