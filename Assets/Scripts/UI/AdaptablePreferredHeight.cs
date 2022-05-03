using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(LayoutElement))]
public class AdaptablePreferredHeight : UIBehaviour, ILayoutElement
{
    public float MaxHeight = 100;
    public RectTransform ContentToGrowWith;

    public int LayoutPriority = 10;

    LayoutElement m_LayoutElement;
    float m_Preferredheight;

    public float minWidth => m_LayoutElement.minWidth;
    public float preferredWidth => m_LayoutElement.preferredWidth;
    public float flexibleWidth => m_LayoutElement.flexibleWidth;
    public float minHeight => m_LayoutElement.minHeight;
    public float preferredHeight => m_Preferredheight;
    public float flexibleHeight => m_LayoutElement.flexibleHeight;
    public int layoutPriority => LayoutPriority;

    public void CalculateLayoutInputHorizontal()
    {
        if (m_LayoutElement == null)
        {
            m_LayoutElement = GetComponent<LayoutElement>();
        }
    }

    public void CalculateLayoutInputVertical()
    {
        if (m_LayoutElement == null)
        {
            m_LayoutElement = GetComponent<LayoutElement>();
        }

        float contentHeight = ContentToGrowWith.sizeDelta.y;

        if (contentHeight < MaxHeight)
        {
            m_Preferredheight = contentHeight;
        }
        else
        {
            m_Preferredheight = MaxHeight;
        }
    }

}