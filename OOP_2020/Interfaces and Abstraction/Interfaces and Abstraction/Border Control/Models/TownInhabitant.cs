

namespace BorderControl.Models
{
    using BorderControl.Contracts;
    public class TownInhabitant
    {
        protected string id;
        public TownInhabitant(string id)
        {
            this.id = id;
        }

        public string GetIdNumber()
        {
            return this.id;
        }
    }
}
