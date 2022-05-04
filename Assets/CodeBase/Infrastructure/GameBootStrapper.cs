using Assets.CodeBase.GameField;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure
{
    public class GameBootStrapper : MonoBehaviour
    {
        [SerializeField]
        private GameZone _gameZone;

        private Game _game;

        private void Awake()
        {
            _game = new Game(_gameZone);
        }
    }
}
