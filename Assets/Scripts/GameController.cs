using Player;
using UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1f;
    }

    public static void LevelComplete()
    {
        FindObjectOfType<LevelCompletePanel>().Enable();
        FindObjectOfType<InputController>().enabled = false;
        Time.timeScale = 0.1f;
    }

    public static void GameOver()
    {
        FindObjectOfType<LevelCompletePanel>().Enable();
        FindObjectOfType<InputController>().enabled = false;
        Time.timeScale = 0.1f;
    }
}
