#pragma warning disable 0649
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField] private Text _subtitleText;

        private void Awake()
        {
            gameObject.SetActive(false);
            _subtitleText.text = $"Level {SceneManager.GetActiveScene().buildIndex}";
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }
    }
}
