using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    private List<string> categories;//Lista das categorias do menu
    [SerializeField] private Dropdown categories_menu;//Select de op��es do menu
    [SerializeField] private GameObject container;//� o container dos bot�es para entrar na cena RA
    [SerializeField] private GameObject button;//� o pr�-fabricado(modelo) do bot�o para acesso nas cenas RA
    [SerializeField] private Dictionary<string, ArrayList> scenes;//Guarda o vinculo de uma categoria com as cenas existentes

    //Executa sempre que a classe for instanciada na cena, similar a um construtor
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;//For�ando o menu a ficar na orienta��o retrato
        prepareCategoriesMenu();
        instanceDicionary();
    }

    //Adiciona as categorias na variavel definida
    private void prepareCategoriesMenu()
    {
        categories = new List<string>();//Instancia a lista
        categories.Add("Ci�ncia");//Adiciona categorias a lista
        categories.Add("Biologia");//Adiciona categorias a lista
        categories.Add("Geografia");//Adiciona categorias a lista
        categories_menu.AddOptions(categories);//Adiciona a lista de categorias no dropdown
        categories_menu.onValueChanged.AddListener(delegate
        {
            prepareButtons(categories_menu.captionText.text);
        });//Adiciona um ouvinte em um status do dropdown e adiciona uma a��o quando o evento for escutado
    }

    //Instancia o dicionario vinculando as cenas com suas devidas categorias
    private void instanceDicionary()
    {
        scenes = new Dictionary<string, ArrayList>();//Instanciando o dicionario
        ArrayList itens_menu = new ArrayList();//Instancia o arraylist que armazena as cenas das categorias
        itens_menu.Add("SpaceAR");//Vinculando cena no arraylist
        scenes.Add("Ci�ncia", itens_menu);//Vinculando a lista de cenas a categoria
        itens_menu = new ArrayList();//Reinstancia o arraylist
        itens_menu.Add("SkeletonAR");//Vinculando cena no arraylist
        scenes.Add("Biologia", itens_menu);//Vinculando a lista de cenas a categoria
        itens_menu = new ArrayList();//Reinstancia o arraylist
        itens_menu.Add("VolcanoAR");//Vinculando cena no arraylist
        scenes.Add("Geografia", itens_menu);//Vinculando a lista de cenas a categoria
    }

    //Alimenta e instancia o modelo de bot�es para link e carregamento da cena RA
    private void prepareButtons(string categoria)
    {
        //Varredura dos filhos presentes no container
        foreach (Transform child in container.transform)
        {
            DestroyImmediate(child.gameObject);//Destroi os objetos filhos ao container
        }

        //Verifica��o se a categoria possui cena
        if (scenes.ContainsKey(categoria))
        {
            ArrayList itens_menu = scenes[categoria];//Instancio um arraylist com as cenas da categoria selecionada
            //Varendo as cenas presentes na categoria selecionada
            for (int i = 0; i < itens_menu.Count; i++) 
            {
                button.GetComponent<ButtonController>().setSettings(itens_menu[i].ToString());//Configura o bot�o referente a cena corrente
                Instantiate(button, new Vector3(0, 0, 0), Quaternion.identity);//Instancia o bot�o na tela do unity
            }
        }
    }
}
