﻿using UnityEngine;
using UnityEngine.UI;

namespace Library.Utility
{
    public static class UiExtensionMethods
    {
        public static void SetAlpha(this Graphic graphic, float alpha)
        {
            graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, alpha);
        }

        public static void SetAlpha(this SpriteRenderer spriteRenderer, float alpha)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, alpha);
        }

        public static Vector2 GetAnchoredPositionOfWorldPosition(this RectTransform rectTransform, Vector3 worldPosition, Camera camera = null)
        {
            if (camera == null)
            {
                camera = Camera.main;
            }
            Vector2 viewportPos = camera.WorldToViewportPoint(worldPosition);
            return new(
                viewportPos.x * rectTransform.rect.width - rectTransform.rect.width / 2f,
                viewportPos.y * rectTransform.rect.height - rectTransform.rect.height / 2f);
        }
    }
}