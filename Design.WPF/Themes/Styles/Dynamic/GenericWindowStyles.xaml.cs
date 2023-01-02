using System;
using System.Windows;

namespace Design.WPF.Themes.Styles.Dynamic {
	public partial class GenericWindowStyles : ResourceDictionary {
		public GenericWindowStyles() { }

		public void OnSwitchThemes(object sender, EventArgs e) {
			var theme = DynamicTheme.ThemeType == ThemeType.Default ?
						ThemeType.Dark : ThemeType.Default;

			DynamicTheme.LoadThemeType(theme);
		}

		private void OnClose(object sender, EventArgs e) {
			var window = (Window)((FrameworkElement)sender).TemplatedParent;
			window.Close();
		}

		private void OnMaximize(object sender, EventArgs e) {
			var window = (Window)((FrameworkElement)sender).TemplatedParent;

			if (window.WindowState == WindowState.Maximized)
				window.WindowState = WindowState.Normal;
			else
				window.WindowState = WindowState.Maximized;
		}

		private void OnMinimize(object sender, EventArgs e) {
			var window = (Window)((FrameworkElement)sender).TemplatedParent;
			window.WindowState = WindowState.Minimized;
		}
	}
}
