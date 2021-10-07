using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Text txt_button;//Armazenar o texto do bot�o
    [SerializeField] private GameObject button_obj;//Armazena o proprio objeto bot�o
    [SerializeField] private Image image;//Armazena a imagem presente no bot�o
    private Button button;//Armazena o componente button do objeto
    private GameObject container;//Armazena o container onde o bot�o sera instanciado
    public string name_obj;//Guarda o nome do objeto (nome da cena, bot�o e imagem)

    //Executa sempre que a classe for instanciada na cena, similar a um construtor
    void Start()
    {
        button = button_obj.GetComponent<Button>();//Instancia do componenete button baseado no componente do proprio objeto
        container = GameObject.Find("buttons_container");//Instanciando o container com o gameobject referenciado
        int posy = 630;//Posi��o y inicial para proje��o do bot�o
        int height = 290;//Altura para proje��o do bot�o com margem
        posy -= (height * container.transform.childCount);//Calculo para posicionamento do bot�o baseado no numero de filhos presentes no container
        button_obj.transform.SetParent(container.transform);//Vinculando o bot�o (objeto) ao container
        button.onClick.AddListener(clickButton);//Adicionando um ouvinte de evento de clique
        button_obj.GetComponent<RectTransform>().localPosition = new Vector3(24, posy, 0);//Defino a posi��o do meu bot�o baseado na posi��o do pai
        Sprite demo_image = Resources.Load<Sprite>("sprites/" + name_obj);//Carrega a imagem target da cena
        image.sprite = demo_image;//Instancia o sprite da imagem com o valor carregado
        button_obj.GetComponent<RectTransform>().localScale = Vector3.one;//Padronizo o tamanho do bot�o
    }

    //A��o do click
    private void clickButton()
    {
        //Carregar a cena com informa��es de ambiente
        PlayerPrefs.SetString("name", name_obj);//Salva na memoria uma variavel name com o valor do nome do objeto
        SceneManager.LoadScene(1, LoadSceneMode.Single);//Realiza o carregamento da cena RA
    }

    //Atribui as configura��es do bot�o
    public void setSettings(string name_txt)
    {
        name_obj = name_txt;//Atribui o nome do objeto
        button_obj.name = name_obj;//Atribui no nome do objeto na cena unity
        txt_button.text = name_obj;//Atribui o texto do bot�o
    }
}
