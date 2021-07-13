using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class BasicAnimation : MonoBehaviour
{
    public Transform earth;
    public VirtualButtonBehaviour button;
    private bool isrotating = false;
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
        isrotating = true;
    }

    void onButtonRealesed(VirtualButtonBehaviour b)
    {
        Debug.Log("Parou de acionar!");
        isrotating = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isrotating)
            earth.Rotate(Vector3.up, speed * Time.deltaTime, Space.World);
    }
}
