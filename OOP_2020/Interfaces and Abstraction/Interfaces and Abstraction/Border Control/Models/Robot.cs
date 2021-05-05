
namespace BorderControl.Models
{
    using BorderControl.Contracts;

    public class Robot :TownInhabitant, IRobot,ICitizen
    {
        private string model;
        public string Model
        {
            get => this.model;
            private set => this.model = value;
        }

        public string Id { get => this.id; private set => this.id = value; }
        public Robot(string model, string id) : base(id)
        {
            this.Model = model;
        }
    }
}
