using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpaceControllerInterface : MonoBehaviour
{
    [SerializeField] private GameObject complete_movement_button;
    [SerializeField] private GameObject rotation_button;
    [SerializeField] private GameObject translation_button;
    [SerializeField] private GameObject rotation_text;
    [SerializeField] private GameObject translation_text;
    [SerializeField] private Transform sun;
    [SerializeField] private Vector3 sun_rotation_direction;
    [SerializeField] private int sun_rotation_velocity;
    [SerializeField] private Transform earth;
    [SerializeField] private Vector3 earth_rotation_direction;
    [SerializeField] private int earth_rotation_velocity;
    [SerializeField] private int segments;
    [SerializeField] private int current_segment;
    [SerializeField] private float earth_translation_with;
    [SerializeField] private float earth_translation_height;
    private SpaceMovement movimenter;
    [SerializeField] private bool stop;
    private bool do_earth_complete_movement;
    private bool do_earth_rotation;
    private bool do_earth_translation;
    // Start is called before the first frame update
    void Start()
    {
        do_earth_complete_movement = false;
        do_earth_rotation = false;
        do_earth_translation = false;
        movimenter = new SpaceMovement();
        complete_movement_button.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(onCompleteMovementButtonPressed);
        complete_movement_button.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(onCompleteMovementButtonRealesed);
        rotation_button.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(onRotationButtonPressed);
        rotation_button.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(onRotationButtonRealesed);
        translation_button.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(onTranslationButtonPressed);
        translation_button.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(onTranslationButtonRealesed);
    }

    private void onCompleteMovementButtonPressed(VirtualButtonBehaviour b)
    {
        if (do_earth_rotation || do_earth_translation) return;
        do_earth_complete_movement = true;
        rotation_button.SetActive(false);
        translation_button.SetActive(false);
    }

    private void onCompleteMovementButtonRealesed(VirtualButtonBehaviour b)
    {
        if (do_earth_rotation || do_earth_translation) return;
        do_earth_complete_movement = false;
        rotation_button.SetActive(true);
        translation_button.SetActive(true);
    }

    private void onRotationButtonPressed(VirtualButtonBehaviour b)
    {
        if (do_earth_complete_movement || do_earth_translation) return;
        do_earth_rotation = true;
        rotation_text.SetActive(true);
        complete_movement_button.SetActive(false);
        translation_button.SetActive(false);
    }

    private void onRotationButtonRealesed(VirtualButtonBehaviour b)
    {
        if (do_earth_complete_movement || do_earth_translation) return;
        do_earth_rotation = false;
        rotation_text.SetActive(false);
        complete_movement_button.SetActive(true);
        translation_button.SetActive(true);
    }

    private void onTranslationButtonPressed(VirtualButtonBehaviour b)
    {
        if (do_earth_complete_movement || do_earth_rotation) return;
        do_earth_translation = true;
        translation_text.SetActive(true);
        complete_movement_button.SetActive(false);
        rotation_button.SetActive(false);
    }

    private void onTranslationButtonRealesed(VirtualButtonBehaviour b)
    {
        if (do_earth_complete_movement || do_earth_rotation) return;
        do_earth_translation = false;
        translation_text.SetActive(false);
        complete_movement_button.SetActive(true);
        rotation_button.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        actions();
    }

    private void actions()
    {
        if (stop) return;
        sunRotation();
        if (do_earth_complete_movement) earthCompleteMovement();
        if (do_earth_rotation) earthRotation();
        if (do_earth_translation) earthTranslation();
    }

    private void sunRotation()
    {
        movimenter.rotationPlanet(sun, sun_rotation_direction, sun_rotation_velocity);
    }

    private void earthRotation()
    {
        movimenter.rotationPlanet(earth, earth_rotation_direction, earth_rotation_velocity);
    }

    private void earthTranslation()
    {
        Vector3 translation_position = movimenter.calculeOrbit(segments, current_segment, earth_translation_with, earth_translation_height, earth.localPosition.z);
        Debug.Log(translation_position);
        earth.localPosition = translation_position;
        current_segment++;
        if (current_segment > segments) current_segment = 0;
    }

    private void earthCompleteMovement()
    {
        earthRotation();
        earthTranslation();
    }
}
