using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAnimation : MonoBehaviour
{
    public bool comeca = false;
    public bool validation = true;
    public Transform x;
    Vector3 pos, posinicial;
    // Start is called before the first frame update
    void Start()
    {
        posinicial = x.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!comeca) return;
        pos = x.position;
        x.Rotate(0, 1, 0.0f, Space.Self);
        if (x.position.y < -1)
            validation = true;
        else if (x.position.y > 0)
            validation = false;
        if (validation)
            pos.y += 0.001f;
        else
            pos.y -= 0.001f;
        x.position = pos;
    }
}
