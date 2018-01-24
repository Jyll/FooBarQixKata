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

        [Fact(DisplayName = "If a number is divisible by three then Foo is returned")]
        public void WhenNumberIsDivisibleByThreeThenFooIsReturned()
        {
            var actualResult = _fooBarQixService.Compute(6);

            Check.That(actualResult).IsEqualTo( FooBarQixService.Foo );
        }

        [Fact(DisplayName = "If a number is divisible by five then Bar is returned")]
        public void WhenNumberIsDivisibleByFiveThenBarIsReturned()
        {
            var actualResult = _fooBarQixService.Compute(10);

            Check.That(actualResult).IsEqualTo( FooBarQixService.Bar );
        }

        [Fact(DisplayName = "If a number is divisible by seven then Qix is returned")]
        public void WhenNumberIsDivisibleBySevenThenQixIsReturned()
        {
            var actualResult = _fooBarQixService.Compute(14);

            Check.That(actualResult).IsEqualTo( FooBarQixService.Qix );
        }

        [Fact(DisplayName = "If a number doesn't meet any of our rules then this number is returned")]
        public void WhenNumberDoesNotMeetAnyRuleThenThisNumberIsReturned()
        {
            var actualResult = _fooBarQixService.Compute(4);

            Check.That(actualResult).IsEqualTo("4");
        }

        [Fact(DisplayName = "Foo is evaluated before Bar and Bar before Qix. Then if a number is divisible by 3 and 5, FooBar is returned")]
        public void FooIsEvaluatedBeforeBarSoIfIHaveBothThenIGetFooBar()
        {
            var actualResult = _fooBarQixService.Compute(60);

            Check.That(actualResult).IsEqualTo( FooBarQixService.Foo + FooBarQixService.Bar );         
        }

        [Fact(DisplayName = "Foo is evaluated before Bar and Bar before Qix.Then if a number is divisible by 3, 5 & 7, FooBarQix is returned")]
        public void FooIsEvaluatedBeforeBarAndBarBeforeQixSoIfIHaveTheThreeThenIGetFooBarQix()
        {
            var actualResult = _fooBarQixService.Compute(210);

            Check.That(actualResult).IsEqualTo( FooBarQixService.Foo + FooBarQixService.Bar + FooBarQixService.Qix );
        }

        [Fact(DisplayName = "When a number contains three then Foo is returned for each occurrence")]
        public void WhenNumberContainsThreeThenFooIsReturned()
        {
            var actualResult = _fooBarQixService.Compute(13);

            Check.That(actualResult).IsEqualTo( FooBarQixService.Foo );
        }

        [Fact(DisplayName = "The foo rule about divisibility is cumulative with the rule about a digit containing 3")]
        public void WhenNumberIsDivisibleByThreeAndContainsThreeOnceThenIShouldHaveFooFoo()
        {
            var actualResult = _fooBarQixService.Compute(3);

            Check.That(actualResult).IsEqualTo( FooBarQixService.Foo +FooBarQixService.Foo );
        }

        [Fact(DisplayName = "When a number contains five then Bar is returned for each occurrence. This is cumulative with the rule about divisibility by 5")]
        public void WhenNumberIsDivisibleByFiveAndContainsFiveOnceThenIShouldHaveBarBar()
        {
            var actualResult = _fooBarQixService.Compute(5);

            Check.That(actualResult).IsEqualTo( FooBarQixService.Bar + FooBarQixService.Bar );
        }

        [Fact(DisplayName = "When a number contains seven then Qix is returned for each occurrence. This is cumulative with the rule about divisibility by seven.")]
        public void WhenNumberIsDivisibleBySevenAndContainsTwoTimesSeven_IShouldHaveQixQixQix()
        {
            var actualResult = _fooBarQixService.Compute(77);

            Check.That(actualResult).IsEqualTo( FooBarQixService.Qix + FooBarQixService.Qix + FooBarQixService.Qix );
        }

        [Fact(DisplayName = "The rule about divisibility is prior to the rule with digits content. So if a number is divisible by 3 and contains a 5, we should have FooBar")]
        public void WhenNumberIsDivisibleByThreeAndContainsFive_ThenIShouldHaveFooBar()
        {
            var actualResult = _fooBarQixService.Compute(51);

            Check.That(actualResult).IsEqualTo( FooBarQixService.Foo + FooBarQixService.Bar );
        }

        [Fact(DisplayName = "When I compute 53, I should have BarFoo as content is analysed in the order of appearance")]
        public void WhenICompute53_IShouldHaveBarFoo()
        {
            var actualResult = _fooBarQixService.Compute(53);

            Check.That(actualResult).IsEqualTo( FooBarQixService.Bar + FooBarQixService.Foo );
        }

        [Fact(DisplayName = "When I compute 15, I should have FooBarBar")]
        public void WhenICompute15_IShouldHaveFooBarBar()
        {
            var actualResult = _fooBarQixService.Compute(15);

            Check.That(actualResult).IsEqualTo( FooBarQixService.Foo + FooBarQixService.Bar + FooBarQixService.Bar );
        }

        [Fact(DisplayName = "Only positive numbers can be computed")]
        public void WhenIComputeMinus1_ThenIShouldGetAnInvalidOperationException()
        {
            var expectedExceptionMessage = "Negative numbers are not allowed in this method.";

            var actualException = Assert.Throws<InvalidOperationException>(() => _fooBarQixService.Compute(-1));
            Check.That(actualException.Message).IsEqualTo(expectedExceptionMessage);
        }

        [Fact(DisplayName = "Classic FooBarQix exercise is computed over 100 iterations from 1 to 100")]
        public void WhenIComputeClassicFooBarQix_ThenIGet100Computations()
        {
            Mock<FooBarQixService> mockedService = new Mock<FooBarQixService>();
            // compute will always return 1
            mockedService.Setup(service => service.Compute(It.IsAny<int>())).Returns("1");
            var currentService = mockedService.Object;

            var actualResults = currentService.DoFooBarQix(100);

            Check.That(actualResults.Count()).IsEqualTo(100);
            // check that returned result of compute has not been modified
            Assert.True(actualResults.All(result => result == "1"));          
            mockedService.Verify(service => service.Compute(It.IsAny<int>()), 
                Times.Exactly(100), 
                "Service has not been called 100 times.");
        }

        [Fact(DisplayName = "Classic FooBarQix exercise does not begin with a number inferior to 1")]
        public void WhenIComputeClassicFooBarQixWithAnEndingIndexLesserThanOne_ThenIShouldGetAnException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _fooBarQixService.DoFooBarQix(0));
        }
    }
}
