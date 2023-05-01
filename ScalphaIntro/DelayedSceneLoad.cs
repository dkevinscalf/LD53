using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayedSceneLoad : MonoBehaviour
{
    public float Delay = 3f;
    public string SceneName;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadCR());
    }

    private IEnumerator LoadCR()
    {
        yield return new WaitForSeconds(Delay);
        if (string.IsNullOrEmpty(SceneName))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        else
            SceneManager.LoadScene(SceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
