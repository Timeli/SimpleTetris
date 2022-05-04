using Assets.CodeBase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameFactory
    {
        private const string PathToFigures = "Prefabs/Figures";
        private const string Spawn = "Spawn";
        
        private readonly List<GameObject> _figurePrefabs = new();
        private readonly Queue<GameObject> _figuresQueue = new();
        private readonly RandomService _random = new();

        private readonly Transform _spawnPoint;

        public Action NextFigureChanged;

        public GameFactory()
        {
            _figurePrefabs = LoadObjects();
            InitialQueue();
            _spawnPoint = GameObject.FindGameObjectWithTag(Spawn).transform;
        }

        public string NextFigureName { get; private set; }

        private void InitialQueue()
        {
            Enqueue();
            Enqueue();
        }

        private void Enqueue() => 
            _figuresQueue.Enqueue(_figurePrefabs[_random.GetRandom(0, _figurePrefabs.Count)]);

        public GameObject CreateFigure()
        {
            GameObject figure = _figuresQueue.Dequeue();
            
            Enqueue();

            NextFigureName = _figuresQueue.ElementAt(0).name;
            NextFigureChanged?.Invoke();

            return GameObject.Instantiate(figure, _spawnPoint);
        }

        private List<GameObject> LoadObjects() =>
            Resources.LoadAll(PathToFigures).OfType<GameObject>().ToList();
    }
}