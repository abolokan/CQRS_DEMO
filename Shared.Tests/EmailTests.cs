using Domain.Users;

namespace Shared.Tests;

public class Tests
{

    [Test]
    public void EmailCreate_Return_SuccessResult()
    {
        var result = Email.Create("test@gmail.com");
        Assert.That(result.Error, Is.EqualTo(Error.None));
        Assert.True(result.IsSuccess);
    }
}