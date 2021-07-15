using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpaceMovement : MonoBehaviour
{
    [SerializeField] private Transform planet;
    [SerializeField] private GameObject explain_text, other_text;
    [SerializeField] private VirtualButtonBehaviour button;
    private bool controller;
    [SerializeField] private int speed;
    [SerializeField] private Vector3 rotation_direction;

    // Start is called before the first frame update
    void Start()
    {
        controller = false;
        button.RegisterOnButtonPressed(onButtonPressed);
        button.RegisterOnButtonReleased(onButtonRealesed);
        explain_text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        rotationPlanet();
    }

    private void onButtonPressed(VirtualButtonBehaviour b)
    {
        controller = true;
        explain_text.SetActive(true);
        other_text.SetActive(false);
    }

    private void onButtonRealesed(VirtualButtonBehaviour b)
    {
        controller = false;
        explain_text.SetActive(false);
    }

    private void rotationPlanet()
    {
        if (!controller) return;
        planet.Rotate(rotation_direction, speed * Time.deltaTime, Space.World);
    }
}
