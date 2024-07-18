using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFirstDescendantAPI;
using TheFirstDescendantAPI.Schemas;

namespace TheFirstDescendantAPITests
{
    public class UserInfoTests : TestBase
    {
        [Fact]
        public async Task CheckUserTest()
        {
            // Arrange
            UserInfo userInfo = new UserInfo(_loggerFac.CreateLogger<UserInfo>());
            User? user = await userInfo.CheckUser(_apiClient, "닉네임#1234");

            // Assert
            Assert.NotNull(user);
            // Add additional assertions here
        }
    }
}
