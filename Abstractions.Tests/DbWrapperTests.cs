using Moq;
using Xunit;
using Abstractions.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Abstractions.Tests;

public class DbWrapperTests
{
    [Fact]
    public async Task DbContextWrapperMockTests()
    {
        var wrapperMock = new Mock<IDbContextWrapper<AnimalContext>>();

        // Set up the wrapper mock to return a certain result when any async int-List-returning function is executed on the context. 
        var expectedBeaverIds = new List<int> { 1, 2, 3 };
        wrapperMock.Setup(wm => wm.Execute(It.IsAny<Func<AnimalContext, Task<List<int>>>>()))
            .ReturnsAsync(expectedBeaverIds);

        // Invoke some function on the context that is supposed to return a list of integers asynchronously.
        var beaverIds = await wrapperMock.Object
            .Execute(context =>
            {
                return context.Beavers
                    .Where(x => x.BeaverName != null && x.BeaverName.StartsWith("A"))
                    .Where(x => x.LodgeId == 45)
                    .Select(x => x.BeaverId)
                    .ToListAsync();
            });

        // For the purposes of this unit test, we were able to assume that EF Core works as expected
        Assert.Same(expectedBeaverIds, beaverIds);
    }
}
