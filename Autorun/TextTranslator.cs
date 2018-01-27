using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YandexLinguistics.NET;
using System.Threading.Tasks;

namespace Autorun
{
    public class TextTranslator
    {
        private const string KEY = "trnsl.1.1.20180114T110811Z.db0fce986035fa2d.b0fde374a99573eca4a2225ee5f0b6a9ec425975";
        private Translator translator;

        private string[] langs = new string[] { "Русский", "Английский" };
        public string[] GetLanguages() => langs;

        public TextTranslator()
        {
            translator = new Translator(KEY);
        }
        public LangPair GetLangPair(string langFrom, string langTo)
        {
            LangPair pair = new LangPair();
            switch (langFrom)
            {
                case "Русский": pair.InputLang = Lang.Ru; break;
                case "Английский": pair.InputLang = Lang.En; break;
            }
            switch (langTo)
            {
                case "Русский": pair.OutputLang = Lang.Ru; break;
                case "Английский": pair.OutputLang = Lang.En; break;
            }
            return pair;
        }
        public string Translate(string text, LangPair pair)
        {
            return translator.Translate(text, pair).Text;
        }
    }
}
