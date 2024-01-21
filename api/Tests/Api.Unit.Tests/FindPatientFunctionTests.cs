using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;
using System.Web.Http;
using Api.Models;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Api.Unit.Tests;

public class FindPatientFunctionTests
{
    private readonly Mock<IDataService> _dataServiceMock = new();
    private readonly Mock<ILogger> _loggerMock = new();

    private FindPatientFunction Sut => new (_dataServiceMock.Object);

    [Fact]
    public async Task Run_When_PatientExists_Then_ReturnsOkAndResult()
    {
        // Arrange
        var patientName = "john";
        var patient = new Patient(Guid.NewGuid(), "John Doe", 33);
        _dataServiceMock.Setup(x => x.FindPatientAsync(patientName, It.IsAny<CancellationToken>()))
            .ReturnsAsync(ResultOrError<Patient, Exception>.WithSuccess(patient))
            .Verifiable();

        // Act
        var result = await Sut.Run(Mock.Of<HttpRequest>(), patientName, _loggerMock.Object, default);

        // Assert
        using var scope = new AssertionScope();
        result.Should().BeOfType<OkObjectResult>().Which.Value.Should().BeEquivalentTo(patient);
        _dataServiceMock.Verify();
    }

    [Fact]
    public async Task Run_When_PatientDoNotExists_Then_ReturnsNotFound()
    {
        // Arrange
        var patientName = "john";
        _dataServiceMock.Setup(x => x.FindPatientAsync(patientName, It.IsAny<CancellationToken>()))
            .ReturnsAsync(ResultOrError<Patient, Exception>.WithError(new InvalidOperationException()))
            .Verifiable();

        // Act
        var result = await Sut.Run(Mock.Of<HttpRequest>(), patientName, _loggerMock.Object, default);

        // Assert
        using var scope = new AssertionScope();
        result.Should().BeOfType<NotFoundResult>();
        _dataServiceMock.Verify();
    }

    [Fact]
    public async Task Run_When_ExceptionIsThrown_Then_ReturnsInternalServerError()
    {
        // Arrange
        var patientName = "john";
        _dataServiceMock.Setup(x => x.FindPatientAsync(patientName, It.IsAny<CancellationToken>()))
            .ReturnsAsync(ResultOrError<Patient, Exception>.WithError(new Exception()))
            .Verifiable();

        // Act
        var result = await Sut.Run(Mock.Of<HttpRequest>(), patientName, _loggerMock.Object, default);

        // Assert
        using var scope = new AssertionScope();
        result.Should().BeOfType<InternalServerErrorResult>();
        _dataServiceMock.Verify();
    }
}