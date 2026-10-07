# Xylocopadream.UiNavigation

Strongly-typed page navigation driven by dependency injection, independent of the UI framework.

Each page is identified by a type implementing `IPageIdentifier` (no fragile strings, no app-wide enum). You register what "navigating" to it means, then navigate from anywhere with `INavigatorService`.

## Usage

```csharp
public sealed class LoginPageIdentifier : IPageIdentifier;
public sealed class MainPageIdentifier : IPageIdentifier;

PageRegistryEntry[] entries =
[
    PageRegistryEntry.For<LoginPageIdentifier>(
        sp => Application.Current!.Windows[0].Page = sp.GetRequiredService<LoginPage>()),
    PageRegistryEntry.For<MainPageIdentifier>(
        sp => Application.Current!.Windows[0].Page = sp.GetRequiredService<AppShell>()),
];

builder.Services.AddUiNavigationServices(entries);
```

```csharp
public sealed class StartViewModel(INavigatorService navigator)
{
    public void GoToLogin() => navigator.NavigateTo<LoginPageIdentifier>();
}
```

## License

GPL-3.0-or-later
