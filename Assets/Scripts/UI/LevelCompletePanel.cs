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
        }

        public void Continue()
        {
            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("BestLevel", currentIndex);
            SceneManager.LoadScene(currentIndex + 1);
        }

        public void Menu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
