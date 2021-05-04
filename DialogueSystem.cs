using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="DialogueSystem",menuName ="ScriptableObjects/DialogueSystem")]
public class DialogueSystem : ScriptableObject
{
    // Some sprite for talking person
    public Sprite talkerSprite;

    // Name of the person that talks
    public string talker;
    
    // Dialogs
    public Context[] contexts;

    // You can use this info if you want players to skip dialog (like closing dialog window) or not
    public bool skippable;

    [System.Serializable]
    public class Context
    {
        // Attribute to make it look nice on Editor
        [TextArea]
        public string dialogue;

        // How long it takes to read this text?
        public int contextReadTime;
    }
}
