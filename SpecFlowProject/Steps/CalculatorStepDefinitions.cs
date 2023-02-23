﻿using FluentAssertions;
using OpenQA.Selenium;
using SpecFlowProject.Drivers;
using SpecFlowProject.PageObjects;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        //Page Object for Calculator
        private readonly CalculatorPageObject _calculatorPageObject;
       
        public CalculatorStepDefinitions(BrowserDriver browserDriver)
        {
            _calculatorPageObject = new CalculatorPageObject(browserDriver.Current);
        }
       

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            //_calculatorPageObject.
            //delegate to Page Object
            _calculatorPageObject.EnterFirstNumber(number.ToString());
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            //delegate to Page Object
            _calculatorPageObject.EnterSecondNumber(number.ToString());
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //delegate to Page Object
            _calculatorPageObject.ClickAdd();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int expectedResult)
        {
            //delegate to Page Object
            var actualResult = _calculatorPageObject.WaitForNonEmptyResult();

            actualResult.Should().Be(expectedResult.ToString());
        }
    }
}