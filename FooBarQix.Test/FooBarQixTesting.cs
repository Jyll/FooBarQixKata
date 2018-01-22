using System;
using Xunit;
using NFluent;
using Moq;
using System.Linq;

namespace FooBarQix.Test
{
    public class FooBarQixTesting
    {
        private readonly IFooBarQixService _fooBarQixService;

        public FooBarQixTesting()
        {
            _fooBarQixService = new FooBarQixService();
        }

        [Fact(DisplayName = "When I compute 6, I should have Foo")]
        public void WhenIComputeTheNumber6WithFooBarQix_ThenIShouldGetBackFoo()
        {
            // act 
            var actualResult = _fooBarQixService.FooBarQixComputation(6);
            // assert 
            Check.That(actualResult).IsEqualTo( FooBarQixService.Foo );
        }

        [Fact(DisplayName = "When I compute 10, I should have Bar")]
        public void WhenIComputeTheNumber10WithFooBarQix_ThenIShouldGetBackBar()
        {
            // act 
            var actualResult = _fooBarQixService.FooBarQixComputation(10);
            // assert 
            Check.That(actualResult).IsEqualTo( FooBarQixService.Bar );
        }

        [Fact(DisplayName = "When I compute 14, I should have Qix")]
        public void WhenIComputeTheNumber14WithFooBarQix_ThenIShouldGetBackQix()
        {
            // act
            var actualResult = _fooBarQixService.FooBarQixComputation(14);
            // assert
            Check.That(actualResult).IsEqualTo( FooBarQixService.Qix );
        }

        [Fact(DisplayName = "When I compute 4 (that does not match foobarqix), I should get 4")]
        public void WhenIComputeANumberThatDoesNotMatchFooBarQixLike4_ThenIShouldGetBackTheNumberGiven()
        {
            // act 
            var actualResult = _fooBarQixService.FooBarQixComputation(4);
            // assert
            Check.That(actualResult).IsEqualTo("4");
        }

        [Fact(DisplayName = "When I compute 60, I should get FooBar")]
        public void WhenIComputeTheNumber60WithFooBarQix_ThenIShouldGetBackFooBar()
        {
            // act
            var actualResult = _fooBarQixService.FooBarQixComputation(60);
            // assert
            Check.That(actualResult).IsEqualTo( FooBarQixService.Foo + FooBarQixService.Bar );         
        }

        [Fact(DisplayName = "When I compute 210, I should get FooBarQix")]
        public void WhenIComputeTheNumber210WithFooBarQix_ThenIShouldGetBackFooBarQix()
        {
            // act
            var actualResult = _fooBarQixService.FooBarQixComputation(210);
            // assert
            Check.That(actualResult).IsEqualTo( FooBarQixService.Foo + FooBarQixService.Bar + FooBarQixService.Qix );
        }

        [Fact(DisplayName = "When I compute 3, I should get FooFoo")]
        public void WhenICompute3_IShouldHaveFooFoo()
        {
            // act 
            var actualResult = _fooBarQixService.FooBarQixComputation(3);
            // assert
            Check.That(actualResult).IsEqualTo( FooBarQixService.Foo + FooBarQixService.Foo );
        }

        [Fact(DisplayName = "When I compute 33, I should get FooFooFoo")]
        public void WhenICompute33_IShouldHaveFooFooFoo()
        {
            // act 
            var actualResult = _fooBarQixService.FooBarQixComputation(33);
            // assert
            Check.That(actualResult).IsEqualTo( FooBarQixService.Foo + FooBarQixService.Foo + FooBarQixService.Foo );
        }

        [Fact(DisplayName = "When I compute 55, I should get BarBarBar")]
        public void WhenICompute55_IShouldHaveBarBarBar()
        {
            // act 
            var actualResult = _fooBarQixService.FooBarQixComputation(55);
            // assert
            Check.That(actualResult).IsEqualTo( FooBarQixService.Bar + FooBarQixService.Bar + FooBarQixService.Bar );
        }

        [Fact(DisplayName = "When I compute 77, I should get QixQixQix")]
        public void WhenICompute77_IShouldHaveQixQixQix()
        {
            // act 
            var actualResult = _fooBarQixService.FooBarQixComputation(77);
            // assert 
            Check.That(actualResult).IsEqualTo( FooBarQixService.Qix + FooBarQixService.Qix + FooBarQixService.Qix );
        }

        [Fact(DisplayName = "When I compute 51, I should have FooBar as divisor have high precedence")]
        public void WhenICompute51_IShouldHaveFooBar()
        {
            // act 
            var actualResult = _fooBarQixService.FooBarQixComputation(51);
            // assert 
            Check.That(actualResult).IsEqualTo( FooBarQixService.Foo + FooBarQixService.Bar );
        }

        [Fact(DisplayName = "When I compute 53, I should have BarFoo as content is analysed in the order of appearance")]
        public void WhenICompute53_IShouldHaveBarFoo()
        {
            // act
            var actualResult = _fooBarQixService.FooBarQixComputation(53);
            // assert
            Check.That(actualResult).IsEqualTo( FooBarQixService.Bar + FooBarQixService.Foo );
        }

        [Fact(DisplayName = "When I compute 15, I should have FooBarBar")]
        public void WhenICompute15_IShouldHaveFooBarBar()
        {
            // act 
            var actualResult = _fooBarQixService.FooBarQixComputation(15);
            // assert 
            Check.That(actualResult).IsEqualTo( FooBarQixService.Foo + FooBarQixService.Bar + FooBarQixService.Bar );
        }

        [Fact(DisplayName = "When I try to compute a negative number, I should get an exception")]
        public void WhenIComputeMinus1_ThenIShouldGetAnInvalidOperationException()
        {
            // arrange 
            var expectedExceptionMessage = "Negative numbers are not allowed in this method.";

            // act
            // assert
            var actualException = Assert.Throws<InvalidOperationException>(() => _fooBarQixService.FooBarQixComputation(-1));
            Check.That(actualException.Message).IsEqualTo(expectedExceptionMessage);
        }

        [Fact(DisplayName = "When I want to compute a classic FooBarQix, I get 100 computations of FooBarQix")]
        public void WhenIComputeClassicFooBarQix_ThenIGet100Computations()
        {
            // arrange 
            Mock<FooBarQixService> mockedService = new Mock<FooBarQixService>();
            mockedService.Setup(service => service.FooBarQixComputation(It.IsAny<int>())).Returns("1");
            var currentService = mockedService.Object;

            // act 
            var actualResults = currentService.DoFooBarQix(100);

            // assert
            Check.That(actualResults.Count()).IsEqualTo(100);
            Assert.True(actualResults.All(result => result == "1"));
            mockedService.Verify(service => service.FooBarQixComputation(It.IsAny<int>()), 
                Times.Exactly(100), 
                "Service has not been called 100 times.");
        }

        [Fact(DisplayName = "When I want to compute a classic FooBarQix with a number lesser than 1, then I get an Exception")]
        public void WhenIComputeClassicFooBarQixWithAnEndingIndexLesserThanOne_ThenIShouldGetAnException()
        {
            // act
            // assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _fooBarQixService.DoFooBarQix(0));
        }
    }
}
