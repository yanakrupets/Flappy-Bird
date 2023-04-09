using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BonusData", menuName = "Bonus")]
public class BonusData : ScriptableObject
{
    [SerializeField] private string _name;
    public string Name 
    { 
        get { return _name; } 
        private set { } 
    }

    [SerializeField] private Sprite _sprite;
    public Sprite Sprite
    {
        get { return _sprite; }
        private set { }
    }

    [SerializeField] private int _points;
    public int Points
    {
        get { return _points; }
        private set { }
    }
}
