using Moq;

namespace lab5
{
    // Interfejs API
    public interface IMyApi
    {
        int GetValue(int input);
    }

    // Implementacja atrapy API
    public class MyApiMock : IMyApi
    {
        private Mock<IMyApi> _mock;

        public MyApiMock()
        {
            _mock = new Mock<IMyApi>();
        }

        public int GetValue(int input)
        {
            // W tym przyk�adzie zawsze zwracamy warto�� 42
            return _mock.Object.GetValue(input);
        }

        // Metoda, kt�ra pozwala na ustawienie odpowiedzi atrapy API
        public void SetMockResponse(int response)
        {
            _mock.Setup(api => api.GetValue(It.IsAny<int>()))
                 .Returns(response);
        }
    }

    // Testy jednostkowe
    [TestFixture]
    public class MyApiTests
    {
        private MyApiMock _apiMock;

        [SetUp]
        public void Setup()
        {
            _apiMock = new MyApiMock();
        }

        [Test]
        public void TestGetValue()
        {
            // Ustawiamy odpowied� atrapy API
            _apiMock.SetMockResponse(10);

            // Wywo�ujemy metod� API i por�wnujemy wynik z oczekiwan� warto�ci�
            Assert.That(_apiMock.GetValue(123), Is.EqualTo(10));
        }
    }
}