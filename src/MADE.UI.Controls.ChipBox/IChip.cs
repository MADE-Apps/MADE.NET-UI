namespace MADE.UI.Controls
{
    using System.Windows.Input;

    public interface IChip
    {
        event ChipRemoveEventHandler Removed;

        ICommand RemoveCommand { get; set; }

        bool CanRemove { get; set; }
    }
}
