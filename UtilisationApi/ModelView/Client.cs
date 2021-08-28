using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UtilisationApi.ModelView
{
    public class Client
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }

        public static implicit operator Client(SelectList v)
        {
            throw new NotImplementedException();
        }
    }
}
