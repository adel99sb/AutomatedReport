using System;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

public class SessionService
{
    private readonly ILocalStorageService _localStorage;
    private readonly NavigationManager _navigation;

    public event Action OnChange;

    public SessionService(ILocalStorageService localStorage, NavigationManager navigation)
    {
        _localStorage = localStorage;
        _navigation = navigation;
    }

    public async Task<string> GetUserIdAsync()
    {
        return await _localStorage.GetItemAsync<string>("userId");
    }

    public async Task SetUserIdAsync(string userId)
    {
        await _localStorage.SetItemAsync("userId", userId);
        NotifyStateChanged();
    }

    public async Task ClearUserIdAsync()
    {
        await _localStorage.SetItemAsync("userId", "");
        await _localStorage.RemoveItemAsync("userId");
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
