using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnButton : MonoBehaviour
{
    [SerializeField] private Button returner;//Botão para retornar ao menu
    //Executa sempre que a classe for instanciada na cena, similar a um construtor
    private void Start()
    {
        returner.onClick.AddListener(returnerClick);//Evento de clique
	}

    void returnerClick()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);//Retorno para cena do menu
    }
}
