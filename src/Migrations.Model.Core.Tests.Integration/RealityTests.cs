namespace Migrations.Model.Tests.Integration
{
    using System.IO;
    using EF.Core;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.Extensions.Configuration;
    using Xunit;

    public class RealityTests
    {
        [Fact]
        public void TrueShouldBeTrue()
        {
            Assert.True(true);
        }
    }


}