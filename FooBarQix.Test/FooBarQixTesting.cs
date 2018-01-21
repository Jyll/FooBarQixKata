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
    }
}
