using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.SkeletonScene
{
    class GamificationController : MonoBehaviour
    {
        [SerializeField] private Button gamification;
        [SerializeField] private GameObject[] skeleton_pieces;
        [SerializeField] private GameObject gamification_text;
        [SerializeField] private Image gamification_image;
        private static bool is_gamification = false;
        private bool is_hidden = true;
        // Start is called before the first frame update
        private void Start()
        {
            gamification.onClick.AddListener(gamificationClick);
        }

        void gamificationClick()
        {
            is_gamification = !is_gamification;
            if (is_gamification) prepareGamification();
            else hideAllGamification();
        }

        private void prepareGamification()
        {
            gamification_image.color = new Color32(91, 217, 106, 255);
            is_hidden = false;
            int randon_index = Random.Range(0, 4);
            gamification_text.SetActive(true);
            skeleton_pieces[randon_index].SetActive(true);
        }

        private void hideAllGamification()
        {
            gamification_image.color = new Color32(212, 117, 117, 255);
            is_hidden = true;
            gamification_text.SetActive(false);
            for (int i = 0; i < skeleton_pieces.Length; i++)
            {
                skeleton_pieces[i].SetActive(false);
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
