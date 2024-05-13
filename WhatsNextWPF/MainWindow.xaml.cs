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

        public int animeCounter = 0;

        /* ========== Jikan Client ========== */
        IJikan jikan;
        PaginatedJikanResponse<ICollection<Anime>> animeResponse;
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

            // Simulate a delay before hiding the snackbar
            await Dispatcher.InvokeAsync(async () =>
            {
                await Task.Delay(3000);
                IsActiveSB = false;
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
                
                // Send a request to the Jikan API to get the anime information
                await GetAnimeInfo();
                
                // If the anime is not found, display a snackbar message
                if (animeResponse.Data.Count == 0)
                {
                    ShowSnackBar("Anime not found!");

                    // Hide the progress bar
                    DoubleAnimation opacityAnimation2 = new DoubleAnimation(0, TimeSpan.FromSeconds(0.8));
                    opacityAnimation2.Completed += (s, e) => ProgressBar.Visibility = Visibility.Hidden;
                    opacityAnimation2.Completed += (s, e) => ProgressBar.Value = 0;
                    ProgressBar.BeginAnimation(ProgressBar.OpacityProperty, opacityAnimation2);
                }
            }
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
                animeResponse = await jikan.SearchAnimeAsync(TextAnimeTB);

                // Set the anime counter to 0
                animeCounter = 0;
            }

            // Wait for the simulated delay to finish
            //await progressTask;               

            // If the anime is not found, display a snackbar message
            if (animeResponse.Data.Count != 0)
            {
                if (animeCounter != 0)
                {
                    HandleAnimations();
                }

                var firstAnime = animeResponse.Data.Skip(animeCounter).First();
                var secondAnime = animeResponse.Data.Skip(animeCounter + 1).First();
                var thirdAnime = animeResponse.Data.Skip(animeCounter + 2).First();
                var fourthAnime = animeResponse.Data.Skip(animeCounter + 3).First();
                var fifthAnime = animeResponse.Data.Skip(animeCounter + 4).First();

                // Display the anime information in the groupbox
                gbOne.Header = firstAnime.Title;
                gbTwo.Header = secondAnime.Title;
                gbThree.Header = thirdAnime.Title;
                gbFour.Header = fourthAnime.Title;
                gbFive.Header = fifthAnime.Title;

                // Fetch the anime images
                var imageResponseFirst = await jikan.GetAnimePicturesAsync((long)firstAnime.MalId);
                var imageUrlFirst = imageResponseFirst.Data.First().JPG.ImageUrl;
                var firstAnimeGenres = firstAnime.Genres.Select(g => g.Name).ToImmutableList();
                if (firstAnimeGenres.Count == 0)
                {
                    firstAnimeGenres = ImmutableList.Create("None");
                }

                var imageResponseSecond = await jikan.GetAnimePicturesAsync((long)secondAnime.MalId);
                var imageUrlSecond = imageResponseSecond.Data.First().JPG.ImageUrl;
                var secondAnimeGenres = secondAnime.Genres.Select(g => g.Name).ToImmutableList();
                if (secondAnimeGenres.Count == 0)
                {
                    secondAnimeGenres = ImmutableList.Create("None");
                }

                var imageResponseThird = await jikan.GetAnimePicturesAsync((long)thirdAnime.MalId);
                var imageUrlThird = imageResponseThird.Data.First().JPG.ImageUrl;
                var thirdAnimeGenres = thirdAnime.Genres.Select(g => g.Name).ToImmutableList();
                if (thirdAnimeGenres.Count == 0)
                {
                    thirdAnimeGenres = ImmutableList.Create("None");
                }

                var imageResponseFourth = await jikan.GetAnimePicturesAsync((long)fourthAnime.MalId);
                var imageUrlFourth = imageResponseFourth.Data.First().JPG.ImageUrl;
                var fourthAnimeGenres = fourthAnime.Genres.Select(g => g.Name).ToImmutableList();
                if (fourthAnimeGenres.Count == 0)
                {
                    fourthAnimeGenres = ImmutableList.Create("None");
                }

                var imageResponseFifth = await jikan.GetAnimePicturesAsync((long)fifthAnime.MalId);
                var imageUrlFifth = imageResponseFifth.Data.First().JPG.ImageUrl;
                var fifthAnimeGenres = fifthAnime.Genres.Select(g => g.Name).ToImmutableList();
                if (fifthAnimeGenres.Count == 0)
                {
                    fifthAnimeGenres = ImmutableList.Create("None");
                }

                var imageWandH = 160;

                // Add the image and text to each groupbox
                SourceGBOne = new BitmapImage(new Uri(imageUrlFirst, UriKind.Absolute));
                imgOne.Width = imageWandH;
                imgOne.Height = imageWandH;
                var genreListOne = string.Join(", ", firstAnimeGenres);
                TextGBOne = "MAL Rating: " + firstAnime.Score + "\nGenres: " + genreListOne;

                SourceGBTwo = new BitmapImage(new Uri(imageUrlSecond, UriKind.Absolute));
                imgTwo.Width = imageWandH;
                imgTwo.Height = imageWandH;
                var genreListTwo = string.Join(", ", secondAnimeGenres);
                TextGBTwo = "MAL Rating: " + secondAnime.Score + "\nGenres: " + genreListTwo;

                SourceGBThree = new BitmapImage(new Uri(imageUrlThird, UriKind.Absolute));
                imgThree.Width = imageWandH;
                imgThree.Height = imageWandH;
                var genreListThree = string.Join(", ", thirdAnimeGenres);
                TextGBThree = "MAL Rating: " + thirdAnime.Score + "\nGenres: " + genreListThree;

                SourceGBFour = new BitmapImage(new Uri(imageUrlFourth, UriKind.Absolute));
                imgFour.Width = imageWandH;
                imgFour.Height = imageWandH;
                var genreListFour = string.Join(", ", fourthAnimeGenres);
                TextGBFour = "MAL Rating: " + fourthAnime.Score + "\nGenres: " + genreListFour;

                SourceGBFive = new BitmapImage(new Uri(imageUrlFifth, UriKind.Absolute));
                imgFive.Width = imageWandH;
                imgFive.Height = imageWandH;
                var genreListFive = string.Join(", ", fifthAnimeGenres);
                TextGBFive = "MAL Rating: " + fifthAnime.Score + "\nGenres: " + genreListFive;

                if (animeCounter == 0 && previousEntry == "")
                {
                    HandleAnimations();
                }
                else if (animeCounter == 0)
                {
                    // Hide the progress bar
                    DoubleAnimation opacityAnimation2 = new DoubleAnimation(0, TimeSpan.FromSeconds(0.8));
                    opacityAnimation2.Completed += (s, e) => ProgressBar.Visibility = Visibility.Hidden;
                    opacityAnimation2.Completed += (s, e) => ProgressBar.Value = 0;
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
                if (animeCounter == 45)
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
                if (animeResponse.Data.Count <= 5)
                {
                    forwardB.IsEnabled = false;
                    forwardB.BeginAnimation(Button.OpacityProperty, opacityAnimationBBLess);
                    forwardB.Visibility = Visibility.Collapsed;

                    backwardB.IsEnabled = false;
                    backwardB.BeginAnimation(Button.OpacityProperty, opacityAnimationBBLess);
                    backwardB.Visibility = Visibility.Collapsed;
                }
            }

            previousEntry = TextAnimeTB;
        }

        private async void HandleAnimations()
        {
            if (animeCounter == 0)
            {
                // Hide the progress bar
                DoubleAnimation opacityAnimation2 = new DoubleAnimation(0, TimeSpan.FromSeconds(0.8));
                opacityAnimation2.Completed += (s, e) => ProgressBar.Visibility = Visibility.Hidden;
                opacityAnimation2.Completed += (s, e) => ProgressBar.Value = 0;
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
            TextGBOne = "";
            loadOne.Visibility = Visibility.Visible;

            imgTwo.Visibility = Visibility.Collapsed;
            bTwo.Visibility = Visibility.Collapsed;
            TextGBTwo = "";
            loadTwo.Visibility = Visibility.Visible;

            imgThree.Visibility = Visibility.Collapsed;
            bThree.Visibility = Visibility.Collapsed;
            TextGBThree = "";
            loadThree.Visibility = Visibility.Visible;

            imgFour.Visibility = Visibility.Collapsed;
            bFour.Visibility = Visibility.Collapsed;
            TextGBFour = "";
            loadFour.Visibility = Visibility.Visible;

            imgFive.Visibility = Visibility.Collapsed;
            bFive.Visibility = Visibility.Collapsed;
            TextGBFive = "";
            loadFive.Visibility = Visibility.Visible;
        }

        private void EndLoading()
        {
            loadOne.Visibility = Visibility.Collapsed;
            imgOne.Visibility = Visibility.Visible;
            bOne.Visibility = Visibility.Visible;

            loadTwo.Visibility = Visibility.Collapsed;
            imgTwo.Visibility = Visibility.Visible;
            bTwo.Visibility = Visibility.Visible;

            loadThree.Visibility = Visibility.Collapsed;
            imgThree.Visibility = Visibility.Visible;
            bThree.Visibility = Visibility.Visible;

            loadFour.Visibility = Visibility.Collapsed;
            imgFour.Visibility = Visibility.Visible;
            bFour.Visibility = Visibility.Visible;

            loadFive.Visibility = Visibility.Collapsed;
            imgFive.Visibility = Visibility.Visible;
            bFive.Visibility = Visibility.Visible;
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

        private void Backward_Click(object sender, RoutedEventArgs e)
        {
            animeCounter -= 5;
            GetAnimeInfo();
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            animeCounter += 5;
            GetAnimeInfo();
        }

        private void SelectAnime_Click(object sender, RoutedEventArgs e)
        {
            // On click, get the information for the anime of the parent groupbox
            GroupBox groupBox = (GroupBox)((StackPanel)((Button)sender).Parent).Parent;
            HeaderGBOne = groupBox.Header.ToString();

            // The groupbox contains a child stackpanel which contains the image and textblock
            StackPanel stackPanel = (StackPanel)groupBox.Content;
            System.Windows.Controls.Image image = (System.Windows.Controls.Image)stackPanel.Children[0];
            TextBlock textBlock = (TextBlock)stackPanel.Children[1];
            SourceGBOne = image.Source;

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

            DoubleAnimation spOpacityAnimation = new DoubleAnimation(0, TimeSpan.FromSeconds(0.8));

            // Attach the event handler to the Completed event for spOpacityAnimation
            spOpacityAnimation.Completed += new EventHandler(spOpacityAnimation_Completed);

            SelectionSP.BeginAnimation(StackPanel.OpacityProperty, spOpacityAnimation);
        }

        private void spOpacityAnimation_Completed(object sender, EventArgs e)
        {
            SelectionSP.Visibility = Visibility.Collapsed;

            SelectedSP.Visibility = Visibility.Visible;

            DoubleAnimation slOpacityAnimation = new DoubleAnimation(1, TimeSpan.FromSeconds(0.8));

            SelectedSP.BeginAnimation(StackPanel.OpacityProperty, slOpacityAnimation);
        }
    }
}