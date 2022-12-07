using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("image_days_count").SetActive(false);
    }
}
