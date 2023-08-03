using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Pirates
{
    public class InputHandler : ITickable
    {
        public Action<Vector2> ScreenTap;

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }
                Vector2 positionOnScreen = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                ScreenTap?.Invoke(positionOnScreen);
            }
        }
    }
}
