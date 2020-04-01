using System;
using System.Collections.Generic;
using System.Text;
using Touitteur.Models;

namespace Touitteur.Services
{
    public interface ITouitteurService
    {
        bool Authenticate(string user, string password);
        List<Touitte> GetTouittes(string search);
    }
}
