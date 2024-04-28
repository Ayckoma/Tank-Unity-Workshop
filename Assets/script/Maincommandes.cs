using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Maincommandes : MonoBehaviour
{   
    public void QuitControls()
    {
        SceneManager.LoadScene(1);
    }
}
