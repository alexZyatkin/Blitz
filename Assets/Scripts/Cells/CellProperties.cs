using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Cells
{
    public class CellProperties : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private Image img;
        private Color color;
        private void Awake()
        {
            img = GetComponent<Image>();
            color = img.color;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            img.color = Color.grey;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            img.color = color;
        }
    }
}