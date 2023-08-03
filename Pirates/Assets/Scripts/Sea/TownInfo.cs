using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pirates
{
    [CreateAssetMenu(menuName = "Tools/Town Info", fileName = "TownInfo")]
    public class TownInfo : ScriptableObject
    {
        [ field: SerializeField] public string Name { get; private set; }
        [ field: SerializeField] public string Country { get; private set; }
        [ field: SerializeField] public int InitialStoreMoney { get; private set; }
        [ field: SerializeField] public int StorePrice { get; private set; }
        [ field: SerializeField] public int PlayerPrice { get; private set; }
        [ field: SerializeField] public int InitialGoodsAmount { get; private set; }
    }
}
