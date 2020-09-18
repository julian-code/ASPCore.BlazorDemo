using Xunit;
using Bunit;
using BlazorDemo.Pages;
using BlazorDemo.Shared;

namespace BlazorDemo.Tests
{
    public class CalculatorTest : TestContext
    {
        private IRenderedComponent<Calculator> _sut;
        private AngleSharp.Dom.IElement _firstNumberInput;
        private AngleSharp.Dom.IElement _secondNumberInput;
        private AngleSharp.Dom.IElement _finalResultInput;

        public CalculatorTest()
        {
            _sut = RenderComponent<Calculator>();
            _firstNumberInput = _sut.Find("#" + ElementIds.Calculator.FirstNumberId);
            _secondNumberInput = _sut.Find("#" + ElementIds.Calculator.SecondNumberId);
            _finalResultInput = _sut.Find("#" + ElementIds.Calculator.FinalResultId);
        }

        [Theory]
        [InlineData("#" + ElementIds.Calculator.ButtonMultiplyId, "2", "3", "6")]
        [InlineData("#" + ElementIds.Calculator.ButtonAddId, "2", "2", "4")]
        [InlineData("#" + ElementIds.Calculator.ButtonDivideId, "6", "2", "3")]
        [InlineData("#" + ElementIds.Calculator.ButtonSubtractId, "2", "6", "-4")]
        [InlineData("#" + ElementIds.Calculator.ButtonRootId, "4", "", "2")]
        [InlineData("#" + ElementIds.Calculator.ButtonPowerOfTwoId, "4", "", "16")]
        [InlineData("#" + ElementIds.Calculator.ButtonOfCubicRootId, "1000", "", "10")]
        public void TestCalculationButtons(string buttonCssSelector, string firstNumber, string secondNumber, string expectedValue)
        {
            //Arrange
            var button = _sut.Find(buttonCssSelector);
            _firstNumberInput.Change(firstNumber);
            _secondNumberInput.Change(secondNumber);

            //Act
            button.Click(); 
            
            //Assert
            _finalResultInput.MarkupMatches($"<input value=\"{expectedValue}\" readonly=\"\" id=\"input_finalResult\"></input>");
        }
    }
}
