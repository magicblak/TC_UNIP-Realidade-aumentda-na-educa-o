using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string name = PlayerPrefs.GetString("name");
        Debug.Log(name);
        Instantiate(Resources.Load("Assets/Prefabs/SpaceAR"));
    }
}
