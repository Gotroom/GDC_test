using UnityEngine;
using System.Collections;

namespace GDCTest
{
    public sealed class Controllers : IInitializable
    {
        private readonly IExecutable[] _executeControllers;
        public int Length => _executeControllers.Length;

        private InputController _inputController;
        private SelectionController _selectionController;

        public Controllers()
        {
            ServiceLocator.SetService(new InputController());
            ServiceLocator.SetService(new SelectionController());

            _executeControllers = new IExecutable[2];

            _executeControllers[0] = ServiceLocator.Resolve<InputController>();

            _executeControllers[1] = ServiceLocator.Resolve<SelectionController>();

        }

        public IExecutable this[int index] => _executeControllers[index];

        public void Initialize()
        {
            foreach (var controller in _executeControllers)
            {
                if (controller is IInitializable initialization)
                {
                    initialization.Initialize();
                }
            }

            ServiceLocator.Resolve<InputController>().On();
            ServiceLocator.Resolve<SelectionController>().On();
        }
    }
}

