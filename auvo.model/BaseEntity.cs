using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auvo.model
{
    /// <summary>
    /// A classe BaseEntity servirá como uma classe base para as demais classes de modelo, 
    /// contendo o atributo Id comum a todas elas. 
    /// </summary>
    public class BaseEntity
    {
        public long Id { get; set; }
    }
}
