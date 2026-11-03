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

        // Registro de idiomas del lanzador: para anadir uno, agregarlo aqui y tratarlo en T().
        public sealed class LangInfo
        {
            public readonly string Code, NativeName, Tag;
            public LangInfo(string code, string nativeName, string tag) { Code = code; NativeName = nativeName; Tag = tag; }
            public string Label => Tag + "  ·  " + NativeName;
            public override string ToString() => Label;
        }

        public static readonly LangInfo[] Languages =
        {
            new LangInfo("es", "Español", "ES"),
            new LangInfo("en", "English", "EN"),
            new LangInfo("pt", "Português (Brasil)", "PT-BR"),
        };

        public static LangInfo Find(string code) => System.Array.Find(Languages, l => l.Code == code);

        // Codigo guardado si existe en el registro; si no, ingles.
        public static string Normalize(string code) => Find(code)?.Code ?? "en";

        public static string LangName(string code) => (Find(code) ?? Find("en")).NativeName;

        public static string T(string es, string en, string pt = null)
        {
            if (Lang == "en") return en;
            if (Lang == "pt") return pt ?? LocPtBr.Get(en) ?? es;
            return es;
        }
    }
}
