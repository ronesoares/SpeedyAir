using Domain.Service;

namespace Domain.Entity
{
    public class Airport
    {
        public string Code { get; protected set; }
        public string Name { get; protected set; }

        public Airport(string code, string name)
        {
            ValidationService.SetDescription(code, "Code", 3, 3);
            ValidationService.SetDescription(name, "Name", 5, 30);

            Code = code;
            Name = name;
        }
    }
}