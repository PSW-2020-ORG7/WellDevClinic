using System;
using System.Windows;
using System.Windows.Threading;


namespace PSW_Wpf_director
{
    /// <summary>
    /// Interaction logic for TutorialVideoDialog.xaml
    /// </summary>
    public partial class TutorialVideoDialog : Window
    {
		public TutorialVideoDialog()
		{
			InitializeComponent();
			this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			DispatcherTimer timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(1);
			timer.Tick += timer_Tick;
			timer.Start();
			mePlayer.Play();
		}

		void timer_Tick(object sender, EventArgs e)
		{
			if (mePlayer.Source != null)
			{
				if (mePlayer.NaturalDuration.HasTimeSpan)
					lblStatus.Content = String.Format("{0} / {1}", mePlayer.Position.ToString(@"mm\:ss"), mePlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
			}
			else
				lblStatus.Content = "No file selected...";
		}

		private void btnPlay_Click(object sender, RoutedEventArgs e)
		{
			mePlayer.Play();
		}

		private void btnPause_Click(object sender, RoutedEventArgs e)
		{
			mePlayer.Pause();
		}

		private void btnStop_Click(object sender, RoutedEventArgs e)
		{
			mePlayer.Stop();
		}
	}
}
