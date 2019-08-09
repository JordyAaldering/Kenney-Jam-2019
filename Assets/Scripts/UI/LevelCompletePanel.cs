#pragma warning disable 0649
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class LevelCompletePanel : MonoBehaviour
    {
        [SerializeField] private Text _subtitleText;
        [SerializeField] private GameObject _continueButton;

        private void Awake()
        {
            transform.GetChild(0).gameObject.SetActive(false);
            _subtitleText.text = $"Level {SceneManager.GetActiveScene().buildIndex}";
        }

        public void Enable()
        {
            transform.GetChild(0).gameObject.SetActive(true);
            _continueButton.SetActive(SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCount);
        }

        public void Continue()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void Menu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
