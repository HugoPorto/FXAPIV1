using Flunt.Validations;

namespace FXAPIV1.Domain.OrderService;
public class OrderService : Entity
{
    public string ClientId { get; private set; }
    public string UsuarioId { get; private set; }
    public string LocalEmbarque { get; private set; }
    public string LocalEmbarqueEndereco { get; private set; }
    public string Destino { get; private set; }
    public string DestinoEndereco { get; private set; }
    public string Contrato { get; private set; }
    public string TotalCaminhaoEmbarcado { get; private set; }
    public string SaldoOS { get; private set; }
    public string PesoContratado { get; private set; }
    public string Finalizado { get; private set; }
    public OrderService() { }
    public OrderService(
        string clientId,
        string clientName,
        string usuarioId,
        string localEmbarque,
        string localEmbarqueEndereco,
        string destino,
        string destinoEndereco,
        string contrato,
        string totalCaminhaoEmbarcado,
        string saldoOS,
        string pesoContratado,
        string finalizado)
    {
        ClientId = clientId;
        UsuarioId = usuarioId;
        LocalEmbarque = localEmbarque;
        LocalEmbarqueEndereco = localEmbarqueEndereco;
        Destino = destino;
        DestinoEndereco = destinoEndereco;
        Contrato = contrato;
        TotalCaminhaoEmbarcado = totalCaminhaoEmbarcado;
        SaldoOS = saldoOS;
        PesoContratado = pesoContratado;
        Finalizado = finalizado;
        CreatedBy = clientName;
        EditedBy = clientName;
        CreatedOn = DateTime.UtcNow;
        EditedOn = DateTime.UtcNow;
        Validate();
    }

    private void Validate()
    {
        var contract = new Contract<OrderService>()
            .IsNotNull(ClientId, "Client");
        AddNotifications(contract);
    }
}