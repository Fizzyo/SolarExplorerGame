using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Breathing : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Finished());
    }

    IEnumerator Finished()
    {
        yield return new WaitForSeconds(150);
        SceneManager.LoadScene("Space 4");
    }

}

