using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour, IInteractable
{
 
    [SerializeField] string[] _lines;
    [SerializeField] string _name;
    [SerializeField] Sprite _face;
    public void OnInteraction()
    {
        //Run behaviour from Dialogue Manager instance
        DialogueManager.instance.OnActive(_lines, _name, _face);
    }
}
