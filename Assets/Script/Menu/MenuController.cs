using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    private List<string> categories;
    [SerializeField] private Dropdown categories_menu;
    [SerializeField] private GameObject container, button;
    [SerializeField] private Dictionary<string, ArrayList> scenes;
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        prepareCategoriesMenu();
        instanceDicionary();
    }

    private void prepareCategoriesMenu()
    {
        categories = new List<string>();
        categories.Add("Ciência");
        categories.Add("Biologia");
        categories.Add("Geografia");
        categories_menu.AddOptions(categories);
        categories_menu.onValueChanged.AddListener(delegate
        {
            prepareButtons(categories_menu.captionText.text);
        });
    }

    private void instanceDicionary()
    {
        ArrayList itens_menu = new ArrayList();
        itens_menu.Add("SpaceAR");
        scenes = new Dictionary<string, ArrayList>();
        scenes.Add("Ciência", itens_menu);
        itens_menu = new ArrayList();
        itens_menu.Add("SkeletonAR");
        scenes.Add("Biologia", itens_menu);
        itens_menu = new ArrayList();
        itens_menu.Add("VolcanoAR");
        scenes.Add("Geografia", itens_menu);
    }

    private void prepareButtons(string categoria)
    {
        foreach (Transform child in container.transform)
        {
            DestroyImmediate(child.gameObject);
        }

        if (scenes.ContainsKey(categoria))
        {
            ArrayList itens_menu = scenes[categoria];
            for (int i = 0; i < itens_menu.Count; i++) 
            {
                button.GetComponent<ButtonController>().setSettings(itens_menu[i].ToString());
                Instantiate(button, new Vector3(0, 0, 0), Quaternion.identity);
            }
        }
    }
}
