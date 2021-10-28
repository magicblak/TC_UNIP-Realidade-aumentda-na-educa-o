using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoriesController : MonoBehaviour
{
    [SerializeField] private GameObject categories_button_obj;//GameObject do botão categoria
    private Button categories_button;//Botão categoria
    [SerializeField] private GameObject categories_container;//Container de botões para redirecionamento da cena AR


    //Executa sempre que a classe for instanciada na cena, similar a um construtor
    void Start()
    {
        categories_button = categories_button_obj.GetComponent<Button>();//Instancia do componenete button baseado no componente do proprio objeto
        Screen.orientation = ScreenOrientation.Portrait;//Forçando o menu a ficar na orientação retrato
        categories_button.onClick.AddListener(clickButtonCategories);//Adicionando um ouvinte de evento de clique
    }
    //Ação do click
    private void clickButtonCategories()
    {
        foreach (Transform child in categories_container.transform)
        {
            if (categories_button.name == child.name) child.gameObject.SetActive(true);
            else child.gameObject.SetActive(false);
        }
    }
}
