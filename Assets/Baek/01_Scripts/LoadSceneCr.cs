using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneCr : MonoBehaviour
{
  public void NextScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
