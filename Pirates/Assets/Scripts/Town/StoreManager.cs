using UnityEngine;
using Zenject;
using TMPro;

namespace Pirates
{
    public class StoreManager : MonoBehaviour
    {
        private GameStatsManager _gameStatsManager;

        [SerializeField] private TextMeshProUGUI storeMoney;
        [SerializeField] private TextMeshProUGUI playerMoney;
        [SerializeField] private TextMeshProUGUI playerFreeSpace;
        [SerializeField] private TextMeshProUGUI storePrice;
        [SerializeField] private TextMeshProUGUI playerPrice;
        [SerializeField] private TextMeshProUGUI storeGoodsAmount;
        [SerializeField] private TextMeshProUGUI playerGoodsAmount;

        [SerializeField] private SeaTownInfoContainer seaTownInfoContainer;
        
        private int _townIndex;

        private int _storePriceInt;
        private int _playerPriceInt;
        private int _playerGoods;
        private int _storeMoneyInt;
        private int _playerMoneyInt;
        private int _storeGoodsInt;

        [Inject]
        private void Construct(GameStatsManager gameStatsManager)
        {
            _gameStatsManager = gameStatsManager;
        }

        private void Start()
        {
            _townIndex = _gameStatsManager.CurrentTownId;
            _playerGoods = _gameStatsManager.GoodsAmount;
            _storePriceInt = seaTownInfoContainer.townInfo[_townIndex].StorePrice;
            _playerPriceInt = seaTownInfoContainer.townInfo[_townIndex].PlayerPrice;
            _storeMoneyInt = seaTownInfoContainer.townInfo[_townIndex].InitialStoreMoney;
            _playerMoneyInt = _gameStatsManager.Money;
            _storeGoodsInt = seaTownInfoContainer.townInfo[_townIndex].InitialGoodsAmount;
        }

        private void Update()
        {
            storeMoney.text = _storeMoneyInt.ToString();
            playerMoney.text = _playerMoneyInt.ToString();
            playerFreeSpace.text = (_gameStatsManager.ShipSpace - _playerGoods).ToString();
            storePrice.text = _storePriceInt.ToString();
            playerPrice.text = _playerPriceInt.ToString();
            storeGoodsAmount.text = _storeGoodsInt.ToString();
            playerGoodsAmount.text = _playerGoods.ToString();
        }

        public void Sell()
        {
            if (_playerGoods >0 && _storeMoneyInt >= _playerPriceInt)
            {
                _playerGoods--;
                _storeGoodsInt++;
                _playerMoneyInt += _playerPriceInt;
                _storeMoneyInt -= _playerPriceInt;

                _gameStatsManager.GoodsAmount = _playerGoods;
                _gameStatsManager.Money = _playerMoneyInt;
            }
        }

        public void Buy()
        {
            if (_storeGoodsInt > 0 && _playerMoneyInt >= _storePriceInt)
            {
                _playerGoods++;
                _storeGoodsInt--;
                _playerMoneyInt -= _storePriceInt;
                _storeMoneyInt += _storePriceInt;
                
                _gameStatsManager.GoodsAmount = _playerGoods;
                _gameStatsManager.Money = _playerMoneyInt;
            }
        }
        
    }
}
