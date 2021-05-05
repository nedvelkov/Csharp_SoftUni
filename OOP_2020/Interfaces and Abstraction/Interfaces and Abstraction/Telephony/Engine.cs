using System;

namespace Telephony
{
    public class Engine
    {
        private IRead read;
        private IWrite write;
        public Engine()
        {
            this.read = new ReadConsole();
            this.write = new ConsoleWriter();
        }
        public void PhoneNumbers()
        {

            var tokkens = this.read.ReadLine().Split();
            for (int i = 0; i < tokkens.Length; i++)
            {
                var currentNum = tokkens[i];
                ICall phone = new StacionaryPhone();
                if (currentNum.Length == 10)
                {
                    phone = new Smartphone();
                }
                try
                {
                    phone.IsPhoneNumber(currentNum);
                    this.write.WriteLine(phone.Call());
                }
                catch (Exception ex)
                {

                    this.write.WriteLine(ex.Message);
                }

            }


        }
        public void WebSites()
        {

            var tokkens = read.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tokkens.Length; i++)
            {
                var currentURL = tokkens[i];
                Smartphone phone = new Smartphone();
                try
                {
                    phone.URL = currentURL;
                    write.WriteLine(phone.Browse());
                }
                catch (Exception ex)
                {

                    this.write.WriteLine(ex.Message);
                }

            }


        }
    }
}
