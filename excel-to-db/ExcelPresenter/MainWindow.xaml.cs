using ExcelPresenter.Model;
using ExcelPresenter.ViewModel;
using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using System.Linq;
using System.Windows;

namespace ExcelPresenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ExcelViewModel ViewModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new ExcelViewModel();
            this.DataContext = ViewModel;
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                RestoreDirectory = true,
                Multiselect = true,
                Filter = "Excel Files (CSV,XLSX,GIF)|*.csv;*.xlsx"
            };

            //var excelWorker = new ExcelWorker();

            var result = openFileDialog.ShowDialog();
            if (result != true) return;

            foreach (var safeFileName in openFileDialog.SafeFileNames)
            {
                //excelWorker.ReadExcel(openFileDialog.FileName);
                if (ViewModel.Excels.Any(excel => excel.FileName == safeFileName)) continue;

                ViewModel.Excels.Add(new Excel { FileName = safeFileName });
            }
        }
    }
}
