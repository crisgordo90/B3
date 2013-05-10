using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B3.Clases
{
    public class cGeneralMetodos
    {
        public String[] Fragmentar(String p_cadena, char[] p_separador)
        {
            String[] vector = p_cadena.Split(p_separador);
            return vector;
        }

        public Boolean Numero(String p_numero)
        {
            int _iNumero = 0;
            return (int.TryParse(p_numero, out _iNumero));
        }
    }

    
}