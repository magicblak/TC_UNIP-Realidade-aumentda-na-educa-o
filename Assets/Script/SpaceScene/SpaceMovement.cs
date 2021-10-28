using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpaceMovement : MonoBehaviour
{

    public Vector3 calculeOrbit(int segments, int current_segment, float width, float height, float posz)
    {
        float posy, posx, angle;
        angle = ((float)current_segment / (float)segments) * 360 * Mathf.Deg2Rad;
        posx = Mathf.Sin(angle) * width;
        posy = Mathf.Cos(angle) * height;
        return new Vector3(posx, posy, posz);
    }

    public void rotationPlanet(Transform planet, Vector3 rotation_direction, int speed)
    {
        planet.Rotate(rotation_direction, speed * Time.deltaTime, Space.World);
    }
}
