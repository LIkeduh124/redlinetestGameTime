using UnityEngine;
using UnityEngine.SceneManagement;

public class ConPress : MonoBehaviour
{
    public void PlayGame()
    {
        GameData.Instance.sideCheck = false;
        SceneManager.LoadScene(1);
    }
}
