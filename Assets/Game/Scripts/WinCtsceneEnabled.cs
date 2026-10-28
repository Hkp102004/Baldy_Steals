using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCtsceneEnabled : MonoBehaviour
{
    [SerializeField] private GameObject BaldySmirk;


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(GameManager.KeyCardBaby == true)
            {
                BaldySmirk.SetActive(true);
            }
            else
            {
                Debug.LogError("You don't have the keycard yet boy or girl");
                return;
            }
        }
    }
}
