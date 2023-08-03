using UnityEngine;
using Zenject;

namespace Pirates
{
    public class PopupController : MonoBehaviour
    {
        [SerializeField] private GameObject popupPanel;
        private App _app;
        
        [Inject]
        private void Construct(App app)
        {
            _app = app;
        }
        public void ShowPopup()
        {
            popupPanel.SetActive(true);
        }

        public void HidePopup()
        {
            popupPanel.SetActive(false);
        }

        public void ShowTown()
        {
            _app.LoadScene("Town");
        }
    }
}
