using Assets.CodeBase.GameField.FieldCleaner;
using Assets.CodeBase.Infrastructure.States;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.GameField.Storeys
{
    public class StoreyLogic : MonoBehaviour
    {
        private List<Storey> _storeys;
        private Stack<int> _storeyToRegroup;
        private Block[] _blocks;

        private Transform _parentStorey;

        public void Initialize(CleanerHolder cleanerHolder, StoreySetter storeySetter)
        {
            _storeys = storeySetter.Storeys;
            _parentStorey = storeySetter.transform;
            _storeyToRegroup = cleanerHolder.StoreyToRegroup;
        }

        public void Regroup()
        {
            while (_storeyToRegroup.Count > 0)
            {
                int storey = _storeyToRegroup.Pop() + 1;

                _blocks = _storeys[storey].GetComponentsInChildren<Block>();

                ChangeParentForStoreys(storey);

                TargetStoreyMoveDown(storey);

                ChangeParentForBlocks(storey);

                RetriveParentForStoreys(storey);

                TargetStoreyMoveToTopLevel(storey);
            }
        }

        private void RetriveParentForStoreys(int storey)
        {
            for (int s = storey + 1; s < _storeys.Count; s++)
                _storeys[s].transform.SetParent(_parentStorey);
        }

        private void ChangeParentForBlocks(int storey)
        {
            foreach (Block block in _blocks)
                block.transform.SetParent(_storeys[storey - 1].transform);
        }

        private void TargetStoreyMoveDown(int storey)
        {
            Transform targetStorey = _storeys[storey].transform;

            targetStorey.localPosition = new Vector2(targetStorey.localPosition.x,
                                                     targetStorey.localPosition.y - Constants.FigureSize);
        }

        private void ChangeParentForStoreys(int storey)
        {
            for (int s = storey + 1; s < _storeys.Count; s++)
                _storeys[s].transform.SetParent(_storeys[storey].transform);
        }

        private void TargetStoreyMoveToTopLevel(int storey)
        {
            Storey Level = _storeys[storey];

            _storeys.RemoveAt(storey);

            Level.transform.localPosition = new Vector2(Level.transform.localPosition.x, Constants.MaxPosYForLevel);

            _storeys.Add(Level);
        }
    }
}
