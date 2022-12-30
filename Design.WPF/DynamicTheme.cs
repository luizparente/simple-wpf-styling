using System;
using System.Windows;
using System.Windows.Media;

namespace Design.WPF {
	public static class DynamicTheme {
		[ThreadStatic]
		private static ResourceDictionary resourceDictionary;

		internal static ResourceDictionary ResourceDictionary {
			get {
				if (resourceDictionary == null) {
					resourceDictionary = new ResourceDictionary();
					LoadThemeType(ThemeType.Default);
				}

				return resourceDictionary;
			}
		}

		public static ThemeType ThemeType { get; set; } = ThemeType.Default;

		public static void LoadThemeType(ThemeType type) {
			ThemeType = type;

			switch (type) {
				case ThemeType.Default:
					SetDefaultThemeStyles();
					break;
				case ThemeType.Dark:
					SetDarkThemeStyles();
					break;
			}

			SetCommonResources();
		}

		private static void SetDefaultThemeStyles() {
			SetResource(ThemeResourceKey.ContentBackground.ToString(),
						new SolidColorBrush(ColorFromHex("#A5A692")));
			SetResource(ThemeResourceKey.ContentForeground.ToString(),
						new SolidColorBrush(ColorFromHex("#011F26")));
		}

		private static void SetDarkThemeStyles() {
			SetResource(ThemeResourceKey.ContentBackground.ToString(),
						new SolidColorBrush(ColorFromHex("#011F26")));
			SetResource(ThemeResourceKey.ContentForeground.ToString(),
						new SolidColorBrush(ColorFromHex("#FAFAFA")));
		}

		private static void SetCommonResources() {
			SetResource(ThemeResourceKey.PrimaryAccent.ToString(),
						new SolidColorBrush(ColorFromHex("#025E73")));
			SetResource(ThemeResourceKey.PrimaryAccentLighter.ToString(),
						new SolidColorBrush(ColorFromHex("#03a5c9")));
			SetResource(ThemeResourceKey.PrimaryAccentContrast.ToString(),
						new SolidColorBrush(ColorFromHex("#FAFAFA")));
			SetResource(ThemeResourceKey.SecondaryAccent.ToString(),
						new SolidColorBrush(ColorFromHex("#F2A71B"))); 
			SetResource(ThemeResourceKey.SecondaryAccentLighter.ToString(),
						new SolidColorBrush(ColorFromHex("#f6be55")));
			SetResource(ThemeResourceKey.SecondaryAccentContrast.ToString(),
						new SolidColorBrush(ColorFromHex("#011F26")));
		}

		public static object? GetResource(ThemeResourceKey key) {
			return ResourceDictionary.Contains(key.ToString()) ?
				ResourceDictionary[key.ToString()] : null;
		}

		internal static void SetResource(object key, object resource) {
			if (!ResourceDictionary.Contains(key.ToString()))
				ResourceDictionary.Add(key, resource);
			else
				ResourceDictionary[key] = resource;
		}

		internal static Color ColorFromHex(string colorHex) {
			return (Color?)ColorConverter.ConvertFromString(colorHex) ?? Colors.Transparent;
		}
	}
}
