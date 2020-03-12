using UnityEngine;
using System;

namespace GDCTest
{
    public class InputController : BaseController, IExecutable
    {
        public static Action CancelPressed;

        private int _mouseButton = (int)MouseButtons.LeftButton;

        public void Execute()
        {
            if (Input.GetMouseButtonDown(_mouseButton))
            {
                var selectedObject = ServiceLocator.Resolve<SelectionController>().SelectedObject;
                if (selectedObject is IDestroyable destroyable)
                {
                    destroyable.Destroy();
                }
            }

            if (Input.GetButtonDown(Constants.CANCEL_KEY))
            {
                CancelPressed?.Invoke();
            }
        }

        public static Vector3 GetCoursorPosition()
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}