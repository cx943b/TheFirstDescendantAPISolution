using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFirstDescendantAPI;
using TheFirstDescendantAPI.Schemas.User;
using Xunit.Abstractions;

namespace TheFirstDescendantAPITests
{
    public class UserInfoTests : TestBase
    {
        public UserInfoTests(ITestOutputHelper output) : base(output) { }

        [Fact]
        public async Task CheckUser()
        {
            UserInfo userInfo = new UserInfo(_loggerFac.CreateLogger<UserInfo>());
            UserBase? user = await userInfo.GetUserId(_apiClient, "cx943b#3107");

            Assert.NotNull(user);
        }
        [Fact]
        public async Task CheckErrorMessage()
        {
            UserInfo userInfo = new UserInfo(_loggerFac.CreateLogger<UserInfo>());
            UserBase? user = await userInfo.GetUserId(_apiClient, "닉네임#1234");

            Assert.Null(user);
        }

        [Fact]
        public async Task GetUserBasic()
        {
            UserInfo userInfo = new UserInfo(_loggerFac.CreateLogger<UserInfo>());
            UserBasic? userBasic = await userInfo.GetUserBasic(_apiClient, _ouId);

            Assert.NotNull(userBasic);
            _output.WriteLine(userBasic.ToString());
        }
        [Fact]
        public async Task GetUserDescendant()
        {
            UserInfo userInfo = new UserInfo(_loggerFac.CreateLogger<UserInfo>());
            UserDescendant? userDescendant = await userInfo.GetUserDescendant(_apiClient, _ouId);

            Assert.NotNull(userDescendant);
            _output.WriteLine(userDescendant.ToString());
        }
        [Fact]
        public async Task GetUserWeapon()
        {
            UserInfo userInfo = new UserInfo(_loggerFac.CreateLogger<UserInfo>());
            UserWeapon? userWeapon = await userInfo.GetUserWeapon(_apiClient, _ouId);

            Assert.NotNull(userWeapon);
            _output.WriteLine(userWeapon.ToString());
        }
        [Fact]
        public async Task GetUserReactor()
        {
            UserInfo userInfo = new UserInfo(_loggerFac.CreateLogger<UserInfo>());
            UserReactor? userReactor = await userInfo.GetUserReactor(_apiClient, _ouId);

            Assert.NotNull(userReactor);
            _output.WriteLine(userReactor.ToString());
        }
        [Fact]
        public async Task GetUserExternalComponent()
        {
            UserInfo userInfo = new UserInfo(_loggerFac.CreateLogger<UserInfo>());
            UserExternalComponent? userExternalComponent = await userInfo.GetUserExternalComponent(_apiClient, _ouId);

            Assert.NotNull(userExternalComponent);
            _output.WriteLine(userExternalComponent.ToString());
        }
    }
}