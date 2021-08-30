using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class EmphasisController : MonoBehaviour
{
    [SerializeField] private VirtualButtonBehaviour emphasis_buttom;
    [SerializeField] private GameObject emphasis_object;
    // Start is called before the first frame update
    void Start()
    {
        emphasis_buttom.RegisterOnButtonPressed(onEmphasisButtonPressed);
        emphasis_buttom.RegisterOnButtonReleased(onEmphasisButtonRealesed);
    }

    private void onEmphasisButtonPressed(VirtualButtonBehaviour b)
    {
        emphasis_object.SetActive(true);
    }

    private void onEmphasisButtonRealesed(VirtualButtonBehaviour b)
    {
        emphasis_object.SetActive(false);
    }
}
