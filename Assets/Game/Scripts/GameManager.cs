using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance {get; set;}

    public void Awake()
    {
        instance = this;
    }

    public static bool KeyCardBaby{get; set;}
}

