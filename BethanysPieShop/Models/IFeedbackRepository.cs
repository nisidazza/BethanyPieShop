using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public interface IFeedbackRepository // this method allows us to add feedback
    {
        void AddFeedback(Feedback feedback);
    }
}
