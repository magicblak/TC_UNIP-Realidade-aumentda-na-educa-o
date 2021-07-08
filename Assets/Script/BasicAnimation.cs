using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class BasicAnimation : MonoBehaviour
{
    public GameObject ball;
    public VirtualButtonBehaviour button;
    Vector3 posinicial;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        posinicial = ball.transform.position;
        button.RegisterOnButtonPressed(onButtonPressed);
        button.RegisterOnButtonReleased(onButtonRealesed);
        rb = ball.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    void onButtonPressed(VirtualButtonBehaviour b)
    {
        Debug.Log("Pressiona");
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void onButtonRealesed(VirtualButtonBehaviour b)
    {
        Debug.Log("Não Pressiona");
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        ball.transform.localPosition = posinicial;
    }
}
