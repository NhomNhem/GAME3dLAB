using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class Register : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_InputField nameInput;
    
    public void GoToLogin()
    {
        // chuyển scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Login");
    }
    
    public void OnRegisterClick()
    {
        // lấy dữ liệu từ input
        var email = emailInput.text;
        var password = passwordInput.text;
        var name = nameInput.text;

        var Account = new Account
        {
            Email = email,
            Password = password,
            Name = name
        };

        var json = JsonUtility.ToJson(Account);
      //  Debug.Log(json);
        StartCoroutine(Post(json));
    }

    IEnumerator Post(string json)
    {
        var url = "https://localhost:44343/api/register";
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
        request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if(request.result == UnityWebRequest.Result.ConnectionError ||
           request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("POST Error: " + request.error);
            Debug.Log(request.downloadHandler.text);
        }
        else
        {
            var response = JsonUtility.FromJson<RegisterModelResponse>(request.downloadHandler.text);
            Debug.Log(response.status);
            if (response.status)
            {
                Debug.Log("Register success");
                Debug.Log(response.data.Email);
                Debug.Log(response.data.Name);
            }
            else
            {
                Debug.Log("Register fail");
                Debug.Log(response.data.Email);
                Debug.Log(response.data.Name);

            }
        }
    }
    
}
