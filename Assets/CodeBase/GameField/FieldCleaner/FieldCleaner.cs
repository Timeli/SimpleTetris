using System;
using System.Collections;
using UnityEngine;

namespace Assets.CodeBase.GameField.FieldCleaner
{
    public class FieldCleaner : MonoBehaviour
    {
        [SerializeField]
        private CleanerHolder _cleanerHolder;

        public AudioSource AudioSource;
        public AudioClip FallAudio;
        public AudioClip DestroyAudio;

        private WaitForFixedUpdate _waitForFixedUpdate;

        public Action DestroyEnded;

        private void Start()
        {
            _waitForFixedUpdate = new WaitForFixedUpdate();
            _cleanerHolder.Collected += InitCleanField;
        }

        private void OnDestroy() =>
            _cleanerHolder.Collected -= InitCleanField;

        public void InitCleanField()
        {
            AudioSource.PlayOneShot(FallAudio, 1f);

            StartCoroutine(CleanField());
        }

        public IEnumerator CleanField()
        {
            AudioSource.clip = DestroyAudio;

            for (int i = 0; i < _cleanerHolder.BlocksToClean.Count; i++)
            {
                if (i % 10 == 0)
                    AudioSource.PlayOneShot(DestroyAudio, 0.21f);

                GameObject block = _cleanerHolder.BlocksToClean[i];
                Destroy(block);
                yield return _waitForFixedUpdate;
                
            }
            _cleanerHolder.BlocksToClean.Clear();

            DestroyEnded?.Invoke();
        }
    }
}