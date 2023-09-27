using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_conta.mathbank.Exceptions
{
    internal class MathBankException : Exception
    {
        public MathBankException() { }

        public MathBankException(string message) : base("Aconteceu uma Exceção -> " + message) { }

        public MathBankException(string message, Exception inner) : base(message, inner) { }

        public MathBankException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
