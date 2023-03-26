using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    void Update()
    {
        if (Time.timeScale == 0f)
        {
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene("Scene1");
                Time.timeScale = 1;
            }

        }

    }
}
