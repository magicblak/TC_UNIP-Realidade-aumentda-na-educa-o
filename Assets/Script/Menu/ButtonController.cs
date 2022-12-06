using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject button_obj;//Armazena o proprio objeto botão
    private Button button;//Armazena o componente button do objeto
    [SerializeField] public string name_obj;//Guarda o nome do objeto (nome da cena, botão e imagem)
    [SerializeField] private string password = "";//Guarda o nome do objeto (nome da cena, botão e imagem)
    [SerializeField] private InputField input_pass;

    //Executa sempre que a classe for instanciada na cena, similar a um construtor
    void Start()
    {
        button = button_obj.GetComponent<Button>();//Instancia do componenete button baseado no componente do proprio objeto
        button.onClick.AddListener(clickButton);//Adicionando um ouvinte de evento de clique
    }

    //Ação do click
    private void clickButton()
    {
        if (input_pass != null)
        {
            if (input_pass.text != password) return;
        }
        //Carregar a cena com informações de ambiente
        PlayerPrefs.SetString("name", name_obj);//Salva na memoria uma variavel name com o valor do nome do objeto
        SceneManager.LoadScene(1, LoadSceneMode.Single);//Realiza o carregamento da cena RA
    }
}
