using Design.WPF;
using System;
using System.Windows;

namespace SimpleWpfStyling {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}

		public void OnSwitchTheme(object sender, EventArgs e) {
			var theme = DynamicTheme.ThemeType == ThemeType.Default ?
						ThemeType.Dark : ThemeType.Default;

			if (theme == ThemeType.Dark) {
				this.btnSwitchTheme.Content = "Switch to Default Theme";
			}
			else {
				this.btnSwitchTheme.Content = "Switch to Dark Theme";
			}

			DynamicTheme.LoadThemeType(theme);
		}
	}
}