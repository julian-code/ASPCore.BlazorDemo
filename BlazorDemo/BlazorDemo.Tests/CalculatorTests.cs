using Xunit;
using Bunit;
using BlazorDemo.Pages;
using BlazorDemo.Shared;
using System.Collections.Generic;
using System.Collections;
using Xunit.Sdk;
using System.Reflection;
using System;
using System.Linq;
using System.IO;

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
        // [InlineData("#" + ElementIds.Calculator.ButtonMultiplyId, "2", "3", "6")]
        // [InlineData("#" + ElementIds.Calculator.ButtonAddId, "2", "2", "4")]
        // [InlineData("#" + ElementIds.Calculator.ButtonDivideId, "6", "2", "3")]
        // [InlineData("#" + ElementIds.Calculator.ButtonSubtractId, "2", "6", "-4")]
        // [InlineData("#" + ElementIds.Calculator.ButtonRootId, "4", "", "2")]
        // [InlineData("#" + ElementIds.Calculator.ButtonPowerOfTwoId, "4", "", "16")]
        // [InlineData("#" + ElementIds.Calculator.ButtonOfCubicRootId, "1000", "", "10")]
        //[MemberData(nameof(GetCalculatorDataMemberData))]
        [ReadTestData(@"/home/julian/Desktop/Undervisning/Test/BlazorCalculator/ASPCore.BlazorDemo/BlazorDemo/BlazorDemo.Tests/TestData/TestData.csv", false)]
        // [ClassData(typeof(GetCalculatorClassData))]
        public void TestCalculationButtons(string buttonCssSelector, string firstNumber, string secondNumber, string expectedValue)
        {
            //Arrange
            var button = _sut.Find(buttonCssSelector);
            _firstNumberInput.Change(firstNumber);
            _secondNumberInput.Change(secondNumber);

            //Act
            button.Click(); 
            
            //Assert
            _finalResultInput.MarkupMatches($"<input value=\"{expectedValue}\" readonly=\"\" id=\"{ElementIds.Calculator.FinalResultId}\"></input>");
        }

        public static IEnumerable<object[]> GetCalculatorDataMemberData() {
            yield return new object[] {
                "#" + ElementIds.Calculator.ButtonMultiplyId,
                "2",
                "3",
                "6"
            };
            yield return new object[] {
                "#" + ElementIds.Calculator.ButtonAddId,
                "2",
                "2",
                "4"
            };
            yield return new object[] {
                "#" + ElementIds.Calculator.ButtonDivideId,
                "6",
                "2",
                "3"
            };
            yield return new object[] {
                "#" + ElementIds.Calculator.ButtonSubtractId,
                "2",
                "6",
                "-4"
            };
            yield return new object[] {
                "#" + ElementIds.Calculator.ButtonRootId,
                "4",
                "",
                "2"
            };
            yield return new object[] {
                "#" + ElementIds.Calculator.ButtonPowerOfTwoId,
                "4",
                "",
                "16"
            };
            yield return new object[] {
                "#" + ElementIds.Calculator.ButtonOfCubicRootId,
                "1000",
                "",
                "10"
            };
        }
    }

    public class GetCalculatorClassData : IEnumerable<object[]>
    {
        private IEnumerable<object[]> data => new[] {
            new object[] {
                "#" + ElementIds.Calculator.ButtonMultiplyId,
                "2",
                "3",
                "6"
            },
            new object[] {
                "#" + ElementIds.Calculator.ButtonAddId,
                "2",
                "2",
                "4"
            },
            new object[] {
                "#" + ElementIds.Calculator.ButtonDivideId,
                "6",
                "2",
                "3"
            },
            new object[] {
                "#" + ElementIds.Calculator.ButtonSubtractId,
                "2",
                "6",
                "-4"
            },
            new object[] {
                "#" + ElementIds.Calculator.ButtonRootId,
                "4",
                "",
                "2"
            },
            new object[] {
                "#" + ElementIds.Calculator.ButtonPowerOfTwoId,
                "4",
                "",
                "16"
            },
            new object[] {
                "#" + ElementIds.Calculator.ButtonOfCubicRootId,
                "1000",
                "",
                "10"
            }
        };
        public IEnumerator<object[]> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class ReadTestData : DataAttribute
    {
        private readonly string filePath;
        private readonly bool hasHeaders;

        public ReadTestData(string filePath, bool hasHeaders)
        {
            this.filePath = filePath;
            this.hasHeaders = hasHeaders;
        }
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var methodParameters = testMethod.GetParameters();

            var paramenterTypes = methodParameters.Select(x => x.ParameterType).ToArray();

            using (var streamReader = new StreamReader(filePath))
            {
                if (hasHeaders)
                {
                    streamReader.ReadLine();
                }
                string csvLine = string.Empty;
                while ((csvLine = streamReader.ReadLine()) != null)
                {
                    var csvRow = csvLine.Split(',');
                    yield return ConvertCsv((object[])csvRow, paramenterTypes);
                }
            }
        }

        private object[] ConvertCsv(IReadOnlyList<object> csvRow, IReadOnlyList<object> paramenterTypes)
        {
            var convertedObject = new object[paramenterTypes.Count];

            for (int i = 0; i < paramenterTypes.Count; i++)
            {
                convertedObject[i] = (paramenterTypes[i] == typeof(string)) ? Convert.ToString(csvRow[i]) : csvRow[i];
            }

            return convertedObject;
            
        }
    }
}
