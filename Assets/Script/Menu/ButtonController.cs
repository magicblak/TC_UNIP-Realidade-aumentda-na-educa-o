using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Text txt_button;
    [SerializeField] private GameObject button_obj;
    private Button button;
    private GameObject container;
    public string name_obj;
    // Start is called before the first frame update
    void Start()
    {
        button = button_obj.GetComponent<Button>();
        container = GameObject.Find("buttons_container");
        int posy = 220;
        int height = 30;
        posy += (height * container.transform.childCount);
        button_obj.transform.SetParent(container.transform);
        button.onClick.AddListener(clickButton);
    }

    private void clickButton()
    {
        //Carregar a cena com informa��es de ambiente
        Debug.Log(name_obj);
        PlayerPrefs.SetString("name", name_obj);
        SceneManager.LoadScene(1);
    }

    public void setName(string name_txt)
    {
        name_obj = name_txt;
        button_obj.name = name_obj;
        txt_button.text = name_obj;
    }
}
