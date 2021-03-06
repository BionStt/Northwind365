using Northwind.Domain.Exceptions;
using Northwind.Domain.ValueObjects;
using Shouldly;
using Xunit;

namespace Northwind.Domain.Tests.ValueObjects
{
    public class AdAccountTests
    {
        [Fact]
        public void ShouldHaveCorrectDomain()
        {
            var account = AdAccount.For("SSW\\Jason");

            account.Domain.ShouldBe("SSW");
        }

        [Fact]
        public void ShouldHaveCorrectName()
        {
            var account = AdAccount.For("SSW\\Jason");

            account.Name.ShouldBe("Jason");
        }

        [Fact]
        public void ImplicitConversionToStringReturnsDomainAndName()
        {
            // Arrange
            const string value = "SSW\\Jason";

            // Act
            var account = AdAccount.For(value);
            string result = account;

            // Assert
            result.ShouldBe(value);
        }

        [Fact]
        public void ExplicitConversionFromStringSetsDomainAndName()
        {
            // Act
            var account = (AdAccount) "SSW\\Jason";

            // Assert
            account.Domain.ShouldBe("SSW");
            account.Name.ShouldBe("Jason");
        }

        [Fact]
        public void ShouldThrowAdAccountInvalidExceptionForInvalidAdAccount()
        {
            Should.Throw<AdAccountInvalidException>(() => (AdAccount)"SSWJason");
        }
    }
}
