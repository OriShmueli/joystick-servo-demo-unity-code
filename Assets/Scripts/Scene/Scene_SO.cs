using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Scene_SO", menuName = "ScriptableObjects/Scenes")]
public abstract class Scene_SO : ScriptableObject
{
    [SerializeField] private Image menuImage;
    [SerializeField] private int numberOfSerialPorts;
    [SerializeField] private bool bluetooth;

    public Image MenuImage => menuImage;
    public int NumberOfSerialPorts => numberOfSerialPorts;
    public bool Bluetooth => bluetooth;
}
