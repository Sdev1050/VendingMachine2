using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Domain.Constants;

namespace VM.Application.Interfaces
{
    public interface IDisplayMessage
    {
        public string GetMessage();
        public void SetMessage(string message);
        public void ResetMessage();
        
    }
}
