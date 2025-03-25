using UnityEngine;

namespace TB_RPG_2D.UI.Helper
{
    public static class UIHelper
    {
        public static Vector2 WorldToUILocalPosition(Vector3 worldPosition, Canvas canvas, Camera camera)
        {
            Vector3 screenPosition = camera.WorldToScreenPoint(worldPosition);
            RectTransform canvasRect = canvas.GetComponent<RectTransform>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRect, screenPosition, canvas.worldCamera, out var localPoint
            );

            return localPoint;
        }
    }
}