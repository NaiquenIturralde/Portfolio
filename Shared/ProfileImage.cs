namespace PortfolioNaiquen.Shared
{
    /// <summary>
    /// Centralized constants for the profile image.
    /// Bump the version suffix whenever the underlying file is replaced
    /// to force the browser to bypass its cache.
    /// </summary>
    public static class ProfileImage
    {
        public const string Path = "img/naiquen-profile.png";
        public const string Version = "2";
        public const string Alt = "Foto de perfil de Naiquen Iturralde";

        public static string Url => $"{Path}?v={Version}";
    }
}
