using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManger : MonoBehaviour
{
   public void PlayScene() {
        
        SceneManager.LoadScene(1);

    }
    public void HomeScene() {
        SceneManager.LoadScene(0);
    }

    public void HowScene()
    {
        SceneManager.LoadScene(2);
    }
}
