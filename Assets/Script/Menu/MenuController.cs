using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    //Executa sempre que a classe for instanciada na cena, similar a um construtor
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;//Forçando o menu a ficar na orientação retrato
    }
}
