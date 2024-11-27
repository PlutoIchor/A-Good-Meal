using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NameBox : MonoBehaviour
{
    [SerializeField] private RectTransform nameBoxRectTransform;  // The RectTransform of the NameBox
    [SerializeField] private TMP_Text nameLabel;  // The TMP_Text component for the name

    public void SetName(string characterName)
    {
        // Set the name text
        nameLabel.text = characterName;

        // Force TextMeshPro to update the mesh after setting the text
        nameLabel.ForceMeshUpdate();

        // Get the preferred width of the name label
        float textWidth = nameLabel.preferredWidth;

        // Set the width of the NameBox RectTransform based on the preferred width of the text
        nameBoxRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, textWidth + 20f); // Add padding

        // Force layout rebuild to prevent unwanted scaling
        LayoutRebuilder.ForceRebuildLayoutImmediate(nameBoxRectTransform);
    }
}
