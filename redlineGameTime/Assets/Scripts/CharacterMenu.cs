using UnityEngine;
using UnityEngine.SceneManagement;
public class CharacterMenu : MonoBehaviour
{
    public void ChooseCon()
    {

        SceneManager.LoadScene(2);
        GameData.Instance.sideCheck = false;
    }

    public void ChooseUni()
    {
        GameData.Instance.sideCheck = true;
        SceneManager.LoadScene(2);
    }
}
