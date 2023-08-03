using TMPro;
using UnityEngine;
using Zenject;

namespace Pirates
{
    public class SeaTownEntity : MonoBehaviour
    {
        [SerializeField] private PopupController popupController;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private int townId;
        [SerializeField] private SeaTownInfoContainer seaTownInfoContainer;
        private string _townName;
        private string _townCountry;
        private GameStatsManager _gameStatsManager;

        [Inject]
        private void Construct(GameStatsManager gameStatsManager)
        {
            _gameStatsManager = gameStatsManager;
        }
        

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ship"))
            {
                popupController.ShowPopup();
                _townName = seaTownInfoContainer.townInfo[townId].Name;
                _townCountry = seaTownInfoContainer.townInfo[townId].Country;
                
                text.text = $"You have arrived at {_townName}. This land is ruled by {_townCountry}. Enjoy your stay or leave immediately.";
                _gameStatsManager.CurrentTownId = townId;
            }
        }
        
    }

}

