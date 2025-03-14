using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void LoadGameScene(int SceneNumber)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneNumber);
    }

}
