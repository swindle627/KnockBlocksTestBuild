using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    // When a button is clicked the scene assigned to that button is loaded
    public void SwitchToScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
