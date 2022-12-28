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
					SetResource(ThemeResourceKey.ContentBackground.ToString(),
								new SolidColorBrush(ColorFromHex("#CCCCCC")));
					SetResource(ThemeResourceKey.ContentForeground.ToString(),
								new SolidColorBrush(ColorFromHex("#1F1F1F")));
					break;
				case ThemeType.Dark:
					SetResource(ThemeResourceKey.ContentBackground.ToString(),
								new SolidColorBrush(ColorFromHex("#1F1F1F")));
					SetResource(ThemeResourceKey.ContentForeground.ToString(),
								new SolidColorBrush(ColorFromHex("#FAFAFA")));
					break;
			}
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
