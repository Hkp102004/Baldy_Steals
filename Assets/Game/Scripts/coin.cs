using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int time = 20; //initially after 20 secs the coin will dissapear
    void Start()
    {
        StartCoroutine(CoinDeletion(time));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator CoinDeletion(int time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
