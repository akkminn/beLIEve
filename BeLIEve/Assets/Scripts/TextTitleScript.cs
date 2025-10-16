using UnityEngine;
using TMPro;

public class TextTitleScript : MonoBehaviour
{
    private TMP_Text titleText;
    private TMP_TextInfo textInfo;

    private int startIndex;
    private int endIndex;
    private string target = "LIE";

    void Start()
    {
        titleText = GetComponent<TMP_Text>();
        titleText.text = "BELIEVE";

        titleText.ForceMeshUpdate();
        textInfo = titleText.textInfo;

        string fullText = titleText.text;
        startIndex = fullText.IndexOf(target);
        endIndex = startIndex + target.Length;
    }

    void Update()
    {
        if (startIndex == -1) return;

        float flash = Mathf.PingPong(Time.time * 2f, 1f); // speed = 2

        Color32 flashColor = Color32.Lerp(new Color32(255, 255, 255, 255), new Color32(255, 0, 0, 255), flash);

        titleText.ForceMeshUpdate();
        textInfo = titleText.textInfo;

        for (int i = startIndex; i < endIndex; i++)
        {
            TMP_CharacterInfo charInfo = textInfo.characterInfo[i];
            if (!charInfo.isVisible)
                continue;

            int meshIndex = charInfo.materialReferenceIndex;
            int vertexIndex = charInfo.vertexIndex;

            Color32[] vertexColors = textInfo.meshInfo[meshIndex].colors32;

            vertexColors[vertexIndex + 0] = flashColor;
            vertexColors[vertexIndex + 1] = flashColor;
            vertexColors[vertexIndex + 2] = flashColor;
            vertexColors[vertexIndex + 3] = flashColor;
        }

        titleText.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
    }
}