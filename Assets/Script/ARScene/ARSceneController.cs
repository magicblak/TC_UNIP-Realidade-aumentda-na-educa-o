using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARSceneController : MonoBehaviour
{
    //Executa sempre que a classe for instanciada na cena, similar a um construtor
    void Awake()
    {
        string name = PlayerPrefs.GetString("name");//Pegando informação salva na memoria (Nome da cena a ser carregada)
        Instantiate(Resources.Load<GameObject>("Prefabs/" + name));//Instancia do molde da cena solicitada
        Screen.orientation = ScreenOrientation.Landscape;//Travando a tela como paisagem
    }
}
