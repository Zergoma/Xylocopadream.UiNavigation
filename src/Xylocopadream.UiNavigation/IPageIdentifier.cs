namespace Xylocopadream.UiNavigation;

/// <summary>
/// This interface is created to give a common base to all PageIdentifier
/// This trick avoid to use string (very fragile), enum (very coupled to each UI exe)
/// We just need in client side to create a derived type implementing IPageIdentifier
/// Then add them to THE PageRegistry, lastly added as a singleton in the DI 
/// </summary>
public interface IPageIdentifier
{
}
