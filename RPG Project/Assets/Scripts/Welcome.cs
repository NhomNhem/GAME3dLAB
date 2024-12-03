using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Welcome : MonoBehaviour
{
    public float delayTime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        // sau 3s chuyển sang scene Login
        Invoke("ChangeScene", delayTime);
    }

    // Update is called once per frame
    void ChangeScene()
    {
        // chuyển scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Login");
    }
}
