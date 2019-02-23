using NUnit.Framework;
using NSubstitute;
using FlowerShop;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestDelivery()
        {
            //Arrange
            IClient MockClient = Substitute.For<IClient>();
            IOrderDAO MockOrderDAO = Substitute.For<IOrderDAO>();
            Order x = new Order(MockOrderDAO, MockClient);

            //Act
            x.Deliver();

            //Assert
            MockOrderDAO.Received().SetDelivered(x);
        }

        [Test]
        public void TestPrice()
        {
            //Arrange
            IClient MockClient = Substitute.For<IClient>();
            IOrderDAO MockOrderDAO = Substitute.For<IOrderDAO>();
            IFlowerDAO MockFlowerDao = Substitute.For<IFlowerDAO>();
            Order x = new Order(MockOrderDAO, MockClient);
            Flower MockFlower = Substitute.For<Flower>(MockFlowerDao, "Not A Flower", 10.00, 5); //Base price of 10.00

            //Act
            x.AddFlowers(MockFlower);

            //Assert
            Assert.AreEqual(12.00, x.Price);
        }
    }
}