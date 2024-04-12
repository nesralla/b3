namespace cdbtests;

using cdbapi.Models;
using cdbapi.Services;

public class Tests
{
    private CdbService _svcCdb;
    private Aliquotas _alq;
    private ImpostoService _svcImposto;
    [SetUp]
    public void Setup()
    {
        _svcCdb = new CdbService();
        _alq = new Aliquotas();
        _svcImposto = new ImpostoService();
    }

    [Test]
    public void CalculoValorBrutoCDB()
    {
        // Arrange
        double ValorInvestido = 1000;
        int PrazoEmMeses = 12;


        // Act
        double ValorBruto = _svcCdb.CalcularValorBruto(ValorInvestido, PrazoEmMeses);

        // Assert
        Assert.That(ValorBruto, Is.GreaterThan(ValorInvestido));
    }
    [Test]
    public void CalculoValorLiquidoCDB()
    {
        // Arrange
        double ValorInvestido = 1000;
        int PrazoEmMeses = 12;
        // Act
        double ValorBruto = _svcCdb.CalcularValorBruto(ValorInvestido, PrazoEmMeses);
        double ValorImposto = _svcImposto.CalcularValorImposto(ValorBruto, PrazoEmMeses);
        double ValorLiquido = _svcCdb.CalcularValorLiquido(ValorBruto, ValorImposto);

        // Assert
        Assert.That(ValorLiquido, Is.GreaterThan(ValorInvestido));
    }
}