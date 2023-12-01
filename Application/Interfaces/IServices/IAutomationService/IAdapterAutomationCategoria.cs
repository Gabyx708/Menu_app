using Application.Models;

namespace Application.Interfaces.IServices.IAutomationService
{
    public interface IAdapterAutomationCategoria
    {
        List<CategoriaResponse> listaCategorias();
        CategoriaResponse insertNuevaCategoria(CategoriaRequest request);
    }
}
