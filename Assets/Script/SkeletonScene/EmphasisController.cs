using Assets.Script.SkeletonScene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class EmphasisController : MonoBehaviour
{
    [SerializeField] private VirtualButtonBehaviour emphasis_buttom;
    [SerializeField] private GameObject emphasis_object;
    [SerializeField] private TextMesh emphasis_text;
    [SerializeField] private TextMesh gamification_result_text;
    [SerializeField] private GameObject gamification_result_bg;
    private static bool general_controller = false;
    private bool local_controller;
    // Start is called before the first frame update
    void Start()
    {
        local_controller = false;
        emphasis_buttom.RegisterOnButtonPressed(onEmphasisButtonPressed);
        emphasis_buttom.RegisterOnButtonReleased(onEmphasisButtonRealesed);
    }

    private void onEmphasisButtonPressed(VirtualButtonBehaviour b)
    {
        if (EmphasisController.general_controller) return;
        EmphasisController.general_controller = true;
        local_controller = true;
        if (GamificationController.getIsGamification()) gamification();
        else
        {
            emphasis_object.SetActive(true);
            emphasis_text.color = new Color32(255, 54, 54, 255);
        }
    }

    private void onEmphasisButtonRealesed(VirtualButtonBehaviour b)
    {
        if (!local_controller) return;
        EmphasisController.general_controller = false;
        local_controller = false;
        emphasis_object.SetActive(false);
        emphasis_text.color = new Color32(255, 255, 255, 255);
        gamification_result_text.text = "";
        GamificationController.endGamification();
        gamification_result_bg.SetActive(false);

    }

    private void gamification()
    {
        if (emphasis_object.activeSelf)
        {
            Debug.Log("Acertou");
            gamification_result_bg.SetActive(true);
            gamification_result_text.text = "VOCÊ ESTÁ NO CAMINHO CERTO, PARABÉNS!";
            gamification_result_text.color = new Color32(87, 217, 162, 255);
        }
        else
        {
            Debug.Log("Errou");
            gamification_result_bg.SetActive(true);
            gamification_result_text.text = "QUE PENA ESTÁ ERRADO, MAS NÃO DESISTA!";
            gamification_result_text.color = new Color32(224, 71, 75, 255);
        }
    }
}
