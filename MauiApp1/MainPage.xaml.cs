
using Plugin.Maui.Audio;

namespace MauiApp1
{    
    public partial class MainPage : ContentPage
    {
        
        private IAudioPlayer _audioPlayer;

        public MainPage()
        {
            InitializeComponent();
            
        }        

        async private void OnCounterClicked(object sender, EventArgs e)
        {

            Random rnd = new Random();
            int n1 = rnd.Next(1, 7);  // creates a number between 1 and 6
            int n2 = rnd.Next(1, 7);  // creates a number between 1 and 6
            risultatoLancio.Text = n1 + " + " + n2 + " = " + (n1 + n2);

            if (_audioPlayer == null)
            {
                // Carica l'audio dalla cartella Resources/Raw
                var audioManager = AudioManager.Current;
                
                string [] audioFile = { "lancio1.mp3", "lancio2.mp3", "lancio3.mp3", "lancio4.mp3" };
                int traccia = rnd.Next(0, 4);  // creates a number between 1 and 6
                var audioFile2 = await FileSystem.OpenAppPackageFileAsync(audioFile[traccia]);
                _audioPlayer = audioManager.CreatePlayer(audioFile2);
            }
            else
            {
                var audioManager = AudioManager.Current;
                string[] audioFile = { "lancio1.mp3", "lancio2.mp3", "lancio3.mp3", "lancio4.mp3" };
                int traccia = rnd.Next(0, 4);  // creates a number between 1 and 6
                var audioFile2 = await FileSystem.OpenAppPackageFileAsync(audioFile[traccia]);
                _audioPlayer = audioManager.CreatePlayer(audioFile2);

            }

            // Riproduci l'audio
            _audioPlayer.Play();

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
