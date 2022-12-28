using System;
using System.Windows;

namespace Design.WPF {
	public sealed class ThemeResourceExtension : DynamicResourceExtension {
		public new ThemeResourceKey ResourceKey {
			get {
				Enum.TryParse(base.ResourceKey.ToString(), out ThemeResourceKey key);

				return key;
			}
			set {
				base.ResourceKey = value.ToString();
			}
		}
	}
}
