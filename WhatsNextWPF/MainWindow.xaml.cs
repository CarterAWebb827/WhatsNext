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
using System.Windows.Media.Animation;
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

        private float _heightGBOne = 300;
        public float HeightGBOne
        {
            get => _heightGBOne;
            set
            {
                if (_heightGBOne != value)
                {
                    _heightGBOne = value;
                    OnPropertyChanged(nameof(HeightGBOne));
                }
            }
        }

        private float _widthGBOne = 175;
        public float WidthGBOne
        {
            get => _widthGBOne;
            set
            {
                if (_widthGBOne != value)
                {
                    _widthGBOne = value;
                    OnPropertyChanged(nameof(WidthGBOne));
                }
            }
        }

        private float _opactiyGBOne = 0.5f;
        public float OpacityGBOne
        {
            get => _opactiyGBOne;
            set
            {
                if (_opactiyGBOne != value)
                {
                    _opactiyGBOne = value;
                    OnPropertyChanged(nameof(OpacityGBOne));
                }
            }
        }

        private float _heightGBTwo = 300;
        public float HeightGBTwo
        {
            get => _heightGBTwo;
            set
            {
                if (_heightGBTwo != value)
                {
                    _heightGBTwo = value;
                    OnPropertyChanged(nameof(HeightGBTwo));
                }
            }
        }

        private float _widthGBTwo = 175;
        public float WidthGBTwo
        {
            get => _widthGBTwo;
            set
            {
                if (_widthGBTwo != value)
                {
                    _widthGBTwo = value;
                    OnPropertyChanged(nameof(WidthGBTwo));
                }
            }
        }

        private float _opactiyGBTwo = 0.5f;
        public float OpacityGBTwo
        {
            get => _opactiyGBTwo;
            set
            {
                if (_opactiyGBTwo != value)
                {
                    _opactiyGBTwo = value;
                    OnPropertyChanged(nameof(OpacityGBTwo));
                }
            }
        }

        private float _heightGBThree = 300;
        public float HeightGBThree
        {
            get => _heightGBThree;
            set
            {
                if (_heightGBThree != value)
                {
                    _heightGBThree = value;
                    OnPropertyChanged(nameof(HeightGBThree));
                }
            }
        }

        private float _widthGBThree = 175;
        public float WidthGBThree
        {
            get => _widthGBThree;
            set
            {
                if (_widthGBThree != value)
                {
                    _widthGBThree = value;
                    OnPropertyChanged(nameof(WidthGBThree));
                }
            }
        }

        private float _opactiyGBThree = 0.5f;
        public float OpacityGBThree
        {
            get => _opactiyGBThree;
            set
            {
                if (_opactiyGBThree != value)
                {
                    _opactiyGBThree = value;
                    OnPropertyChanged(nameof(OpacityGBThree));
                }
            }
        }

        private float _heightGBFour = 300;
        public float HeightGBFour
        {
            get => _heightGBFour;
            set
            {
                if (_heightGBFour != value)
                {
                    _heightGBFour = value;
                    OnPropertyChanged(nameof(HeightGBFour));
                }
            }
        }

        private float _widthGBFour = 175;
        public float WidthGBFour
        {
            get => _widthGBFour;
            set
            {
                if (_widthGBFour != value)
                {
                    _widthGBFour = value;
                    OnPropertyChanged(nameof(WidthGBFour));
                }
            }
        }

        private float _opactiyGBFour = 0.5f;
        public float OpacityGBFour
        {
            get => _opactiyGBFour;
            set
            {
                if (_opactiyGBFour != value)
                {
                    _opactiyGBFour = value;
                    OnPropertyChanged(nameof(OpacityGBFour));
                }
            }
        }

        private float _heightGBFive = 300;
        public float HeightGBFive
        {
            get => _heightGBFive;
            set
            {
                if (_heightGBFive != value)
                {
                    _heightGBFive = value;
                    OnPropertyChanged(nameof(HeightGBFive));
                }
            }
        }

        private float _widthGBFive = 175;
        public float WidthGBFive
        {
            get => _widthGBFive;
            set
            {
                if (_widthGBFive != value)
                {
                    _widthGBFive = value;
                    OnPropertyChanged(nameof(WidthGBFive));
                }
            }
        }

        private float _opactiyGBFive = 0.5f;
        public float OpacityGBFive
        {
            get => _opactiyGBFive;
            set
            {
                if (_opactiyGBFive != value)
                {
                    _opactiyGBFive = value;
                    OnPropertyChanged(nameof(OpacityGBFive));
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

            gbOne.Height = HeightGBOne;
            gbTwo.Height = HeightGBOne;
            gbOne.Opacity = OpacityGBOne;

            gbTwo.Height = HeightGBTwo;
            gbTwo.Width = WidthGBTwo;
            gbTwo.Opacity = OpacityGBTwo;

            gbThree.Height = HeightGBThree;
            gbThree.Width = WidthGBThree;
            gbThree.Opacity = OpacityGBThree;

            gbFour.Height = HeightGBFour;
            gbFour.Width = WidthGBFour;
            gbFour.Opacity = OpacityGBFour;

            gbFive.Height = HeightGBFive;
            gbFive.Width = WidthGBFive;
            gbFive.Opacity = OpacityGBFive;

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

        private void MouseOver_GB(object sender, MouseEventArgs e)
        {
            DoubleAnimation heightAnim = new DoubleAnimation(330, TimeSpan.FromSeconds(0.2));
            DoubleAnimation widthAnim = new DoubleAnimation(192.5, TimeSpan.FromSeconds(0.2));
            DoubleAnimation opacityAnim = new DoubleAnimation(1, TimeSpan.FromSeconds(0.2));
            GroupBox groupBox = sender as GroupBox;

            if (groupBox != null)
            {
                groupBox.BeginAnimation(GroupBox.HeightProperty, heightAnim);
                groupBox.BeginAnimation(GroupBox.WidthProperty, widthAnim);
                groupBox.BeginAnimation(UIElement.OpacityProperty, opacityAnim);
            }
        }

        private void MouseLeave_GB(object sender, MouseEventArgs e)
        {
            DoubleAnimation heightAnim = new DoubleAnimation(300, TimeSpan.FromSeconds(0.2));
            DoubleAnimation widthAnim = new DoubleAnimation(175, TimeSpan.FromSeconds(0.2));
            DoubleAnimation opacityAnim = new DoubleAnimation(0.5, TimeSpan.FromSeconds(0.2));
            GroupBox groupBox = sender as GroupBox;

            if (groupBox != null)
            {
                groupBox.BeginAnimation(GroupBox.HeightProperty, heightAnim);
                groupBox.BeginAnimation(GroupBox.WidthProperty, widthAnim);
                groupBox.BeginAnimation(UIElement.OpacityProperty, opacityAnim);
            }
        }


        private void SelectAnime_Click(object sender, RoutedEventArgs e)
        {

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