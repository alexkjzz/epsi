        //Ajout d'un package nuget manuellement :
        //    dotnet add .\XXXXX.csproj package "AxaFrance.WebEngine.Web"
        
        using OpenQA.Selenium;
        using AxaFrance.WebEngine.Web;
        using AxaFrance.WebEngine;

        var driver = BrowserFactory.GetDriver(AxaFrance.WebEngine.Platform.Windows, 
            BrowserType.Chrome);
        driver.Navigate().GoToUrl("http://google.fr");

        driver.FindElement(By.XPath("//input[@name='q']")).SendKeys("EPSI"+ Keys.Return);

        var premierTitre = driver.FindElement(By.XPath("//H3"));
        Console.WriteLine($"Premier résultat : {premierTitre.Text} ");