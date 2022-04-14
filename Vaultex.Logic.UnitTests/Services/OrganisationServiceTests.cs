using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
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
    }
}
