public class CurrentCompanyService : ICurrentCompanyService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentCompanyService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid GetCompanyId()
    {
        var companyId = _httpContextAccessor.HttpContext?
            .User?
            .FindFirst("companyId")?.Value;

        return Guid.Parse(companyId!);
    }
}