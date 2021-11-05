using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContainerPage : MonoBehaviour
{
    [SerializeField] private GameObject container_button_obj;//Gameobject do botão para abrir e fechar o container
    [SerializeField] private GameObject container_page;//Pagina com as informações
    [SerializeField] private GameObject button_info;//botão referência para habilitar
    private static GameObject ref_obj;//Refência para habilitar e desabilitar
    private Button container_button;//Botão que chama a página de créditos
    //Executa sempre que a classe for instanciada na cena, similar a um construtor
    private void Start()
    {
        container_button = container_button_obj.GetComponent<Button>();//Pegando o componente de botão
        container_button.onClick.AddListener(clickButtonCredit);//Adicionando evento de clique
    }

    void clickButtonCredit()
    {
        if (ref_obj == null) ref_obj = button_info;//Controla o objeto a ser habilitado nos containers
        container_page.SetActive(!container_page.activeSelf);//Mostrando a tela de container
        if (ref_obj != null)
        {
            ref_obj.SetActive(container_page.activeSelf);//Mostrando o botão na tela de container
        }
        ref_obj = button_info;
    }
}