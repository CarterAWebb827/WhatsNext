using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using JikanDotNet;
using System.DirectoryServices;
using System.Collections.Immutable;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System.Runtime.CompilerServices;
using WhatsNextCA;

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

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
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

        /* ========== Height, Width, and Opacity for GroupBoxes ========== */
        public static float startGBHeight = 0;
        public static float baseGBHeight = 400;
        public static float startGBWidth = 0;
        public static float baseGBWidth = 200;

        private float _heightGBOne = startGBHeight;
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

        private float _widthGBOne = startGBWidth;
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

        private float _heightGBTwo = startGBHeight;
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

        private float _widthGBTwo = startGBWidth;
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

        private float _heightGBThree = startGBHeight;
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

        private float _widthGBThree = startGBWidth;
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

        private float _heightGBFour = startGBHeight;
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

        private float _widthGBFour = startGBWidth;
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

        private float _heightGBFive = startGBHeight;
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

        private float _widthGBFive = startGBWidth;
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

        /* ========== Header, Source Image, and Text for GroupBoxes ========== */
        private string _headerGBOne = "Default";
        public string HeaderGBOne
        {
            get => _headerGBOne;
            set
            {
                if (_headerGBOne != value)
                {
                    _headerGBOne = value;
                    OnPropertyChanged(nameof(HeaderGBOne));
                }
            }
        }

        private ImageSource _sourceGBOne = new BitmapImage(new Uri("C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextWPF\\Resources\\Default.jpg"));
        public ImageSource SourceGBOne
        {
            get => _sourceGBOne;
            set
            {
                if (_sourceGBOne != value)
                {
                    _sourceGBOne = value;
                    OnPropertyChanged(nameof(SourceGBOne));
                }
            }
        }

        private string _textGBOne = "MAL Rating:\nURL:";
        public string TextGBOne
        {
            get => _textGBOne;
            set
            {
                if (_textGBOne != value)
                {
                    _textGBOne = value;
                    OnPropertyChanged(nameof(TextGBOne));
                }
            }
        }

        private string _headerGBTwo = "Default";
        public string HeaderGBTwo
        {
            get => _headerGBTwo;
            set
            {
                if (_headerGBTwo != value)
                {
                    _headerGBTwo = value;
                    OnPropertyChanged(nameof(HeaderGBTwo));
                }
            }
        }

        private ImageSource _sourceGBTwo = new BitmapImage(new Uri("C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextWPF\\Resources\\Default.jpg"));
        public ImageSource SourceGBTwo
        {
            get => _sourceGBTwo;
            set
            {
                if (_sourceGBTwo != value)
                {
                    _sourceGBTwo = value;
                    OnPropertyChanged(nameof(SourceGBTwo));
                }
            }
        }

        private string _textGBTwo = "MAL Rating:\nURL:";
        public string TextGBTwo
        {
            get => _textGBTwo;
            set
            {
                if (_textGBTwo != value)
                {
                    _textGBTwo = value;
                    OnPropertyChanged(nameof(TextGBTwo));
                }
            }
        }

        private string _headerGBThree = "Default";
        public string HeaderGBThree
        {
            get => _headerGBThree;
            set
            {
                if (_headerGBThree != value)
                {
                    _headerGBThree = value;
                    OnPropertyChanged(nameof(HeaderGBThree));
                }
            }
        }

        private ImageSource _sourceGBThree = new BitmapImage(new Uri("C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextWPF\\Resources\\Default.jpg"));
        public ImageSource SourceGBThree
        {
            get => _sourceGBThree;
            set
            {
                if (_sourceGBThree != value)
                {
                    _sourceGBThree = value;
                    OnPropertyChanged(nameof(SourceGBThree));
                }
            }
        }

        private string _textGBThree = "MAL Rating:\nURL:";
        public string TextGBThree
        {
            get => _textGBThree;
            set
            {
                if (_textGBThree != value)
                {
                    _textGBThree = value;
                    OnPropertyChanged(nameof(TextGBThree));
                }
            }
        }

        private string _headerGBFour = "Default";
        public string HeaderGBFour
        {
            get => _headerGBFour;
            set
            {
                if (_headerGBFour != value)
                {
                    _headerGBFour = value;
                    OnPropertyChanged(nameof(HeaderGBFour));
                }
            }
        }

        private ImageSource _sourceGBFour = new BitmapImage(new Uri("C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextWPF\\Resources\\Default.jpg"));
        public ImageSource SourceGBFour
        {
            get => _sourceGBFour;
            set
            {
                if (_sourceGBFour != value)
                {
                    _sourceGBFour = value;
                    OnPropertyChanged(nameof(SourceGBFour));
                }
            }
        }

        private string _textGBFour = "MAL Rating:\nURL:";
        public string TextGBFour
        {
            get => _textGBFour;
            set
            {
                if (_textGBFour != value)
                {
                    _textGBFour = value;
                    OnPropertyChanged(nameof(TextGBFour));
                }
            }
        }

        private string _headerGBFive = "Default";
        public string HeaderGBFive
        {
            get => _headerGBFive;
            set
            {
                if (_headerGBFive != value)
                {
                    _headerGBFive = value;
                    OnPropertyChanged(nameof(HeaderGBFive));
                }
            }
        }

        private ImageSource _sourceGBFive = new BitmapImage(new Uri("C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextWPF\\Resources\\Default.jpg"));
        public ImageSource SourceGBFive
        {
            get => _sourceGBFive;
            set
            {
                if (_sourceGBFive != value)
                {
                    _sourceGBFive = value;
                    OnPropertyChanged(nameof(SourceGBFive));
                }
            }
        }

        private string _textGBFive = "MAL Rating:\nURL:";
        public string TextGBFive
        {
            get => _textGBFive;
            set
            {
                if (_textGBFive != value)
                {
                    _textGBFive = value;
                    OnPropertyChanged(nameof(TextGBFive));
                }
            }
        }

        /* ========== Height, Width, and Opacity for Buttons ========== */
        public static float baseBHeight = 50;
        public static float baseBWidth = 125;

        private float _heightBOne = baseBHeight;
        public float HeightBOne
        {
            get => _heightBOne;
            set
            {
                if (_heightBOne != value)
                {
                    _heightBOne = value;
                    OnPropertyChanged(nameof(HeightBOne));
                }
            }
        }

        private float _widthBOne = baseBWidth;
        public float WidthBOne
        {
            get => _widthBOne;
            set
            {
                if (_widthBOne != value)
                {
                    _widthBOne = value;
                    OnPropertyChanged(nameof(WidthBOne));
                }
            }
        }

        private float _opactiyBOne = 0.5f;
        public float OpacityBOne
        {
            get => _opactiyBOne;
            set
            {
                if (_opactiyBOne != value)
                {
                    _opactiyBOne = value;
                    OnPropertyChanged(nameof(OpacityBOne));
                }
            }
        }

        private float _heightBTwo = baseBHeight;
        public float HeightBTwo
        {
            get => _heightBTwo;
            set
            {
                if (_heightBTwo != value)
                {
                    _heightBTwo = value;
                    OnPropertyChanged(nameof(HeightBTwo));
                }
            }
        }

        private float _widthBTwo = baseBWidth;
        public float WidthBTwo
        {
            get => _widthBTwo;
            set
            {
                if (_widthBTwo != value)
                {
                    _widthBTwo = value;
                    OnPropertyChanged(nameof(WidthBTwo));
                }
            }
        }

        private float _opactiyBTwo = 0.5f;
        public float OpacityBTwo
        {
            get => _opactiyBTwo;
            set
            {
                if (_opactiyBTwo != value)
                {
                    _opactiyBTwo = value;
                    OnPropertyChanged(nameof(OpacityBTwo));
                }
            }
        }

        private float _heightBThree = baseBHeight;
        public float HeightBThree
        {
            get => _heightBThree;
            set
            {
                if (_heightBThree != value)
                {
                    _heightBThree = value;
                    OnPropertyChanged(nameof(HeightBThree));
                }
            }
        }

        private float _widthBThree = baseBWidth;
        public float WidthBThree
        {
            get => _widthBThree;
            set
            {
                if (_widthBThree != value)
                {
                    _widthBThree = value;
                    OnPropertyChanged(nameof(WidthBThree));
                }
            }
        }

        private float _opactiyBThree = 0.5f;
        public float OpacityBThree
        {
            get => _opactiyBThree;
            set
            {
                if (_opactiyBThree != value)
                {
                    _opactiyBThree = value;
                    OnPropertyChanged(nameof(OpacityBThree));
                }
            }
        }

        private float _heightBFour = baseBHeight;
        public float HeightBFour
        {
            get => _heightBFour;
            set
            {
                if (_heightBFour != value)
                {
                    _heightBFour = value;
                    OnPropertyChanged(nameof(HeightBFour));
                }
            }
        }

        private float _widthBFour = baseBWidth;
        public float WidthBFour
        {
            get => _widthBFour;
            set
            {
                if (_widthBFour != value)
                {
                    _widthBFour = value;
                    OnPropertyChanged(nameof(WidthBFour));
                }
            }
        }

        private float _opactiyBFour = 0.5f;
        public float OpacityBFour
        {
            get => _opactiyBFour;
            set
            {
                if (_opactiyBFour != value)
                {
                    _opactiyBFour = value;
                    OnPropertyChanged(nameof(OpacityBFour));
                }
            }
        }

        private float _heightBFive = baseBHeight;
        public float HeightBFive
        {
            get => _heightBFive;
            set
            {
                if (_heightBFive != value)
                {
                    _heightBFive = value;
                    OnPropertyChanged(nameof(HeightBFive));
                }
            }
        }

        private float _widthBFive = baseBWidth;
        public float WidthBFive
        {
            get => _widthBFive;
            set
            {
                if (_widthBFive != value)
                {
                    _widthBFive = value;
                    OnPropertyChanged(nameof(WidthBFive));
                }
            }
        }

        private float _opactiyBFive = 0.5f;
        public float OpacityBFive
        {
            get => _opactiyBFive;
            set
            {
                if (_opactiyBFive != value)
                {
                    _opactiyBFive = value;
                    OnPropertyChanged(nameof(OpacityBFive));
                }
            }
        }

        private float _valuePB = 0;
        public float ValuePB
        {
            get => _valuePB;
            set
            {
                if (_valuePB != value)
                {
                    _valuePB = value;
                    OnPropertyChanged(nameof(ValuePB));
                }
            }
        }

        private float _widthPB = 0;
        public float WidthPB
        {
            get => _widthPB;
            set
            {
                if (_widthPB != value)
                {
                    _widthPB = value;
                    OnPropertyChanged(nameof(WidthPB));
                }
            }
        }

        private Visibility _visibilityPB = Visibility.Hidden;
        public Visibility VisibilityPB
        {
            get => _visibilityPB;
            set
            {
                if (_visibilityPB != value)
                {
                    _visibilityPB = value;
                    OnPropertyChanged(nameof(VisibilityPB));
                }
            }
        }

        private float _opacityPB = 0;
        public float OpacityPB
        {
            get => _opacityPB;
            set
            {
                if (_opacityPB != value)
                {
                    _opacityPB = value;
                    OnPropertyChanged(nameof(OpacityPB));
                }
            }
        }

        private float _backwardBVal = 0;
        public float BackwardBVal
        {
            get => _backwardBVal;
            set => SetProperty(ref _backwardBVal, value);
        }

        private float _opacityBB = 0f;
        public float OpacityBB
        {
            get => _opacityBB;
            set
            {
                if (_opacityBB != value)
                {
                    _opacityBB = value;
                    OnPropertyChanged(nameof(OpacityBB));
                }
            }
        }

        private bool _enabledBB = false;
        public bool EnabledBB
        {
            get => _enabledBB;
            set
            {
                if (_enabledBB != value)
                {
                    _enabledBB = value;
                    OnPropertyChanged(nameof(EnabledBB));
                }
            }
        }

        private float _forwardBVal = 5;
        public float ForwardBVal
        {
            get => _forwardBVal;
            private set => SetProperty(ref _forwardBVal, value);
        }

        private float _opacityFB = 0f;
        public float OpacityFB
        {
            get => _opacityFB;
            set
            {
                if (_opacityFB != value)
                {
                    _opacityFB = value;
                    OnPropertyChanged(nameof(OpacityFB));
                }
            }
        }

        private bool _enabledFB = false;
        public bool EnabledFB
        {
            get => _enabledFB;
            set
            {
                if (_enabledFB != value)
                {
                    _enabledFB = value;
                    OnPropertyChanged(nameof(EnabledFB));
                }
            }
        }

        public enum AgeRatingSelected
        {
            SFW,
            NSFW,
            ALL
        }

        private AgeRatingSelected _ageRatingSelected = AgeRatingSelected.ALL;
        private AgeRatingSelected _previousAgeRating = AgeRatingSelected.ALL;

        public int animeCounter = 0;
        public int animeTotal = 0;

        public Recommendation recommendation = new Recommendation(); // Recommendation object
        List<DataCollector.AnimeData> jData = new List<DataCollector.AnimeData>(); // List of anime data from Jikan
        List<DataCollector.AnimeData> cbData = new List<DataCollector.AnimeData>(); // List of anime data from Content-Based Filtering

        /* ========== Jikan Client ========== */
        IJikan jikan;
        PaginatedJikanResponse<ICollection<Anime>> animeResponse = null;
        List<Anime> animeResponsesList = new List<Anime>();
        List<Anime> sfwAnimeResponsesList = new List<Anime>();
        List<Anime> nsfwAnimeResponsesList = new List<Anime>();
        string previousEntry = "";

        public MainWindow()
        {
            InitializeComponent();

            SelectionSP.Visibility = Visibility.Visible;

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

            bOne.Height = HeightBOne;
            bOne.Width = WidthBOne;
            bOne.Opacity = OpacityBOne;

            bTwo.Height = HeightBTwo;
            bTwo.Width = WidthBTwo;
            bTwo.Opacity = OpacityBTwo;

            bThree.Height = HeightBTwo;
            bThree.Width = WidthBTwo;
            bThree.Opacity = OpacityBTwo;

            bFour.Height = HeightBTwo;
            bFour.Width = WidthBTwo;
            bFour.Opacity = OpacityBTwo;

            bFive.Height = HeightBTwo;
            bFive.Width = WidthBTwo;
            bFive.Opacity = OpacityBTwo;

            backwardB.IsEnabled = EnabledBB;
            forwardB.IsEnabled = EnabledFB;

            WidthPB = (float)this.Width - 200;

            this.DataContext = this;

            jikan = new Jikan();
        }

        private async void ShowSnackBar(string message)
        {
            MessageSB = message;
            IsActiveSB = true;
            recommendTypeTB.Visibility = Visibility.Collapsed;
            TestSnackBar.Visibility = Visibility.Visible;

            // Simulate a delay before hiding the snackbar
            await Dispatcher.InvokeAsync(async () =>
            {
                await Task.Delay(3000);
                IsActiveSB = false;
                TestSnackBar.Visibility = Visibility.Collapsed;
                recommendTypeTB.Visibility = Visibility.Visible;
            });
        }

        private async void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return && !string.IsNullOrWhiteSpace(TextAnimeTB))
            {
                //ShowSnackBar(TextAnimeTB);

                ProgressBar.Visibility = Visibility.Visible;
                //ProgressBar.Opacity = 1;
                // animate the opacity of the progress bar
                DoubleAnimation opacityAnimation = new DoubleAnimation(1, TimeSpan.FromSeconds(0.8));
                ProgressBar.BeginAnimation(ProgressBar.OpacityProperty, opacityAnimation);

                // Hide allTB, sfwTB, and nsfwTB
                allTB.Visibility = Visibility.Collapsed;
                sfwTB.Visibility = Visibility.Collapsed;
                nsfwTB.Visibility = Visibility.Collapsed;

                // Send a request to the Jikan API to get the anime information
                await GetAnimeInfo();

                // If the anime is not found, display a snackbar message
                if (animeResponse.Data.Count == 0)
                {
                    ShowSnackBar("Anime not found!");

                    // Hide the progress bar
                    DoubleAnimation opacityAnimation2 = new DoubleAnimation(0, TimeSpan.FromSeconds(0.8));
                    opacityAnimation2.Completed += new EventHandler(pb_Completed);
                    ProgressBar.BeginAnimation(ProgressBar.OpacityProperty, opacityAnimation2);
                }
            }
        }

        private void pb_Completed(object sender, EventArgs e)
        {
            ProgressBar.Visibility = Visibility.Hidden;
            ProgressBar.Value = 0;

            // Show allTB, sfwTB, and nsfwTB
            allTB.Visibility = Visibility.Visible;
            sfwTB.Visibility = Visibility.Visible;
            nsfwTB.Visibility = Visibility.Visible;
        }

        private async Task GetAnimeInfo()
        {
            // Send a request to the Jikan API to get the anime information
            if (previousEntry != TextAnimeTB)
            {
                // Clear AnimeResponse
                animeResponse = null;
                if (previousEntry != "")
                {
                    ShowLoading();
                }

                AnimeSearchConfig searchConfig = new AnimeSearchConfig()
                {
                    Query = TextAnimeTB,
                    Sfw = true,
                    Type = AnimeType.EveryType,
                    MinimumScore = 0,
                    MaximumScore = 10,
                };

                animeResponse = await jikan.SearchAnimeAsync(searchConfig);
                
                ApplyFilter(animeResponse);

                // If SFW is empty, disable the SFW button
                if (sfwAnimeResponsesList.Count == 0)
                {
                    sfwTB.IsEnabled = false;
                    sfwTB.IsChecked = false;
                    allTB.IsChecked = true;

                    _ageRatingSelected = AgeRatingSelected.ALL;
                }
                else
                {
                    sfwTB.IsEnabled = true;
                }

                // If NSFW is empty, disable the NSFW button
                if (nsfwAnimeResponsesList.Count == 0)
                {
                    nsfwTB.IsEnabled = false;
                    nsfwTB.IsChecked = false;
                    allTB.IsChecked = true;

                    _ageRatingSelected = AgeRatingSelected.ALL;
                }
                else
                {
                    nsfwTB.IsEnabled = true;
                }

                // Set the anime counter to 0
                animeCounter = 0;
                animeTotal = animeResponse.Data.Count;
            }

            if (animeResponse == null)
            {
                ShowSnackBar("Please search for an anime.");

                return;
            }

            // If the anime is not found, display a snackbar message
            if (animeResponse.Data.Count != 0)
            {
                if (animeCounter != 0)
                {
                    HandleAnimations();
                }

                Anime firstAnime;
                Anime secondAnime;
                Anime thirdAnime;
                Anime fourthAnime;
                Anime fifthAnime;

                // Depending on the age rating selected, display the anime information
                switch (_ageRatingSelected)
                {
                    case AgeRatingSelected.SFW:
                        firstAnime = sfwAnimeResponsesList[animeCounter];
                        secondAnime = sfwAnimeResponsesList[animeCounter + 1];
                        thirdAnime = sfwAnimeResponsesList[animeCounter + 2];
                        fourthAnime = sfwAnimeResponsesList[animeCounter + 3];
                        fifthAnime = sfwAnimeResponsesList[animeCounter + 4];
                        break;
                    case AgeRatingSelected.NSFW:
                        firstAnime = nsfwAnimeResponsesList[animeCounter];
                        secondAnime = nsfwAnimeResponsesList[animeCounter + 1];
                        thirdAnime = nsfwAnimeResponsesList[animeCounter + 2];
                        fourthAnime = nsfwAnimeResponsesList[animeCounter + 3];
                        fifthAnime = nsfwAnimeResponsesList[animeCounter + 4];
                        break;
                    default:
                        firstAnime = animeResponsesList[animeCounter];
                        secondAnime = animeResponsesList[animeCounter + 1];
                        thirdAnime = animeResponsesList[animeCounter + 2];
                        fourthAnime = animeResponsesList[animeCounter + 3];
                        fifthAnime = animeResponsesList[animeCounter + 4];
                        break;
                }

                // If the previous age rating is not the same as the current age rating, show the loading animation
                if (_previousAgeRating != _ageRatingSelected)
                {
                    ShowLoading();
                }

                // Display the anime information in the groupbox
                gbOne.Header = firstAnime.Title ?? "None";
                gbTwo.Header = secondAnime.Title ?? "None";
                gbThree.Header = thirdAnime.Title ?? "None";
                gbFour.Header = fourthAnime.Title ?? "None";
                gbFive.Header = fifthAnime.Title ?? "None";

                var imageWandH = 160;

                // if there is data in the first anime, display the information
                if (firstAnime != null)
                {
                    gbOne.Visibility = Visibility.Visible;

                    // Fetch the anime images
                    var imageResponseFirst = await jikan.GetAnimePicturesAsync((long)firstAnime.MalId);
                    var image = imageResponseFirst.Data.FirstOrDefault();
                    var imageUrlFirst = image?.JPG.ImageUrl ?? "C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextWPF\\Resources\\Default.jpg";
                    var firstAnimeGenres = firstAnime.Genres.Select(g => g.Name).ToImmutableList() ?? ImmutableList.Create("None");
                    if (firstAnimeGenres.Count == 0)
                    {
                        firstAnimeGenres = ImmutableList.Create("None");
                    }
                    var firstAnimeType = firstAnime.Type ?? "None";
                    var firstAnimeAgeRating = firstAnime.Rating ?? "None";

                    // Add the image and text to each groupbox
                    SourceGBOne = new BitmapImage(new Uri(imageUrlFirst, UriKind.Absolute));
                    imgOne.Width = imageWandH;
                    imgOne.Height = imageWandH;
                    var genreListOne = string.Join(", ", firstAnimeGenres);
                    TextGBOne = "MAL Rating: " + firstAnime.Score + "\nGenres: " + genreListOne + "\nType: " + firstAnimeType + "\nAge Rating: " + firstAnimeAgeRating;
                } 
                else
                {
                    SourceGBOne = new BitmapImage(new Uri("C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextWPF\\Resources\\Default.jpg", UriKind.Absolute));
                    imgOne.Width = imageWandH;
                    imgOne.Height = imageWandH;
                    TextGBOne = "MAL Rating: 0\nGenres: None" + "\nType: None\nAge Rating: None";

                    // Collapse the groupbox if there is no data
                    gbOne.Visibility = Visibility.Collapsed;
                }

                if (secondAnime != null)
                {
                    gbTwo.Visibility = Visibility.Visible;

                    var imageResponseSecond = await jikan.GetAnimePicturesAsync((long)secondAnime.MalId);
                    var image = imageResponseSecond.Data.FirstOrDefault();
                    var imageUrlSecond = image?.JPG.ImageUrl ?? "C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextWPF\\Resources\\Default.jpg";
                    var secondAnimeGenres = secondAnime.Genres.Select(g => g.Name).ToImmutableList() ?? ImmutableList.Create("None");
                    if (secondAnimeGenres.Count == 0)
                    {
                        secondAnimeGenres = ImmutableList.Create("None");
                    }
                    var secondAnimeType = secondAnime.Type ?? "None";
                    var secondAnimeAgeRating = secondAnime.Rating ?? "None";

                    SourceGBTwo = new BitmapImage(new Uri(imageUrlSecond, UriKind.Absolute));
                    imgTwo.Width = imageWandH;
                    imgTwo.Height = imageWandH;
                    var genreListTwo = string.Join(", ", secondAnimeGenres);
                    TextGBTwo = "MAL Rating: " + secondAnime.Score + "\nGenres: " + genreListTwo + "\nType: " + secondAnimeType + "\nAge Rating: " + secondAnimeAgeRating;
                }
                else
                {
                    SourceGBTwo = new BitmapImage(new Uri("C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextWPF\\Resources\\Default.jpg", UriKind.Absolute));
                    imgTwo.Width = imageWandH;
                    imgTwo.Height = imageWandH;
                    TextGBTwo = "MAL Rating: 0\nGenres: None" + "\nType: None\nAge Rating: None";

                    // Collapse the groupbox if there is no data
                    gbTwo.Visibility = Visibility.Collapsed;
                }

                if (thirdAnime != null)
                {
                    gbThree.Visibility = Visibility.Visible;

                    var imageResponseThird = await jikan.GetAnimePicturesAsync((long)thirdAnime.MalId);
                    var image = imageResponseThird.Data.FirstOrDefault();
                    var imageUrlThird = image?.JPG.ImageUrl ?? "C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextWPF\\Resources\\Default.jpg";
                    var thirdAnimeGenres = thirdAnime.Genres.Select(g => g.Name).ToImmutableList() ?? ImmutableList.Create("None");
                    if (thirdAnimeGenres.Count == 0)
                    {
                        thirdAnimeGenres = ImmutableList.Create("None");
                    }
                    var thirdAnimeType = thirdAnime.Type ?? "None";
                    var thirdAnimeAgeRating = thirdAnime.Rating ?? "None";

                    SourceGBThree = new BitmapImage(new Uri(imageUrlThird, UriKind.Absolute));
                    imgThree.Width = imageWandH;
                    imgThree.Height = imageWandH;
                    var genreListThree = string.Join(", ", thirdAnimeGenres);
                    TextGBThree = "MAL Rating: " + thirdAnime.Score + "\nGenres: " + genreListThree + "\nType: " + thirdAnimeType + "\nAge Rating: " + thirdAnimeAgeRating;
                }
                else
                {
                    SourceGBThree = new BitmapImage(new Uri("C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextWPF\\Resources\\Default.jpg", UriKind.Absolute));
                    imgThree.Width = imageWandH;
                    imgThree.Height = imageWandH;
                    TextGBThree = "MAL Rating: 0\nGenres: None" + "\nType: None\nAge Rating: None";

                    // Collapse the groupbox if there is no data
                    gbThree.Visibility = Visibility.Collapsed;
                }

                if (fourthAnime != null)
                {
                    gbFour.Visibility = Visibility.Visible;

                    var imageResponseFourth = await jikan.GetAnimePicturesAsync((long)fourthAnime.MalId);
                    var image = imageResponseFourth.Data.FirstOrDefault();
                    var imageUrlFourth = image?.JPG.ImageUrl ?? "C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextWPF\\Resources\\Default.jpg";
                    var fourthAnimeGenres = fourthAnime.Genres.Select(g => g.Name).ToImmutableList() ?? ImmutableList.Create("None");
                    if (fourthAnimeGenres.Count == 0)
                    {
                        fourthAnimeGenres = ImmutableList.Create("None");
                    }
                    var fourthAnimeType = fourthAnime.Type ?? "None";
                    var fourthAnimeAgeRating = fourthAnime.Rating ?? "None";

                    SourceGBFour = new BitmapImage(new Uri(imageUrlFourth, UriKind.Absolute));
                    imgFour.Width = imageWandH;
                    imgFour.Height = imageWandH;
                    var genreListFour = string.Join(", ", fourthAnimeGenres);
                    TextGBFour = "MAL Rating: " + fourthAnime.Score + "\nGenres: " + genreListFour + "\nType: " + fourthAnimeType + "\nAge Rating: " + fourthAnimeAgeRating;
                } 
                else
                {
                    SourceGBFour = new BitmapImage(new Uri("C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextWPF\\Resources\\Default.jpg", UriKind.Absolute));
                    imgFour.Width = imageWandH;
                    imgFour.Height = imageWandH;
                    TextGBFour = "MAL Rating: 0\nGenres: None" + "\nType: None\nAge Rating: None";

                    // Collapse the groupbox if there is no data
                    gbFour.Visibility = Visibility.Collapsed;
                }

                if (fifthAnime != null)
                {
                    gbFive.Visibility = Visibility.Visible;

                    var imageResponseFifth = await jikan.GetAnimePicturesAsync((long)fifthAnime.MalId);
                    var image = imageResponseFifth.Data.FirstOrDefault();
                    var imageUrlFifth = image?.JPG.ImageUrl ?? "C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextWPF\\Resources\\Default.jpg";
                    var fifthAnimeGenres = fifthAnime.Genres.Select(g => g.Name).ToImmutableList() ?? ImmutableList.Create("None");
                    if (fifthAnimeGenres.Count == 0)
                    {
                        fifthAnimeGenres = ImmutableList.Create("None");
                    }
                    var fifthAnimeType = fifthAnime.Type ?? "None";
                    var fifthAnimeAgeRating = fifthAnime.Rating ?? "None";

                    SourceGBFive = new BitmapImage(new Uri(imageUrlFifth, UriKind.Absolute));
                    imgFive.Width = imageWandH;
                    imgFive.Height = imageWandH;
                    var genreListFive = string.Join(", ", fifthAnimeGenres);
                    TextGBFive = "MAL Rating: " + fifthAnime.Score + "\nGenres: " + genreListFive + "\nType: " + fifthAnimeType + "\nAge Rating: " + fifthAnimeAgeRating;
                }
                else
                {
                    SourceGBFive = new BitmapImage(new Uri("C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextWPF\\Resources\\Default.jpg", UriKind.Absolute));
                    imgFive.Width = imageWandH;
                    imgFive.Height = imageWandH;
                    TextGBFive = "MAL Rating: 0\nGenres: None" + "\nType: None\nAge Rating: None";

                    // Collapse the groupbox if there is no data
                    gbFive.Visibility = Visibility.Collapsed;
                }

                if (animeCounter == 0 && previousEntry == "")
                {
                    HandleAnimations();
                }
                else if (animeCounter == 0)
                {
                    // Hide the progress bar
                    DoubleAnimation opacityAnimation2 = new DoubleAnimation(0, TimeSpan.FromSeconds(0.8));
                    opacityAnimation2.Completed += new EventHandler(pb_Completed);
                    ProgressBar.BeginAnimation(ProgressBar.OpacityProperty, opacityAnimation2);

                    EndLoading();
                }
                else
                {
                    EndLoading();
                }

                // Show the Backward and Forward buttons
                DoubleAnimation opacityAnimationBBLess = new DoubleAnimation(0.5, TimeSpan.FromSeconds(0.8));
                DoubleAnimation opacityAnimationBBMore = new DoubleAnimation(1, TimeSpan.FromSeconds(0.8));
                if (animeCounter == 0)
                {
                    backwardB.BeginAnimation(Button.OpacityProperty, opacityAnimationBBLess);
                    backwardB.IsEnabled = false;
                    backwardB.Visibility = Visibility.Visible;
                }
                else
                {
                    backwardB.BeginAnimation(Button.OpacityProperty, opacityAnimationBBMore);
                    backwardB.IsEnabled = true;
                    backwardB.Visibility = Visibility.Visible;
                }
                if (animeCounter >= animeTotal - 5)
                {
                    forwardB.BeginAnimation(Button.OpacityProperty, opacityAnimationBBLess);
                    forwardB.IsEnabled = false;
                    forwardB.Visibility = Visibility.Visible;
                }
                else
                {
                    forwardB.BeginAnimation(Button.OpacityProperty, opacityAnimationBBMore);
                    forwardB.IsEnabled = true;
                    forwardB.Visibility = Visibility.Visible;
                }

                // if there are less than 5 anime, disable the forward button
                if (animeResponsesList.Count <= 5 && _ageRatingSelected == AgeRatingSelected.ALL)
                {
                    forwardB.IsEnabled = false;
                    forwardB.BeginAnimation(Button.OpacityProperty, opacityAnimationBBLess);
                    forwardB.Visibility = Visibility.Collapsed;

                    backwardB.IsEnabled = false;
                    backwardB.BeginAnimation(Button.OpacityProperty, opacityAnimationBBLess);
                    backwardB.Visibility = Visibility.Collapsed;
                }
                else if (sfwAnimeResponsesList.Count <= 5 && _ageRatingSelected == AgeRatingSelected.SFW)
                {
                    forwardB.IsEnabled = false;
                    forwardB.BeginAnimation(Button.OpacityProperty, opacityAnimationBBLess);
                    forwardB.Visibility = Visibility.Collapsed;

                    backwardB.IsEnabled = false;
                    backwardB.BeginAnimation(Button.OpacityProperty, opacityAnimationBBLess);
                    backwardB.Visibility = Visibility.Collapsed;
                }
                else if (nsfwAnimeResponsesList.Count <= 5 && _ageRatingSelected == AgeRatingSelected.NSFW)
                {
                    forwardB.IsEnabled = false;
                    forwardB.BeginAnimation(Button.OpacityProperty, opacityAnimationBBLess);
                    forwardB.Visibility = Visibility.Collapsed;

                    backwardB.IsEnabled = false;
                    backwardB.BeginAnimation(Button.OpacityProperty, opacityAnimationBBLess);
                    backwardB.Visibility = Visibility.Collapsed;
                }
            }

            _previousAgeRating = _ageRatingSelected;
            previousEntry = TextAnimeTB;
        }

        private void ApplyFilter(PaginatedJikanResponse<ICollection<Anime>> animeResponse)
        {
            // Clear the lists
            animeResponsesList.Clear();
            sfwAnimeResponsesList.Clear();
            nsfwAnimeResponsesList.Clear();

            foreach (var anime in animeResponse.Data)
            {
                if (anime.Rating == "Rx - Hentai")
                {
                    nsfwAnimeResponsesList.Add(anime);
                }
                else if (anime.Rating != "Rx - Hentai")
                {
                    sfwAnimeResponsesList.Add(anime);
                }

                animeResponsesList.Add(anime);
            }
        }

        private async void HandleAnimations()
        {
            if (animeCounter == 0)
            {
                // Hide the progress bar
                DoubleAnimation opacityAnimation2 = new DoubleAnimation(0, TimeSpan.FromSeconds(0.8));
                opacityAnimation2.Completed += new EventHandler(pb_Completed);
                ProgressBar.BeginAnimation(ProgressBar.OpacityProperty, opacityAnimation2);

                // Show the groupboxes with a width, height, and opacity animation with a delay between each
                DoubleAnimation heightAnim = new DoubleAnimation(baseGBHeight, TimeSpan.FromSeconds(0.35));
                DoubleAnimation widthAnim = new DoubleAnimation(baseGBWidth, TimeSpan.FromSeconds(0.35));
                DoubleAnimation opacityAnim = new DoubleAnimation(0.5, TimeSpan.FromSeconds(0.35));

                gbOne.BeginAnimation(GroupBox.HeightProperty, heightAnim);
                gbOne.BeginAnimation(GroupBox.WidthProperty, widthAnim);
                gbOne.BeginAnimation(UIElement.OpacityProperty, opacityAnim);

                await Task.Delay(200);

                gbTwo.BeginAnimation(GroupBox.HeightProperty, heightAnim);
                gbTwo.BeginAnimation(GroupBox.WidthProperty, widthAnim);
                gbTwo.BeginAnimation(UIElement.OpacityProperty, opacityAnim);

                await Task.Delay(200);

                gbThree.BeginAnimation(GroupBox.HeightProperty, heightAnim);
                gbThree.BeginAnimation(GroupBox.WidthProperty, widthAnim);
                gbThree.BeginAnimation(UIElement.OpacityProperty, opacityAnim);

                await Task.Delay(200);

                gbFour.BeginAnimation(GroupBox.HeightProperty, heightAnim);
                gbFour.BeginAnimation(GroupBox.WidthProperty, widthAnim);
                gbFour.BeginAnimation(UIElement.OpacityProperty, opacityAnim);

                await Task.Delay(200);

                gbFive.BeginAnimation(GroupBox.HeightProperty, heightAnim);
                gbFive.BeginAnimation(GroupBox.WidthProperty, widthAnim);
                gbFive.BeginAnimation(UIElement.OpacityProperty, opacityAnim);
            }
            else
            {
                // Collapse the other items in the groupbox and make loadOne visible
                ShowLoading();
            }
        }

        private void ShowLoading()
        {
            imgOne.Visibility = Visibility.Collapsed;
            bOne.Visibility = Visibility.Collapsed;
            bOne.IsEnabled = false;
            TextGBOne = "";
            loadOne.Visibility = Visibility.Visible;

            imgTwo.Visibility = Visibility.Collapsed;
            bTwo.Visibility = Visibility.Collapsed;
            bTwo.IsEnabled = false;
            TextGBTwo = "";
            loadTwo.Visibility = Visibility.Visible;

            imgThree.Visibility = Visibility.Collapsed;
            bThree.Visibility = Visibility.Collapsed;
            bThree.IsEnabled = false;
            TextGBThree = "";
            loadThree.Visibility = Visibility.Visible;

            imgFour.Visibility = Visibility.Collapsed;
            bFour.Visibility = Visibility.Collapsed;
            bFour.IsEnabled = false;
            TextGBFour = "";
            loadFour.Visibility = Visibility.Visible;

            imgFive.Visibility = Visibility.Collapsed;
            bFive.Visibility = Visibility.Collapsed;
            bFive.IsEnabled = false;
            TextGBFive = "";
            loadFive.Visibility = Visibility.Visible;
        }

        private void EndLoading()
        {
            loadOne.Visibility = Visibility.Collapsed;
            imgOne.Visibility = Visibility.Visible;
            bOne.Visibility = Visibility.Visible;
            bOne.IsEnabled = true;

            loadTwo.Visibility = Visibility.Collapsed;
            imgTwo.Visibility = Visibility.Visible;
            bTwo.Visibility = Visibility.Visible;
            bTwo.IsEnabled = true;

            loadThree.Visibility = Visibility.Collapsed;
            imgThree.Visibility = Visibility.Visible;
            bThree.Visibility = Visibility.Visible;
            bThree.IsEnabled = true;

            loadFour.Visibility = Visibility.Collapsed;
            imgFour.Visibility = Visibility.Visible;
            bFour.Visibility = Visibility.Visible;
            bFour.IsEnabled = true;

            loadFive.Visibility = Visibility.Collapsed;
            imgFive.Visibility = Visibility.Visible;
            bFive.Visibility = Visibility.Visible;
            bFive.IsEnabled = true;
        }

        private void MouseOver_GB(object sender, MouseEventArgs e)
        {
            DoubleAnimation heightAnim = new DoubleAnimation(baseGBHeight * 1.05, TimeSpan.FromSeconds(0.15));
            DoubleAnimation widthAnim = new DoubleAnimation(baseGBWidth * 1.05, TimeSpan.FromSeconds(0.15));
            DoubleAnimation opacityAnim = new DoubleAnimation(1, TimeSpan.FromSeconds(0.15));
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
            DoubleAnimation heightAnim = new DoubleAnimation(baseGBHeight, TimeSpan.FromSeconds(0.075));
            DoubleAnimation widthAnim = new DoubleAnimation(baseGBWidth, TimeSpan.FromSeconds(0.075));
            DoubleAnimation opacityAnim = new DoubleAnimation(0.5, TimeSpan.FromSeconds(0.075));
            GroupBox groupBox = sender as GroupBox;

            if (groupBox != null)
            {
                groupBox.BeginAnimation(GroupBox.HeightProperty, heightAnim);
                groupBox.BeginAnimation(GroupBox.WidthProperty, widthAnim);
                groupBox.BeginAnimation(UIElement.OpacityProperty, opacityAnim);
            }
        }

        private void MouseOver_B(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            double height = button.ActualHeight;
            double width = button.ActualWidth;

            DoubleAnimation heightAnim = new DoubleAnimation(height + 5, TimeSpan.FromSeconds(0.15));
            DoubleAnimation widthAnim = new DoubleAnimation(width + 5, TimeSpan.FromSeconds(0.15));
            DoubleAnimation opacityAnim = new DoubleAnimation(1, TimeSpan.FromSeconds(0.15));

            if (button != null)
            {
                button.BeginAnimation(Button.HeightProperty, heightAnim);
                button.BeginAnimation(Button.WidthProperty, widthAnim);
                button.BeginAnimation(UIElement.OpacityProperty, opacityAnim);
            }
        }

        private void MouseLeave_B(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            double height = button.ActualHeight;
            double width = button.ActualWidth;

            DoubleAnimation heightAnim = new DoubleAnimation(height - 5, TimeSpan.FromSeconds(0.075));
            DoubleAnimation widthAnim = new DoubleAnimation(width - 5, TimeSpan.FromSeconds(0.075));
            DoubleAnimation opacityAnim = new DoubleAnimation(0.5, TimeSpan.FromSeconds(0.075));

            if (button != null)
            {
                button.BeginAnimation(Button.HeightProperty, heightAnim);
                button.BeginAnimation(Button.WidthProperty, widthAnim);
                button.BeginAnimation(UIElement.OpacityProperty, opacityAnim);
            }
        }

        private async void Backward_Click(object sender, RoutedEventArgs e)
        {
            animeCounter -= 5;
            int numAnime = (animeCounter * 100) / (animeTotal);
            //BackwardBVal = numAnime;
            //ForwardBVal = numAnime + 5;

            // "Animate" the click
            AnimateClick(numAnime);

            GetAnimeInfo();
        }

        private async void Forward_Click(object sender, RoutedEventArgs e)
        {
            animeCounter += 5;
            int numAnime = (animeCounter * 100) / (animeTotal);
            //BackwardBVal = numAnime;
            //ForwardBVal = numAnime + 5;

            // "Animate" the click
            AnimateClick(numAnime);

            GetAnimeInfo();
        }

        private async Task AnimateClick(int numAnime)
        {
            while (BackwardBVal != numAnime)
            {
                if (BackwardBVal > numAnime)
                {
                    BackwardBVal--;
                }
                else
                {
                    BackwardBVal++;
                }

                if (ForwardBVal > numAnime + 5)
                {
                    ForwardBVal--;
                }
                else
                {
                    ForwardBVal++;
                }

                await Task.Delay(20);
            }
        }

        private async void SelectAnime_Click(object sender, RoutedEventArgs e)
        {
            // On click, get the information for the anime of the parent groupbox
            GroupBox groupBox = (GroupBox)((Grid)((Button)sender).Parent).Parent;
            string title = groupBox.Header.ToString();
            DataCollector.AnimeData anime = recommendation.GetAnimeFromTitle(title);

            jData.Clear();
            //jData = await recommendation.JikanRecommendations(anime);

            Button button = (Button)sender;
            if (button != null && button.Command != null)
            {
                if (button.Command.CanExecute(button.CommandParameter))
                {
                    button.Command.Execute(button.CommandParameter);
                }
            }

            // Call the ShowSnackBar method to display the information
            //ShowSnackBar(textBlock.Text);

            // Disable the recommendation type toggle button
            recommendTypeTB.IsEnabled = false;

            DoubleAnimation spOpacityAnimation = new DoubleAnimation(0, TimeSpan.FromSeconds(0.8));

            // Attach the event handler to the Completed event for spOpacityAnimation
            spOpacityAnimation.Completed += new EventHandler(spOpacityAnimation_Completed);

            SelectionSP.BeginAnimation(StackPanel.OpacityProperty, spOpacityAnimation);

            if (recommendTypeTB.IsChecked == true)
            {
                cbData = await recommendation.CBRecommendations(anime);
                jData.Clear();
            }
            else if (recommendTypeTB.IsChecked == false)
            {
                jData = await recommendation.JikanRecommendations(anime);
                cbData.Clear();
            }
        }

        private void spOpacityAnimation_Completed(object sender, EventArgs e)
        {
            SelectionSP.Visibility = Visibility.Collapsed;

            SelectedSP.Visibility = Visibility.Visible;

            DoubleAnimation slOpacityAnimation = new DoubleAnimation(1, TimeSpan.FromSeconds(0.8));

            slOpacityAnimation.Completed += new EventHandler(LoadSelectedAnime);

            SelectedSP.BeginAnimation(StackPanel.OpacityProperty, slOpacityAnimation);
        }

        private void LoadSelectedAnime(object sender, EventArgs e)
        {
            /*
            if (jData.Count != 0)
            {
                DataCollector.AnimeData anime = jData[0];

                // Fetch the anime images
                var imageResponse = await jikan.GetAnimePicturesAsync((long)anime.MalId);
                var image = imageResponse.Data.FirstOrDefault();
                var imageUrl = image?.JPG.ImageUrl ?? "C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextWPF\\Resources\\Default.jpg";
                var animeGenres = anime.Genres.Select(g => g.Name).ToImmutableList() ?? ImmutableList.Create("None");
                if (animeGenres.Count == 0)
                {
                    animeGenres = ImmutableList.Create("None");
                }
                var animeType = anime.Type ?? "None";
                var animeAgeRating = anime.Rating ?? "None";

                // Add the image and text to each groupbox
                SourceGBOne = new BitmapImage(new Uri(imageUrl, UriKind.Absolute));
                imgOne.Width = 160;
                imgOne.Height = 160;
                var genreList = string.Join(", ", animeGenres);
                TextGBOne = "MAL Rating: " + anime.Score + "\nGenres: " + genreList + "\nType: " + animeType + "\nAge Rating: " + animeAgeRating;
            }
            else if (cbData.Count != 0)
            {
                DataCollector.AnimeData anime = cbData[0];

                // Fetch the anime images
                var imageResponse = await jikan.GetAnimePicturesAsync((long)anime.MalId);
                var image = imageResponse.Data.FirstOrDefault();
                var imageUrl = image?.JPG.ImageUrl ?? "C:\\Users\\Carter\\Desktop\\Coding Projects\\WhatsNext\\WhatsNextWPF\\Resources\\Default.jpg";
                var animeGenres = anime.Genres.Select(g => g.Name).ToImmutableList() ?? ImmutableList.Create("None");
                if (animeGenres.Count == 0)
                {
                    animeGenres = ImmutableList.Create("None");
                }
                var animeType = anime.Type ?? "None";
                var animeAgeRating = anime.Rating ?? "None";

                // Add the image and text to each groupbox
                SourceGBOne = new BitmapImage(new Uri(imageUrl, UriKind.Absolute));
                imgOne.Width = 160;
                imgOne.Height = 160;
            }
            */
        }

        private void allTB_Click(object sender, RoutedEventArgs e)
        {
            _ageRatingSelected = AgeRatingSelected.ALL;
            sfwTB.IsChecked = false;
            nsfwTB.IsChecked = false;

            if (_previousAgeRating != _ageRatingSelected)
            {
                animeCounter = 0;

                GetAnimeInfo();
            }
        }
        private async void sfwTB_Click(object sender, RoutedEventArgs e)
        {
            _ageRatingSelected = AgeRatingSelected.SFW;
            nsfwTB.IsChecked = false;
            allTB.IsChecked = false;

            if (_previousAgeRating != _ageRatingSelected)
            {
                animeCounter = 0;

                int numAnime = (animeCounter * 100) / (animeTotal);
                //BackwardBVal = numAnime;
                //ForwardBVal = numAnime + 5;

                // "Animate" the click
                AnimateClick(numAnime);

                GetAnimeInfo();
            }
        }

        private async void nsfwTB_Click(object sender, RoutedEventArgs e)
        {
            _ageRatingSelected = AgeRatingSelected.NSFW;
            sfwTB.IsChecked = false;
            allTB.IsChecked = false;

            if (_previousAgeRating != _ageRatingSelected)
            {
                animeCounter = 0;

                int numAnime = (animeCounter * 100) / (animeTotal);
                //BackwardBVal = numAnime;
                //ForwardBVal = numAnime + 5;

                // "Animate" the click
                AnimateClick(numAnime);

                GetAnimeInfo();
            }
        }
    }
}