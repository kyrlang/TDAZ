using System;
using System.Runtime.Serialization;

namespace LojaOnline.DAO
{
    [Serializable]
    internal class EmailCadastradoException : Exception
    {
        public EmailCadastradoException(){}

        public EmailCadastradoException(string message) : base(message) {}

        //public EmailCadastradoException(string message, Exception innerException) : base(message, innerException)
        //{
        //}

        //protected EmailCadastradoException(SerializationInfo info, StreamingContext context) : base(info, context)
        //{
        //}
    }
}