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
        public static float baseGBHeight = 315;
        public static float baseGBWidth = 175;

        private float _heightGBOne = baseGBHeight;
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

        private float _widthGBOne = baseGBWidth;
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

        private float _heightGBTwo = baseGBHeight;
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

        private float _widthGBTwo = baseGBWidth;
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

        private float _heightGBThree = baseGBHeight;
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

        private float _widthGBThree = baseGBWidth;
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

        private float _heightGBFour = baseGBHeight;
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

        private float _widthGBFour = baseGBWidth;
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

        private float _heightGBFive = baseGBHeight;
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

        private float _widthGBFive = baseGBWidth;
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
        public static float baseBWidth = 115;

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

        /* ========== HTTP Client ========== */
        // Create a new HttpClient instance
        private static readonly HttpClient client = new HttpClient();

        IJikan jikan;

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

            WidthPB = (float)this.Width - 200;

            this.DataContext = this;

            jikan = new Jikan();
        }

        // Async is a modifier that you can apply to methods to indicate that they contain code that can be run asynchronously
        public async Task<string> GetApiDataAsync()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions
            try
            {
                string apiURL = "https://api.jikan.moe/v3/top/anime/1/tv";
                // Call asynchronous network methods in a try/catch block to handle exceptions
                HttpResponseMessage response = await client.GetAsync(string.Format(apiURL));

                // Check that response was successful or throw exception
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                return responseBody;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return "";
            }
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
                /*
                var progressTask = Task.Run(() =>
                {
                    for (int i = 0; i <= 1000; i++)
                    {
                        Dispatcher.Invoke(() => ProgressBar.Value = i, System.Windows.Threading.DispatcherPriority.Background);
                        System.Threading.Thread.Sleep(20);
                    }
                });*/

                // Send a request to the Jikan API to get the anime information
                var animeResponse = await jikan.SearchAnimeAsync(TextAnimeTB);

                // Wait for the simulated delay to finish
                //await progressTask;

                // Hide the progress bar
                DoubleAnimation opacityAnimation2 = new DoubleAnimation(0, TimeSpan.FromSeconds(0.8));
                opacityAnimation2.Completed += (s, e) => ProgressBar.Visibility = Visibility.Hidden;
                opacityAnimation2.Completed += (s, e) => ProgressBar.Value = 0;
                ProgressBar.BeginAnimation(ProgressBar.OpacityProperty, opacityAnimation2);

                // If the anime is not found, display a snackbar message
                if (animeResponse.Data.Count == 0)
                {
                    ShowSnackBar("Anime not found!");
                }
                else
                {
                    var firstAnime = animeResponse.Data.First();

                    // Display the anime information in the groupbox
                    gbOne.Header = firstAnime.Title;

                    // Fetch the anime images
                    var imageResponse = await jikan.GetAnimePicturesAsync((long)firstAnime.MalId);
                    var imageUrl = imageResponse.Data.First().JPG.ImageUrl;

                    // Create new StackPanel and populate with the image and text
                    gbOne.Content = new StackPanel
                    {
                        Children =
                        {
                            new System.Windows.Controls.Image
                            {
                                Source = new BitmapImage(new Uri(imageUrl)),
                                Height = 150,
                                Width = 150
                            },
                            new TextBlock
                            {
                                Text = $"MAL Rating: {firstAnime.Score}\nURL: {firstAnime.Url}"
                            }
                        }
                    };
                }
            }
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