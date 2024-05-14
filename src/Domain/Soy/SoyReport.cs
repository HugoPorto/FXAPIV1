using Flunt.Validations;

namespace FXAPIV1.Domain.SoyReport;

public class SoyReport : Entity
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
    public string SojaIntacta { get; private set; }
    public string CNPJParticipante { get; private set; }
    public bool VistoriaVeiculo { get; private set; }
    public string Umidade { get; private set; }
    public string Impureza { get; private set; }
    public string Ardidos { get; private set; }
    public string Queimados { get; private set; }
    public string FermentadosChocosImaturoGerminado { get; private set; }
    public string Picados { get; private set; }
    public string Mofados { get; private set; }
    public string Esverdeados { get; private set; }
    public string PartidosQuebradosAmassados { get; private set; }
    public string TotalAvariado { get; private set; }
    public string Observacoes { get; private set; }
    public string NomeClassificador { get; private set; }
    public string NomeMotorista { get; private set; }
    public string QrCodePDF { get; private set; }
    public string OrdemCarga { get; private set; }
    public SoyReport() { }
    public SoyReport(
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
        string sojaIntacta,
        string cnpjParticipante,
        bool vistoriaVeiculo,
        string umidade,
        string impureza,
        string ardidos,
        string queimados,
        string fermentadosChocosImaturoGerminado,
        string picados,
        string mofados,
        string esverdeados,
        string partidosQuebradosAmassados,
        string totalAvariado,
        string observacoes,
        string nomeClassificador,
        string nomeMotorista,
        string qrCodePDF,
        string ordemCarga)
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
        SojaIntacta = sojaIntacta;
        CNPJParticipante = cnpjParticipante;
        VistoriaVeiculo = vistoriaVeiculo;
        Umidade = umidade;
        Impureza = impureza;
        Ardidos = ardidos;
        Queimados = queimados;
        FermentadosChocosImaturoGerminado = fermentadosChocosImaturoGerminado;
        Picados = picados;
        Mofados = mofados;
        Esverdeados = esverdeados;
        PartidosQuebradosAmassados = partidosQuebradosAmassados;
        TotalAvariado = totalAvariado;
        Observacoes = observacoes;
        NomeClassificador = nomeClassificador;
        NomeMotorista = nomeMotorista;
        CreatedBy = clientName;
        EditedBy = clientName;
        CreatedOn = DateTime.UtcNow;
        EditedOn = DateTime.UtcNow;
    }
}