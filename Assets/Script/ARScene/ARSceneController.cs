using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        string name = PlayerPrefs.GetString("name");
        Instantiate(Resources.Load<GameObject>("Prefabs/" + name));
        Screen.orientation = ScreenOrientation.AutoRotation;
    }
}
