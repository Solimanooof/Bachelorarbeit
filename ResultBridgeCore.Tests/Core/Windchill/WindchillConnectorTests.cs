using NUnit.Framework;
using ResultBridge.Core.Core.Windchill;
using ResultBridgeCore.Tests.Utils;
using System;

namespace ResultBridgeCore.Tests.Core.Windchill
{
    [TestFixture]
    public class WindchillConnectorTests
    {
        [Test]
        public void Connect_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var windchillConnector = new WindchillConnector("emea-integrity.karlstorz.com", 7001);
            string userName = "soabdelwah";
            string password = "12363";

            bool connectedEventRaised = false;
            windchillConnector.OnConnected += (sender, args) => connectedEventRaised = true;

            // Act
            windchillConnector.Connect(
                userName,
                password);

            // Assert
            Assert.IsTrue(connectedEventRaised);
        }

        [Test]
        public void SetTestResultFor_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var windchillConnector = new WindchillConnector("emea-integrity.karlstorz.com", 7001);
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
            var windchillConnector = new WindchillConnector("emea-integrity.karlstorz.com", 7001);

            bool disconnectedEventRaised = false;
            windchillConnector.OnDisconnected += (sender, args) => disconnectedEventRaised = true;
            // Act
            windchillConnector.Disconnect();

            // Assert
            Assert.IsTrue(disconnectedEventRaised);
        }
    }
}
