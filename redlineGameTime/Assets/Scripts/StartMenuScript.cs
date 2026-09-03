using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlayGame()
    {
        Debug.Log("Game Start button pressed");
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        // Logs a message in the console to prove it works while inside the Editor
        Debug.Log("Player has quit the game!");

#if UNITY_EDITOR
        // This stops play mode if you are testing inside the Unity Editor
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        // This closes the actual built application (.exe, .app, etc.)
        Application.Quit();

    }
}
