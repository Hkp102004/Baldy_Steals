using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadingManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image progressBar;

    void Start()
    {
        StartCoroutine(LoadLevelAsync());
    }

    IEnumerator LoadLevelAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Main");

        while(operation.isDone == false)
        {
            progressBar.fillAmount = operation.progress;
            yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(2);
        }
    }
}
