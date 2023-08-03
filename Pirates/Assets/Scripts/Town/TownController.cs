using UnityEngine;
using Zenject;
using TMPro;

namespace Pirates
{
    public class TownController : MonoBehaviour
    {
        private GameStatsManager _gameStatsManager;
        private App _app;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private SeaTownInfoContainer seaTownInfoContainer;
        [SerializeField] private GameObject storePanel;
        
        [Inject]
        private void Construct(GameStatsManager gameStatsManager, App app)
        {
            _gameStatsManager = gameStatsManager;
            _app = app;
        }

        private void Start()
        {
            int townIndex = _gameStatsManager.CurrentTownId;
            text.text = seaTownInfoContainer.townInfo[townIndex].Name;
        }

        public void CloseStore()
        {
            storePanel.SetActive(false);
        }

        public void EnterStore()
        {
            storePanel.SetActive(true);
        }

        public void LeaveTown()
        {
            _app.LoadScene("Sea");
        }
    }
}

