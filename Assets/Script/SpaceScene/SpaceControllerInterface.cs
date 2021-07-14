using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceControllerInterface : MonoBehaviour
{
    [SerializeField] private GameObject movement_button, rotation_button, translation_button, rotation_text, translation_text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verifyCompleteMovementButtom();
    }

    private void verifyCompleteMovementButtom()
    {
        if (rotation_text.activeSelf || translation_text.activeSelf) movement_button.SetActive(false);
        else movement_button.SetActive(true);
    }
}
