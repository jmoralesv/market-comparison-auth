// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;

namespace Market.Comparison.Auth.Pages.Diagnostics;

public class ViewModel
{
    public ViewModel(AuthenticateResult result)
    {
        AuthenticateResult = result;

        if (result.Properties?.Items.ContainsKey("client_list") ?? false)
        {
            var encoded = result.Properties.Items["client_list"];
            var bytes = Duende.IdentityModel.Base64Url.Decode(encoded!);
            var value = Encoding.UTF8.GetString(bytes);

            Clients = JsonSerializer.Deserialize<string[]>(value)!;
        }
    }

    public AuthenticateResult AuthenticateResult { get; }
    public IEnumerable<string> Clients { get; } = new List<string>();
}