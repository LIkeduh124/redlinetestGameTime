using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //A script made to open the Scene of the gameplay, once pressed.
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
}
