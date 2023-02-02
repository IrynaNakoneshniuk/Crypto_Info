
using LiveCharts;
using System.Windows.Input;
using Crypto_Info.Command;


namespace Crypto_Info
{
    public class MainVM:BaseVM
    {
        private SeriesCollection _series;
        private decimal? _supplay;
        private decimal? _price;
        public decimal ? Supplay
        {
            get
            {
                return _supplay;
            }
            set
            {
                _supplay = value;
                OnPropertyChanged(nameof(Supplay));
            }
        }
        public decimal? Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public SeriesCollection Series
        {
            get { return _series; }
            set { _series = value;
                OnPropertyChanged(nameof(Series));
            }
        }

        public ICommand SelectedIntervalcommand { get; set; }

        public MainVM()
        {
            SelectedIntervalcommand = new SelectedIntervalCommand(this);
        }
    } 
}


