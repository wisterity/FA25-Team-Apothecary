using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // runs when we tap our Play button
    public void PlayGame()
    {
        // loads our first scene (rename to whatever your level is called)
        SceneManager.LoadScene("ShopScene");
    }
}

