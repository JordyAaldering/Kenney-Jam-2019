#pragma warning disable 0649
using Extensions;
using UnityEngine;

namespace UI
{
    public class RandomBackground : MonoBehaviour
    {
        [SerializeField] private Sprite[] _backgrounds;

        private void Awake()
        {
            GetComponent<SpriteRenderer>().sprite = _backgrounds.GetRandom();
        }
    }
}
