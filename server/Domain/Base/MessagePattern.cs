using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Base
{
    [NotMapped]
    public abstract class MessagePattern
    {
        public MessagePattern()
        {
            Errors = new List<string>();
        }

        public List<string> Errors { get; private set; }

        public bool IsFailure { get; private set; }

        public void AddErrorMessage(string mensage)
        {
            IsFailure = true;
            Errors.Add(mensage);
        }

        public void AddErrorsMessages(List<string> mensages)
        {
            IsFailure = true;
            Errors.AddRange(mensages);
        }
    }
}