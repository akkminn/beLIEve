using UnityEngine;
using TMPro;

public class TextTitleScript : MonoBehaviour
{
    private TMP_Text titleText;

    void Start()
    {
        // Get the TextMeshPro component
        titleText = GetComponent<TMP_Text>();

        // Set the text
        titleText.text = "BELIEVE";

        // Generate mesh info
        titleText.ForceMeshUpdate();

        TMP_TextInfo textInfo = titleText.textInfo;

        // Find and color only the substring "LIE"
        string fullText = titleText.text;
        string target = "LIE";

        int startIndex = fullText.IndexOf(target);
        if (startIndex != -1)
        {
            // Loop through the characters that make up "LIE"
            for (int i = startIndex; i < startIndex + target.Length; i++)
            {
                TMP_CharacterInfo charInfo = textInfo.characterInfo[i];

                if (!charInfo.isVisible)
                    continue;

                int meshIndex = charInfo.materialReferenceIndex;
                int vertexIndex = charInfo.vertexIndex;

                Color32[] vertexColors = textInfo.meshInfo[meshIndex].colors32;

                Color32 red = new Color32(255, 0, 0, 255);

                vertexColors[vertexIndex + 0] = red;
                vertexColors[vertexIndex + 1] = red;
                vertexColors[vertexIndex + 2] = red;
                vertexColors[vertexIndex + 3] = red;
            }

            // Apply color changes to the mesh
            titleText.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
        }
    }
}
