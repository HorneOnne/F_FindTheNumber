using UnityEngine;
using System.Collections.Generic;
using TMPro;

namespace FindTheNumber
{

    public class LanguageManager : MonoBehaviour
    {
        public static LanguageManager Instance { get; private set; }
        public static System.Action OnLanguageChanged;

        private Dictionary<string, WordDict> dict = new Dictionary<string, WordDict>()
        {
            {"PLAY", new WordDict("PLAY", "JOUER", "GIOCARE")},
            {"DIFFICULTY", new WordDict("DIFFICULTY", "DIFFICULTe", "DIFFICOLTa")},
            {"SETTINGS", new WordDict("SETTINGS", "PARAMeTRES", "IMPOSTAZIONI")},
            {"HOW TO PLAY", new WordDict("HOW TO PLAY", "COMMENT JOUER", "COME GIOCARE")},
            {"LOW", new WordDict("LOW", "FAIBLE", "BASSO")},
            {"MEDIUM", new WordDict("MEDIUM", "MOYEN", "MEDIO")},
            {"HARD", new WordDict("HARD", "DUR", "IMPOSTAZIONI")},
            {"BACK", new WordDict("BACK", "DOS", "INDIETRO")},
            {"ENGLISH", new WordDict("ENGLISH", "ANGLAIS", "INGLESE")},
            {"FRENCH", new WordDict("FRENCH", "FRANcAIS", "FRENCH")},
            {"ITALIAN", new WordDict("ITALIAN", "ITALIEN", "ITALIANO")},

        };


        public enum Languague
        {
            English,
            French,
            Italian
        }

        public Languague CurrentLanguague;


        private void Awake()
        {
            // Check if an instance already exists, and destroy the duplicate
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void Start()
        {
            // Make the GameObject persist across scenes
            DontDestroyOnLoad(this.gameObject);
        }


        public void ChangeLanguague(Languague languague)
        {
            this.CurrentLanguague = languague;
            OnLanguageChanged?.Invoke();
        }

        public string GetWord(Languague type, string word)
        {
            if (dict.ContainsKey(word))
            {
                return dict[word].GetWord(type);
            }
            return "";
        }

        public string GetHowToPlayContent(Languague language)
        {
            switch (language)
            {
                default:
                case LanguageManager.Languague.English:
                    return "HOW TO PLAY\r\n\r\nYour goal is to find the numbers from smallest to largest as quickly as possible. You can also choose several difficulties to make it interesting for you!";
                case LanguageManager.Languague.French:
                    return "COMMENT JOUER\r\n\r\nVotre objectif est de trouver les nombres du plus petit au plus grand le plus rapidement possible. Vous pouvez egalement choisir plusieurs difficultes pour le rendre interessant pour vous !";
                case LanguageManager.Languague.Italian:
                    return "COME GIOCARE\r\n\r\nIl tuo obiettivo e trovare i numeri dal piu piccolo al piu grande il piu rapidamente possibile. Puoi anche scegliere diverse difficolta per renderlo interessante per te!";
            }
        }
    }

    public class WordDict
    {
        public string English;
        public string Frence;
        public string Italian;
        public string Norwegian;

        public WordDict(string english, string french, string italian)
        {
            English = english;
            Frence = french;
            Italian = italian;
        }

        public string GetWord(LanguageManager.Languague language)
        {
            switch (language)
            {
                default:
                case LanguageManager.Languague.English:
                    return English;
                case LanguageManager.Languague.French:
                    return Frence;
                case LanguageManager.Languague.Italian:
                    return Italian;
            }
        }     
    }
}
