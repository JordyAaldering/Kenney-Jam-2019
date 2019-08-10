#pragma warning disable 0649
using Extensions;
using UnityEngine;

namespace Utilities
{
    public class RandomSound : MonoBehaviour
    {
        [SerializeField] private AudioClip[] _sounds;

        private AudioSource _source;
        
        private void Awake()
        {
            _source = FindObjectOfType<AudioSource>();
        }

        public void Play()
        {
            _source.PlayOneShot(_sounds.GetRandom());
        }
    }
}
