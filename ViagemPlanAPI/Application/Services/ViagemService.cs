using ViagemPlanAPI.Application.Services.Interfaces;
using ViagemPlanAPI.Infrastructure.Repositories;
using ViagemPlanLibrary.Domain.Entities;
using ViagemPlanLibrary.Domain.Interfaces;

namespace ViagemPlanAPI.Application.Services;

public class ViagemService : IViagemService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDestinoService _destinoService;

    public ViagemService(IUnitOfWork unitOfWork, IDestinoService destinoService)
    {
        _unitOfWork = unitOfWork;
        _destinoService = destinoService;
    }

    public decimal CalcularCustoTotalViagem(Viagem viagem)
    {
        return viagem.CalcularCustoTotalViagem();
    }

    public async Task AdicionarDestinoAsync(Viagem viagem, Destino destino)
    {
        ArgumentNullException.ThrowIfNull(viagem);
        ArgumentNullException.ThrowIfNull(destino);

        var repository = _unitOfWork.GetRepository<Viagem>();
        viagem.AdicionarDestino(destino);
        repository.Update(viagem);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task RemoverDestinoAsync(Viagem viagem, Destino destino)
    {
        if (viagem == null) throw new ArgumentNullException(nameof(viagem));
        if (destino == null) throw new ArgumentNullException(nameof(destino));

        var repository = _unitOfWork.GetRepository<Viagem>();
        viagem.RemoverDestino(destino);
        repository.Update(viagem);
        await _unitOfWork.SaveChangesAsync();
    }



    public async Task<IEnumerable<Viagem>> ListarViagemAsync()
    {
        var repository = _unitOfWork.GetRepository<Viagem>();
        return await repository.GetAllAsync();

    }


}
