using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void Scenes(int index) 
    {
        SceneManager.LoadScene(index);
    }
}
