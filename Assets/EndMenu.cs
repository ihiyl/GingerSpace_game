using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    public void End()
    {
        SceneManager.LoadScene(0);
    }
}
