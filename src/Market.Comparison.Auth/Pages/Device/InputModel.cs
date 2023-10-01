namespace Market.Comparison.Auth.Pages.Device;

public class InputModel
{
    public string Button { get; set; } = default!;
    public IEnumerable<string> ScopesConsented { get; set; } = default!;
    public bool RememberConsent { get; set; } = true;
    public string? ReturnUrl { get; set; }
    public string? Description { get; set; }
    public string UserCode { get; set; } = default!;
}