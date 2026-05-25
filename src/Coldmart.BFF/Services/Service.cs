using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text;
using System.Text.Json;
using Coldmart.Core.Communication;

namespace Coldmart.BFF.Services;

[ExcludeFromCodeCoverage]
public abstract class Service
{
    protected readonly static JsonSerializerOptions DefaultOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    protected StringContent ObterConteudo(object dado)
    {
        return new StringContent(
            JsonSerializer.Serialize(dado),
            Encoding.UTF8,
            "application/json");
    }

    protected bool TratarErrosResponse(HttpResponseMessage response)
    {
        if (response.StatusCode == HttpStatusCode.BadRequest) return false;
        response.EnsureSuccessStatusCode();
        return true;
    }

    protected async Task<T?> DeserializarObjetoResponse<T>(HttpResponseMessage responseMessage)
    {
        using var content = await responseMessage.Content.ReadAsStreamAsync();
        return content.Length == 0 ? default : await JsonSerializer.DeserializeAsync<T>(content, DefaultOptions);
    }

    protected ResponseResult RetornoOk()
    {
        return new ResponseResult();
    }
}
