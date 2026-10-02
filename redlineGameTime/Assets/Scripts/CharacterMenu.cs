using UnityEngine;
using UnityEngine.SceneManagement;
public class CharacterMenu : MonoBehaviour
{
    public void ChooseCon()
    {

        SceneManager.LoadScene(3);
        GameData.Instance.sideCheck = false;
    }

    public void ChooseUni()
    {
        GameData.Instance.sideCheck = true;
        SceneManager.LoadScene(3);
    }
}
