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
    [SerializeField] private int segment;
    [SerializeField] private bool is_orbit;
    private int current_segment;


    // Start is called before the first frame update
    void Start()
    {
        controller = false;
        button.RegisterOnButtonPressed(onButtonPressed);
        button.RegisterOnButtonReleased(onButtonRealesed);
        explain_text.SetActive(false);
        current_segment = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!is_orbit) rotationPlanet();
        else orbitPlanet();
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

    private void orbitPlanet()
    {
        if (!controller) return;
        planet.localPosition = calculeCircle(segment, current_segment);
        current_segment++;
        Debug.Log(current_segment);
        if (current_segment > segment) current_segment = 0;
    }

    public static Vector3 calculeCircle(int segments, int current_segment)
    {
        float posy, posx, angle;
        float yaxis = 25, xaxis = 30;
        angle = ((float)current_segment / (float)segments) * 360 * Mathf.Deg2Rad;
        posy = Mathf.Cos(angle) * yaxis;
        posx = Mathf.Sin(angle) * xaxis;
        return new Vector3(posx, posy, 9.49f);
    }

    private void rotationPlanet()
    {
        if (!controller) return;
        planet.Rotate(rotation_direction, speed * Time.deltaTime, Space.World);
    }
}
