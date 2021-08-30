using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class EmphasisController : MonoBehaviour
{
    [SerializeField] private VirtualButtonBehaviour emphasis_buttom;
    [SerializeField] private GameObject emphasis_object;
    [SerializeField] private TextMesh emphasis_text;
    private static bool general_controller = false;
    private bool local_controller;
    // Start is called before the first frame update
    void Start()
    {
        local_controller = false;
        emphasis_buttom.RegisterOnButtonPressed(onEmphasisButtonPressed);
        emphasis_buttom.RegisterOnButtonReleased(onEmphasisButtonRealesed);
    }

    private void onEmphasisButtonPressed(VirtualButtonBehaviour b)
    {
        if (EmphasisController.general_controller) return;
        EmphasisController.general_controller = true;
        local_controller = true;
        emphasis_object.SetActive(true);
        emphasis_text.color = new Color32(255, 54, 54, 255);
    }

    private void onEmphasisButtonRealesed(VirtualButtonBehaviour b)
    {
        if (!local_controller) return;
        EmphasisController.general_controller = false;
        local_controller = false;
        emphasis_object.SetActive(false);
        emphasis_text.color = new Color32(255, 255, 255, 255);
    }
}
