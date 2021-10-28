using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnButton : MonoBehaviour
{
    [SerializeField] private Button returner;
    // Start is called before the first frame update
    private void Start()
    {
        returner.onClick.AddListener(returnerClick);
	}

    void returnerClick()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
