using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("stage1");
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }
}
