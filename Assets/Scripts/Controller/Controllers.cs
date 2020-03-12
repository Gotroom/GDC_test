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
            ServiceLocator.SetService(new TimeController());
            ServiceLocator.SetService(new SelectionController());
            ServiceLocator.SetService(new CirclesController());
            ServiceLocator.SetService(new MenuController());

            _executeControllers = new IExecutable[4];

            _executeControllers[0] = ServiceLocator.Resolve<InputController>();

            _executeControllers[1] = ServiceLocator.Resolve<TimeController>();

            _executeControllers[2] = ServiceLocator.Resolve<SelectionController>();

            _executeControllers[3] = ServiceLocator.Resolve<CirclesController>();

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

            ServiceLocator.Resolve<MenuController>().Initialize();

            ServiceLocator.Resolve<InputController>().On();
            ServiceLocator.Resolve<TimeController>().On();
            ServiceLocator.Resolve<SelectionController>().On();
            ServiceLocator.Resolve<CirclesController>().On();
        }
    }
}

