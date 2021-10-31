using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditPage : MonoBehaviour
{
    [SerializeField] private GameObject credit_button_obj;//Gameobject do bot�o cr�ditos
    [SerializeField] private GameObject credit_page;//Pagina com as informa��es de creditos
    private Button credit_button;//Bot�o que chama a p�gina de cr�ditos
    //Executa sempre que a classe for instanciada na cena, similar a um construtor
    void Start()
    {
        credit_button = credit_button_obj.GetComponent<Button>();//Pegando o componente de bot�o
        credit_button.onClick.AddListener(clickButtonCredit);//Adicionando evento de clique
    }

    void clickButtonCredit()
    {
        credit_page.SetActive(!credit_page.activeSelf);//Mostrando a tela de cr�ditos
    }
}
