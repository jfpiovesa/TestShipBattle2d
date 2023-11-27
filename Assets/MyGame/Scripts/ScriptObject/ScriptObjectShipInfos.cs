using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ship", menuName = "ShipPlayer/ship")]
public class ScriptObjectShipInfos : ScriptableObject
{
    public int IdShip;
    public Sprite imageShip;
    public GameObject prefabShip;
}
