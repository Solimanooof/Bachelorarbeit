using NUnit.Framework;
using ResultBridge.Core.Core.Windchill;
using ResultBridgeCore.Tests.Utils;
using System;
using System.Threading;
using CredentialManagement;
using ResultBridge.Core.Model;
using ResultBridge.Core.Model.Windchill;

namespace ResultBridgeCore.Tests.Core.Windchill
{
    [TestFixture]
    public class WindchillConnectorTests
    {
        //[SetUp]
        //public void Setup()
        //{
        //    var windchillConfiguration = new WindchillConfiguration("emea-integrity.karlstorz.com", 7001);
        //    var userCredentials = new UserCredentials("soabdelwah", "12363");
        //    // Arrange
        //    var windchillConnector = new WindchillConnector(windchillConfiguration, userCredentials);
        //    windchillConnector.Disconnect();
        //}

        [Test]
        public void CallingConnect_WhenWrongUserDetails_ThanOnConnectedIsNotCalledAndCommandFileIsCalled()
        {
            var windchillConfiguration = new WindchillConfiguration("emea-integrity.karlstorz.com", 7001);
            var userCredentials = new UserCredentials("soabdelwah", "12363");
            // Arrange
            var windchillConnector = new WindchillConnector(windchillConfiguration, userCredentials);
            string userName = "soabdelwah";
            string password = "12363";

            var onConnectedEventCalled = new AutoResetEvent(false);
            windchillConnector.OnConnected += (sender, args) => onConnectedEventCalled.Set();
            var onCommandFailedEventCalled = new AutoResetEvent(false);
            windchillConnector.OnCommandFailed += (sender, args) => onCommandFailedEventCalled.Set();

            // Act
            windchillConnector.Connect();

            // Assert
            Assert.IsFalse(onConnectedEventCalled.WaitOne(TimeSpan.FromSeconds(30)));
            Assert.IsTrue(onCommandFailedEventCalled.WaitOne(TimeSpan.FromSeconds(30)));
        }

        [Test]
        public void ReadCreadential()
        {
            var cred = new Credential { Target = "windchill" };
            bool isLoaded = cred.Load();
            Assert.That(cred.Username, Is.EqualTo("soliman"));
        }

        [Test]
        public void WhenCallingIsConnectedWhenUserIsDisconnected_ThenItShouldReturnFalse()
        {
            // Arrange
            var windchillConfiguration = new WindchillConfiguration("emea-integrity.karlstorz.com", 7001);
            var userCredentials = new UserCredentials("soabdelwah", "12363");
            var windchillConnector = new WindchillConnector(windchillConfiguration, userCredentials);

            // Act
            bool isConnected = windchillConnector.IsConnected();
            Console.WriteLine(isConnected);

            // Assert
            Assert.That(isConnected, Is.False);
        }

        [Test]
        public void WhenCallingIsConnectedWhenUserIsConnected_ThenItShouldReturnTrue()
        {
            // Arrange
            var windchillConfiguration = new WindchillConfiguration("emea-integrity.karlstorz.com", 7001);
            var userCredentials = new UserCredentials("soabdelwah", "12363");
            var windchillConnector = new WindchillConnector(windchillConfiguration, userCredentials);

            // Act
            bool isConnected = windchillConnector.IsConnected();

            // Assert
            Assert.That(isConnected, Is.True);
        }

        [Test]
        public void SetTestResultFor_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var windchillConfiguration = new WindchillConfiguration("emea-integrity.karlstorz.com", 7001);
            var userCredentials = new UserCredentials("soabdelwah", "12363");
            var windchillConnector = new WindchillConnector(windchillConfiguration, userCredentials);
            string caseId = "12236";
            string result = "pass";
            string sessionId = "25893";

            bool importedEventRaised = false;
            windchillConnector.OnTestResultImported += (sender, args) =>
            {
                importedEventRaised = true;
                Assert.AreEqual(caseId, caseId);
                Assert.AreEqual(sessionId, sessionId);
                Assert.AreEqual(result, result);

            };
            // Act
            windchillConnector.SetTestResultFor(
                caseId,
                result,
                sessionId);

            // Assert
            Assert.IsTrue(importedEventRaised);
        }

        [Test]
        public void Disconnect_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var windchillConfiguration = new WindchillConfiguration("emea-integrity.karlstorz.com", 7001);
            var userCredentials = new UserCredentials("soabdelwah", "12363");
            var windchillConnector = new WindchillConnector(windchillConfiguration, userCredentials);

            bool disconnectedEventRaised = false;
            windchillConnector.OnDisconnected += (sender, args) => disconnectedEventRaised = true;
            // Act
            windchillConnector.Disconnect();

            // Assert
            Assert.IsTrue(disconnectedEventRaised);
        }
    }
}
