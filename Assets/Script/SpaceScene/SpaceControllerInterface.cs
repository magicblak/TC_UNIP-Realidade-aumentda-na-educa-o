using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpaceControllerInterface : MonoBehaviour
{
    [SerializeField] private GameObject rotation_button;//Objeto do bot�o rota��o
    [SerializeField] private TextMesh txt_days_count;//Objeto do bot�o rota��o
    [SerializeField] private GameObject translation_button;//Objeto do bot�o transla��o
    [SerializeField] private GameObject rotation_text;//Texto explicativo da rota��o
    [SerializeField] private GameObject password_text;//Texto explicativo da rota��o
    [SerializeField] private GameObject translation_text;//Texto explicativo da trnala��o
    [SerializeField] private Transform sun;//Componente de transforma��o do sol
    [SerializeField] private Vector3 sun_rotation_direction;//Dire��o da rota��o
    [SerializeField] private int sun_rotation_velocity;//Velocidade de rota��o do sol
    [SerializeField] private Transform earth;//Componente de transforma��o da terra
    [SerializeField] private Vector3 earth_rotation_direction;//Dire��o da rota��o da terra
    [SerializeField] private int earth_rotation_velocity;//Velocidade de rota��o da terra
    [SerializeField] private int segments;//Segmentos para calculo da transla��o
    [SerializeField] private int current_segment;//Segmento corrente da transla��o
    [SerializeField] private float earth_translation_with;//Largura da transla��o
    [SerializeField] private float earth_translation_height;//Profundidade da transla��o
    private SpaceMovement movimenter;//Classe que calcula movimentos
    [SerializeField] private bool stop;//Booleano controlador
    private bool do_earth_complete_movement;//Controlador do movimento comleto
    private bool do_earth_rotation;//Controlador da rota��o
    private bool do_earth_translation;//Controlador da transla��o
    private int days_count = 0;
    private float rotation_count = 0;
    //Executa sempre que a classe for instanciada na cena, similar a um construtor
    void Start()
    {
        do_earth_complete_movement = false;
        do_earth_rotation = false;
        do_earth_translation = false;
        movimenter = new SpaceMovement();
        //Adicionando ouvintes de evento
        rotation_button.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(onRotationButtonPressed);
        rotation_button.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(onRotationButtonRealesed);
        translation_button.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(onTranslationButtonPressed);
        translation_button.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(onTranslationButtonRealesed);
    }

    private void onRotationButtonPressed(VirtualButtonBehaviour b)
    {
        if (do_earth_complete_movement || do_earth_translation) return;
        do_earth_rotation = true;
        rotation_text.SetActive(true);
        translation_button.SetActive(false);
    }

    private void onRotationButtonRealesed(VirtualButtonBehaviour b)
    {
        if (do_earth_complete_movement || do_earth_translation) return;
        do_earth_rotation = false;
        rotation_text.SetActive(false);
        translation_button.SetActive(true);
    }

    private void onTranslationButtonPressed(VirtualButtonBehaviour b)
    {
        if (do_earth_complete_movement || do_earth_rotation) return;
        do_earth_translation = true;
        translation_text.SetActive(true);
        rotation_button.SetActive(false);
    }

    private void onTranslationButtonRealesed(VirtualButtonBehaviour b)
    {
        if (do_earth_complete_movement || do_earth_rotation) return;
        do_earth_translation = false;
        translation_text.SetActive(false);
        rotation_button.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        actions();
    }

    private void actions()
    {
        //Chama a��es baseado no controle booleano
        verifyGoalComplete();
        if (stop) return;
        sunRotation();
        if (do_earth_complete_movement) earthCompleteMovement();
        if (do_earth_rotation) earthRotation();
        if (do_earth_translation) earthTranslation();
    }

    private void verifyGoalComplete()
    {
        if (days_count < 2000) return;
        earth_rotation_velocity = 30;
        password_text.SetActive(true);
        translation_text.SetActive(false);
        rotation_button.SetActive(false);
        rotation_text.SetActive(false);
        translation_button.SetActive(false);
        movimenter.rotationPlanet(earth, earth_rotation_direction, earth_rotation_velocity);
        earthTranslation();
    }

    private void sunRotation()
    {
        movimenter.rotationPlanet(sun, sun_rotation_direction, sun_rotation_velocity);
    }

    private void earthRotation()
    {
        movimenter.rotationPlanet(earth, earth_rotation_direction, earth_rotation_velocity);
        rotation_count += 10;
        if(rotation_count > 360)
        {
            rotation_count = earth_rotation_velocity * Time.deltaTime;
            days_count++;
            txt_days_count.text = days_count + " Dias";
        }
    }

    private void earthTranslation()
    {
        Vector3 translation_position = movimenter.calculeOrbit(segments, current_segment, earth_translation_with, earth_translation_height, earth.localPosition.z);
        Debug.Log(translation_position);
        earth.localPosition = translation_position;
        current_segment++;
        if (current_segment > segments)
        {
            current_segment = 0;
            days_count += 365;
            txt_days_count.text = days_count + " Dias";
        }
    }

    private void earthCompleteMovement()
    {
        earthRotation();
        earthTranslation();
    }
}
