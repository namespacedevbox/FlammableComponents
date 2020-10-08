namespace FlammableComponents.Components.ModalDialog
{
    public class ModalResult
    {
        public bool Cancelled { get; private set; }

        public ModalResult(bool cancelled)
        {
            Cancelled = cancelled;
        }
    }
}
