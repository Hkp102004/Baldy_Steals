using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager instance; //making a singleton

    public static UIManager Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.LogError("Instance is null in UImanager");
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }
}
