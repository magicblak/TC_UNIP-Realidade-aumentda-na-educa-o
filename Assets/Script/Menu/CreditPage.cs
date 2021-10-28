using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditPage : MonoBehaviour
{
    [SerializeField] private GameObject categories_button_obj;
    [SerializeField] private GameObject credit_page;
    private Button credit_button;
    // Start is called before the first frame update
    void Start()
    {
        credit_button = categories_button_obj.GetComponent<Button>();
        credit_button.onClick.AddListener(clickButtonCredit);
    }

    void clickButtonCredit()
    {
        credit_page.SetActive(!credit_page.activeSelf);
    }
}
