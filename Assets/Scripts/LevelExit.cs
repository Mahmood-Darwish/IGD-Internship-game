using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public string NextLevel;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
            SceneManager.LoadScene(NextLevel);
    }
}
