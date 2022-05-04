using CodeBase.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeBase.GameField.TopZone
{
    public class NextFigureShower : MonoBehaviour
    {
        public Image NextFigureImage;
        public List<Sprite> Sprites;

        private GameFactory _gameFactory;

        public void Construct(GameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            _gameFactory.NextFigureChanged += ShowNextFigure;
        }

        private void OnDestroy() =>
            _gameFactory.NextFigureChanged -= ShowNextFigure;

        private void ShowNextFigure() => 
            NextFigureImage.sprite = Sprites.First(x => x.name == _gameFactory.NextFigureName);
    }
}