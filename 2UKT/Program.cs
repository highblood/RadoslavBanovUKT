using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace _2UKT
{
    class Program
    {
        static void Main(string[] args)
        {
            //дефинираме интерфейса, с който ще управляваме браузъра, като в случаят е Мозила
            //ако искаме Хроум, слагаме ChromeDriver() заедно с OpenQA.Selenium.Chrome
            IWebDriver driver = new FirefoxDriver();

            //задаваме начална страница
            driver.Url = "https://www.google.com/";

            //уголемяваме прозореца
            driver.Manage().Window.Maximize();

            //слагаме лимит на време за търсене на даден елемент преди да спре програмата
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //намираме търсачката на Гугъл по Xpath, след което ѝ подаваме текст "Youtube" и симулираме натискане на Enter
            driver.FindElement(By.XPath("/html/body/div/div[3]/form/div[2]/div[1]/div[1]/div/div[2]/input")).SendKeys("Youtube" + Keys.Enter);

            //намираме първия линк и с мeтода Click() го избираме
            driver.FindElement(By.TagName("h3")).Click();

            //намираме търсачката в Youtube и подаваме текст, чрез който да търси видеото и отново симулираме натискане на Enter
            driver.FindElement(By.Name("search_query")).SendKeys("Blade soundtrack" + Keys.Enter);

            //избираме първото видео и го пускаме
            driver.FindElement(By.XPath("/html/body/ytd-app/div/ytd-page-manager/ytd-search/div[1]/ytd-two-column-search-results-renderer/div/ytd-section-list-renderer/div[2]/ytd-item-section-renderer/div[3]/ytd-video-renderer[1]/div[1]/div/div[1]/div/h3/a/yt-formatted-string")).Click();

            //прекратявaме процесът за зададените милисекунди 
            Thread.Sleep(20000);

            //затваряме този драйвер и всички асоциирани прозорци
            driver.Quit();
        }
    }
}
