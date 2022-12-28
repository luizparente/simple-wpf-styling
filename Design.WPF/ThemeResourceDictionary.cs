using System.Windows;

namespace Design.WPF {
	public sealed class ThemeResourceDictionary : ResourceDictionary {
		public ThemeResourceDictionary() {
			MergedDictionaries.Add(DynamicTheme.ResourceDictionary);
		}
	}
}
