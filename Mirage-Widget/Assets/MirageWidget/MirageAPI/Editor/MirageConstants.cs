using System.IO;

namespace MirageWidget.MirageAPI.Editor
{
	public static class MirageConstants
	{
		public const string ResourcesPath = "Assets/MirageWidget/MirageAPI/Data/Resources";
		public const string MirageAPISettingsName = "MirageAPISettings";

		public static readonly string DefaultSettingsAssetPath =
			Path.Combine(ResourcesPath, MirageAPISettingsName + ".asset");
	}
}