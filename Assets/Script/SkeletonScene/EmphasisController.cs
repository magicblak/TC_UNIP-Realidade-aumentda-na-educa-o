using Assets.Script.SkeletonScene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class EmphasisController : MonoBehaviour
{
    [SerializeField] private VirtualButtonBehaviour emphasis_buttom;//Bot�o para destacar parte do esqueleto
    [SerializeField] private GameObject emphasis_object;//GameObject que destaca o objeto
    [SerializeField] private TextMesh emphasis_text;//Texto do bot�o virtual
    [SerializeField] private TextMesh gamification_result_text;//Texto que mostra resultado na gamifica��o
    [SerializeField] private GameObject gamification_result_bg;//Imagem de fundo para apresenta��o do resultado
    private static bool general_controller = false;//Controlador booleano para n�o haver mais de uma parte selecionada
    private bool local_controller;//Controle local para saber se evento foi acionado
    // Start is called before the first frame update
    void Start()
    {
        local_controller = false;
        emphasis_buttom.RegisterOnButtonPressed(onEmphasisButtonPressed);//Adicionando evento
        emphasis_buttom.RegisterOnButtonReleased(onEmphasisButtonRealesed);//Adicionando evento
    }

    private void onEmphasisButtonPressed(VirtualButtonBehaviour b)
    {
        if (EmphasisController.general_controller) return;//Valida��o se existe algum bot�o j� acionado
        EmphasisController.general_controller = true;//Aciona bot�o para n�o permitir simultaniedade no destaque das partes do esqueleto
        local_controller = true;//Controlador local de bot�o
        //Chama metodo de gamifica��o caso esteja no modo
        if (GamificationController.getIsGamification()) gamification();
        else
        {
            //Destaca a parte do esqueleto e o texto selecionado
            emphasis_object.SetActive(true);
            emphasis_text.color = new Color32(255, 54, 54, 255);
        }
    }

    private void onEmphasisButtonRealesed(VirtualButtonBehaviour b)
    {
        //Valida se o clique foi dessa instancia
        if (!local_controller) return;
        EmphasisController.general_controller = false;//Avisa as demais classes que o evento n�o esta mais acionado
        local_controller = false;//Remove controle local
        emphasis_object.SetActive(false);//Esconte destaque
        emphasis_text.color = new Color32(255, 255, 255, 255);//Volta o texto na cor padr�o
        gamification_result_text.text = "";//Limpa o texto de resultado da gamifica��o
        GamificationController.endGamification();//Finaliza gamifica��o
        gamification_result_bg.SetActive(false);//Esconte resultado da gamifica��o

    }

    private void gamification()
    {
        if (emphasis_object.activeSelf)
        {
            //Apresenta resultado quando usu�rio acerta
            gamification_result_bg.SetActive(true);
            gamification_result_text.text = "VOC� EST� NO CAMINHO CERTO, PARAB�NS!";
            gamification_result_text.color = new Color32(87, 217, 162, 255);
        }
        else
        {
            //Apresenta resultado quando usu�rio erra
            gamification_result_bg.SetActive(true);
            gamification_result_text.text = "QUE PENA EST� ERRADO, MAS N�O DESISTA!";
            gamification_result_text.color = new Color32(224, 71, 75, 255);
        }
    }
}
