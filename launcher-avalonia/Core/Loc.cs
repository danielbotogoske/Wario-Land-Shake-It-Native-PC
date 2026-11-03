namespace WarioLauncher.Core
{
    // Textos del lanzador en español, inglés o portugués de Brasil.
    // Lang: "es", "en" o "pt". El portugués se busca en LocPtBr por el texto en inglés,
    // o se pasa como tercer argumento cuando el texto lleva valores dentro.
    public static class Loc
    {
        public static string Lang = "en";

        public static bool English
        {
            get => Lang == "en";
            set => Lang = value ? "en" : "es";
        }

        public static bool PtBr => Lang == "pt";

        public static string NextLang(string lang) => lang == "en" ? "es" : lang == "es" ? "pt" : "en";

        public static string LangName(string lang) => lang == "es" ? "Español" : lang == "pt" ? "Português" : "English";

        public static string T(string es, string en, string pt = null)
        {
            if (Lang == "en") return en;
            if (Lang == "pt") return pt ?? LocPtBr.Get(en) ?? es;
            return es;
        }
    }
}
