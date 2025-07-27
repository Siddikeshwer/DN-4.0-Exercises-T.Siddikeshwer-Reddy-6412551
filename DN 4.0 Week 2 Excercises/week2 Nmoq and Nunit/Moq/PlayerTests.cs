using NUnit.Framework;
using Moq;
using PlayersManagerLib;
using System;

namespace PlayersManager.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Mock<IPlayerMapper> _mockPlayerMapper;

        [OneTimeSetUp]
        public void Init()
        {
            _mockPlayerMapper = new Mock<IPlayerMapper>();
        }

        [Test]
        public void RegisterNewPlayer_ShouldReturnPlayer_WhenNameIsUnique()
        {
            _mockPlayerMapper.Setup(m => m.IsPlayerNameExistsInDb(It.IsAny<string>())).Returns(false);

            var player = Player.RegisterNewPlayer("Dhoni", _mockPlayerMapper.Object);

            Assert.That(player, Is.Not.Null);
            Assert.That(player.Name, Is.EqualTo("Dhoni"));
            Assert.That(player.Age, Is.EqualTo(23));
            Assert.That(player.Country, Is.EqualTo("India"));
            Assert.That(player.NoOfMatches, Is.EqualTo(30));
        }

        [Test]
        public void RegisterNewPlayer_ShouldThrowException_WhenNameAlreadyExists()
        {
            _mockPlayerMapper.Setup(m => m.IsPlayerNameExistsInDb(It.IsAny<string>())).Returns(true);

            Assert.Throws<ArgumentException>(() => Player.RegisterNewPlayer("Dhoni", _mockPlayerMapper.Object));
        }

        [Test]
        public void RegisterNewPlayer_ShouldThrowException_WhenNameIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => Player.RegisterNewPlayer("", _mockPlayerMapper.Object));
        }
    }
}
