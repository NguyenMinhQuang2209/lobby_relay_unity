using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : NetworkBehaviour
{
    public static SceneController instance;

    public enum SceneName
    {
        Lobby,
        Map_1
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    public void ChangeSceneNetwork(SceneName name, bool single = true)
    {
        if (single)
        {
            NetworkManager.SceneManager.LoadScene(name.ToString(), LoadSceneMode.Single);
        }
        else
        {
            NetworkManager.SceneManager.LoadScene(name.ToString(), LoadSceneMode.Additive);
        }
    }

    public void ChangeScene(SceneName name, bool single = true)
    {
        if (single)
        {
            SceneManager.LoadScene(name.ToString(), LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene(name.ToString(), LoadSceneMode.Additive);
        }
    }

    [ServerRpc]
    public void StartSceneServerRpc(SceneName name, bool single = true)
    {
        if (single)
        {
            NetworkManager.SceneManager.LoadScene(name.ToString(), LoadSceneMode.Single);
        }
        else
        {
            NetworkManager.SceneManager.LoadScene(name.ToString(), LoadSceneMode.Additive);
        }
    }

}
