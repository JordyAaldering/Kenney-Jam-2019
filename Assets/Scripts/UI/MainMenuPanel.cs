using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenuPanel : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }

        public void ContinueGame()
        {
            int bestLevel = PlayerPrefs.GetInt("BestLevel", 1);
            SceneManager.LoadScene(bestLevel);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
