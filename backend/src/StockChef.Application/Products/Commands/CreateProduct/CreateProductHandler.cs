using MediatR;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, Unit>
{
    private readonly IProductRepository _repository;
    private readonly ICurrentCompanyService _currentCompanyService;
    private readonly IUnitRepository _unitRepository;

    public CreateProductHandler(
        IProductRepository repository,
        ICurrentCompanyService currentCompanyService,
        IUnitRepository unitRepository)
    {
        _repository = repository;
        _currentCompanyService = currentCompanyService;
        _unitRepository = unitRepository;
    }

    public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var companyId = _currentCompanyService.GetCompanyId();

        var unit = await _unitRepository.GetByIdAsync(request.UnitId);

        if (unit is null || unit.CompanyId != companyId)
            throw new Exception("Unidade inválida");

        var product = new Product(
            request.Name,
            request.UnitPrice,
            request.UnitId,
            companyId
        );

        await _repository.AddAsync(product);

        return Unit.Value;
    }
}