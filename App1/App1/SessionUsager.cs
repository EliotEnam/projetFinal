using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
   public static class SessionUsager
    {
        public static string IdAdherent {  get; set; }
        public static string NomAdherent { get; set; }
        public static string NomAdmin { get; set; }
        public static string MdpAdmin { get; set; }
        public static string RoleUsager { get; set; }

        public static bool AdherentConnecte { get; set; }
        public static bool AdminConnecte { get; set; }

        public static void TerminerSession()
        {
            IdAdherent = null;
            NomAdmin = null;
            MdpAdmin = null;
            AdherentConnecte = false;
            AdminConnecte = false;
        }
    }
}
