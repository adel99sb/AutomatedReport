using MauiApp1.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Threading.Tasks;

namespace MauiApp1.WhatsAppSetting
{
    public class WhatsAppService
    {
        private static IWebElement SearchInput;
        private static bool isReady;
        private static EdgeDriver EdgeDriver;
        private static string userDataDir = @"C:\path\to\whatsapp\user\data";

        public async Task StartService()
        {
            // Set up Edge WebDriver options
            foreach (var process in System.Diagnostics.Process.GetProcessesByName("msedge"))
            {
                process.Kill();
            }
            var options = new EdgeOptions();
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");

            // Persist cookies and session by setting user-data-dir
            options.AddArgument($"--user-data-dir={userDataDir}");

            // Optional: Specify profile directory (useful if there are multiple profiles)
            options.AddArgument("--profile-directory=Default");

            // Uncomment to run in headless mode if needed
            // options.AddArgument("--headless");

            EdgeDriver = new EdgeDriver(options);

            // Navigate to WhatsApp Web with retry logic
            int maxRetries = 5;
            int delayBetweenRetries = 5000; // 5 seconds
            bool isNavigated = false;

            for (int i = 0; i < maxRetries; i++)
            {
                try
                {
                    EdgeDriver.Navigate().GoToUrl("https://web.whatsapp.com/");
                    isNavigated = true;
                    break;
                }
                catch (WebDriverException ex)
                {
                    Console.WriteLine($"Navigation attempt {i + 1} failed: {ex.Message}");
                    await Task.Delay(delayBetweenRetries);
                }
            }

            if (!isNavigated)
            {
                throw new Exception("Failed to navigate to WhatsApp Web after multiple attempts.");
            }

            isReady = false;
            Console.WriteLine("Please scan the QR code and log in to WhatsApp Web if necessary.");

            // Wait for the user to scan the QR code and log in
            await Task.Delay(TimeSpan.FromSeconds(20)); // Adjust this delay as necessary
        }

        public async Task<bool> IsEdgeSessionAlive()
        {
            try
            {
                if (EdgeDriver != null && EdgeDriver.SessionId != null)
                {
                    // Check if the WhatsApp search input is present, indicating the session is active
                    SearchInput = EdgeDriver.FindElement(By.CssSelector("div[contenteditable='true']"));
                    Console.WriteLine("Edge session is alive and WhatsApp is ready.");
                    isReady = true;
                    return true;
                }
            }
            catch (WebDriverException ex)
            {
                Console.WriteLine($"Edge session check failed: {ex.Message}");
            }

            // If session is not found or driver is not initialized, return false
            return false;
        }

        public async Task<bool> IsReadyToRun()
        {
            // Check if the Edge session is alive and WhatsApp is ready
            if (await IsEdgeSessionAlive())
            {
                return true;
            }

            // If the Edge session is not alive, start the service
            await StartService();

            try
            {
                // Wait for the element to be ready after starting the service
                await Task.Delay(TimeSpan.FromSeconds(10)); // Adjust this delay as necessary

                SearchInput = EdgeDriver.FindElement(By.CssSelector("div[contenteditable='true']"));
                Console.WriteLine("WhatsApp Service is ready.");
                isReady = true;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"WhatsApp Service is not ready yet: {ex.Message}");
                isReady = false;
            }

            return isReady;
        }
        public async Task<string> SendMessageToList(List<string> recipients, string message)
        {
            if (isReady)
            {
                if (recipients.Count > 0 && !string.IsNullOrEmpty(message))
                {
                    int FailedTimes = 0;
                    try
                    {
                        foreach (var item in recipients)
                        {
                            var res = await SendMessage(item, message);
                            if (!res)
                            {
                                FailedTimes++;
                            }
                        }
                        if (recipients.Count - FailedTimes == 0)
                            return $"{recipients.Count} رسائل تم ارسالها بنجاح";
                        else
                            return $"{recipients.Count - FailedTimes} رسائل تم ارسالها و {FailedTimes} فشلت";
                    }
                    catch (Exception ex)
                    {
                        isReady = false;
                        return ex.Message;
                    }
                }
                else
                {
                    return "الرجاء اختيار المستقبلين و كتابة الرسالة اولاً";
                }
            }
            else
            {
                isReady = false;
                return "خدمات الواتساب غير متوفرة الرجاء اعادة تشغيل التطبيق";
            }
        }
        public async Task<string> SendHappyBirthDay(List<HappyBirthDay> happyBirthDays)
        {
            string messageP1 = " اسرة معهد Sun Rise تتمنى للطالب/ة ";
            string messageP2 = " عيد ميلاد سعيد وعمراً طويلاً ";
            string message = "";
            if (isReady)
            {
                if (happyBirthDays.Count > 0)
                {
                    int FailedTimes = 0;
                    try
                    {
                        foreach (var item in happyBirthDays)
                        {
                            message = messageP1 + item.name + messageP2;
                            var res = await SendMessage(item.phone, message);
                            if (!res)
                            {
                                FailedTimes++;
                            }
                        }
                        if (happyBirthDays.Count - FailedTimes == 0)
                            return $"{happyBirthDays.Count} رسائل تم ارسالها بنجاح";
                        else
                            return $"{happyBirthDays.Count - FailedTimes} رسائل تم ارسالها و {FailedTimes} فشلت";
                    }
                    catch (Exception ex)
                    {
                        isReady = false;
                        return ex.Message;
                    }
                }
                else
                {
                    return "الرجاء اختيار المستقبلين و كتابة الرسالة اولاً";
                }
            }
            else
            {
                isReady = false;
                return "خدمات الواتساب غير متوفرة الرجاء اعادة تشغيل التطبيق";
            }
        }

        private async Task<bool> SendMessage(string recipient, string message)
        {
            if (isReady)
            {
                try
                {
                    SearchInput.Clear();
                    SearchInput.SendKeys(recipient + Keys.Enter);
                    SearchInput.Click();
                    var chatScreen = EdgeDriver.FindElement(By.Id("main"));
                    var messageInput = chatScreen.FindElement(By.CssSelector("div[contenteditable='true']"));
                    messageInput.SendKeys(message + Keys.Enter); // Send the message        
                    Console.WriteLine($"تم ارسال الرسالة الى {recipient}: {message}");
                    return true;
                }
                catch (NoSuchElementException ex)
                {
                    Console.WriteLine($"حدث خطأ بأرسال الرسالة الى {recipient}: {ex.Message}");
                    isReady = false;
                }
            }

            return false;
        }
        
    }
}
