using Assets.CodeBase.Infrastructure.States;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.GameField.Storeys
{
    public class StoreySetter : MonoBehaviour
    {
        private const int MaxStorey = 19;

        public Transform StartingPoint;

        public List<Storey> Storeys;

        public void SetParentFor(GameObject block)
        {
            block.transform.SetParent(StartingPoint);
            int storey = CalculateStorey(block);

            if (storey > MaxStorey)
                return;

            block.transform.SetParent(Storeys[(int)storey].transform);
        }

        private static int CalculateStorey(GameObject block) =>
            (int)Math.Round(block.transform.localPosition.y) / Constants.FigureSize;
    }
}