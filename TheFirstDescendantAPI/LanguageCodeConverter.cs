namespace TheFirstDescendantAPI
{
    public class LanguageCodeConverter
    {
        public static string Convert(LanguageCode code)
        {
            return code switch
            {
                LanguageCode.KO => "ko",
                LanguageCode.EN => "en",
                LanguageCode.DE => "de",
                LanguageCode.FR => "fr",
                LanguageCode.JA => "ja",
                LanguageCode.CN => "zh-CN",
                LanguageCode.TW => "zh-TW",
                LanguageCode.IT => "it",
                LanguageCode.PL => "pl",
                LanguageCode.PT => "pt",
                LanguageCode.RU => "ru",
                LanguageCode.ES => "es",
                _ => throw new ArgumentOutOfRangeException(nameof(code), code, null),
            };
        }
    }
}
