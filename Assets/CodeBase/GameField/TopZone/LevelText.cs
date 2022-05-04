using TMPro;
using UnityEngine;

namespace Assets.CodeBase.GameField.TopZone
{
    public class LevelText : MonoBehaviour
    {
        public TMP_Text Level;

        public void UpdateLevel(int lines) =>
            Level.text = $"{lines + 1}";
    }
}