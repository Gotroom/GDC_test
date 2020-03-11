using UnityEngine;
using System.Collections;

namespace GDCTest
{
    public class SelectionController : BaseController, IExecutable
    {
        public ISelectable SelectedObject
        {
            get { return _selectedObj; }
        }

        private readonly float _clickError = 0.2f;
        private ISelectable _selectedObj;

        public SelectionController()
        {

        }

        public void Execute()
        {
            if (!IsActive)
            {
                return;
            }

            var collider = Physics2D.OverlapCircle(InputController.GetCoursorPosition(), _clickError);
            if (collider)
            {
                SelectObject(collider.gameObject);
            }
        }

        private void SelectObject(GameObject obj)
        {
            _selectedObj = obj.GetComponent<ISelectable>();
            CustomDebug.Log(_selectedObj.GetMessage());
        }

    }
}

