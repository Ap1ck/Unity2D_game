using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Coin",menuName ="ScriptableObjects/CoinScriptableObject")]

public class CoinScpriptableObject : ScriptableObject
{
    private int _coin = 0;

    public int AddCoin(int value)
    {
        _coin += value;
        return _coin;
    }
}
