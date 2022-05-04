using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.GameField.FieldCleaner
{
    public class CleanerHolder : MonoBehaviour
    {
        [SerializeField]
        private Cleaner _cleaner;

        private RaycastHit2D[] _hits;
        private readonly List<GameObject> _blocksToClean = new();
        private readonly Stack<int> _storeyToRegroup = new();

        public Action Collected;
        public Action GameEnded;

        public List<GameObject> BlocksToClean => _blocksToClean;
        public Stack<int> StoreyToRegroup => _storeyToRegroup;

        public int Lines { get; private set; }

        public void CleanField()
        {

            for (int storey = 0; storey <= 20; storey++)
            {
                _cleaner.CastRay(out _hits);
                _cleaner.DoStep();

                if (_hits.Length == 10)
                {
                    _storeyToRegroup.Push(storey);
                    CollectBlocksToDestroy();

                    Lines++;
                }
                else if (_hits.Length == 0)
                {
                    break;
                }

                CheckEndStorey(storey);
            }

            _cleaner.ToStartPosition();
            Collected?.Invoke();
        }


        private void CheckEndStorey(int storey)
        {
            if (storey == 20)
                GameEnded?.Invoke();
        }

        private void CollectBlocksToDestroy()
        {
            foreach (RaycastHit2D hit in _hits)
                _blocksToClean.Add(hit.collider.gameObject);
        }
    }
}