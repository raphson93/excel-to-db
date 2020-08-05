using ExcelPresenter.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ExcelPresenter.ViewModel
{
    public class ExcelViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Excel> Excels { get; set; }
        private int _countExcels;
        public int CountExcels
        {
            get
            {
                return _countExcels;
            }
            set
            {
                _countExcels = value;
                OnPropertyChanged(nameof(CountExcels));
            }
        }

        public ExcelViewModel()
        {
            Excels = new ObservableCollection<Excel>();
            Excels.CollectionChanged += Excels_CollectionChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Excels_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            ++CountExcels;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
