using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI; // Import for Image component

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel; // For the dialogue text
    [SerializeField] private TMP_Text nameLabel; // For the character's name
    [SerializeField] private Image characterSprite; // For the character's sprite
    [SerializeField] private NameBox nameBox;
    [SerializeField] private DialogueObject testDialogue;

    private TypewriterEffect typewriterEffect;

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        CloseDialogueBox();
        ShowDialogue(testDialogue);
    }


    public void ShowDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);    
        StartCoroutine(StopThroughDialogue(dialogueObject));    
    }

    private IEnumerator StopThroughDialogue(DialogueObject dialogueObject)
    {
        foreach (DialogueLine line in dialogueObject.Dialogue)
        {
            // Set the character's name using the NameBox
            nameBox.SetName(line.characterName);

            // Set the character's sprite
            if (line.characterSprite != null)
            {
                characterSprite.sprite = line.characterSprite;
                characterSprite.enabled = true; // Make sure the sprite is visible
            }
            else
            {
                characterSprite.enabled = false; // Hide the sprite if none is provided
            }

            // Use the typewriter effect for the dialogue text
            yield return typewriterEffect.Run(line.dialogueText, textLabel);

            // Wait for player input to continue
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        CloseDialogueBox();
    }


    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
        nameLabel.text = string.Empty;
        characterSprite.sprite = null; // Clear the character sprite
        characterSprite.enabled = false; // Hide the sprite
    }
}
