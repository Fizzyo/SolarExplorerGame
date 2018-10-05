using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
    public void quitbutton()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
