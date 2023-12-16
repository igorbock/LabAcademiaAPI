namespace LabAcademiaAPI.Services;

public class UsuarioTreinoService : IUsuarioTreinoService
{
    public HttpClient? C_HttpClient { get; set; }

    public UsuarioTreinoService(HttpClient p_HttpClient)
    {
        C_HttpClient = p_HttpClient;
    }

    public async Task<IEnumerable<IdentityUser>> CM_ObterUsuariosAsync()
    {
        var m_Response = await C_HttpClient!.GetAsync("https://localhost:7121/api/Usuario/todos");
        m_Response.EnsureSuccessStatusCode();

        var m_JSON = await m_Response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<IEnumerable<IdentityUser>>(m_JSON) ?? Enumerable.Empty<IdentityUser>();
    }

    public async Task<IdentityUser> CM_ObterUsuarioPorClaimAsync(string p_NomeClaim, string p_ValorClaim)
    {
        var m_Endereco = $"https://localhost:7121/api/Usuario/claim?p_NomeClaim={p_NomeClaim.Trim()}&p_ValorClaim={p_ValorClaim.Trim()}";
        var m_Response = await C_HttpClient!.GetAsync(m_Endereco);
        m_Response.EnsureSuccessStatusCode();

        var m_JSON = await m_Response.Content.ReadAsStringAsync();
        var m_Retorno = JsonSerializer.Deserialize<IEnumerable<IdentityUser>>(m_JSON) ?? Enumerable.Empty<IdentityUser>();
        return m_Retorno.SingleOrDefault()!;
    }

    public async Task<IdentityUser> CM_ObterUsuarioPorIdAsync(string p_ID, string p_Authorization)
    {
        var m_Token = p_Authorization.Replace("Bearer ", string.Empty);
        C_HttpClient!.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", m_Token);

        var m_Endereco = $"https://localhost:7121/api/Usuario/id?p_Id={p_ID}";
        var m_Response = await C_HttpClient!.GetAsync(m_Endereco);
        m_Response.EnsureSuccessStatusCode();

        var m_JSON = await m_Response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<IdentityUser>(m_JSON);
    }

    public async Task<IEnumerable<ClaimDTO>> CM_ObterClaimsDoUsuarioAsync(string p_IdUsuario)
    {
        var m_Endereco = $"https://localhost:7121/api/Usuario/claims?p_IdUsuario={p_IdUsuario}";
        var m_Response = await C_HttpClient!.GetAsync(m_Endereco);
        m_Response.EnsureSuccessStatusCode();

        var m_JSON = await m_Response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<IEnumerable<ClaimDTO>>(m_JSON);
    }
}
