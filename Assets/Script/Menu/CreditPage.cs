using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditPage : MonoBehaviour
{
    [SerializeField] private GameObject credit_button_obj;//Gameobject do botão créditos
    [SerializeField] private GameObject credit_page;//Pagina com as informações de creditos
    private Button credit_button;//Botão que chama a página de créditos
    //Executa sempre que a classe for instanciada na cena, similar a um construtor
    void Start()
    {
        credit_button = credit_button_obj.GetComponent<Button>();//Pegando o componente de botão
        credit_button.onClick.AddListener(clickButtonCredit);//Adicionando evento de clique
    }

    void clickButtonCredit()
    {
        credit_page.SetActive(!credit_page.activeSelf);//Mostrando a tela de créditos
    }
}
