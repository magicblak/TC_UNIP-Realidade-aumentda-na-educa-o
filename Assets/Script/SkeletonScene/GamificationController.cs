using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.SkeletonScene
{
    class GamificationController : MonoBehaviour
    {
        [SerializeField] private Button gamification;//Botão que ativa gamificação
        [SerializeField] private GameObject[] skeleton_pieces;//Partes do esqueleto para destaque
        [SerializeField] private GameObject gamification_text;//Pergunta da gamificação
        [SerializeField] private Image gamification_image;//Imagem do botão para troca de cor
        private static bool is_gamification = false;//Controle do ambiente para saber se é ou não gamificação
        private bool is_hidden = true;//Avisa se os componentes de gamificação estão escondidos ou não
        //Executa sempre que a classe for instanciada na cena, similar a um construtor
        private void Start()
        {
            gamification.onClick.AddListener(gamificationClick);//Adiciona evento
        }

        void gamificationClick()
        {
            is_gamification = !is_gamification;//Troca estado de gamificação
            //Valida estado e roda metodo correspondente
            if (is_gamification) prepareGamification();
            else hideAllGamification();
        }

        private void prepareGamification()
        {
            gamification_image.color = new Color32(91, 217, 106, 255);//Troca a cor do botão
            is_hidden = false;
            int randon_index = Random.Range(0, 4);//Sorteia uma parte do esqueleto
            gamification_text.SetActive(true);//Mostra pergunta
            skeleton_pieces[randon_index].SetActive(true);//Destaca parte do esqueleto
        }

        private void hideAllGamification()
        {
            gamification_image.color = new Color32(212, 117, 117, 255);//Volta cor da imagem para padrão
            is_hidden = true;
            gamification_text.SetActive(false);//Esconte texto
            for (int i = 0; i < skeleton_pieces.Length; i++)
            {
                skeleton_pieces[i].SetActive(false);//Esconde todos os destaques do esqueleto
            }
        }

        public static bool getIsGamification()
        {
            return is_gamification;
        }

        public static void endGamification()
        {
            is_gamification = false;
        }

        private void Update()
        {
            if (!is_gamification && !is_hidden) hideAllGamification();
        }
    }
}
