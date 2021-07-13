using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Translation : MonoBehaviour
{
    public Transform sun;
    public VirtualButtonBehaviour button;
    private bool istranslating = false;
    public int speed = 10;

    // Start is called before the first frame update
    void Start()
    {

        button.RegisterOnButtonPressed(onButtonPressed);
        button.RegisterOnButtonReleased(onButtonRealesed);

    }

    void onButtonPressed(VirtualButtonBehaviour b)
    {
        Debug.Log("Acionou!");
        istranslating = true;
    }

    void onButtonRealesed(VirtualButtonBehaviour b)
    {
        Debug.Log("Parou de acionar!");
        istranslating = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (istranslating)
            sun.Rotate(Vector3.up, speed * Time.deltaTime, Space.World);
    }
}
