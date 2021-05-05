namespace Telephony
{
   public interface ICall
    {
        public int Number { get; }
        public string Call();
        public void IsPhoneNumber(string num);

        
    }
}
