using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace LocationFood.Common.Helpers
{
    public static class Settings
    {
        private const string _reservation = "Reservation";
        private const string _token = "Token";
        private const string _customer = "Customer";
        private const string _isRemembered = "IsRemembered";
        private static readonly string _stringDefault = string.Empty;
        private static readonly bool _boolDefault = false;

        private static ISettings AppSettings => CrossSettings.Current;

        public static string Pet
        {
            get => AppSettings.GetValueOrDefault(_reservation, _stringDefault);
            set => AppSettings.AddOrUpdateValue(_reservation, value);
        }

        public static string Token
        {
            get => AppSettings.GetValueOrDefault(_token, _stringDefault);
            set => AppSettings.AddOrUpdateValue(_token, value);
        }

        public static string Customer
        {
            get => AppSettings.GetValueOrDefault(_customer, _stringDefault);
            set => AppSettings.AddOrUpdateValue(_customer, value);
        }

        public static bool IsRemembered
        {
            get => AppSettings.GetValueOrDefault(_isRemembered, _boolDefault);
            set => AppSettings.AddOrUpdateValue(_isRemembered, value);
        }
    }
}
