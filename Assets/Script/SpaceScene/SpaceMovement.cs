using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpaceMovement : MonoBehaviour
{
    //Calculo de translação da terra
    public Vector3 calculeOrbit(int segments, int current_segment, float width, float height, float posz)
    {
        float posy, posx, angle;
        angle = ((float)current_segment / (float)segments) * 360 * Mathf.Deg2Rad;//Calcula anglo corrente baseado no numero de segmentos existentes
        posx = Mathf.Sin(angle) * width;//Calcula posição X baseada na largura
        posy = Mathf.Cos(angle) * height;//Calcula posição Y baseado na profundidade
        return new Vector3(posx, posy, posz);//Retorna posição para translação
    }

    //Rotação da terra
    public void rotationPlanet(Transform planet, Vector3 rotation_direction, int speed)
    {
        planet.Rotate(rotation_direction, speed * Time.deltaTime, Space.World);
    }
}
