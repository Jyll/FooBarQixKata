using System;
using Xunit;
using NFluent;

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
            Check.That(actualResult).IsEqualTo("Foo");
        }

        [Fact(DisplayName = "When I compute 10, I should have Bar")]
        public void WhenIComputeTheNumber10WithFooBarQix_ThenIShouldGetBackBar()
        {
            // act 
            var actualResult = _fooBarQixService.FooBarQixComputation(10);
            // assert 
            Check.That(actualResult).IsEqualTo("Bar");
        }

        [Fact(DisplayName = "When I compute 14, I should have Qix")]
        public void WhenIComputeTheNumber14WithFooBarQix_ThenIShouldGetBackQix()
        {
            // act
            var actualResult = _fooBarQixService.FooBarQixComputation(14);
            // assert
            Check.That(actualResult).IsEqualTo("Qix");
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
            Check.That(actualResult).IsEqualTo("FooBar");         
        }

        [Fact(DisplayName = "When I compute 210, I should get FooBarQix")]
        public void WhenIComputeTheNumber210WithFooBarQix_ThenIShouldGetBackFooBarQix()
        {
            // act
            var actualResult = _fooBarQixService.FooBarQixComputation(210);
            // assert
            Check.That(actualResult).IsEqualTo("FooBarQix");
        }

        [Fact(DisplayName = "When I compute 3, I should get FooFoo")]
        public void WhenICompute3_IShouldHaveFooFoo()
        {
            // act 
            var actualResult = _fooBarQixService.FooBarQixComputation(3);
            // assert
            Check.That(actualResult).IsEqualTo("FooFoo");
        }

        [Fact(DisplayName = "When I compute 33, I should get FooFooFoo")]
        public void WhenICompute33_IShouldHaveFooFooFoo()
        {
            // act 
            var actualResult = _fooBarQixService.FooBarQixComputation(33);
            // assert
            Check.That(actualResult).IsEqualTo("FooFooFoo");
        }

        [Fact(DisplayName = "When I compute 55, I should get BarBarBar")]
        public void WhenICompute55_IShouldHaveBarBarBar()
        {
            // act 
            var actualResult = _fooBarQixService.FooBarQixComputation(55);
            // assert
            Check.That(actualResult).IsEqualTo("BarBarBar");
        }

        [Fact(DisplayName = "When I compute 77, I should get QixQixQix")]
        public void WhenICompute77_IShouldHaveQixQixQix()
        {
            // act 
            var actualResult = _fooBarQixService.FooBarQixComputation(77);
            // assert 
            Check.That(actualResult).IsEqualTo("QixQixQix");
        }

        [Fact(DisplayName = "When I compute 51, I should have FooBar as divisor have high precedence")]
        public void WhenICompute51_IShouldHaveFooBar()
        {
            // act 
            var actualResult = _fooBarQixService.FooBarQixComputation(51);
            // assert 
            Check.That(actualResult).IsEqualTo("FooBar");
        }

        [Fact(DisplayName = "When I compute 53, I should have BarFoo as content is analysed in the order of appearance")]
        public void WhenICompute53_IShouldHaveBarFoo()
        {
            // act
            var actualResult = _fooBarQixService.FooBarQixComputation(53);
            // assert
            Check.That(actualResult).IsEqualTo("BarFoo");
        }

        [Fact(DisplayName = "When I compute 15, I should have FooBarBar")]
        public void WhenICompute15_IShouldHaveFooBarBar()
        {
            // act 
            var actualResult = _fooBarQixService.FooBarQixComputation(15);
            // assert 
            Check.That(actualResult).IsEqualTo("FooBarBar");
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
    }
}
