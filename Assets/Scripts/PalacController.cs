using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class PalaceController: MonoBehaviour
{
    [SerializeField]
    private GameObject Money;
    [SerializeField]
    private GameObject Keys;
    public static PalaceController Instance { get; private set; }
    private void Awake() 
    { 
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }

        Debug.Log("Palac jest obsługiwany moj panie!"); 
    }

    public enum PalaceStates
    {
        money,
        vagina,
        keys
    }

    public void UpdateStatus(PalaceStates _palaceStates)
    {
        switch(_palaceStates)
        {
            case PalaceStates.money:
                Destroy(Money.gameObject);
                break;
            case PalaceStates.vagina:
                break;
            case PalaceStates.keys:
                break;
            default:
                Debug.Log("this state doesnt exist");
                break;
        }
    }


}
