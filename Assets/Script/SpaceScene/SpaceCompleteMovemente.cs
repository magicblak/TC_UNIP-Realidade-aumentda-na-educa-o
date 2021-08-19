using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpaceCompleteMovemente : MonoBehaviour
{
    [SerializeField] private Transform earth;
    [SerializeField] private VirtualButtonBehaviour button;
    private bool controller;
    [SerializeField] private int speed_rotation, speed_translation;
    [SerializeField] private Vector3 rotation_direction, translation_direction;
    [SerializeField] private int segment;
    private int current_segment;
    // Start is called before the first frame update
    void Start()
    {
        current_segment = 0;
        controller = false;
        button.RegisterOnButtonPressed(onButtonPressed);
        button.RegisterOnButtonReleased(onButtonRealesed);
    }

    // Update is called once per frame
    void Update()
    {
        movimentPlanet();
    }

    private void onButtonPressed(VirtualButtonBehaviour b)
    {
        controller = true;
    }

    private void onButtonRealesed(VirtualButtonBehaviour b)
    {
        controller = false;
    }

    private void movimentPlanet()
    {
        if (!controller) return;
        earth.Rotate(rotation_direction, speed_rotation * Time.deltaTime, Space.World);
        earth.localPosition = SpaceMovement.calculeCircle(segment, current_segment);
        current_segment++;
        if (current_segment > segment) current_segment = 0;
    }
}
