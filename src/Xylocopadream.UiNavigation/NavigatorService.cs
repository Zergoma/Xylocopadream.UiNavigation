namespace Xylocopadream.UiNavigation;

internal sealed class NavigatorService : INavigatorService
{
    private readonly IServiceProvider _services;
    private readonly PageRegistry _pages;


    public NavigatorService(
        IServiceProvider services,
        PageRegistry pages)
    {
        _services = services;
        _pages = pages;
    }

    public void NavigateTo<TIdentifier>()
        where TIdentifier : IPageIdentifier
    {
        if (!_pages.TryGet(typeof(TIdentifier), out Action<IServiceProvider> pageAction))
        {
            throw new InvalidOperationException(
                $"No page registered for '{typeof(TIdentifier).Name}'. Add a PageRegistryEntry for it in AddUiNavigationServices.");
        }

        pageAction(_services);
    }
}
