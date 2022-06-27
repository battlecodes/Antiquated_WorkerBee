using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerBee.Utilities.Validators
{
    public interface IValidate<T>
    {
        public (bool, T) Validate();
    }
}
