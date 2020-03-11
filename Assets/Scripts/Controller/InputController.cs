using UnityEngine;
using System;

namespace GDCTest
{
    public class InputController : BaseController, IExecutable
    { 
        private int _mouseButton = (int)MouseButtons.LeftButton;

        public InputController()
        {

        }

        public void Execute()
        {
            if (Input.GetMouseButtonDown(_mouseButton))
            {
                CustomDebug.Log("clicked");
                var selectedObject = ServiceLocator.Resolve<SelectionController>().SelectedObject;
                if (selectedObject is IDestroyable destroyable)
                {
                    destroyable.Destroy();
                }
            }
        }

        public static Vector3 GetCoursorPosition()
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}