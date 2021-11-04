using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // LoadScene 에 사용

public class ClearDirector : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene("GameScene");
        }
    }
}
