using System.IO;
using UnityEngine;

namespace Assets.CodeBase.Data
{
    public class SaverService
    {
        private const string Postfix = "SaveInfo.json";

        public int CurrentBestScore { get; private set; }

        public void ResetScore() =>
            SaveBestScore(0);

        public void SaveBestScore(int score)
        {
            SaveInfo saveInfo = new();
            saveInfo.BestScore = score;

            string json = JsonUtility.ToJson(saveInfo);
            File.WriteAllText(Path.Combine(Application.persistentDataPath, Postfix), json);
        }

        public void LoadSaveFile()
        {
            string path = Path.Combine(Application.persistentDataPath, Postfix);
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                SaveInfo saveInfo = JsonUtility.FromJson<SaveInfo>(json);

                CurrentBestScore = saveInfo.BestScore;
            }
        }
    }
}
