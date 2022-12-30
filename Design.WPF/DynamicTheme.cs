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

		public static ThemeType ThemeType { get; private set; } = ThemeType.Default;

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
						new SolidColorBrush(GetColorFromHex("#A5A692")));
			SetResource(ThemeResourceKey.ContentBackgroundAccent.ToString(),
						new SolidColorBrush(GetColorFromHex("#e8e8e3")));
			SetResource(ThemeResourceKey.ContentForeground.ToString(),
						new SolidColorBrush(GetColorFromHex("#011F26")));
			SetResource(ThemeResourceKey.ContentForegroundAccent.ToString(),
						new SolidColorBrush(GetColorFromHex("#023d4b")));
		}

		private static void SetDarkThemeStyles() {
			SetResource(ThemeResourceKey.ContentBackground.ToString(),
						new SolidColorBrush(GetColorFromHex("#1D1D1D")));
			SetResource(ThemeResourceKey.ContentBackgroundAccent.ToString(),
						new SolidColorBrush(GetColorFromHex("#333333")));
			SetResource(ThemeResourceKey.ContentForeground.ToString(),
						new SolidColorBrush(GetColorFromHex("#FAFAFA")));
			SetResource(ThemeResourceKey.ContentForegroundAccent.ToString(),
						new SolidColorBrush(GetColorFromHex("#e6e6e6")));
		}

		private static void SetCommonResources() {
			SetResource(ThemeResourceKey.PrimaryAccent.ToString(),
						new SolidColorBrush(GetColorFromHex("#025E73")));
			SetResource(ThemeResourceKey.PrimaryAccentLighter.ToString(),
						new SolidColorBrush(GetColorFromHex("#03a5c9")));
			SetResource(ThemeResourceKey.PrimaryAccentContrast.ToString(),
						new SolidColorBrush(GetColorFromHex("#FAFAFA")));
			SetResource(ThemeResourceKey.SecondaryAccent.ToString(),
						new SolidColorBrush(GetColorFromHex("#F2A71B"))); 
			SetResource(ThemeResourceKey.SecondaryAccentLighter.ToString(),
						new SolidColorBrush(GetColorFromHex("#f6be55")));
			SetResource(ThemeResourceKey.SecondaryAccentContrast.ToString(),
						new SolidColorBrush(GetColorFromHex("#011F26")));
			SetResource(ThemeResourceKey.DefaultOpacity.ToString(), 0.5d);
			SetResource(ThemeResourceKey.DefaultGradient.ToString(),
						new LinearGradientBrush() { 
							StartPoint = new Point(0, 0.5),
							EndPoint = new Point(0.5, 0.5),
							GradientStops = new GradientStopCollection() {
								new GradientStop() { Offset = 0, Color = GetColorFromHex("#FF833AB4") },
								new GradientStop() { Offset = 1, Color = GetColorFromHex("#FFFD1D1D") }
							}
						});
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

		internal static Color GetColorFromHex(string colorHex) {
			return (Color?)ColorConverter.ConvertFromString(colorHex) ?? Colors.Transparent;
		}
	}
}
