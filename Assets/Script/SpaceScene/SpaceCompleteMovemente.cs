using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpaceCompleteMovemente : MonoBehaviour
{
    [SerializeField] private Transform earth, sun;
    [SerializeField] private VirtualButtonBehaviour button;
    private bool controller;
    [SerializeField] private int speed_rotation, speed_translation;
    [SerializeField] private Vector3 rotation_direction, translation_direction;
    // Start is called before the first frame update
    void Start()
    {
        controller = false;
        button.RegisterOnButtonPressed(onButtonPressed);
        button.RegisterOnButtonReleased(onButtonRealesed);
    }

    // Update is called once per frame
    void Update()
    {
        rotationPlanet();
    }

    private void onButtonPressed(VirtualButtonBehaviour b)
    {
        controller = true;
    }

    private void onButtonRealesed(VirtualButtonBehaviour b)
    {
        controller = false;
    }

    private void rotationPlanet()
    {
        if (!controller) return;
        earth.Rotate(rotation_direction, speed_rotation * Time.deltaTime, Space.World);
        sun.Rotate(translation_direction, speed_translation * Time.deltaTime, Space.World);
    }
}
