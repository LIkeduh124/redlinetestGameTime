using UnityEngine;
using UnityEngine.SceneManagement;
public class UnionPress : MonoBehaviour
{
    public void PlayGame()
    {
        GameData.Instance.sideCheck = true;
        SceneManager.LoadScene(1);
    }
}
