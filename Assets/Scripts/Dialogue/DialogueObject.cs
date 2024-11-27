using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class DialogueLine
{
    public string characterName; // The name of the character speaking
    public Sprite characterSprite; // The sprite of the character speaking
    [TextArea] public string dialogueText; // The actual dialogue line
}

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    [SerializeField] private List<DialogueLine> dialogue;

    public List<DialogueLine> Dialogue => dialogue;
}
