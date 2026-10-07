namespace Xylocopadream.UiNavigation;

/// <summary>
/// Immutable map "page identifier type -> navigation action", built once at startup.
/// </summary>
internal sealed class PageRegistry
{
    private readonly Dictionary<Type, Action<IServiceProvider>> _pages = [];

    public PageRegistry(IEnumerable<PageRegistryEntry> entries)
    {
        foreach (PageRegistryEntry entry in entries)
        {
            if (!_pages.TryAdd(entry.Type, entry.Action))
            {
                throw new ArgumentException(
                    $"Page identifier '{entry.Type.Name}' is registered more than once.",
                    nameof(entries));
            }
        }
    }

    public bool TryGet(Type identifier, out Action<IServiceProvider> action)
        => _pages.TryGetValue(identifier, out action!);
}

/// <summary>
/// What navigating to a page means, e.g. setting the window page.
/// Prefer <see cref="For{TPage}"/>, checked at compile time.
/// </summary>
public sealed record PageRegistryEntry
{
    public Type Type { get; }

    public Action<IServiceProvider> Action { get; }

    public PageRegistryEntry(Type type, Action<IServiceProvider> action)
    {
        ArgumentNullException.ThrowIfNull(type);
        ArgumentNullException.ThrowIfNull(action);

        if (!typeof(IPageIdentifier).IsAssignableFrom(type))
        {
            throw new ArgumentException(
                $"'{type.Name}' must implement {nameof(IPageIdentifier)}.",
                nameof(type));
        }

        Type = type;
        Action = action;
    }

    public static PageRegistryEntry For<TPage>(Action<IServiceProvider> action)
        where TPage : IPageIdentifier
        => new(typeof(TPage), action);
}
