using MaterialDesignThemes.Wpf;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WhatsNextWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _textAnimeTB = "";
        public string TextAnimeTB
        {
            get => _textAnimeTB;
            set
            {
                if (_textAnimeTB != value)
                {
                    _textAnimeTB = value;
                    OnPropertyChanged(nameof(TextAnimeTB));
                }
            }
        }

        private string _textMangaTB = "";
        public string TextMangaTB
        {
            get => _textMangaTB;
            set
            {
                if (_textMangaTB != value)
                {
                    _textMangaTB = value;
                    OnPropertyChanged(nameof(TextMangaTB));
                }
            }
        }

        private bool _isActiveSB = false;
        public bool IsActiveSB
        {
            get => _isActiveSB;
            set
            {
                if (_isActiveSB != value)
                {
                    _isActiveSB = value;
                    OnPropertyChanged(nameof(IsActiveSB));
                }
            }
        }

        private string _messageSB = "";
        public string MessageSB
        {
            get => _messageSB;
            set
            {
                if (_messageSB != value)
                {
                    _messageSB = value;
                    OnPropertyChanged(nameof(MessageSB));
                }
            }
        }

        private string _headerGB = "Default";
        public string HeaderGB
        {
            get => _headerGB;
            set
            {
                if (_headerGB != value)
                {
                    _headerGB = value;
                    OnPropertyChanged(nameof(HeaderGB));
                }
            }
        }

        private ImageSource _sourceGB = new BitmapImage(new Uri("C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextWPF\\Resources\\Default.jpg"));
        public ImageSource SourceGB
        {
            get => _sourceGB;
            set
            {
                if (_sourceGB != value)
                {
                    _sourceGB = value;
                    OnPropertyChanged(nameof(SourceGB));
                }
            }
        }

        private string _textGB = "Name:\nRating:\nURL:";
        public string TextGB
        {
            get => _textGB;
            set
            {
                if (_textGB != value)
                {
                    _textGB = value;
                    OnPropertyChanged(nameof(TextGB));
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private async void ShowSnackBar(string message)
        {
            MessageSB = message;
            IsActiveSB = true;

            // Simulate a delay before hiding the snackbar
            await Dispatcher.InvokeAsync(async () =>
            {
                await Task.Delay(3000);
                IsActiveSB = false;
            });
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return && !string.IsNullOrWhiteSpace(TextAnimeTB))
            {
                ShowSnackBar(TextAnimeTB);
            }
        }
    }

    public class ImagePathConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string imagePath && !string.IsNullOrEmpty(imagePath))
            {
                return new BitmapImage(new Uri(imagePath, UriKind.Absolute));
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}