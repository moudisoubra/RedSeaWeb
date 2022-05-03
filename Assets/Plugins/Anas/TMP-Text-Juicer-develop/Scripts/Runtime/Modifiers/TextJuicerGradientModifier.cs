using TMPro;
using UnityEngine;

namespace BrunoMikoski.TextJuicer.Modifiers
{
    [AddComponentMenu( "UI/Text Juicer Modifiers/Gradiend Modifier", 11 )]
    public sealed class TextJuicerGradientModifier : TextJuicerVertexModifier
    {
        [SerializeField]
        private Gradient entryGradient;
        [SerializeField]
        private Gradient exitgradient;

        private Color32[] newVertexColors;
        private Color targetColor;

        public bool exit;

        public override bool ModifyGeometry
        {
            get
            {
                return false;
            }
        }
        public override bool ModifyVertex
        {
            get
            {
                return true;
            }
        }

        public override void ModifyCharacter(CharacterData characterData, TMP_Text textComponent,
            TMP_TextInfo textInfo,
            float progress,
            TMP_MeshInfo[] meshInfo)
        {
            if (entryGradient == null || exitgradient == null)
                return;

            int materialIndex = characterData.MaterialIndex;

            newVertexColors = textInfo.meshInfo[materialIndex].colors32;

            int vertexIndex = characterData.VertexIndex;

            if(exit)
                targetColor = exitgradient.Evaluate( characterData.Progress );
            else
                targetColor = entryGradient.Evaluate(characterData.Progress);

            newVertexColors[vertexIndex + 0] = targetColor;
            newVertexColors[vertexIndex + 1] = targetColor;
            newVertexColors[vertexIndex + 2] = targetColor;
            newVertexColors[vertexIndex + 3] = targetColor;
        }
    }
}
