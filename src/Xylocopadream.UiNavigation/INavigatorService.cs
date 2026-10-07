namespace Xylocopadream.UiNavigation;

public interface INavigatorService
{
    void NavigateTo<TIdentifier>()
        where TIdentifier : IPageIdentifier;
}
