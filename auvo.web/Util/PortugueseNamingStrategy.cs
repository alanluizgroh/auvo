using Newtonsoft.Json.Serialization;

namespace auvo.web.Util
{
    public class PortugueseNamingStrategy : DefaultNamingStrategy
    {
        private readonly IDictionary<string, string> _translations;

        public PortugueseNamingStrategy()
        {
            // Add translations for each property name
            _translations = new Dictionary<string, string>
        {
            { "Name", "Nome" },
            { "DepartmentName", "Departamento" },
            { "Month", "MesVigencia" },
            { "Year", "AnoVigencia" },
            { "TotalPayroll", "TotalPagar" },
            { "TotalDiscounts", "TotalDescontos" },
            { "TotalExtraHours", "TotalExtras" },
            { "EmployeesPay", "Funcionarios" },
            { "Code", "Codigo" },
            { "WorkedDays", "DiasTrabalhados" },
            { "DaysOff", "DiasFalta" },
            { "DaysExtras", "DiasExtras" },
            { "TotalToReceive", "TotalReceber" },
            { "ExtraHours", "HorasExtras" }
        };
        }

        protected override string ResolvePropertyName(string name)
        {
            // Translate the property name to Portuguese
            if (_translations.TryGetValue(name, out string translatedName))
            {
                return translatedName;
            }

            // Use the default naming strategy for other properties
            return base.ResolvePropertyName(name);
        }
    }

}
