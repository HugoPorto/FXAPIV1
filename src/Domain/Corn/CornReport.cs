using Flunt.Validations;

namespace FXAPIV1.Domain.CornReport;
public class CornReport : Entity
{
    public string Produto { get; private set; }
    public string OrderServiceId { get; private set; }
    public string NumeroNotaFiscal { get; private set; }
    public string PesoLiquido { get; private set; }
    public string NumeroLacre { get; private set; }
    public string PlacaCaminhao1 { get; private set; }
    public string PlacaCaminhao2 { get; private set; }
    public string PlacaCaminhao3 { get; private set; }
    public string Transportadora { get; private set; }
    public string PesoAmostra { get; private set; }
    public string TesteAflatoxina { get; private set; }
    public bool VistoriaVeiculo { get; private set; }
    public string Umidade { get; private set; }
    public string Impureza { get; private set; }
    public string ArdidoQueimado { get; private set; }
    public string Fermentados { get; private set; }
    public string Carunchados { get; private set; }
    public string PartidosQuebrados { get; private set; }
    public string TotalAvariado { get; private set; }
    public string Observacoes { get; private set; }
    public string NomeClassificador { get; private set; }
    public string NomeMotorista { get; private set; }
    public string OrdemCarga { get; private set; }
    public string QrCodePDF { get; private set; }
    public CornReport() { }

    public CornReport(
        string produto,
        string clientName,
        string orderServiceId,
        string numeroNotaFiscal,
        string pesoLiquido,
        string numeroLacre,
        string placaCaminhao1,
        string placaCaminhao2,
        string placaCaminhao3,
        string transportadora,
        string pesoAmostra,
        string testeAflatoxina,
        bool vistoriaVeiculo,
        string umidade,
        string impureza,
        string ardidoQueimado,
        string fermentados,
        string carunchados,
        string partidosQuebrados,
        string totalAvariado,
        string observacoes,
        string nomeClassificador,
        string nomeMotorista,
        string ordemCarga,
        string qrCodePDF)
    {
        Produto = produto;
        OrderServiceId = orderServiceId;
        NumeroNotaFiscal = numeroNotaFiscal;
        PesoLiquido = pesoLiquido;
        NumeroLacre = numeroLacre;
        PlacaCaminhao1 = placaCaminhao1;
        PlacaCaminhao2 = placaCaminhao2;
        PlacaCaminhao3 = placaCaminhao3;
        Transportadora = transportadora;
        PesoAmostra = pesoAmostra;
        TesteAflatoxina = testeAflatoxina;
        VistoriaVeiculo = vistoriaVeiculo;
        Umidade = umidade;
        Impureza = impureza;
        ArdidoQueimado = ardidoQueimado;
        Fermentados = fermentados;
        Carunchados = carunchados;
        PartidosQuebrados = partidosQuebrados;
        TotalAvariado = totalAvariado;
        Observacoes = observacoes;
        NomeClassificador = nomeClassificador;
        NomeMotorista = nomeMotorista;
        OrdemCarga = ordemCarga;
        QrCodePDF = qrCodePDF;
        CreatedBy = clientName;
        EditedBy = clientName;
        CreatedOn = DateTime.UtcNow;
        EditedOn = DateTime.UtcNow;
    }

}