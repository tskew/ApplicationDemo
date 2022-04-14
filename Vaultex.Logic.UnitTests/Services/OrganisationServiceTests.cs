using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Vaultex.Entities;
using Vaultex.Logic.Repositories;
using Vaultex.Logic.Services;
using Vaultex.Logic.ViewModels;
using Xunit;

namespace Vaultex.Logic.UnitTests.Services
{
    public class OrganisationServiceTests
    {
        [Fact]
        public void GetOrganisations_NoOrganisationsExist_ReturnsViewModelWithEmptyOrganisations()
        {
            // Arrange
            var repo = Substitute.For<IOrganisationServiceRepository>();
            repo.GetOrganisations().Returns(new List<Organisation>());
            var sut = new OrganisationService(repo);

            // Act
            OrganisationIndexViewModel result = sut.GetOrganisations();

            // Assert
            result.Should().NotBeNull();
            result.Organisations.Should().BeEmpty();
        }

        [Fact]
        public void GetOrganisations_OrganisationsExist_ReturnsViewModelWithPopulatedOrganisations()
        {
            // Arrange
            var repo = Substitute.For<IOrganisationServiceRepository>();
            repo.GetOrganisations().Returns(new List<Organisation>
            {
                new Organisation { Id = 1 },
                new Organisation { Id = 2 }
            });
            var sut = new OrganisationService(repo);

            // Act
            OrganisationIndexViewModel result = sut.GetOrganisations();

            // Assert
            result.Should().NotBeNull();
            result.Organisations.Should().HaveCount(2);
        }

        [Fact]
        public void GetOrganisations_OrganisationDoesNotHaveAddress2_AddressLineIsFormattedCorrectly()
        {
            // Arrange
            var repo = Substitute.For<IOrganisationServiceRepository>();
            repo.GetOrganisations().Returns(new List<Organisation> { new Organisation { AddressLine1 = "a", Town = "b", PostCode = "c" } });
            var sut = new OrganisationService(repo);

            // Act
            OrganisationIndexViewModel result = sut.GetOrganisations();

            // Assert
            result.Organisations.Should().ContainSingle();
            result.Organisations.Single().Address.Should().Be("a, b. c");
        }

        [Fact]
        public void GetOrganisations_OrganisationHasAddress2_AddressLineIsFormattedCorrectly()
        {
            // Arrange
            var repo = Substitute.For<IOrganisationServiceRepository>();
            repo.GetOrganisations().Returns(new List<Organisation> { new Organisation { AddressLine1 = "a", AddressLine2 = "b", Town = "c", PostCode = "d" } });
            var sut = new OrganisationService(repo);

            // Act
            OrganisationIndexViewModel result = sut.GetOrganisations();

            // Assert
            result.Organisations.Should().ContainSingle();
            result.Organisations.Single().Address.Should().Be("a, b, c. d");
        }
    }
}
