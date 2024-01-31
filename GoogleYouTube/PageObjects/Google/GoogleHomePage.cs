﻿using CynkyDriver;
using OpenQA.Selenium;
using System;

namespace GoogleYouTube.PageObjects.CommonPages
{
    public class GoogleHomePage
    {
        IWebDriver _Driver;

        public GoogleHomePage(IWebDriver driver)
        {
            _Driver = driver;
        }

        #region Locators

        PageElement Search_textbox => new PageElement(_Driver, By.XPath($"//textarea[@title='Search']|//textarea[@aria-label='Google Search']"));
        PageElement Results_label => new PageElement(_Driver, By.XPath($"//div[@id='search']//div[@jscontroller and @lang]|//div[@jsdata and @data-hveid and @data-ved and not(@jscontroller)]"));

        #endregion

        #region Actions

        public void Search(string term)
        {
            Search_textbox.Click();
            Search_textbox.SendKeysNoValidation(term + Keys.Enter);
        }

        public int GetNumberOfSearchResults()
        {
            if (!Results_label.IsDisplayed())
                throw new Exception("Results not displayed!");
            return Results_label.GetAllElements().Count;
        }
        #endregion
    }
}